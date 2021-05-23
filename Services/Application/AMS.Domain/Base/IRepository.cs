using AMS.Domain;

public interface IRepository
{
    IUnitOfWork UnitOfWork { get; }
}