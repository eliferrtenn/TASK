using Microsoft.EntityFrameworkCore;
using VardabitCore.Data.Models;

namespace VardabitCore.Data.Context
{
	public class VardabitContext : DbContext
	{
        public VardabitContext(DbContextOptions<VardabitContext> options) : base(options)
        {
        }
        public DbSet<Marka> Marka { get; set; }
        public DbSet<Model> Model { get; set; }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Versiyon> Versiyon { get; set; }
    }
}