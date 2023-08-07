namespace Tascus.Core.Dtos
{
    public class Operation_Payload
    {
        public string Model_Number { get; set; } = string.Empty;
        public string Serial_Number { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public int Operation_ID { get; set; }
    }

}
