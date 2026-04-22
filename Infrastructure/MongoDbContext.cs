using MongoDB.Driver;
using ProgramAppointments.Domain;

namespace ProgramAppointments.Infrastructure
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

     
        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        // Exponemos las colecciones listas para ser consultadas
        public IMongoCollection<Usuario> Usuarios => _database.GetCollection<Usuario>("usuarios");
        public IMongoCollection<Reunion> Reuniones => _database.GetCollection<Reunion>("reuniones");
    }
}