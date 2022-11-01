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
        const matriculaX = Matricula.create(camiaoDTO.matricula);

        if (!!matriculaX === false || matriculaX.getValue.length === 0) {
            return Result.fail<Camiao>('Deve ter uma matrícula')
        }

        const caracteristicaX = Caracteristica.create(camiaoDTO.caracteristica);
        const autonomiaX = Autonomia.create(camiaoDTO.autonomia);
        const capTransX = CapacidadeTransporte.create(camiaoDTO.capacidadeTransporte);
        const capBateriaX = CapacidadeBateria.create(camiaoDTO.capacidadeBateria);
        const taraX = Tara.create(camiaoDTO.tara);
        const tempoX = TempoCarregamento.create(camiaoDTO.tempoCarregamento);

        const c = new Camiao({
            matricula: matriculaX.getValue(),
            caracteristica: caracteristicaX.getValue(),
            autonomia: autonomiaX.getValue(),
            capacidadeTransporte: capTransX.getValue(),
            capacidadeBateria: capBateriaX.getValue(),
            tara: taraX.getValue(),
            tempoCarregamento: tempoX.getValue()
        }, id);

        return Result.ok<Camiao>(c)

    }
}