using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Armazéns {
    public class Munícipio : IValueObject {
        private String nome {get;}

        public Munícipio(String nome) {
            this.nome = nome;
        }

        public String GetNome => nome;

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (!(obj is Munícipio))
                return false;

            Munícipio munícipio = (Munícipio) obj;

            return this.nome.Equals(munícipio.nome);
        }
        
        public override int GetHashCode() {
            return nome.GetHashCode();
        }

        public override string ToString() {
            return nome;
        }
    }
}