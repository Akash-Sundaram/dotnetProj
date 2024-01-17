using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
namespace LibraryManagement.Data;

public class ApplicationDbContext:DbContext
{
 
    
    public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}
public DbSet<Books> Books{get;set;}
//public DbSet<AvailablePolicies> AvailablePolicies{get;set;}
public DbSet<MyBook> MyBook{get;set;}

}