
namespace Ordering.Domain.Abstractions;


public interface IEntity<T> : IEntiry
{
    public T Id { get; set; }
}


public interface IEntiry
{
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public string? LastModifiedBy { get; set; }
}



