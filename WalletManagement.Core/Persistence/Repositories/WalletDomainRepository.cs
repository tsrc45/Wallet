using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WalletManagement.Core.Domain.Models;
using WalletManagement.Core.Domain.Repositories;

namespace WalletManagement.Core.Persistence.Repositories
{
    public class WalletDomainRepository : GenericRepository<WalletDomain, idp_dtplatformContext>, IWalletDomainRepository
    {
        private readonly ILogger _logger;
        public WalletDomainRepository(idp_dtplatformContext context, ILogger logger) :
            base(context, logger)
        {
            _logger = logger;
        }


        public async Task<IEnumerable<WalletDomain>> ListAllScopeAsync()
        {
            try
            {
                return await Context.WalletDomains
                    .Where(u => u.Status != "DELETED").OrderByDescending(s => s.CreatedDate).ToListAsync();
            }
            catch (Exception error)
            {
                _logger.LogError("ListAllScopeAsync::Database exception: {0}", error);
                return null;
            }
        }

        public async Task<WalletDomain> GetWalletDomainByIdWithPurposes(int id)
        {
            try
            {
                return await Context.WalletDomains
                    .SingleOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception error)
            {
                _logger.LogError("GetRoleByRoleIdWithActivities::Database exception: {0}", error);
                return null;
            }
        }
    }
}