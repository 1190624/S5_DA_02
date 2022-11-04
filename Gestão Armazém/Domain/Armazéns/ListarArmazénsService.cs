using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Armazéns.DTO;

namespace DDDSample1.Domain.Armazéns
{
    public class ListarArmazénsService
    {
        private readonly IArmazémRepository _repo;

        private readonly IUnitOfWork gestorPersist;

        public ListarArmazénsService(IUnitOfWork gestorPersist, IArmazémRepository repo)
        {
            this.gestorPersist = gestorPersist;
            this._repo = repo;
        }
        public async Task<List<ArmazémDTO>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();

            foreach(Armazém armazém in list){
                //TODO
            }

            List<ArmazémDTO> listaArmazémDTO = list.ConvertAll<ArmazémDTO>(armazém => ArmazémMapper.toDTO(armazém));

            return listaArmazémDTO;
        }
    }
}