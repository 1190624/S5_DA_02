import { Service, Inject } from 'typedi';
import config from "../../config";
import { Result } from "../core/logic/Result";
import ICamiaoRepo from './IRepos/ICamiaoRepo';
import ICamiaoService from './IServices/ICamiaoService';
import CamiaoDTO from '../dto/CamiaoDTO';
import { CamiaoMapper } from '../mappers/CamiaoMapper';
import { Camiao } from '../domain/camião/Camiao';

@Service()
export default class CamiaoService implements ICamiaoService {
  constructor(
      @Inject(config.repos.camiao.name) private camiaoRepo : ICamiaoRepo
  ) {}

    public async criarCamiao(camiaoDTO : CamiaoDTO) : Promise<Result<CamiaoDTO>> {
      try {
        const result = await Camiao.create(camiaoDTO);

        if (result.isFailure)
          return Result.fail<CamiaoDTO>(result.errorValue());

        
        const camiaoResult = result.getValue();

        await this.camiaoRepo.save(camiaoResult);

        const camiaoDTOResult = CamiaoMapper.toDTO(camiaoResult) as CamiaoDTO;

        return Result.ok<CamiaoDTO>(camiaoDTOResult);
      } catch (exception) {
        throw exception;
      }
    }

    public async updateCamiao(camiaoDTO: CamiaoDTO): Promise<Result<CamiaoDTO>> {
        try {
            const camiao = await this.camiaoRepo.findByDomainMatricula(camiaoDTO.matricula);
      
            if (camiao === null) {
              return Result.fail<CamiaoDTO>("Camião não encontrado.");
            }
            else {
              camiao.matricula.props.value = camiaoDTO.matricula;
              camiao.caracteristica.props.value = camiaoDTO.caracteristica;
              camiao.autonomia.props.value = camiaoDTO.autonomia;
              camiao.capacidadeTransporte.props.value = camiaoDTO.capacidadeTransporte;
              camiao.capacidadeBateria.props.value = camiaoDTO.capacidadeBateria;
              camiao.tara.props.value = camiaoDTO.tara;
              camiao.tempoCarregamento.props.value = camiaoDTO.tempoCarregamento;
        
              await this.camiaoRepo.save(camiao);
      
              const camiaoDTOResult = CamiaoMapper.toDTO( camiao) as CamiaoDTO;
              return Result.ok<CamiaoDTO>( camiaoDTOResult)
              }
          } catch (e) {
            throw e;
          }
    }


    public async getListaCamiao(): Promise<Result<CamiaoDTO[]>> {
      try {
        const listaCamiao = await this.camiaoRepo.findAll();

        if (listaCamiao == null) {
            return Result.fail<CamiaoDTO[]>("Não existem camiões registados.");
        }

        const resultado = listaCamiao.map((listaCamiao) => CamiaoMapper.toDTO(listaCamiao) as CamiaoDTO);
        return Result.ok<CamiaoDTO[]>(resultado);
    } catch(e) {
        throw e;
    }
      
    }



}