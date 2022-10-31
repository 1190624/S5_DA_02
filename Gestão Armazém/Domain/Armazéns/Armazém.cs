using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;

namespace DDDSample1.Domain.Armazéns {
    public class Armazém : Entity<Identificador>, IAggregateRoot {
        private Designação designação;
        private Endereço endereço;
        private Munícipio munícipio;
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
        public Munícipio Munícipio => munícipio;
        public Coordenadas Coordenadas => coordenadas;
    }
}