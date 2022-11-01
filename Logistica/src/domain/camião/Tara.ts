import { ValueObject } from "../../core/domain/ValueObject";
import { Result } from "../../core/logic/Result";
import { Guard } from "../../core/logic/Guard";

interface TaraProps {
    value: number;
}

export class Tara extends ValueObject<TaraProps>{


    get value(): number {
        return this.props.value;
    }

    private constructor(props: TaraProps) {
        super(props);
    }

    public static create(text: number): Result<Tara> {
        let guardResult = Guard.againstNullOrUndefined(text, 'text');

        if (guardResult.succeeded) {

            return Result.ok<Tara>(new Tara({ value: text }))
        }else{
            return Result.fail<Tara>(guardResult.message);
        }
    }

    toString() {
        return String(this.props.value)
    }
}