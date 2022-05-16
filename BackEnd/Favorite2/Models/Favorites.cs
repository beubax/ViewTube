using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Favorite2.Models
{
    public class Favorites
    {

        [BsonId]
        [Required]
        public string Id { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Json { get; set; }
    }
}
