using System.Text.Json.Serialization;

public class Inventory
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    [JsonPropertyName("item_id")]
    public required string ItemId { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("item_reference")]
    public string ItemReference { get; set; }

    [JsonPropertyName("locations")]
    public List<InventoriesLocations> Locations { get; set; } = new List<InventoriesLocations>();
    // public List<int> Locations { get; set; } = new List<int>();
    // public required List<int> Locations { get; set; } = new();
    // public ICollection<InventoriesLocations> Locations { get; set; } = new List<InventoriesLocations>();
    // public List<InventoriesLocations> Locations { get; set; }

    [JsonPropertyName("total_on_hand")]
    public int TotalOnHand { get; set; }

    [JsonPropertyName("total_expected")]
    public int TotalExpected { get; set; }

    [JsonPropertyName("total_ordered")]
    public int TotalOrdered { get; set; }

    [JsonPropertyName("total_allocated")]
    public int TotalAllocated { get; set; }

    [JsonPropertyName("total_available")]
    public int TotalAvailable { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
