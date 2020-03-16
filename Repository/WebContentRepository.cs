using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using csbc_server.Data;
using csbc_server.Interfaces;
using csbc_server.Models;
using csbc_server.Repositories;

namespace CSBC.Core.Repositories
{
    public class
    WebContentRepository
    : EFRepository<WebContent>, IWebContentRepository
    {
        private readonly CsbcContext context;

        public WebContentRepository(CsbcContext _context) :
            base(_context)
        {
            context = _context;
        }

        public IQueryable<WebContent> GetAll(int companyId)
        {
            return context
                .Set<WebContent>()
                .Where(s => s.CompanyId == companyId)
                .OrderBy(s => s.ContentSequence);
        }

        public IQueryable<WebContent> GetActiveWebContent(int companyId)
        {
            return context
                .Set<WebContent>()
                .Where(s => s.CompanyId == companyId)
                .Where(w => w.ExpirationDate >= DateTime.Now)
                .OrderBy(s => s.ContentSequence);
        }

        public override void Update(WebContent entity)
        {
            var dbEntityEntry = context.Entry(entity);
            entity.ModifiedDate = DateTime.Now;
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Modified;
            }
            dbEntityEntry.State = EntityState.Modified;
            context.SaveChanges();
        }

        public override WebContent Insert(WebContent entity)
        {
            var newEntity = new WebContent();
            newEntity.Title = entity.Title;
            newEntity.Location = entity.Location;
            // newEntity.WebContentType = new WebContentType();
            // newEntity.WebContentType.WebContentTypeId =
            //     entity.WebContentType.WebContentTypeId;
            // newEntity.WebContentType.WebContentTypeDescription =
            //     entity.WebContentType.WebContentTypeDescription;
            newEntity.WebContentTypeId = entity.WebContentType.WebContentTypeId;
            newEntity.ExpirationDate = entity.ExpirationDate;
            newEntity.SubTitle = entity.SubTitle;
            newEntity.ContentSequence = entity.ContentSequence;
            newEntity.DateAndTime = entity.DateAndTime;
            newEntity.Page = entity.Page;
            var dbEntityEntry = context.Entry(newEntity);
            newEntity.ModifiedDate = DateTime.Now;

            // var maxId = context.WebContent.Max(x => x.WebContentId);
            // entity.WebContentId = null;
            newEntity.CompanyId =
                entity.CompanyId == null ? 1 : entity.CompanyId;
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add (newEntity);
            }
            context.SaveChanges();
            return entity;
        }
    }
}
