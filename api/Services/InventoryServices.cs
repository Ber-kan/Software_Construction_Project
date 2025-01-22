using Microsoft.EntityFrameworkCore;

public class InventoryServices : IInventory
{
    private readonly MyContext _context;
    
    public InventoryServices(MyContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Inventory>> GetInventories()
    {
        return await _context.Inventories.ToListAsync();
    }

    public async Task<Inventory> GetInventoryById(int id)
    {
        if (id <= 0) return null;

        return await _context.Inventories.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<List<int>> GetInventoryLocations(int id)
    {
        if (id <= 0) return null;

        return await _context.InventoriesLocations
            .Where(il => il.InventoryId == id)
            .Select(il => il.LocationId)
            .ToListAsync();
    }

    public async Task<Inventory> AddInventory(Inventory inventory)
    {
        if (inventory == null || !inventory.Locations.Any())
        {
            throw new ArgumentNullException("Inventory or its locations list cannot be null.");
        }

        var existingInventory = await _context.Inventories.FirstOrDefaultAsync(i => i.Id == inventory.Id);
        if (existingInventory != null) return null;

        _context.Inventories.Add(inventory);

        foreach (var inventoryLocation in inventory.Locations)
        {
            _context.InventoriesLocations.Add(new InventoriesLocations
            {
                InventoryId = inventory.Id,
                LocationId = inventoryLocation.LocationId  // Access LocationId correctly
            });
        }

        await _context.SaveChangesAsync();

        return inventory;
    }

    public async Task<Inventory> UpdateInventory(int id, Inventory inventory)
    {
        if (id <= 0) return null;

        var existingInventory = await GetInventoryById(id);
        if (existingInventory == null) return null;

        existingInventory.ItemId = inventory.ItemId;
        existingInventory.Description = inventory.Description;
        existingInventory.ItemReference = inventory.ItemReference;
        existingInventory.TotalOnHand = inventory.TotalOnHand;
        existingInventory.TotalExpected = inventory.TotalExpected;
        existingInventory.TotalOrdered = inventory.TotalOrdered;
        existingInventory.TotalAllocated = inventory.TotalAllocated;
        existingInventory.TotalAvailable = inventory.TotalAvailable;
        existingInventory.UpdatedAt = DateTime.Now;

        var currentLocations = await _context.InventoriesLocations
            .Where(il => il.InventoryId == id)
            .ToListAsync();

        _context.InventoriesLocations.RemoveRange(currentLocations);

        foreach (var inventoryLocation in inventory.Locations)
        {
            _context.InventoriesLocations.Add(new InventoriesLocations
            {
                InventoryId = id,
                LocationId = inventoryLocation.LocationId  // Access LocationId correctly
            });
        }

        await _context.SaveChangesAsync();

        return existingInventory;
    }

    public async Task<bool> DeleteInventory(int id)
    {
        if (id <= 0) return false;

        var existingInventory = await GetInventoryById(id);
        if (existingInventory == null) return false;

        _context.Inventories.Remove(existingInventory);
        await _context.SaveChangesAsync();

        return true;
    }
}