using mysqlWebApi.Models;

namespace mysqlWebApi.Services
{
    public class BancosService : IBancosService

        {
            wareHousesContext context;

            public BancosService(wareHousesContext dbcontext)
            {
                this.context = dbcontext;
            }
            public IEnumerable<Banks> Get()
            {
                return context.Bancos;
            }

            public async Task Save(Banks bancos)
            {
                context.Add(bancos);
                await context.SaveChangesAsync();
            }

            public async Task Update(int id, Banks bancos)
            {
                var bancoActual = context.Bancos.Find(id);
                if (bancoActual != null)
                {
                    
                    bancoActual.Nombre = bancos.Nombre;
                    bancoActual.Sucursal = bancos.Sucursal;
                    bancoActual.Numsucursal = bancos.Numsucursal;
                    bancoActual.Contacto = bancos.Contacto;
                    bancoActual.Telefono = bancos.Telefono;
                    bancoActual.ICodigoSat = bancos.ICodigoSat;
                    await context.SaveChangesAsync();
                }

            }

            public async Task Delete(int id)
            {
                var bancoActual = context.Bancos.Find(id);
                if (bancoActual != null)
                {

                    context.Remove(bancoActual);
                    await context.SaveChangesAsync();
                }

            }

        }

        public interface IBancosService
        {
            IEnumerable<Banks> Get();
            Task Save(Banks bancos);
            Task Update(int id, Banks bancos);
            Task Delete(int id);

        }
    }


