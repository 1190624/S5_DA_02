using System;
using System.Runtime.Serialization;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Common {
    [DataContract]
    public class Identificador : EntityId {
        [DataMember(Name = "Value")]
        private String value;

        public Identificador(String value) : base(value) {
            this.value = value;
        }

        public String GetValue => value;

        // TODO: Perguntar ao prof. utilidade do método.
        protected override Object createFromString(String texto) {
            return texto;
        }

        public override String AsString() {
            return (String) base.Value;
        }
    }
}