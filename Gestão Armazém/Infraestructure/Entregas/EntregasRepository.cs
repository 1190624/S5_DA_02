using DDDSample1.Infrastructure.Shared;
using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Common;

namespace DDDSample1.Infrastructure.Entregas {
    public class EntregasRepository : BaseRepository<Entrega, Identificador>, IEntregasRepository {
        public EntregasRepository(DDDSample1DbContext context) : base(context.entrega) {}
    }
}