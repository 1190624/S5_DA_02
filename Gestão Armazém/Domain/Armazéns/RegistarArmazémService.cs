using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Armazéns.DTO;
using DDDSample1.Domain.Common;

namespace DDDSample1.Domain.Armazéns {
    public class RegistarArmazémService {
        private readonly IArmazémRepository armazémRepo;
        private readonly IUnitOfWork gestorPersist;

        public RegistarArmazémService(IArmazémRepository armazémRepo, IUnitOfWork gestorPersist) {
            this.armazémRepo = armazémRepo;
            this.gestorPersist = gestorPersist;
        }
 
        public async Task<ArmazémDTO> RegistarArmazém(ArmazémDTO armazémDTO) {
            Armazém armazém = ArmazémMapper.toArmazém(armazémDTO);

            await armazémRepo.AddAsync(armazém);
            await gestorPersist.CommitAsync();

            return ArmazémMapper.toDTO(armazém);
        }

        public async Task<List<ArmazémDTO>> GetAllAsync() {
            var list = await armazémRepo.GetAllAsync();

            List<ArmazémDTO> armazémDTOList = list.ConvertAll<ArmazémDTO>(armazém => ArmazémMapper.toDTO(armazém));

            return armazémDTOList;
        }

        public async Task<ArmazémDTO> GetByIdAsync(String Id) {
            Identificador identificador = new Identificador(Id);
            var armazém = await armazémRepo.GetByIdAsync(identificador);

            if (armazém == null)
                return null;

            return ArmazémMapper.toDTO(armazém);
        }

        public async Task<ArmazémDTO> DeleteAsync(String Id)
        {
            Identificador identificador = new Identificador(Id);
            var armazém = await armazémRepo.GetByIdAsync(identificador); 

            if (armazém == null)
                return null;   

            
            this.armazémRepo.Remove(armazém);
            await this.gestorPersist.CommitAsync();

            return ArmazémMapper.toDTO(armazém);
        }
    }
}