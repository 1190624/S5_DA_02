using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Entregas {
    public class TempoRetirada : IValueObject {

// em minutos
    private Double tempoRetirada;

    public TempoRetirada(Double tempoRetirada){
        this.tempoRetirada = tempoRetirada;
    }

    public Double GetTempoRetirada => tempoRetirada;
    

    public override bool Equals(object obj){
        if (ReferenceEquals(null, obj))
                return false;
            if (!(obj is TempoRetirada))
                return false;

        TempoRetirada tempoRetirada = (TempoRetirada) obj;

        return this.tempoRetirada.Equals(tempoRetirada.tempoRetirada);
    }

    public override int GetHashCode() {
        return tempoRetirada.GetHashCode();
    }

    public override string ToString() {
        return tempoRetirada.ToString();
    }

    }
}