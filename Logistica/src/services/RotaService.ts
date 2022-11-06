import { Inject, Service } from 'typedi';
import IRotaService from './IServices/IRotaService';
import config from '../../config';
import IRotaRepo from './IRepos/IRotaRepo';
import IRotaDTO from '../dto/IRotaDTO';
import { Result } from '../core/logic/Result';
import { Rota } from '../domain/rota/rota';
import { RotaMap } from '../mappers/RotaMap';

@Service()
export default class RotaService implements IRotaService {
  constructor(@Inject(config.repos.rota.name) private rotaRepo: IRotaRepo) {}

  async createRota(rotaDTO: IRotaDTO): Promise<Result<IRotaDTO>> {
    try {
      const rotaOrError = await Rota.create(rotaDTO);

      if (rotaOrError.isFailure) {
        return Result.fail<IRotaDTO>(rotaOrError.errorValue());
      }
      const rotaResult = rotaOrError.getValue();

      await this.rotaRepo.save(rotaResult);

      const rotaDTOResult = RotaMap.toDTO(rotaResult) as IRotaDTO;
      return Result.ok<IRotaDTO>(rotaDTOResult);
    } catch (e) {
      throw e;
    }
  }
}