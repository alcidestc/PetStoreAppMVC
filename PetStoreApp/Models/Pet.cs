using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PetStoreApp.Models;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Modelos
{
    public class Pet
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [Display(Name ="Categoria")]
        [JsonProperty("category")]
        public Category Category { get; set; }

        [Display(Name ="Nombre")]
        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Display(Name = "Urls de fotos")]
        [JsonProperty("photoUrls", Required = Required.Default)]
        public List<string> PhotoUrls { get; set; }

        [JsonProperty("tags", Required = Required.Default)]
        public List<Category> Tags { get; set; }

        [Display(Name="Estado")]
        [Required]
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
    }
}
