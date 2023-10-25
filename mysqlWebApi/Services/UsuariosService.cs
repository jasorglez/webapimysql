using mysqlWebApi.Models;

namespace mysqlWebApi.Services
{
    public class UsuariosService : IUsuariosService
    {
        MagallanesContext context;

        public UsuariosService(MagallanesContext dbcontext)
        {
            this.context = dbcontext;
        }
        public IEnumerable<Usuarios> Get()
        {
            return context.Usuarios;
        }

        public async Task Save(Usuarios usuarios)
        {
            context.Add(usuarios);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, Usuarios usuarios)
        {
            var usuarioActual = context.Usuarios.Find(id);
            if (usuarioActual != null)
            {
                usuarioActual.Usuario = usuarios.Usuario;
                usuarioActual.Password = usuarios.Password;
                usuarioActual.Nombre = usuarios.Nombre;
                usuarioActual.Mail = usuarios.Mail;
                usuarioActual.Puesto = usuarios.Puesto;
                await context.SaveChangesAsync();
            }
            
        }

        public async Task Delete(int id)
        {
            var usuarioActual = context.Usuarios.Find(id);
            if (usuarioActual != null)
            {
                
                 context.Remove(usuarioActual);
                await context.SaveChangesAsync(); 
            }
            
        }

    }

    public interface IUsuariosService
    {
        IEnumerable<Usuarios> Get();
        Task Save(Usuarios usuarios);
        Task Update(int id, Usuarios usuarios);
        Task Delete(int id);

    }
}
