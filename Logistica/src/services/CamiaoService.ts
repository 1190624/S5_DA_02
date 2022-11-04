import { Service, Inject } from 'typedi';
import config from "../../config";
import { Result } from "../core/logic/Result";
import ICamiaoRepo from './IRepos/ICamiaoRepo';
import ICamiaoService from './IServices/ICamiaoService';
import CamiaoDTO from '../dto/CamiaoDTO';
import { CamiaoMap } from '../mappers/CamiaoMap';

@Service()
export default class CamiaoService implements ICamiaoService {
  constructor(
      @Inject(config.repos.camiao.matricula) private camiaoRepo : ICamiaoRepo
  ) {}

    public async updateCamiao(camiaoDTO: CamiaoDTO): Promise<Result<CamiaoDTO>> {
        try {
            const camiao = await this.camiaoRepo.findByDomainMatricula(camiaoDTO.matricula);
      
            if (camiao === null) {
              return Result.fail<CamiaoDTO>("Camião não encontrado.");
            }
            else {
              camiao.matricula.props.value = camiaoDTO.matricula;
              // TODO: acrescentar os atibutos
              await this.camiaoRepo.save(camiao);
      
              const camiaoDTOResult = CamiaoMap.toDTO( camiao) as CamiaoDTO;
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

        const resultado = listaCamiao.map((listaCamiao) => CamiaoMap.toDTO(listaCamiao) as CamiaoDTO);
        return Result.ok<CamiaoDTO[]>(resultado);
    } catch(e) {
        throw e;
    }
      
    }



}