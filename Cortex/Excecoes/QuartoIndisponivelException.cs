using FeriasCo.Cortex.Interfaces;

namespace FeriasCo.Cortex.Excecoes
{
    public class QuartoIndisponivelException : FeriasCoException
    {
        public QuartoIndisponivelException(int id) : base($"O quarto {id} está indiponível para as datas da reserva")
        {
        }
    }
}
