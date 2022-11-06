import { ValueObject } from '../../core/domain/ValueObject';
import { Guard } from '../../core/logic/Guard';
import { Result } from '../../core/logic/Result';

interface RotaIdProps {
  value: string;
}

export class RotaId extends ValueObject<RotaIdProps> {
  get value(): string {
    return this.props.value;
  }

  set value(value: string) {
    this.props.value = value;
  }

  private constructor(props: RotaIdProps) {
    super(props);
  }

  public static create(id: string): Result<RotaId> {
    const guardResult = Guard.againstNullOrUndefined(id, 'id');

    if (!guardResult.succeeded) {
      return Result.fail<RotaId>(guardResult.message);
    } else {
      return Result.ok<RotaId>(new RotaId({ value: id }));
    }
  }
}
