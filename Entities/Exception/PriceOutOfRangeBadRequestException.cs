namespace Entities.Exception
{
    public class PriceOutOfRangeBadRequestException : BadRequestException
    {
        public PriceOutOfRangeBadRequestException() : base("Maximum Price Shoul Be Less Than 1000 and Greater 10") // servis üzerinde hata mesajı üretmesini istemiyorum. Statik tanımlayacağım.
        {
        }
    }
}
