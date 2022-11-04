using System;
using DDDSample1.Domain.Armazéns.Factory;

namespace DDDSample1.Domain.Armazéns.DTO {
    public class ArmazémMapper {

        public static ArmazémDTO toDTO(Armazém armazém) {
            return new ArmazémDTO(armazém.Id.GetValue, 
                armazém.Designação.GetTexto, 
                armazém.Endereço.GetCódigoPostal, 
                armazém.Endereço.GetNúmeroPorta,
                armazém.Endereço.GetNomeRua,
                armazém.Endereço.GetLocalidade,
                armazém.Endereço.GetPaís,
                armazém.Munícipio.GetNome,
                armazém.Coordenadas.GetLatitude,
                armazém.Coordenadas.GetLongitude);
        }

        public static Armazém toArmazém(ArmazémDTO armazémDTO) {
            return new ArmazémFactory().CriarArmazém(armazémDTO.GetIdentificador,
                armazémDTO.GetDesignação, 
                armazémDTO.GetCódigoPostal,
                armazémDTO.GetNúmeroPorta,
                armazémDTO.GetNomeRua,
                armazémDTO.GetLocalidade,
                armazémDTO.GetPaís,
                armazémDTO.GetMunícipio,
                armazémDTO.GetLatitude,
                armazémDTO.GetLongitude);
        }
    }
}