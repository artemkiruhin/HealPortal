namespace HealPortal.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    ICommentRepository CommentRepository { get; }
    IPostRepository PostRepository { get; }
    IUserRepository UserRepository { get; }
    ITagRepository TagRepository { get; }
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}