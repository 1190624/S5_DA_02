using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Armazéns {
    public class Coordenadas : IValueObject {
        private Double latitude;
        private Double longitude;

        public Coordenadas(Double latitude, Double longitude) {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public Double GetLatitude => latitude;
        public Double GetLongitude => longitude;

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (!(obj is Coordenadas))
                return false;

            Coordenadas coordenada = (Coordenadas) obj;

            return this.latitude.Equals(coordenada.latitude) && this.longitude.Equals(coordenada.longitude);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.latitude, this.longitude);
        }
    }
}