using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircoAPI.Services.Factories.Canguros
{
    public static class CanguroFactory
    {
        #region Methods

        public static Canguro Crear(Int32 posicionInicial, Int32 posicionesPorSalto)
        {
            return new Canguro(posicionInicial, posicionesPorSalto);
        }

        #endregion
    }
}
