using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Persistence.Repositories
{
    public static class HttpContextExtensions
    {
        public async static Task InsertPaginationParamenterInResponseHeader<T>(this HttpContext httpContext,IQueryable<T> queryable)
        {
            if(httpContext is null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            double count = await queryable.CountAsync();
            httpContext.Response.Headers.Append("totalAmountofRecords", count.ToString());
        }
    }
}
