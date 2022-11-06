import { ValueObject } from "../../core/domain/ValueObject";
import { Result } from "../../core/logic/Result";

interface TempoCarregamentoProps {
    value: string;
}

export class TempoCarregamento extends ValueObject<TempoCarregamentoProps>{
    get value(): string {
        return this.props.value;
    }

    public constructor(props: TempoCarregamentoProps) {
        super(props);
    }

    public static create(valor: string): Result<TempoCarregamento> {
        const TEMPO_REGEX = /(([0-9]:0[1-9])|([0-9]:[1-5][0-9])|([1-3][0-9]:0[1-9])|([1-3][0-9]:[1-5][0-9]))/g

        if (new RegExp(TEMPO_REGEX).test(valor))
            //throw new BusinessRuleValidationException("Formato inválido do Tempo de Carregamento do Camião Elétrico;<br/>O Tempo de Carregamento deve seguir o seguinte formato \"HH:MM\";<br/>");

        return Result.ok<TempoCarregamento>(new TempoCarregamento({ value: valor }))
    }

    toString() {
        return String(this.props.value)
    }
}