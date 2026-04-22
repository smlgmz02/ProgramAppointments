using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GestionReuniones.Domain
{
    public class Usuario
    {
        [BsonId] // Identificador interno de Mongo
        public ObjectId IdMongo { get; set; }

        [BsonElement("id_usuario")]
        public int IdUsuario { get; set; }

        [BsonElement("rol_usuario")]
        public string Rol { get; set; }

        [BsonElement("nombre_usuario")]
        public string Nombre { get; set; }

        [BsonElement("apellido_usuario")]
        public string Apellido { get; set; }

        [BsonElement("email_usuario")]
        public string Email { get; set; }

        [BsonElement("password_usuario")]
        public string Password { get; set; }
    }
}