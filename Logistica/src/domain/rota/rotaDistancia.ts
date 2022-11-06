import { ValueObject } from '../../core/domain/ValueObject';
import { Result } from '../../core/logic/Result';

interface RotaDistanciaProps {
  distancia: string;
}

export class RotaDistancia extends ValueObject<RotaDistanciaProps> {
  get distancia(): string {
    return this.props.distancia;
  }

  set distancia(value: string) {
    this.props.distancia = value;
  }

  private constructor(props: RotaDistanciaProps) {
    super(props);
  }

  public static create(text: string): Result<RotaDistancia> {
    const regex = new RegExp(/([1-9][0-9]*)((.|,)([0-9]{2}))?/);
      
    if(regex.test(text)) {
      return Result.ok<RotaDistancia>(new RotaDistancia({distancia: text}));
    }
    return Result.fail("A distância inserida não é valida!");
  }
}
