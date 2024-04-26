using Microsoft.EntityFrameworkCore;
using RoomBookingSystem.Domain.Assets;

namespace RoomBookingSystem.Infrastructure
{
    public partial class RoomBookingSystemDbContext
    {
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentLocation> EquipmentLocations { get; set; }
    }
}
