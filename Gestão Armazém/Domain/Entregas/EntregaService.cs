using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Entregas.DTO;
using System;
using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Armazéns;

namespace DDDSample1.Domain.Entregas
{
    public class EntregaService
    {
        private readonly IEntregasRepository _repo;

        private readonly IUnitOfWork gestorPersist;

        //private readonly IArmazémRepository armazémRepo;

        public EntregaService(IUnitOfWork gestorPersist, IEntregasRepository repo)
        {
            this.gestorPersist = gestorPersist;
            this._repo = repo;
        }

        public async Task<EntregasDTO> editarEntregaAsync(EntregasDTO novaEntregaDTO)
        {
            var entrega = await this._repo.GetByIdAsync(new Identificador(novaEntregaDTO.GetIdentificador));
            if(entrega == null)
            return null;


            //TODO verificar se existe armazem 
            // change all fields
            
        /*
            armazém.changeDesignação(novoArmazémDTO.GetDesignação);
            armazém.changeEndereço(novoArmazémDTO.códigoPostal, novoArmazémDTO.GetNúmeroPorta, novoArmazémDTO.GetNomeRua,
                novoArmazémDTO.GetLocalidade, novoArmazémDTO.GetPaís);
            armazém.changeMunicípio(novoArmazémDTO.GetMunícipio);
            armazém.changeCoordenadas(novoArmazémDTO.latitude, novoArmazémDTO.longitude);
*/

            await this.gestorPersist.CommitAsync();

            return EntregasMapper.toDTO(entrega);
        }


        public async Task<EntregasDTO> RegistarEntrega(EntregasDTO entregasDTO) {
            Entrega entrega = EntregasMapper.toEntrega(entregasDTO);

           /* var armazém = await this.armazémRepo.GetByIdAsync(new Identificador(entregasDTO.GetArmazém));
            if(armazém == null)
                return null;
*/
            await _repo.AddAsync(entrega);
            await gestorPersist.CommitAsync();
            

            return EntregasMapper.toDTO(entrega);
        }

        public async Task<EntregasDTO> GetByIdAsync(String Id) {
            Identificador identificador = new Identificador(Id);
            var entrega = await _repo.GetByIdAsync(identificador);

            if (entrega == null)
                return null;

            return EntregasMapper.toDTO(entrega);
        }
        
        public async Task<List<EntregasDTO>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();

            List<EntregasDTO> listaEntregasDTO = list.ConvertAll<EntregasDTO>(entrega => EntregasMapper.toDTO(entrega));

            return listaEntregasDTO;
        }



    }
}