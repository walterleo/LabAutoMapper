using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public class AppDbContext: DbContext
  {
    public AppDbContext() { }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    { 
      if (!optionsBuilder.IsConfigured) 
      { 
        optionsBuilder.UseSqlServer(@"Data Source= localhost;Initial Catalog=Lab_AutoMapper;Integrated Security=True; Encrypt=False;"); 
      }
    }

  }
}
