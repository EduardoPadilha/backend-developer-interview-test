namespace FeriasCo.Cortex.Interfaces.Repositorios
{
    public interface IRepositorioComando<TEntidade> where TEntidade : IEntidade
    {
        int Adicionar(TEntidade entidade);
        void Editar(TEntidade entidade);
        void Remover(TEntidade entidade);
    }
}
