import { ValueObject } from '../../core/domain/ValueObject';
import { Result } from '../../core/logic/Result';

interface RotaGastoEnergeticoProps {
  gastoEnergetico: string;
}

export class RotaGastoEnergetico extends ValueObject<RotaGastoEnergeticoProps> {
  get gastoEnergetico(): string {
    return this.props.gastoEnergetico;
  }

  set gastoEnergetico(value: string) {
    this.props.gastoEnergetico = value;
  }

  private constructor(props: RotaGastoEnergeticoProps) {
    super(props);
  }

  public static create(text: string): Result<RotaGastoEnergetico> {

  return Result.ok<RotaGastoEnergetico>(new RotaGastoEnergetico({gastoEnergetico: text}));  
  }
}
