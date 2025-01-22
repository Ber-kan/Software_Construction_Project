using System.Text.Json;
using Microsoft.EntityFrameworkCore;

public class LocationServices : ILocations
{
    private readonly MyContext _context;
    public LocationServices(MyContext context)
    {
        _context = context;
    }

    public async Task<Locations> GetLocationById(int id)
    {
        return await _context.Locations.FirstOrDefaultAsync(_ => _.Id == id);
    }
    
    public async Task<IEnumerable<Locations>> GetLocations()
    {
        return await _context.Locations.ToListAsync();
    }

    public async Task<Locations> AddLocation(Locations location)
    {
        var existingLocation = await _context.Locations.FirstOrDefaultAsync(_ => _.Code == location.Code || _.Id == location.Id);

        if (existingLocation != null)
        {
            return null;
        }

        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
        return location;
    }

    public async Task<Locations> UpdateLocation(int id, Locations location)
    {
        if (id <= 0 || location == null)
        {
            return null;
        }

        var existingLocation = await _context.Locations.FindAsync(id);
        if (existingLocation == null)
        {
            return null;
        }

        existingLocation.Code = location.Code;
        existingLocation.Name = location.Name;
        existingLocation.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();
        return existingLocation;
    }

    public async Task<bool> DeleteLocation(int id)
    {
        if (id <= 0)
        {
            return false;
        }

        var existingLocation = await _context.Locations.FirstOrDefaultAsync(_ => _.Id == id);
            
        if (existingLocation == null)
        {
            return false;
        }

        _context.Locations.Remove(existingLocation);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task ReadJson(string path)
    {
        path = "data/" + path;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            List<Locations>? locations = JsonSerializer.Deserialize<List<Locations>>(json);
            if (locations == null) return;

            await UploadToDB(locations);
        }
    }

    public async Task<int> UploadToDB(List<Locations> locations)
    {
        var transaction = _context.Database.BeginTransaction();
        foreach (Locations location in locations)
        {
            if (locations == null) return -1;
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
        }
        await transaction.CommitAsync();
        return 1;
    }
}
