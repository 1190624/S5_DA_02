import { AggregateRoot } from "../../core/domain/AggregateRoot";
import { UniqueEntityID } from "../../core/domain/UniqueEntityID";
import { Result } from "../../core/logic/Result";
import CamiaoDTO from "../../dto/CamiaoDTO";
import { Autonomia } from "./Autonomia";
import { CapacidadeBateria } from "./CapacidadeBateria";
import { CapacidadeTransporte } from "./CapacidadeTransporte";
import { Caracteristica } from "./Caracteristica";
import { Matricula } from "./Matricula";
import { Tara } from "./Tara";
import { TempoCarregamento } from "./TempoCarregamento";


interface CamiaoProps {
    matricula: Matricula
    caracteristica: Caracteristica
    autonomia: Autonomia
    capacidadeTransporte: CapacidadeTransporte
    capacidadeBateria: CapacidadeBateria
    tara: Tara
    tempoCarregamento: TempoCarregamento

}

export class Camiao extends AggregateRoot<CamiaoProps> {
    get id(): UniqueEntityID {
        return this._id;
    }

    get matricula(): Matricula {
        return this.props.matricula;
    }

    get caracteristica(): Caracteristica {
        return this.props.caracteristica;
    }

    get autonomia(): Autonomia {
        return this.props.autonomia;
    }

    get capacidadeTransporte(): CapacidadeTransporte {
        return this.props.capacidadeTransporte;
    }

    get capacidadeBateria(): CapacidadeBateria {
        return this.props.capacidadeBateria;
    }

    get tara(): Tara {
        return this.props.tara;
    }

    get tempoCarregamento(): TempoCarregamento {
        return this.props.tempoCarregamento;
    }


    private constructor(props: CamiaoProps, id?: UniqueEntityID) {
        super(props, id);
    }

    public static create(camiaoDTO: CamiaoDTO | any, id?: UniqueEntityID): Result<Camiao> {
        const matriculaAux = camiaoDTO.matricula;
        const caracteristicaAux = camiaoDTO.caracteristica;
        const autonomiaAux = camiaoDTO.autonomia;
        const capTransAux = camiaoDTO.capacidadeTransporte;
        const capBateriaAux = camiaoDTO.capacidadeBateria;
        const taraAux = camiaoDTO.tara;
        const tempoAux = camiaoDTO.tempoCarregamento;

        const camiao = new Camiao({
            matricula: new Matricula(matriculaAux),
            caracteristica: new Caracteristica(caracteristicaAux),
            autonomia: new Autonomia(autonomiaAux),
            capacidadeTransporte: new CapacidadeTransporte(capTransAux),
            capacidadeBateria: new CapacidadeBateria(capBateriaAux),
            tara: new Tara(taraAux),
            tempoCarregamento: new TempoCarregamento(tempoAux)
        }, id);

        return Result.ok<Camiao>(camiao);

    }
}