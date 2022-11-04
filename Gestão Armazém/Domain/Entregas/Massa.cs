using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Entregas {
    public class Massa : IValueObject {

    private Double massa;

    public Massa(Double massa){
        this.massa = massa;
    }

    public Double GetMassa => massa;
    

    public override int GetHashCode() {
        return massa.GetHashCode();
    }

    public override string ToString() {
        return massa.ToString();
    }

    }
}