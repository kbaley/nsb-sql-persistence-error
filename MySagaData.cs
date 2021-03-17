using NServiceBus;

namespace ConsoleApp {
    public class MySagaData : ContainSagaData {
        public MySagaData()
        {
            MyValue = decimal.MinValue;
        }
        public int MyId { get; set; }
        public decimal MyValue { get; set; }
        public GenericMessage MyMessage { get; set; }

        public override string ToString() {
            return $"ID: {MyId}, MyValue: {MyValue}, [[MyMessage: {MyMessage}]]";
        }
    }
}