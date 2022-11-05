using System;
using System.Runtime.Serialization;
using DDDSample1.Domain.Armazéns;

namespace DDDSample1.Domain.Entregas.DTO {
    [DataContract]
    public class EntregasDTO{
        [DataMember(Name = "Identificador")]
        public String identificador;

        [DataMember(Name = "Armazém")]
        public Armazém armazém;

        [DataMember(Name = "Dia")]
        public String dia;

        [DataMember(Name = "Mes")]
        public String mes;

        [DataMember(Name = "Ano")]
        public String ano;

        [DataMember(Name = "Massa")]
        public Double massa;

        [DataMember(Name = "Tempo Colocação")]
        public Double tempoColocação;

        [DataMember(Name = "Tempo Retirada")]
        public Double tempoRetirada;

        public EntregasDTO(String identificador,
            Armazém armazém,
            String dia,
            String mes,
            String ano,
            Double massa,
            Double tempoColocação,
            Double tempoRetirada){
            this.identificador = identificador;
            this.armazém = armazém;
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
            this.massa = massa;
            this.tempoColocação = tempoColocação;
            this.tempoRetirada = tempoRetirada;
        }

        public String GetIdentificador => identificador;
        public Armazém GetArmazém => armazém;
        public String GetDia => dia;
        public String GetMes => mes;
        public String GetAno => ano;
        public Double GetMassa => massa;
        public Double GetTempoColocação => tempoColocação;
        public Double GetTempoRetirada => tempoRetirada;
        
    }

}