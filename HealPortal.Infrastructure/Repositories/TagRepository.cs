using HealPortal.Domain.Models.Entities;
using HealPortal.Domain.Repositories;
using HealPortal.Infrastructure.Repositories.Base;

namespace HealPortal.Infrastructure.Repositories;

public class TagRepository : BaseCrudRepository<TagEntity>, ITagRepository
{
    public TagRepository(IUnitOfWork database, AppDbContext context) : base(database, context)
    {
    }
}