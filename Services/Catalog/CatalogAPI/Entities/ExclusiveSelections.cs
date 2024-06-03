using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CatalogAPI.Entities
{
    public class ExclusiveSelections
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ExclusiveSelectionsID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryID { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
    }
}
