using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Interfaces;
using FeriasCo.Cortex.Interfaces.Repositorios.Comando;
using FeriasCo.Cortex.Interfaces.Repositorios.Consulta;
using FeriasCo.Cortex.Servicos;
using FeriasCo.Cortex.Validadores;
using FeriasCo.Mock.Repositorio.Repositorios.Comando;
using FeriasCo.Mock.Repositorio.Repositorios.Consulta;
using SimpleInjector;

namespace FeriasCo.Teste
{
    public class TesteBase
    {
        protected readonly Container container;
        public TesteBase()
        {
            container = new Container();

            container.Register<IValidador<Reserva>, ReservaValidador>();
            container.Register<IReservaRepositorio, ReservaRepositorio>();
            container.Register<IReservaResumoRepositorio, ReservaResumoRepositorio>();
            container.Register<IQuartoResumoRepositorio, QuartoResumoRepositorio>();
            container.Register<ReservaServico>();
        }
    }
}
