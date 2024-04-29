using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CatalogAPI.Entities
{
    public class Banner
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BannerID { get; set; }
        public string ProductImage { get; set; }
        public string CategoryID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
    }
}
