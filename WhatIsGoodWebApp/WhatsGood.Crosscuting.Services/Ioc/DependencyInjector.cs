using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsGood.Crosscuting.Services.Ioc
{
    public class DependencyInjector
    {

        private static volatile IUnityContainer container;
        private static object syncRoot = new Object();

        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    lock (syncRoot)
                    {
                        if (container == null)
                            container = new UnityContainer();
                    }
                }
                return container;
            }
        }
                

        /// <summary>
        /// Returns an instance of the default type registered with the container as the type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>( ){

            return Container.Resolve<T>();
        }
        /// <summary>
        /// Returns an instance of the type registered with the container as the type T with the specified name. Names are case-sensitive.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T Resolve<T>(string name)        
        {
            return Container.Resolve<T>(name);
        }

        /// <summary>
        /// Returns an instance of the default type registered with the container as the type t.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Object Resolve(Type t) 
        {
            return Container.Resolve(t);
        }

        /// <summary>
        /// Returns an instance of the default type registered with the container as the type t with the specified name. Names are case-sensitive.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="name"></param>
        public Object Resolve(Type t, string name)
        {
            return Container.Resolve(t, name);
        }
    }
}
