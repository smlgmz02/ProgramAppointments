using MongoDB.Driver;
using GestionReuniones.Domain;
using GestionReuniones.Infrastructure;
using System.Threading.Tasks;

namespace GestionReuniones.Application
{
    public class AuthService
    {
        private readonly MongoDbContext _context;

        public AuthService(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> LoginAsync(string email, string password)
        {
            // Validamos las credenciales contra la base de datos.
            // Nota: En un futuro, si el proyecto escala, cambiaremos esta 
            // validación en texto plano por una comparación de Hashes.
            var usuario = await _context.Usuarios
                .Find(u => u.Email == email && u.Password == password)
                .FirstOrDefaultAsync();

            return usuario;
        }
    }
}