using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Entregas {
    public class TempoColocação : IValueObject {

// em minutos
    private Double tempoColocação;

    public TempoColocação(Double tempoColocação){
        this.tempoColocação = tempoColocação;
    }

    public Double GetTempoColocação => tempoColocação;
    
    public override bool Equals(object obj){
        if (ReferenceEquals(null, obj))
                return false;
            if (!(obj is TempoColocação))
                return false;

        TempoColocação tempoColocação = (TempoColocação) obj;

        return this.tempoColocação.Equals(tempoColocação.tempoColocação);
    }

    public override int GetHashCode() {
        return tempoColocação.GetHashCode();
    }

    public override string ToString() {
        return tempoColocação.ToString();
    }

    }
}