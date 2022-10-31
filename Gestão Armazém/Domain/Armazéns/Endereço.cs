using System;
using System.Text;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Armazéns {
    public class Endereço : IValueObject {
        private String códigoPostal;
        private Int16 númeroPorta;
        private String nomeRua;
        private String localidade;
        private String país;

        public Endereço(String códigoPostal, Int16 númeroPorta, String nomeRua, String localidade, String país) {
            this.códigoPostal = códigoPostal;
            this.númeroPorta = númeroPorta;
            this.nomeRua = nomeRua;
            this.localidade = localidade;
            this.país = país;
        }

        public String GetCódigoPostal => códigoPostal;
        public Int16 GetNúmeroPorta => númeroPorta;
        public String GetNomeRua => nomeRua;
        public String GetLocalidade => localidade;
        public String GetPaís => país;

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (!(obj is Endereço))
                return false;

            Endereço endereço = (Endereço) obj;

            return this.códigoPostal.Equals(endereço.códigoPostal)
                && this.númeroPorta.Equals(endereço.númeroPorta)
                && this.nomeRua.Equals(endereço.nomeRua)
                && this.localidade.Equals(endereço.localidade)
                && this.país.Equals(endereço.país);
        }

        public override int GetHashCode() {
            return HashCode.Combine(códigoPostal, númeroPorta, nomeRua, localidade, país);
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();

            builder.Append(nomeRua).Append(", ")
                .Append(númeroPorta).Append("\n")
                .Append(códigoPostal).Append(", ")
                .Append(localidade).Append("\n")
                .Append(país);

            return builder.ToString();
        }
    }
}