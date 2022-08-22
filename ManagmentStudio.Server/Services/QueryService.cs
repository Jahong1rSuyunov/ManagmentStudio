using ManagmentStudio.Server.AppDbContext;
using ManagmentStudio.Shared;
using Microsoft.EntityFrameworkCore;

namespace ManagmentStudio.Server.Services
{
    public class QueryService : IQueryService
    {
        private readonly QueryDbContext context;

        public QueryService(QueryDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CheckName(string name, string ConnectorType)
        {
            int resault = await context.Queries.Where(x => x.QueryName.Equals(name) && x.ConnectorType.Equals(ConnectorType)).CountAsync();
            if (resault == 0) return true;
            return false;
        }

        public async Task<Query> Create(Query query)
        {
            var obj = await context.Queries.AddAsync(query);
            await context.SaveChangesAsync();
            return obj.Entity;
        }

        public async Task Delete(int id)
        {
            var query = await context.Queries.FirstOrDefaultAsync(x => x.QueryId.Equals(id));
            if (query != null)
            {
                context.Queries.Remove(query);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Query>> GetQueries(string ConnectorType)
        {
            return await context.Queries.Where(x => x.ConnectorType == ConnectorType).ToListAsync();
        }

        public async Task<Query> GetQuery(int id)
        {
            var obj = await context.Queries.FirstOrDefaultAsync(x => x.QueryId == id);
            return obj;
        }

        public async Task UpdateQuery(Query query)
        {
            context.Queries.Update(query);
            await context.SaveChangesAsync();
        }
    }
}
