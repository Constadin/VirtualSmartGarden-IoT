using VirtualSmartGarden.Core.Entities;
using VirtualSmartGarden.Core.Interfaces;
using VirtualSmartGarden.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using VirtualSmartGarden.Application.Interfaces;

namespace VirtualSmartGarden.Infrastructure.Repositories
{

    public class SensorDataRepository : ISensorDataRepository, ISensorDataRepositoryApp
    {
        private readonly AppDbContext _context;

        public SensorDataRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SensorData>> GetLatestSensorDataAsync()
        {
            return await _context.SensorData
                .OrderByDescending(s => s.Timestamp)
                .Take(10)
                .ToListAsync();
        }

        public async Task AddRangeAsync(IEnumerable<SensorData> data)
        {
            await _context.SensorData.AddRangeAsync(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SensorData>> GetAllAsync()
        {
            return await _context.SensorData
                .OrderBy(sd => sd.GroupId)
                .ThenBy(sd => sd.Timestamp)
                .ToListAsync();
        }
    }

}
