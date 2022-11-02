import { Request, Response, NextFunction } from 'express';
import { Inject, Service } from 'typedi';
import config from "../../config";

import { Result } from "../core/logic/Result";
import ICamiaoController from './IControllers/ICamiaoController';
import { ParamsDictionary } from 'express-serve-static-core';
import { ParsedQs } from 'qs';
import ICamiaoService from '../services/IServices/ICamiaoService';
import CamiaoDTO from '../dto/CamiaoDTO';

@Service()
export default class CamiaoController implements ICamiaoController /* TODO: extends ../core/infra/BaseController */ {
    
    constructor(
        @Inject(config.services.role.name) private camiaoServiceInstance : ICamiaoService
    ) {}
    
    
    
    public async updateCamiao(req: Request<ParamsDictionary, any, any, ParsedQs, Record<string, any>>, res: Response<any, Record<string, any>>, next: NextFunction) {
        try {
            const camiaoOrError = await this.camiaoServiceInstance.updateCamiao(req.body as CamiaoDTO) as Result<CamiaoDTO>;
      
            if (camiaoOrError.isFailure) {
              return res.status(404).send();
            }
      
            const camiaoDTO = camiaoOrError.getValue();
            return res.status(201).json(camiaoDTO);
          }
          catch (e) {
            return next(e);
          }
        };

}