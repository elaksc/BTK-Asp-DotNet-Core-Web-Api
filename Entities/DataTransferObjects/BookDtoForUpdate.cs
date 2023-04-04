using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record BookDtoForUpdate : BookDtorForManipulation
    {
        [Required]
        public int Id { get; set; }
    }
    //{ *** yukarıdaki kullanım
    //eın daha detaylı hali aşağıdaki gibi. ***
    //    public int Id { get; init; } //readonly olma, immutable olma = init. tanımlandığı yerde değerini de vericeksin. Değişmez.
    //    public String? Title { get; init; }
    //    public decimal Price { get; init; }
    //}
}
