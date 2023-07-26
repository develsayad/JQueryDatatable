using Core.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Web.Data
{
    public interface IApplicationDbContext
    {


        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChanges();
    }
}
