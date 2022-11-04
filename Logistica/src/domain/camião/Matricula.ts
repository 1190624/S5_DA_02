import { ValueObject } from "../../core/domain/ValueObject";
import { Result } from "../../core/logic/Result";

interface MatriculaProps {
    value: string;
  }
  
  export class Matricula extends ValueObject<MatriculaProps> {
    get value (): string {
      return this.props.value;
    }
    
    private constructor (props: MatriculaProps) {
      super(props);
    }
  
    public static create (matricula: string): Result<Matricula> {
      //const guardResult = Guard.againstNullOrUndefined(matricula, 'matricula');
      
      let sampleRegEx: RegExp = /[A-Z]{2}-[0-9]{2}-[0-9]{2}/;
      if (!sampleRegEx.test(matricula)) {
        return Result.fail<Matricula>("A sequência inserida nâo pertence às matriculas portuguesas emitidas pelo IMT (AA-00-AA)");
      } else {
        return Result.ok<Matricula>(new Matricula({ value: matricula })) 
    }
    return null;
  }
}