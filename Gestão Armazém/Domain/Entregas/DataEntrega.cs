using System;
using System.Text;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Entregas {
    public class DataEntrega : IValueObject {

    private String dia;

    private String mes;

    private String ano;

    public DataEntrega(String dia, String mes, String ano){
        this.dia = dia;
        this.mes = mes;
        this.ano = ano;        
    }

    public String GetDia => dia;
    
    public String GetMes => mes;

    public String GetAno => ano;

    public override bool Equals(object obj){
        if (ReferenceEquals(null, obj))
                return false;
            if (!(obj is DataEntrega))
                return false;
        
        DataEntrega dataEntrega = (DataEntrega) obj;

        return this.dia.Equals(dataEntrega.dia)
            && this.mes.Equals(dataEntrega.mes)
            && this.ano.Equals(dataEntrega.ano);
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(this.dia, this.mes, this.ano);
    } 

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(dia).Append("-")
            .Append(mes).Append("-")
            .Append(ano);


        return builder.ToString();
    }

    }
}