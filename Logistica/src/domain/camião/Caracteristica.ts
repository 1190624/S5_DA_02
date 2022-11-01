import { ValueObject } from "../../core/domain/ValueObject";
import { Result } from "../../core/logic/Result";
import { Guard } from "../../core/logic/Guard";

interface CaracteristicaProps {
    value: string;
}

export class Caracteristica extends ValueObject<CaracteristicaProps>{


    get value(): string {
        return this.props.value;
    }

    private constructor(props: CaracteristicaProps) {
        super(props);
    }

    public static create(text: string): Result<Caracteristica> {
        let guardResult = Guard.againstNullOrUndefined(text, 'text');

        if (guardResult.succeeded) {

            return Result.ok<Caracteristica>(new Caracteristica({ value: text }))
        }else{
            return Result.fail<Caracteristica>(guardResult.message);
        }
    }

    toString() {
        return String(this.props.value)
    }
}