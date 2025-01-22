using System.Text.Json.Serialization;

public class OrdersItem
{
    [JsonIgnore]
    public int OrderId { get; set; }

    [JsonPropertyName("uid")]
    public required string Uid { get; set; }

    [JsonPropertyName("code")]
    public required string Code { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("short_description")]
    public string ShortDescription { get; set; }

    [JsonPropertyName("upc_code")]
    public required string UpcCode { get; set; }

    [JsonPropertyName("model_number")]
    public required string ModelNumber { get; set; }

    [JsonPropertyName("commodity_code")]
    public string CommodityCode { get; set; }

    [JsonPropertyName("item_line")]
    public int ItemLine { get; set; }

    [JsonPropertyName("item_group")]
    public int ItemGroup { get; set; }
}
