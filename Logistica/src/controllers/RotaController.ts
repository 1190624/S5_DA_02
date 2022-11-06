import { Inject, Service } from 'typedi';
import IRotaController from './IControllers/IRotaController';
import config from '../../config';
import IRotaService from '../services/IServices/IRotaService';
import { NextFunction, Request, Response } from 'express';
import { Result } from '../core/logic/Result';
import IRotaDTO from '../dto/IRotaDTO';

@Service()
export default class RotaController implements IRotaController {
    constructor(@Inject(config.services.rota.name) private rotaServiceInstance: IRotaService) {}
  
    public async createRota(req: Request, res: Response, next: NextFunction) {

      try {
        const rotaOrError = (await this.rotaServiceInstance.createRota(req.body as IRotaDTO)) as Result<IRotaDTO>;
        
        if (rotaOrError.isFailure) {
          return res.status(402).send();
        }
        
  
        const rotaDTO = rotaOrError.getValue();
        return res.json(rotaDTO).status(201);
      } catch (e) {
        return next(e);
      }
    }
}