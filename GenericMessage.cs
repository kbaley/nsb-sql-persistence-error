namespace ConsoleApp
{
    public class GenericMessage
    {
        public GenericMessage()
        {
            MyValue = decimal.MinValue;
        }

        public int MyId { get; set; }
        public string Name { get; set; }
        public decimal MyValue { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, MyValue: {MyValue}";
        }
    }
}