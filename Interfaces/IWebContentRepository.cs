using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using csbc_server.Interfaces;
using csbc_server.Models;

namespace csbc_server.Interfaces
{
    public interface IWebContentRepository: IRepository<WebContent>
    {
        IQueryable<WebContent> GetAll(int companyId);
        IQueryable<WebContent> GetActiveWebContent(int companyId);
        new void Update (WebContent  entity);
        new WebContent Insert(WebContent entity);
    }
}