using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;
using System;

namespace DDDSample1.Domain.Armazéns {
    [DataContract]
    public class Armazém : Entity<Identificador>, IAggregateRoot {
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
            this.Id = identificador;
            this.designação = designação;
            this.endereço = endereço;
            this.munícipio = munícipio;
            this.coordenadas = coordenadas;
        }

        public Designação Designação => designação;
        public Endereço Endereço => endereço;
        public Endereço GetEndereço() {
            return endereço;
        }
        public Munícipio Munícipio => munícipio;
        public Coordenadas Coordenadas => coordenadas;

        public void changeDesignação(String designação)
        {
            this.designação = new Designação(designação);
        }

        public void changeEndereço(String códigoPostal, Int16 númeroPorta, String nomeRua, String localidade, String país)
        {
            this.endereço = new Endereço(códigoPostal, númeroPorta, nomeRua, localidade, país);
        }

        public void changeMunicípio(String munícipio)
        {
            this.munícipio = new Munícipio(munícipio);
        }

        public void changeCoordenadas(Double latitude, Double longitude)
        {
            this.coordenadas = new Coordenadas(latitude, longitude);
        }
    }
}