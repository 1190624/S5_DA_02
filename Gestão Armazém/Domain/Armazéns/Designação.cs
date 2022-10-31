using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Armazéns {
    public class Designação : IValueObject {
        private String texto;

        public Designação(String texto) {
            this.texto = texto;
        }

        public String GetTexto => texto;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (!(obj is Designação))
                return false;

            Designação designação = (Designação) obj;

            return texto.Equals(designação.texto);
        }

        public override int GetHashCode()
        {
            return texto.GetHashCode();
        }

        public override string ToString()
        {
            return texto;
        }
    }
}