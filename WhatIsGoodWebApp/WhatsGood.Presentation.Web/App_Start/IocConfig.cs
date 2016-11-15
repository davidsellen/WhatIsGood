using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsGood.Presentation.Web.App_Start
{
    public class IocConfig
    {
        internal static void Configure()
        {

            var rootComposition = new RootComposition.Initializer();
            rootComposition.Initialize();

        }

    }
}