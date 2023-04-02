namespace Entities.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException //sealed : kalıtılması mümkün olmayan
    {
        public BookNotFoundException(int id) : base($"The book with id : {id} could not found")
        {
        }
    }
}
