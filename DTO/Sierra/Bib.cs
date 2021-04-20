using System;
using System.Collections.Generic;
using System.Text.Json;
using MARC4J.Net.MARC;
using Newtonsoft.Json.Linq;

namespace DTO.Sierra
{
    public class Bib
    {
        public string Id { get; set; } = default!;
        public string? Title { get; set; }
        public string? Author { get; set; }
        public JsonDocument? Marc { get; set; }
        
        public int? PublishYear { get; set; }
        public int? Copies { get; set; }
        
        public bool? Deleted { get; set; }
        public bool? Suppressed { get; set; }
        
        public DateTime? CatalogDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        
        public Language? Lang { get; set; }
        public MaterialType? MaterialType { get; set; }
        public Country? Country { get; set; }
        
        public ICollection<Library>? Locations { get; set; }
    }
}