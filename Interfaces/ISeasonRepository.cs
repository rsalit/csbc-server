using csbc_server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csbc_server.Interfaces
{
    public interface ISeasonRepository : IRepository<Season>
    {
        Season GetSeason(int companyId, int seasonId = 0);
        Season GetCurrentSeason(int companyId);
        int GetSeason(int companyId, string seasonDescription);
        IQueryable<Season> GetSeasons(int companyId);
        List<SponsorFee> GetSeasonFees(int seasonId);
        Task<List<Season>> GetAll(int companyId);
    }
}
