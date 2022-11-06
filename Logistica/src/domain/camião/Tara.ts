import { ValueObject } from "../../core/domain/ValueObject";
import { Result } from "../../core/logic/Result";

interface TaraProps {
    value: number;
}

export class Tara extends ValueObject<TaraProps>{
    get value(): number {
        return this.props.value;
    }

    public constructor(props: TaraProps) {
        super(props);
    }

    public static create(valor: number): Result<Tara> {
        const TARA_MIN = 1000;

        if (valor || valor < TARA_MIN)
            //throw new BusinessRuleValidationException("A Tara inserida é inferior ao minímo estabelecido (" + TARA_MIN + "kg);<br/>");

        return Result.ok<Tara>(new Tara({ value: valor }))
    }

    public toString() {
        return String(this.props.value)
    }
}