using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Interfaces.Repositorios.Consulta;
using System.Collections.Generic;
using System.Linq;

namespace FeriasCo.Mock.Repositorio.Repositorios.Consulta
{
    public class QuartoRepositorio : IQuartoRepositorio
    {

        public Quarto Obter(int id)
        {
            return Banco.Instancia.Quartos.FirstOrDefault(quartos => quartos.Id == id);
        }

        public IEnumerable<Quarto> ObterTodos()
        {
            return Banco.Instancia.Quartos;
        }
    }
}
