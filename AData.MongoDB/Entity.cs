using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AData.MongoDB
{
    public class Entity
    {
        public Entity()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonElement(Order = 0)]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
