import { Result } from "../../core/logic/Result";
import CamiaoDTO from "../../dto/CamiaoDTO";

export default interface ICamiaoService  {
  //createRole(roleDTO: ICamiaoDTO): Promise<Result<ICamiaoDTO>>;
  updateCamiao(camiaoDTO: CamiaoDTO): Promise<Result<CamiaoDTO>>;
  getListaCamiao(): Promise<Result<CamiaoDTO[]>>;
}