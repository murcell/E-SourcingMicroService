using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using ThirdParty.Json.LitJson;

namespace ESourcing.Products.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 
        // todo:Bu şekilde firek entityi controllara gödnerdiğimde nullabla yapmadığımda validationa takılıyor
        // o yzden nullabla yaptım. daha güzel bir yolu var mı araştır. IValidate interface'ini kullanıp middleware yapabilirim onun dışında

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Summary")]
        public string Summary { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Image")]
        public string ImageFile { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }
    }
}
