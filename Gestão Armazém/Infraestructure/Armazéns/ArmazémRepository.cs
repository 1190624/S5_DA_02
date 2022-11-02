using DDDSample1.Infrastructure.Shared;
using DDDSample1.Domain.Armazéns;
using DDDSample1.Domain.Common;

namespace DDDSample1.Infrastructure.Armazéns {
    public class ArmazémRepository : BaseRepository<Armazém, Identificador>, IArmazémRepository {
        public ArmazémRepository(DDDSample1DbContext context) : base(context.armazéns) {}
    }
}