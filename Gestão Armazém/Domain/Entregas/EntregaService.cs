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
        private readonly IArmazémRepository armazémRepo;

        private readonly IUnitOfWork gestorPersist;

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

            var armazém = await this.armazémRepo.GetByIdAsync(new Identificador(novaEntregaDTO.armazém.Id.GetValue));
            if(armazém == null)
            return null; 
            

            entrega.changeArmazém(novaEntregaDTO.GetArmazém);
            entrega.changeDataEntrega(novaEntregaDTO.GetDia, novaEntregaDTO.GetMes, novaEntregaDTO.GetAno);
            entrega.changeMassa(novaEntregaDTO.GetMassa);
            entrega.changeTempoColocação(novaEntregaDTO.GetTempoColocação);
            entrega.changeTempoRetirada(novaEntregaDTO.GetTempoRetirada);

            await this.gestorPersist.CommitAsync();

            return EntregasMapper.toDTO(entrega);
        }
    }
}