namespace testapp.Models.Interfaces
{
    public interface IEntity<TId>
    {
        public TId Id { get; set; }
    }
}
