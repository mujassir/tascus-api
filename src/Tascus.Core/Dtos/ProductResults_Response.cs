namespace Tascus.Core.Dtos
{
    public class ProductResults_Response
    {
        public string Step_Name { get; set; } = string.Empty;
        public string Step_Measurement { get; set; } = string.Empty;
        public string Step_Result { get; set; } = string.Empty;
        public string High_Limit { get; set; } = string.Empty;
        public string Low_Limit { get; set; } = string.Empty;
        public string Step_Status { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;
        public int Step_Run { get; set; }
        public string Operation_Name { get; set; } = string.Empty;
        public int Operation_ID { get; set; }
        public DateTime Date { get; set; }
    }
}
