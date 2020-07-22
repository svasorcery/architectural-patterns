using Microsoft.EntityFrameworkCore;

namespace SvaSorcery.Patterns.Enterprise.ORM.EmbeddedValue
{
    public class HospitalScheduleDbContext : DbContext
    {
        public HospitalScheduleDbContext(DbContextOptions<HospitalScheduleDbContext> options)
            : base(options)
        {
        }

        public DbSet<HospitalScheduleSlot> Slots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HospitalScheduleSlot>(entity =>
            {
                entity.Property(e => e.TimeRange.From).HasColumnName("TimeFrom");
                entity.Property(e => e.TimeRange.To).HasColumnName("TimeTo");
                entity.ToTable("Slots");
            });
            
        }
    }
}
