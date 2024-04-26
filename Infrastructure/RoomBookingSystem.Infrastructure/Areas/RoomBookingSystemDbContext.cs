using Microsoft.EntityFrameworkCore;

namespace RoomBookingSystem.Infrastructure
{
    public partial class RoomBookingSystemDbContext
    {
        public DbSet<Domain.Areas.Area> Areas { get; set; }
        public DbSet<Domain.Areas.AreaBooking> AreaBookings { get; set; }
        public DbSet<Domain.Areas.AreaRestriction> AreaRestrictions { get; set; }
        public DbSet<Domain.Areas.AreaSubUse> AreaSubUse { get; set; }
        public DbSet<Domain.Areas.AreaType> AreaTypes { get; set; }
        public DbSet<Domain.Areas.AreaUse> AreaUses { get; set; }
        public DbSet<Domain.Areas.AreaWorkNotice> AreaWorkNotices { get; set; }
    }
}
