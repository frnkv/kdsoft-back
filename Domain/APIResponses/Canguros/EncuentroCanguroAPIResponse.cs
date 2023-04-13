using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.APIResponses.Canguros
{
    public class EncuentroCanguroAPIResponse
    {
        #region Constructors

        public EncuentroCanguroAPIResponse(Boolean encuentro, int? posicionDeEncuentro = null, String? error = null)
        {
            Encuentro = encuentro;
            Error = error;
            PosicionDeEncuentro = posicionDeEncuentro;
        }

        #endregion

        #region Properties

        public String? Error { get; private set; }
        public Boolean Encuentro { get; private set; }
        public int? PosicionDeEncuentro { get; private set; }
        public String Mensaje => Encuentro ? "SI" : "NO";
        public Boolean ConExito => String.IsNullOrEmpty(Error);

        #endregion
    }
}
