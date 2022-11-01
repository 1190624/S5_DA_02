import { ValueObject } from "../../core/domain/ValueObject";
import { Result } from "../../core/logic/Result";
import { Guard } from "../../core/logic/Guard";

interface AutonomiaProps {
    value: number;
}

export class Autonomia extends ValueObject<AutonomiaProps>{


    get value(): number {
        return this.props.value;
    }

    private constructor(props: AutonomiaProps) {
        super(props);
    }

    public static create(autonomia: number): Result<Autonomia> {
        let guardResult = Guard.againstNullOrUndefined(autonomia, '');

        if (guardResult.succeeded) {

            return Result.ok<Autonomia>(new Autonomia({ value: autonomia}))
        }else{
            return Result.fail<Autonomia>(guardResult.message);
        }
    }

    toString() {
        return String(this.props.value)
    }
}