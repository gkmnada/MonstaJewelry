using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CatalogAPI.Entities
{
    public class Footer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FooterID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public string CategoryID { get; set; }
        public string CouponCode { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
    }
}
