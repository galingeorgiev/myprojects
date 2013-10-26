namespace MongoDBDictionary
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class DictionaryItem
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Word { get; set; }
        public string Translation { get; set; }

        public override string ToString()
        {
            return string.Format("Word: {0} - Translation: {1}", this.Word, this.Translation);
        }
    }
}
