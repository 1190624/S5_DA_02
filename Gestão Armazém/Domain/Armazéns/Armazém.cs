using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;

namespace DDDSample1.Domain.Armazéns {
    [DataContract]
    public class Armazém : Entity<Identificador>, IAggregateRoot {
        [Key]
        [DataMember(Name = "Identificador")]
        private Identificador identificador;
        [DataMember(Name = "Designação")]
        private Designação designação;
        [DataMember(Name = "Endereço")]
        private Endereço endereço;
        [DataMember(Name = "Munícipio")]
        private Munícipio munícipio;
        [DataMember(Name = "Coordenadas")]
        private Coordenadas coordenadas;

        public Armazém() {}

        public Armazém(Identificador identificador, Designação designação, Endereço endereço, Munícipio munícipio, Coordenadas coordenadas) {
            this.identificador = identificador;
            this.designação = designação;
            this.endereço = endereço;
            this.munícipio = munícipio;
            this.coordenadas = coordenadas;
        }

        public Armazém(Identificador identificador, Designação designação) {
            this.identificador = identificador;
            this.designação = designação;
        }

        public Identificador Identificador => identificador;
        public Designação Designação => designação;
        public Endereço Endereço => endereço;
        public Endereço GetEndereço() {
            return endereço;
        }
        public Munícipio Munícipio => munícipio;
        public Coordenadas Coordenadas => coordenadas;
    }
}