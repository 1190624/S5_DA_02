import { Mapper } from "../core/infra/Mapper";

import { Document, Model } from 'mongoose';
import { IRolePersistence } from '../dataschema/IRolePersistence';

import { Role } from "../domain/role";

import { UniqueEntityID } from "../core/domain/UniqueEntityID";
import { Camiao } from "../domain/camião/Camiao";
import CamiaoDTO from "../dto/CamiaoDTO";

export class CamiaoMap extends Mapper<Camiao> {
  
  public static toDTO(camiao: Camiao): CamiaoDTO {
    return {
        id: camiao.id.toString(),
        matricula: camiao.matricula.value,
        caracteristica: camiao.caracteristica.value,
        autonomia: camiao.autonomia.value,
        capacidadeTransporte: camiao.capacidadeTransporte.value,
        capacidadeBateria: camiao.capacidadeBateria.value,
        tara: camiao.tara.value,
        tempoCarregamento: camiao.tempoCarregamento.value,
    } as CamiaoDTO;
  }

  public static toDomain (camiao: any | Model<IRolePersistence & Document> ): Camiao {
    const camiaoOrError = Camiao.create(
      camiao,
      new UniqueEntityID(camiao.domainId)
    );

    camiaoOrError.isFailure ? console.log(camiaoOrError.error) : '';

    return camiaoOrError.isSuccess ? camiaoOrError.getValue() : null;
  }

  public static toPersistence (camiao: Camiao): any {
    return {
      domainId: camiao.id.toString(),
      matricula: camiao.matricula,
      caracteristica: camiao.caracteristica,
      autonomia: camiao.autonomia,
      capacidadeTransporte: camiao.capacidadeTransporte,
      capacidadeBateria: camiao.capacidadeBateria,
      tara: camiao.tara,
      tempoCarregamento: camiao.tempoCarregamento,
    }
  }
}