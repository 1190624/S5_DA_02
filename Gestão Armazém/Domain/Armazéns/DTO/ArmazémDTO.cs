using System;
using System.Runtime.Serialization;

namespace DDDSample1.Domain.Armazéns.DTO {
    [DataContract]
    public class ArmazémDTO {
        [DataMember(Name = "Identificador")]
        public String identificador;
        [DataMember(Name = "Designacao")]
        public String designação;
        [DataMember(Name = "CodigoPostal")]
        public String códigoPostal;
        [DataMember(Name = "NumeroPorta")]
        public Int16 númeroPorta;
        [DataMember(Name = "NomeRua")]
        public String nomeRua;
        [DataMember(Name = "Localidade")]
        public String localidade;
        [DataMember(Name = "Pais")]
        public String país;
        [DataMember(Name = "Municipio")]
        public String munícipio;
        [DataMember(Name = "Latitude")]
        public Double latitude;
        [DataMember(Name = "Longitude")]
        public Double longitude;

        public ArmazémDTO(String identificador,
            String designação, 
            String códigoPostal, 
            Int16 númeroPorta, 
            String nomeRua, 
            String localidade,
            String país, 
            String munícipio, 
            Double latitude, 
            Double longitude) {
            this.identificador = identificador;
            this.designação = designação;
            this.códigoPostal = códigoPostal;
            this.númeroPorta = númeroPorta;
            this.nomeRua = nomeRua;
            this.localidade = localidade;
            this.país = país;
            this.munícipio = munícipio;
            this.latitude = latitude;
            this.longitude = longitude;
        }
        
        public String GetIdentificador => identificador;
        public String GetDesignação => designação;
        public String GetCódigoPostal => códigoPostal;
        public Int16 GetNúmeroPorta => númeroPorta;
        public String GetNomeRua => nomeRua;
        public String GetLocalidade => localidade;
        public String GetPaís => país;
        public String GetMunícipio => munícipio;
        public Double GetLatitude => latitude;
        public Double GetLongitude => longitude;
    }
}