using Autofac;
using NLayer.Core.Repositorys;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Repository.Mapping;
using NLayer.Repository.Repositorys;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Services;
using System.Reflection;
//Modulun AutoFact daki module oldugunu gosteririk burada : AutoFac yuklemek lazimdir
using Module = Autofac.Module;
namespace NLayer.API.Modules
{
    public class RepoServiceModule : Module
    {
        //protected override void Load(ContainerBuilder builder)
        //{

        //    //GenericTypler da RegisterGeneric olur
        //    builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>));

        //    //GenericTypler da RegisterGeneric olur
        //    builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>));

        //    //Typlerda ise RegisterType olaraq yazilir
        //    builder.RegisterType<UnitOfWork>().As(typeof(IUnitOfWork));


        //    var apiAssembly = Assembly.GetExecutingAssembly();

        //    var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));

        //    var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));


        //    //Sonunda Repository olan serviceleri tapmaq ve cagirmaq ucun 
        //    builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
        //        .Where(x => x.Name.EndsWith("Repository"))
        //        .AsImplementedInterfaces()
        //        .InstancePerLifetimeScope();

        //    //Sonunda Service olan serviceleri tapmaq ve cagirmaq ucun 
        //    builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
        //        .Where(x => x.Name.EndsWith("Service"))
        //        .AsImplementedInterfaces()
        //        .InstancePerLifetimeScope();
        //}
    }
}
