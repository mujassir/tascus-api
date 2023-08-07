namespace Tascus.Core.Model
{
    public class OperationData
    {
        public int ID { get; set; }
        public string Model_Number { get; set; } = string.Empty;
        public string Serial_Number { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public int Operation_ID { get; set; }
    }
    public enum Statuses
    {
        EXECUTING,
        SUSPENDED,
        COMPLETE
    }
    public enum ResultsEnum
    {
        PASS,
        FAIL
    }
    public enum OperationIDs
    {
        Op1000 = 1000,
        Op1010 = 1010,
        Op1020 = 1020
    }
}
