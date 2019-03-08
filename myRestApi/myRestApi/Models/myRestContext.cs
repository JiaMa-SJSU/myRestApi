using System;
using Microsoft.EntityFrameworkCore;

namespace myRestApi.Models
{
    public class myRestContext : DbContext
    {
        public myRestContext(DbContextOptions<myRestContext> options)
            : base(options)
        {
        }
        public DbSet<SomeItem> SomeItems { get; set; }
    }
}
