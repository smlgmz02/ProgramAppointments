using MongoDB.Driver;
using GestionReuniones.Domain;

namespace GestionReuniones.Infrastructure
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        // Pasaremos la cadena de conexión al instanciar la clase
        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        // Exponemos las colecciones listas para ser consultadas
        public IMongoCollection<Usuario> Usuarios => _database.GetCollection<Usuario>("usuario");
        public IMongoCollection<Reunion> Reuniones => _database.GetCollection<Reunion>("reunion");
    }
}