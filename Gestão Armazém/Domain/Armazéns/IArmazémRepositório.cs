using DDDSample1.Domain.Common;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Armazéns {
    public interface IArmazémRepository : IRepository<Armazém, Identificador> {}
}