using Entities.DataTransferObjects;
using System.ComponentModel.DataAnnotations;

public record BookDtoForInsertion : BookDtorForManipulation
{
    [Required(ErrorMessage ="CategoryId is required")]
    public int CategoryId { get; init; }

}
