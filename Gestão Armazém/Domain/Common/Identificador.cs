using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Common {
    public class Identificador : EntityId {
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