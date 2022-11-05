using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Armazéns.DTO;
using System;

namespace DDDSample1.Domain.Armazéns
{
    public class EditarArmazémService
    {
        private readonly IArmazémRepository _repo;

        private readonly IUnitOfWork gestorPersist;

        public EditarArmazémService(IUnitOfWork gestorPersist, IArmazémRepository repo)
        {
            this.gestorPersist = gestorPersist;
            this._repo = repo;
        }

        public async Task<ArmazémDTO> EditarArmazémAsync(ArmazémDTO novoArmazémDTO)
        {
            var armazém = await this._repo.GetByIdAsync(new Identificador(novoArmazémDTO.GetIdentificador));
            if(armazém == null)
            return null;

            // change all fields
            
            armazém.changeDesignação(novoArmazémDTO.GetDesignação);
            armazém.changeEndereço(novoArmazémDTO.códigoPostal, novoArmazémDTO.GetNúmeroPorta, novoArmazémDTO.GetNomeRua,
                novoArmazémDTO.GetLocalidade, novoArmazémDTO.GetPaís);
            armazém.changeMunicípio(novoArmazémDTO.GetMunícipio);
            armazém.changeCoordenadas(novoArmazémDTO.latitude, novoArmazémDTO.longitude);

            await this.gestorPersist.CommitAsync();

            return ArmazémMapper.toDTO(armazém);
        }
    }
}