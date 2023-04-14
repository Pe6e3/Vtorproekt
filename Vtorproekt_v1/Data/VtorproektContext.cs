using VtorP.Models;
using Microsoft.EntityFrameworkCore;

namespace VtorP.Data;

public class VtorPContext : DbContext
{
    public VtorPContext(DbContextOptions<VtorPContext> options): base(options) { }

    public DbSet<Bale> Bales { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<Production> Productions { get; set; }
    public DbSet<Storage> Storages { get; set; }
    public DbSet<Tax> Taxes { get; set; }
    public DbSet<WorkType> WorkTypes { get; set; }








}
