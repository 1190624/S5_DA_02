import { Request, Response, NextFunction } from 'express';

export default interface ICamiaoController  {
  //createRole(req: Request, res: Response, next: NextFunction);
  updateCamiao(req: Request, res: Response, next: NextFunction);
}