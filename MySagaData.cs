using NServiceBus;

namespace ConsoleApp {
    public class MySagaData : ContainSagaData {
        public MySagaData()
        {
        }
        public int MyId { get; set; }
        public decimal? MyValue { get; set; }
        public GenericMessage MyMessage { get; set; }

        public override string ToString() {
            return $"ID: {MyId}, MyValue: {MyValue}, [[MyMessage: {MyMessage}]]";
        }
    }
}