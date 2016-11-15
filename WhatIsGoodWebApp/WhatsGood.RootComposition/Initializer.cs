using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsGood.Crosscuting.Services.Ioc;
using WhatsGood.Domain.Repositories;
using WhatsGood.Repository;
using WhatsGood.Repository.Repositories;


namespace WhatsGood.RootComposition
{
    public class Initializer
    {
        public void Initialize()
        {

            IUnityContainer container = DependencyInjector.Container;

            #region Instances

            container.RegisterType<IUnitOfWork, EventDbContext>(new InjectionConstructor("WhatsGoodDBLocalConnection"));
            
            #endregion
          
        }

       
    }
}
