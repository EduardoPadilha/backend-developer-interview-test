namespace FeriasCo.Cortex.Interfaces.Repositorios
{
    public interface IRepositorioConsulta<TEntidade> where TEntidade : IEntidade
    {
        TEntidade Obter(int id);
    }
}
