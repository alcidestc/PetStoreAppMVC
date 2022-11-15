using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace PetStoreApp.Models
{
    public class Order
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("petId")]
        [Display(Name = "Mascota")]
        public long PetId { get; set; }

        [JsonProperty("quantity")]
        [Display(Name = "Cantidad")]
        public long Quantity { get; set; }

        [JsonProperty("shipDate")]
        [Display(Name = "Fecha de compra")]
        [DataType(DataType.DateTime)]
        public DateTimeOffset ShipDate { get; set; } = DateTime.Parse(DateTime.Now.ToString("g"));

        [JsonProperty("status")]
        [Display(Name = "Estado")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusOrder Status { get; set; }

        [JsonProperty("complete")]
        [Display(Name = "Completado")]
        public bool Complete { get; set; }
    }
}
