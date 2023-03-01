using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ArquivoCliente_API.Modelo
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; } = default!;
        [BsonElement("Sobrenome")]
        public string Sobrenome { get; set; } = default!;
        [BsonElement("Idade")]
        public int Idade { get; set; } = default!;
        [BsonElement("Sexo")]
        public string Sexo { get; set; } = default!;

    }
}
