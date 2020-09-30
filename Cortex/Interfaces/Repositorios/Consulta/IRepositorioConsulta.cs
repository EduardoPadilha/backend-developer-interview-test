using System.Collections.Generic;

namespace FeriasCo.Cortex.Interfaces.Repositorios.Consulta
{
    public interface IRepositorioConsulta<TEntidade> where TEntidade : IEntidade
    {
        TEntidade Obter(int id);
    }
}
