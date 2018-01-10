namespace Narato.Libraries.POC.Domain.Common
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
    }
}