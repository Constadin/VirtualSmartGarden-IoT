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
        public async Task<IEnumerable<SensorData>> GetLatestGroupsAsync(int take)
        {
            var latestGroupIds = await _context.SensorData
                .GroupBy(sd => sd.GroupId)
                .OrderByDescending(g => g.Max(sd => sd.Timestamp))
                .Take(take)
                .Select(g => g.Key)
                .ToListAsync();

            var sensorData = await _context.SensorData
                .Where(sd => latestGroupIds.Contains(sd.GroupId))
                .OrderBy(sd => sd.GroupId)
                .ThenBy(sd => sd.Timestamp)
                .ToListAsync();

            return sensorData;
        }

    }

}
