using System;
using System.Linq;
using EDziekanat.EntityFramework;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace EDziekanat.Web.Core.ActionFilters
{
    public class UnitOfWorkActionFilter : ActionFilterAttribute
    {
        private readonly EDziekanatDbContext _dbContext;

        public UnitOfWorkActionFilter(EDziekanatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var dataModificationRequestTypes = new[] { "post", "put", "delete" };
            if (!dataModificationRequestTypes.Contains(context.HttpContext.Request.Method, StringComparer.InvariantCultureIgnoreCase) ||
                context.Exception != null ||
                !context.ModelState.IsValid)
            {
                return;
            }

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                dbUpdateConcurrencyException.Entries.Single().Reload();
                _dbContext.SaveChanges();
            }
        }
    }
}
