import { Router } from 'express';
import { celebrate, Joi } from 'celebrate';

import { Container } from 'typedi'; 

import config from "../../../config";
import ICamiaoController from '../../controllers/IControllers/ICamiaoController';

const route = Router();

export default (app: Router) => {
  app.use('/camiao', route);

  const ctrl = Container.get(config.controllers.role.name) as ICamiaoController;
/*
  route.post('',
    celebrate({
      body: Joi.object({
        matricula: Joi.string().required(),
        caracteristica: Joi.string().required(),
        autonomia: Joi.string().required(),
        capacidadeTransporte: Joi.string().required(),
        capacidadeBateria: Joi.string().required(),
        tara: Joi.string().required(),
        tempoCarregamento: Joi.string().required()
      })
    }),
    (req, res, next) => ctrl.createRole(req, res, next) );
*/

  route.put('',
    celebrate({
      body: Joi.object({
        matricula: Joi.string().required(),
        caracteristica: Joi.string().required(),
        autonomia: Joi.string().required(),
        capacidadeTransporte: Joi.string().required(),
        capacidadeBateria: Joi.string().required(),
        tara: Joi.string().required(),
        tempoCarregamento: Joi.string().required()
      }),
    }),
    (req, res, next) => ctrl.updateCamiao(req, res, next));

/*
    route.get('/feed/:userId',
    celebrate({
        params: Joi.object({
            userId: Joi.string().required(),
        })
    }),
    (req, res, next) => ctrl.feedPosts(req, res, next));*/
};