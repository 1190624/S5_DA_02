using System;

namespace DDDSample1.Domain.Armazéns.DTO {
    public class ArmazémDTO {
        private String identificador;
        private String designação;
        private String códigoPostal;
        private Int16 númeroPorta;
        private String nomeRua;
        private String localidade;
        private String país;
        private String munícipio;
        private Double latitude;
        private Double longitude;

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