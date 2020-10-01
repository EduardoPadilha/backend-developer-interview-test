namespace FeriasCo.Cortex.Interfaces.Repositorios.Comando
{
    public interface IRepositorioComando<TEntidade> where TEntidade : IEntidade
    {
        void Adicionar(TEntidade entidade);
        void Editar(TEntidade entidade);
        void Remover(TEntidade entidade);
    }
}
