namespace Tascus.Core.Model
{
    public class ProductionData
    {
        public int ID { get; set; }
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
        public string Serial_Number { get; set; } = string.Empty;
        public string Part_Number { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
    public enum OperationIDsAll
    {
        Op1 = -1,
        Op1000 = 1000,
        Op1010 = 1010,
        Op1020 = 1020
    }

}
