﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(S2021A6FH.Startup))]

namespace S2021A6FH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
