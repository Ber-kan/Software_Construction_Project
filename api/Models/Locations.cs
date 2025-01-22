using System.Text.Json.Serialization;

public class Locations
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }
    
    [JsonPropertyName("warehouse_id")]
    public required int WarehouseId { get; set; }
    
    [JsonPropertyName("code")]
    public required string Code { get; set; }
    
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public ICollection<InventoriesLocations> Inventories { get; set; } = new List<InventoriesLocations>();


    public Locations() {}

    public Locations(int id, int warehouseId, string code, string name)
    {
        this.Id = id;
        this.WarehouseId = warehouseId;
        this.Code = code;
        this.Name = name;
    }

    public Locations(int warehouseId, string code, string name)
    {
        this.WarehouseId = warehouseId;
        this.Code = code;
        this.Name = name;
    }
}
