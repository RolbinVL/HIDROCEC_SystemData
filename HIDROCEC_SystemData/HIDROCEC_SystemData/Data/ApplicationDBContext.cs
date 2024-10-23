using HIDROCEC_SystemData.Client.Pages;
using HIDROCEC_SystemData.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;

namespace HIDROCEC_SystemData.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Rols { get; set; }
    }
}

