import { ValueObject } from "../../core/domain/ValueObject";
import { Result } from "../../core/logic/Result";
import { Guard } from "../../core/logic/Guard";

interface CapacidadeTransporteProps {
    value: number;
}

export class CapacidadeTransporte extends ValueObject<CapacidadeTransporteProps>{


    get value(): number {
        return this.props.value;
    }

    private constructor(props: CapacidadeTransporteProps) {
        super(props);
    }

    public static create(text: number): Result<CapacidadeTransporte> {
        let guardResult = Guard.againstNullOrUndefined(text, 'text');

        if (guardResult.succeeded) {

            return Result.ok<CapacidadeTransporte>(new CapacidadeTransporte({ value: text }))
        }else{
            return Result.fail<CapacidadeTransporte>(guardResult.message);
        }
    }

    toString() {
        return String(this.props.value)
    }
}