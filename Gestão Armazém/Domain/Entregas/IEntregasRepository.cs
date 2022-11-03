using DDDSample1.Domain.Common;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Entregas {
    public interface IEntregasRepository : IRepository<Entrega, Identificador> {}
}