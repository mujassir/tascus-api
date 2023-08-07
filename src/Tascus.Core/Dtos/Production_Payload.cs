using System.ComponentModel.DataAnnotations;

namespace Tascus.Core.Dtos
{
    public class Production_Payload
    {
        [Required]
        public string Part_Number { get; set; } = string.Empty;
        [Required]
        public string Serial_Number { get; set; } = string.Empty;
        [Required]
        public int Operation_ID { get; set; }
    }
}
