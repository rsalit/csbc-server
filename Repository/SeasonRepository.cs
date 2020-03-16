using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using csbc_server.Data;
using csbc_server.Interfaces;
using csbc_server.Models;

namespace csbc_server.Repositories
{
    public class SeasonRepository : EFRepository<Season>, ISeasonRepository
    {
        private readonly CsbcContext context;

        public SeasonRepository(CsbcContext _context) :
            base(_context)
        {
            context = _context;
        }


#region IRepository<T> Members
        public Task<List<Season>> GetAll(int companyId) =>
            context
                .Season
                .OrderByDescending(s => s.CompanyID == companyId)
                .ToListAsync();


#endregion // Context.Set<Season>().Where(s => s.CompanyID == companyId);


        public Season GetSeason(int companyId, int seasonId = 0)
        {
            try
            {
                var season =
                    Context
                        .Set<Season>()
                        .Where(s =>
                            s.CompanyID == companyId && s.SeasonID == seasonId);
                return season.First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Season GetCurrentSeason(int companyId)
        {
            try
            {
                var season =
                    Context
                        .Set<Season>()
                        .FirstOrDefault(n =>
                            (n.CurrentSeason == true) &&
                            (n.CompanyID == companyId));
                return season;
            }
            catch
            {
                return new Season();
            }
        }

        public int GetSeason(int companyId, string seasonDescription)
        {
            try
            {
                var season =
                    Context
                        .Set<Season>()
                        .FirstOrDefault(n =>
                            (n.Description == seasonDescription) &&
                            (n.CompanyID == companyId));

                return season.SeasonID;
            }
            catch
            {
                return 0;
            }
        }

        public IQueryable<Season> GetSeasons(int companyId)
        {
            var q =
                from s in Context.Set<Season>()
                where s.CompanyID == companyId
                orderby s.FromDate ascending
                select s;

            //List<Season> seasons = q.ToList();
            return q;
        }

        // public List<SeasonCount> GetSeasonCounts(int seasonId)
        // {
        //     var connection = Context.Database.Connection;
        //     try
        //     {
        //         var sSQL = " EXEC SeasonCounts @SeasonID = " + seasonId.ToString();
        //         var result = Context.Database.SqlQuery<SeasonCount>("EXEC SeasonCounts @SeasonID",
        //             new SqlParameter("SeasonID", seasonId.ToString())
        //             );
        //         return result.ToList<SeasonCount>();
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new Exception(ex.Message);
        //     }
        // }
        public List<SponsorFee> GetSeasonFees(int seasonId)
        {
            var fees = new List<SponsorFee>();
            var scholarshipFee =
                new SponsorFee { Name = "Scholarship", Amount = 0 };
            fees.Add (scholarshipFee);
            var discountFee =
                new SponsorFee { Name = "Discount", Amount = (decimal) 112.50 };
            fees.Add (discountFee);
            var season = GetById(seasonId);
            if (season != null)
                fees
                    .Add(new SponsorFee {
                        Name = "Standard",
                        Amount = Convert.ToDecimal(season.SponsorFee)
                    });
            return fees;
        }

        public IQueryable<SeasonCount> GetSeasonCountsSimple(int seasonId)
        {
            var result =
                (
                from s in Context.Set<Season>()
                from d in Context.Set<Division>()
                from p in Context.Set<Player>()
                where s.SeasonID == d.SeasonID
                where d.DivisionID == p.DivisionID
                where s.SeasonID == seasonId
                group p.PlayerID by new { p.DivisionID, d.Div_Desc }
                into
                totals
                select
                new { Div_Desc = totals.Key.Div_Desc, Total = totals.Count() }
                )
                    .ToList()
                    .Select(x =>
                        new SeasonCount {
                            Div_Desc = x.Div_Desc,
                            Total = x.Total
                        })
                    .AsQueryable();
            return result;
        }

        List<SponsorFee> ISeasonRepository.GetSeasonFees(int seasonId)
        {
            throw new NotImplementedException();
        }
    }
}
