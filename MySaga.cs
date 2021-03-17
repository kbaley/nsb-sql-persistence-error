using System;
using System.Threading.Tasks;
using NServiceBus;

namespace ConsoleApp
{
    public class MySaga : Saga<MySagaData>,
        IHandleMessages<AnotherMessage>,
        IAmStartedByMessages<GenericMessage>
    {
        public Task Handle(AnotherMessage message, IMessageHandlerContext context)
        {
            Console.WriteLine(Data);
            Console.WriteLine(message);

            return Task.CompletedTask;
        }

        public Task Handle(GenericMessage message, IMessageHandlerContext context)
        {
            Console.WriteLine(message);

            Data.MyId = message.MyId;
            Data.MyValue = message.MyValue;
            Data.MyMessage = message;
            Console.WriteLine(Data);

            return Task.CompletedTask;
        }

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<MySagaData> mapper)
        {
            mapper.ConfigureMapping<GenericMessage>(message => message.MyId).ToSaga(saga => saga.MyId);
            mapper.ConfigureMapping<AnotherMessage>(message => message.MyId).ToSaga(saga => saga.MyId);
        }
    }
}