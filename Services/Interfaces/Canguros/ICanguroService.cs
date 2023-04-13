using Domain.APIRequests.Canguros;
using Domain.APIResponses;
using Domain.APIResponses.Canguros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.Canguros
{
    public interface ICanguroService
    {
        public EncuentroCanguroAPIResponse ShowEncuentroDeCanguros(EncuentroCanguroAPIRequest request);
    }
}
