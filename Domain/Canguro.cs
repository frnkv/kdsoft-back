namespace Domain
{
    public class Canguro
    {
        #region Constructors

        public Canguro(int posicionInicial, int posicionesPorSalto)
        {
            SetPosicionInicial(posicionInicial);
            SetPosicionesPorSalto(posicionesPorSalto);
            DistanciaActual = posicionInicial;
            CantidadDeSaltosDados = 0;

        }

        #endregion

        #region Properties

        public int PosicionInicial { get; private set; }
        public int PosicionesPorSalto { get; private set; }
        public int DistanciaActual { get; private set; }
        public int CantidadDeSaltosDados { get; private set; }

        #endregion

        #region Methods

        public void Saltar()
        {
            DistanciaActual += PosicionesPorSalto;
            CantidadDeSaltosDados++;
        }

        #region Setters

        /// <summary>
        /// 0 <= posicionInicial <= 10000
        /// </summary>
        /// <param name="posicionInicial"></param>
        private void SetPosicionInicial(int posicionInicial)
        {
            if (posicionInicial < 0 || posicionInicial > 10000) 
            {
                throw new Exception("La posición inicial de un canguro debe estar entre 0 y 10000");
            }

            PosicionInicial = posicionInicial;
        }


        /// <summary>
        /// 1 <= posicionesPorSalto<= 10000
        /// </summary>
        /// <param name="posicionInicial"></param>
        private void SetPosicionesPorSalto(int posicionesPorSalto)
        {
            if (posicionesPorSalto < 1 || posicionesPorSalto > 10000) 
            {
                throw new Exception("Las posiciones por salto de un canguro deben ser entre 1 y 10000");
            }

            PosicionesPorSalto = posicionesPorSalto;
        }

        #endregion

        #endregion
    }
}