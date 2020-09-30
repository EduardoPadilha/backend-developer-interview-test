using FeriasCo.Cortex.Entidades;
using FeriasCo.Cortex.Interfaces.Repositorios.Consulta;
using System.Collections.Generic;
using System.Linq;

namespace FeriasCo.Mock.Repositorio.Repositorios.Consulta
{
    public class QuartoResumoRepositorio : IQuartoResumoRepositorio
    {
        private readonly List<Quarto> quartos = new List<Quarto>
        {
            new Quarto
            {
                Descricao = "Quarto 1",
                Capacidade = 1,
                Id = 1
            },
            new Quarto
            {
                Descricao = "Quarto 2",
                Capacidade = 2,
                Id = 2
            },
            new Quarto
            {
                Descricao = "Quarto 3",
                Capacidade = 3,
                Id = 3
            },
            new Quarto
            {
                Descricao = "Quarto 5",
                Capacidade = 5,
                Id = 5
            },
        };

        public Quarto Obter(int id)
        {
            return quartos.FirstOrDefault(quartos => quartos.Id == id);
        }
    }
}
