using System.ComponentModel.DataAnnotations;

namespace StockMarketAPI.DataTransferObject
{
    public class MathOperationDTO
    {
        [Required(ErrorMessage = "Function Name Required")]
        public string funName { get; set; }

        [Required(ErrorMessage = "Date Required")]
        public DateTime Date { get; set; }

        public override string? ToString()
        {
            return $"[ {funName}, {Date} ]";
        }
    }
}
