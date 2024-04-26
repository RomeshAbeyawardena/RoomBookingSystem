using Microsoft.EntityFrameworkCore;

namespace RoomBookingSystem.Infrastructure
{
    public partial class RoomBookingSystemDbContext
    {
        public DbSet<Domain.Addresses.Address> Addresses { get; set; }
    }
}
