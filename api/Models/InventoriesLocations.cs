using System.Text.Json.Serialization;

public class InventoriesLocations
{
    // [JsonIgnore]
    // public int InventoryId { get; set; }

    // [JsonPropertyName("location_id")]
    // public int LocationId { get; set; }


    public int InventoryId { get; set; }
    public Inventory Inventory { get; set; }

    public int LocationId { get; set; }
    public Locations Location { get; set; }


    // Since you have a one-to-many relationship (one inventory can have many locations), you can keep
    // this class as is, except you may want to add a navigation property back to Inventory if needed
    // public Inventory? Inventory { get; set; }  // Navigation property (optional)
}