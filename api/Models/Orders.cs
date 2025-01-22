using System.Text.Json.Serialization;

public class Orders
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    [JsonPropertyName("source_id")]
    public required int SourceId { get; set; }

    [JsonPropertyName("order_date")]
    public required DateTime OrderDate { get; set; }

    [JsonPropertyName("request_date")]
    public DateTime RequestDate { get; set; }

    [JsonPropertyName("reference")]
    public string Reference { get; set; }

    [JsonPropertyName("reference_extra")]
    public string ReferenceExtra { get; set; }

    [JsonPropertyName("order_status")]
    public required string OrderStatus { get; set; }

    [JsonPropertyName("notes")]
    public string Notes { get; set; }

    [JsonPropertyName("shipping_notes")]
    public string ShippingNotes { get; set; }

    [JsonPropertyName("picking_notes")]
    public string PickingNotes { get; set; }

    [JsonPropertyName("warehouse_id")]
    public required int WarehouseId { get; set; }

    [JsonPropertyName("ship_to")]
    public int? ShipTo { get; set; } = null;

    [JsonPropertyName("bill_to")]
    public required int? BillTo { get; set; } = null;

    [JsonPropertyName("shipment_id")]
    public int ShipmentId { get; set; }

    [JsonPropertyName("total_amount")]
    public decimal TotalAmount { get; set; }

    [JsonPropertyName("total_discount")]
    public decimal TotalDiscount { get; set; }

    [JsonPropertyName("total_tax")]
    public decimal TotalTax { get; set; }

    [JsonPropertyName("total_surcharge")]
    public decimal TotalSurcharge { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("items")]
    public required List<OrdersItem> Items { get; set; } = new();
}
