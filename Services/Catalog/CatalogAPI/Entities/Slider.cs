using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CatalogAPI.Entities
{
    public class Slider
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SliderID { get; set; }
        public string ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string PriceDescription { get; set; }
        public string CouponCode { get; set; }
    }
}
