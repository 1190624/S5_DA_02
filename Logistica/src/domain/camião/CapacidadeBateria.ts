import { ValueObject } from "../../core/domain/ValueObject";
import { Result } from "../../core/logic/Result";
import { Guard } from "../../core/logic/Guard";

interface CapacidadeBateriaProps {
    value: number;
}

export class CapacidadeBateria extends ValueObject<CapacidadeBateriaProps>{


    get value(): number {
        return this.props.value;
    }

    private constructor(props: CapacidadeBateriaProps) {
        super(props);
    }

    public static create(text: number): Result<CapacidadeBateria> {
        let guardResult = Guard.againstNullOrUndefined(text, 'text');

        if (guardResult.succeeded) {

            return Result.ok<CapacidadeBateria>(new CapacidadeBateria({ value: text }))
        }else{
            return Result.fail<CapacidadeBateria>(guardResult.message);
        }
    }

    toString() {
        return String(this.props.value)
    }
}