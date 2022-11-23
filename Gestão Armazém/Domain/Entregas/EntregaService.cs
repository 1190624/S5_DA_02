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

        //private readonly IArmazémRepository armazémRepo;

        public EntregaService(IUnitOfWork gestorPersist, IEntregasRepository repo, IArmazémRepository armazémRepository)
        {
            this.gestorPersist = gestorPersist;
            this._repo = repo;
            this.armazémRepo = armazémRepository;
        }

        public async Task<EntregasDTO> editarEntregaAsync(EntregasDTO novaEntregaDTO)
        {
            var entrega = await this._repo.GetByIdAsync(new Identificador(novaEntregaDTO.GetIdentificador));
            if(entrega == null)
            return null;

            var armazém = await this.armazémRepo.GetByIdAsync(new Identificador(novaEntregaDTO.GetArmazém));
            if(armazém == null)
            return null; 
            

            entrega.changeArmazém(novaEntregaDTO.armazém);
            entrega.changeDataEntrega(novaEntregaDTO.GetDia, novaEntregaDTO.GetMes, novaEntregaDTO.GetAno);
            entrega.changeMassa(novaEntregaDTO.GetMassa);
            entrega.changeTempoColocação(novaEntregaDTO.GetTempoColocação);
            entrega.changeTempoRetirada(novaEntregaDTO.GetTempoRetirada);

            await this.gestorPersist.CommitAsync();

            return EntregasMapper.toDTO(entrega);
        }


        public async Task<EntregasDTO> RegistarEntrega(EntregasDTO entregasDTO) {
            Entrega entrega = EntregasMapper.toEntrega(entregasDTO);

            var armazém = await this.armazémRepo.GetByIdAsync(new Identificador(entregasDTO.GetArmazém));
            if(armazém == null)
                return null;

            await _repo.AddAsync(entrega);
            await gestorPersist.CommitAsync();
            

            return EntregasMapper.toDTO(entrega);
        }


/*
            public async Task<EntregasDTO> AddAsync(EntregasDTO dto)
    {
        Entrega entrega = EntregasMapper.toEntrega(dto);
        //var delivery = new Delivery(dto.DeliveryIdentifier,dto.Day, dto.Month, dto.Year, dto.Mass, dto.StoreId,
          // dto.PlacingTime, dto.WithdrawalTime);

        await _repo.AddAsync(entrega);

        await gestorPersist.CommitAsync();

        return  EntregasMapper.toDTO(entrega);
    }
    */

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