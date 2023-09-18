using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using ApplicationCore.Services;
using Infrastructure.Repositories;

namespace WebApi.Core
{
    public static class ServiceExtensionInterface
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddInfrastructure(this IServiceCollection services)
        {
            #region Repositories 

            services.AddTransient<IAccesoRepository, AccesoRepository>();
            services.AddTransient<IEstadoRepository, EstadoRepository>();
            services.AddTransient<IFacturacionRepository, FacturacionRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IMateriaPrimaRepository, MateriaPrimaRepository>();
            services.AddTransient<IRolRepository, RolRepository>();
            services.AddTransient<IOrdenRepository, OrdenRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            #endregion Repositories

            #region Services 

            services.AddTransient<IAccesoService, AccesoService>();
            services.AddTransient<IEstadoService, EstadoService>();
            services.AddTransient<IFacturacionService, FacturacionService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IMateriaPrimaService, MateriaPrimaService>();
            services.AddTransient<IRolService, RolService>();
            services.AddTransient<IOrdenService, OrdenService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IContraseniaService, ContraseniaService>();

            #endregion Services
        }
    }
}
