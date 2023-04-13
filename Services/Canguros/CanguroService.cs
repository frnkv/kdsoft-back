using CircoAPI.Services.Factories.Canguros;
using CircoAPI.Services.Helpers.Canguros;
using Domain;
using Domain.APIRequests.Canguros;
using Domain.APIResponses.Canguros;
using Services.Interfaces.Canguros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CircoAPI.Services.Canguros
{
    public class CanguroService : ICanguroService
    {
        #region Methods

        public EncuentroCanguroAPIResponse ShowEncuentroDeCanguros(EncuentroCanguroAPIRequest request)
        {
            Boolean encuentro = false;
            String? error = null;
            int? posicionDeEncuentro = null;
            try
            {
                List<Canguro> canguros = CrearCanguros(request);

                Boolean yaEsImposibleQueSeCrucen = EncuentroCangurosHelper.ValidarPosicionesPorSalto(canguros.AsEnumerable().Reverse().ToList());

                while(!encuentro && !yaEsImposibleQueSeCrucen)
                {
                    encuentro = RealizarSalto(ref yaEsImposibleQueSeCrucen, canguros);
                }

                if (encuentro)
                {
                    posicionDeEncuentro = canguros.First().DistanciaActual;
                }
            }
            catch(Exception ex)
            {
                error = ex.Message;
            }

            return new EncuentroCanguroAPIResponse(encuentro, posicionDeEncuentro, error);
        }

        private static bool RealizarSalto(ref bool yaEsImposibleQueSeCrucen, List<Canguro> canguros)
        {
            bool encuentro;
            canguros.ForEach(c => c.Saltar());

            encuentro = EncuentroCangurosHelper.ChequearEncuentro(canguros);

            if (!encuentro)
            {
                yaEsImposibleQueSeCrucen = EncuentroCangurosHelper.SeSobrePasaron(yaEsImposibleQueSeCrucen, canguros);
            }

            return encuentro;
        }

        #region Helpers

        private static List<Canguro> CrearCanguros(EncuentroCanguroAPIRequest request)
        {
            List<Canguro> canguros = request.Canguros
                .Select(x => CanguroFactory.Crear(x.PosicionInicial, x.PosicionesPorSalto))
                .ToList();

            EncuentroCangurosHelper.ValidarPosicionesIniciales(canguros);

            return canguros;
        }

        #endregion

        #endregion
    }
}
