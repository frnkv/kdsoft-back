using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.APIRequests.Canguros
{
    public class EncuentroCanguroAPIRequest
    {
        public EncuentroCanguroAPIRequest(List<EncuentroCanguroAPIRequestDto> canguros)
        {
            Canguros = canguros;
        }

        public List<EncuentroCanguroAPIRequestDto> Canguros { get; set; }

    }
}
