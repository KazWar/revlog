using System.ComponentModel.DataAnnotations;

namespace SendCloudService.Models
{
    public class ReturnShipment
    {
        [JsonProperty("from_address")]
        public string FromAddress { get; set; } = default!;

        [JsonProperty("to_address")]
        public string ToAddress { get; set; } = default!;

        [JsonProperty("shipping_products")]
        public string ShippingProducts { get; set; } = default!;

        /// <summary>
        /// Package dimensions given in height * width * length in meters(M)
        /// </summary>
        public Dimensions Dimensions { get; set; } = default!;

        /// <summary>
        /// Total weight in kilograms (KG)
        /// </summary>
        public decimal Weight { get; set; } = default!;

        /// <summary>
        /// The number of collos this return consists of.
        /// Is a number which is 1+ or if not given defaults to 1
        /// </summary>
        [JsonProperty("collo_count")]
        public int? ColloCount { get; set; }

        /// <summary>
        /// Array containing Parcel type objects
        /// </summary>
        [JsonProperty("parcel_items")]
        public Parcel[]? Parcels { get; set; }

        /// <summary>
        /// When true SendCloud will send out the default track and trace emails
        /// </summary>
        [JsonProperty("send_tracking_emails")]
        public bool? SendTrackingEmails { get; set; }

        /// <summary>
        /// Brand to link this return to. For sending e-mails for example
        /// </summary>
        [JsonProperty("brand_id")]
        public int? BrandId { get; set; }

        /// <summary>
        /// Total insured value
        /// </summary>
        [JsonProperty("total_insured_value")]
        public decimal? TotalInsuredValue { get; set; }

        /// <summary>
        /// Which order this return shipment belongs to
        /// </summary>
        [JsonProperty("order_number")]
        public string? OrderNumber { get; set; }

        /// <summary>
        /// Total cost of the shipment calculcated from Parcel values
        /// </summary>
        [JsonProperty("total_order_value")]
        public decimal? TotalOrderValue { get; set; }

        [JsonProperty("external_reference")]
        public string? ExternalReference { get; set; }
    }

    public class ReturnShipmentResponse
    {
        /// <summary>
        /// The return number of the created shipment
        /// </summary>
        public int Return { get; set; }
    }

    /// <summary>
    /// Response given by the /returns/validate API endpoints
    /// </summary>
    public class ReturnShipmentValidationResponse: ReturnShipment
    {
        /// <summary>
        /// Returns true if the payload is correctly structured 
        /// </summary>
        [JsonProperty("is_valid")]
        public bool IsValid { get; set; }
    }

    #region ReturnShipment helper classes

    public class Dimensions
    {
        /// <summary>
        /// Height in meters(M)
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// Width in meters(M)
        /// </summary>
        public decimal Width { get; set; }

        /// <summary>
        /// Length in meters(M)
        /// </summary>
        public decimal Length { get; set; }
    }

    public class Parcel
    {
        /// <summary>
        /// Description of the item
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Quantity of the shipped items
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Weight of a single item in kilograms(KG)
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// Value of a single item
        /// </summary>
        public decimal? Value { get; set; }

        /// <summary>
        /// Harmonized system code
        /// </summary>
        [JsonProperty("hs_code")]
        public string? HsCode { get; set; }

        /// <summary>
        /// ISO-2 code of the country where the items were originally produced in
        /// </summary>
        [MaxLength(2)]
        [JsonProperty("origin_country")]
        public int? OriginCountry { get; set; }

        /// <summary>
        /// The Stock Keeping Unit(SKU) of the product
        /// </summary>
        public string? SKU { get; set; }

        /// <summary>
        /// The internal ID of the product
        /// </summary>
        [JsonProperty("product_id")]
        public string? ProductId { get; set; }
    }

    #endregion
}
