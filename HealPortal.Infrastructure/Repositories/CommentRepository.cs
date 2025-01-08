using HealPortal.Domain.Models.Entities;
using HealPortal.Domain.Repositories;
using HealPortal.Infrastructure.Repositories.Base;

namespace HealPortal.Infrastructure.Repositories;

public class CommentRepository : BaseCrudRepository<CommentEntity>, ICommentRepository
{
    public CommentRepository(IUnitOfWork database, AppDbContext context) : base(database, context)
    {
    }
}