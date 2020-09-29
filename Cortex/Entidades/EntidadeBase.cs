using FeriasCo.Cortex.Interfaces;

namespace FeriasCo.Cortex.Entidades
{
    public class EntidadeBase : IEntidade
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this != obj)
                return false;

            return Equals((EntidadeBase)obj);
        }

        public virtual bool Equals(EntidadeBase obj)
        {
            return obj.Id == Id;
        }

        public override int GetHashCode()
        {
            return $"{ GetType().FullName}-{Id}".GetHashCode();
        }
    }
}
