using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminQueryController : ControllerBase
    {
        public int SearchClient()
        {
            throw new NotImplementedException();
        }

        public int AquiredProducts()
        {
            throw new NotImplementedException();
        }

        public int SearchProduct()
        {
            throw new NotImplementedException();
        }

        public int SearchClientsInCommon()
        {
            throw new NotImplementedException();
        }
    }
}
