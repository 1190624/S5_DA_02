import { ValueObject } from "../../core/domain/ValueObject";
import { Result } from "../../core/logic/Result";
import { Guard } from "../../core/logic/Guard";

interface TempoCarregamentoProps {
    value: number;
}

export class TempoCarregamento extends ValueObject<TempoCarregamentoProps>{


    get value(): number {
        return this.props.value;
    }

    private constructor(props: TempoCarregamentoProps) {
        super(props);
    }

    public static create(text: number): Result<TempoCarregamento> {
        let guardResult = Guard.againstNullOrUndefined(text, 'text');

        if (guardResult.succeeded) {

            return Result.ok<TempoCarregamento>(new TempoCarregamento({ value: text }))
        }else{
            return Result.fail<TempoCarregamento>(guardResult.message);
        }
    }

    toString() {
        return String(this.props.value)
    }
}