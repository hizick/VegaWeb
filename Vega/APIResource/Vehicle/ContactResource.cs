using System.ComponentModel.DataAnnotations;

namespace Vega.APIResource.Vehicle
{
    public class ContactResource
    {
        [Required][StringLength(40)] public string ContactName { get; set; }
        [Required] [StringLength(40)] public string ContactPhone { get; set; }
        [Required] public string ContactEmail { get; set; }
    }
}
