using mysqlWebApi.Models;

namespace mysqlWebApi.Services
{
    public class UsuariosService : IUsuariosService
    {
        wareHousesContext context;

        public UsuariosService(wareHousesContext dbcontext)
        {
            this.context = dbcontext;
        }
        public IEnumerable<Users> Get()
        {
            return context.Users;
        }

        public async Task Save(Users usuarios)
        {
            context.Add(usuarios);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, Users usuarios)
        {
            var usuarioActual = context.Users.Find(id);
            if (usuarioActual != null)
            {
                usuarioActual.Usuario = usuarios.Usuario;
                usuarioActual.Password = usuarios.Password;
                usuarioActual.Name = usuarios.Name;
                usuarioActual.Mail = usuarios.Mail;
                usuarioActual.Position = usuarios.Position;
                await context.SaveChangesAsync();
            }
            
        }

        public async Task Delete(int id)
        {
            var usuarioActual = context.Users.Find(id);
            if (usuarioActual != null)
            {
                
                 context.Remove(usuarioActual);
                await context.SaveChangesAsync(); 
            }
            
        }

    }

    public interface IUsuariosService
    {
        IEnumerable<Users> Get();
        Task Save(Users usuarios);
        Task Update(int id, Users usuarios);
        Task Delete(int id);

    }
}
