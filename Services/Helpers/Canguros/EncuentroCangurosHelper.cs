using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircoAPI.Services.Helpers.Canguros
{
    public static class EncuentroCangurosHelper
    {
        #region Validations

        /// <summary>
        /// Si el canguro que arrancó más atrás pasó al que arrancó más adelante,
        /// ya es imposible que coincidan.
        /// </summary>
        /// <param name="yaEsImposibleQueSeCrucen"></param>
        /// <param name="canguros"></param>
        /// <returns></returns>
        public static bool SeSobrePasaron(bool yaEsImposibleQueSeCrucen, List<Canguro> canguros)
        {
            for (int posicionCanguro = 0; posicionCanguro < canguros.Count(); posicionCanguro++)
            {
                Canguro canguro = canguros.ElementAt(posicionCanguro);

                Canguro? canguroSiguiente = canguros.ElementAtOrDefault(posicionCanguro + 1);

                if (canguroSiguiente == default(Canguro))
                {
                    continue;
                }

                yaEsImposibleQueSeCrucen = canguro.DistanciaActual > canguroSiguiente.DistanciaActual;
            }

            return yaEsImposibleQueSeCrucen;
        }

        /// <summary>
        /// Regla 0 <= x1 < x2 <= 10000
        /// Canguro N debe arrancar detrás que Canguro N+1
        /// </summary>
        /// <param name="canguros"></param>
        /// <exception cref="Exception"></exception>
        public static void ValidarPosicionesIniciales(List<Canguro> canguros)
        {
            Boolean errorEnPosicionesIniciales = ValidarDatosCanguros(
                canguros,
                (valor, canguro) => valor > canguro.PosicionInicial,
                (canguro) => canguro.PosicionInicial
            );

            if (errorEnPosicionesIniciales)
            {
                throw new Exception($"Los canguros deben ingresarse en orden ascendente de posiciones");
            }
        }

        /// <summary>
        /// Si Canguro N+1 avanza más o igual posiciones que Canguro N, ya es
        /// imposible que se crucen.
        /// </summary>
        /// <param name="canguros"></param>
        /// <returns></returns>
        public static Boolean ValidarPosicionesPorSalto(List<Canguro> canguros)
        {
            return ValidarDatosCanguros(
                canguros,
                (valor, canguro) => valor >= canguro.PosicionesPorSalto,
                (canguro) => canguro.PosicionesPorSalto
            );
        }

        /// <summary>
        /// Función de agregación para recorrer los canguros en base a un acumulador,
        /// en este caso, se va pisando el acumulador según la posición inicial ó velocidad por salto
        /// </summary>
        /// <param name="canguros"></param>
        /// <param name="eval"></param>
        /// <param name="getValor"></param>
        /// <returns></returns>
        public static Boolean ValidarDatosCanguros(List<Canguro> canguros, Func<int, Canguro, bool> eval, Func<Canguro, int> getValor)
        {
            int valor = 0;
            Boolean error = false;

            _ = canguros.Aggregate(valor, (valor, canguro) =>
            {
                error = eval.Invoke(valor, canguro);

                return getValor.Invoke(canguro);
            });

            return error;
        }

        /// <summary>
        /// Agrupo por distancia actual de cada uno, si me da 1, significa que todos los canguros
        /// tienen la misma distancia en salto T.
        /// </summary>
        /// <param name="canguros"></param>
        /// <returns></returns>
        public static Boolean ChequearEncuentro(List<Canguro> canguros)
        {
            int distancias = canguros.GroupBy(x => x.DistanciaActual).Count();

            return distancias == 1;
        }

        #endregion
    }
}
