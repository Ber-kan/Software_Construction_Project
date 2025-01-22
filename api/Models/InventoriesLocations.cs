using System.Text.Json.Serialization;

public class InventoriesLocations
{
    public int InventoryId { get; set; }
    public Inventory Inventory { get; set; }

    public int LocationId { get; set; }
    public Locations Location { get; set; }
}
