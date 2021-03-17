namespace ConsoleApp
{
    public class AnotherMessage
    {
        public int MyId { get; set; }

        public override string ToString()
        {
            return $"MyId: {MyId}";
        }
    }
}