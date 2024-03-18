using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BluRayCollectionAPI.Models
{
    public class Blurays
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public string Director { get; set; } = null!;
        public string ReleaseDate { get; set; } = null!;
        public string Rating { get; set; } = null!;
        public string Format { get; set; } = null!;
        public string Language { get; set; } = null!;
        public string Subtitles { get; set; } = null!;
        public string RunTime { get; set; } = null!;
        public string Plot { get; set; } = null!;
        public string CoverImage { get; set; } = null!;
    }
}
