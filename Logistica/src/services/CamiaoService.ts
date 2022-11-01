import { Service, Inject } from 'typedi';
import config from "../../config";
import IRoleDTO from '../dto/IRoleDTO';
import { Role } from "../domain/role";
import IRoleRepo from '../services/IRepos/IRoleRepo';
import IRoleService from './IServices/IRoleService';
import { Result } from "../core/logic/Result";
import { RoleMap } from "../mappers/RoleMap";
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
              await this.camiaoRepo.save(camiao);
      
              const camiaoDTOResult = CamiaoMap.toDTO( camiao) as CamiaoDTO;
              return Result.ok<CamiaoDTO>( camiaoDTOResult)
              }
          } catch (e) {
            throw e;
          }
    }



}