import {Injectable, Pipe, PipeTransform} from '@angular/core';

@Pipe({
  name: 'filter',
})

@Injectable()
export class FilterPipe implements PipeTransform {

  transform(items: any[], domainType: string, params: any): any[] {

    if (!items) {
      return [];
    }

    let finalList = JSON.parse(JSON.stringify(items)) as any[];

    if (domainType === "entrega") {

      //TODO
    } else if (domainType === "rota") {

        //TODO
    } else if (domainType === "camiao") {

      if (!params.matricula && !params.caracteristica && !params.autonomia && !params.capacidadeTransporte && !params.capacidadeBateria && !params.tara && !params.tempoCarregamento) {
        return items;
      }

      if (params.matricula) {
        finalList = finalList.filter((singleItem) =>
          singleItem['matricula'].toLowerCase().includes(params.matricula.toLowerCase())
        );
      }

      if (params.caracteristica) {
        finalList = finalList.filter((singleItem) =>
          singleItem['caracteristica'].toString().toLowerCase().includes(params.caracteristica.toLowerCase())
        );
      }

      if (params.autonomia) {
        finalList = finalList.filter((singleItem) =>
          singleItem['autonomia'].toString().toLowerCase().includes(params.autonomia.toLowerCase())
        );
      }

      if (params.capacidadeTransporte) {
        finalList = finalList.filter((singleItem) =>
          singleItem['capacidadeTransporte'].toString().toLowerCase().includes(params.capacidadeTransporte.toLowerCase())
        );
      }

      if (params.capacidadeBateria) {
        finalList = finalList.filter((singleItem) =>
          singleItem['capacidadeBateria'].toString().toLowerCase().includes(params.capacidadeBateria.toLowerCase())
        );
      }

      if (params.tara) {
        finalList = finalList.filter((singleItem) =>
          singleItem['tara'].toString().toLowerCase().includes(params.tara.toLowerCase())
        );
      }
      if (params.tempoCarregamento) {
        finalList = finalList.filter((singleItem) =>
          singleItem['tempoCarregamento'].toString().toLowerCase().includes(params.tempoCarregamento.toLowerCase())
        );
      }
    } else if (domainType === "warehouse") {

      //TODO
    }

    return finalList;
  }
}