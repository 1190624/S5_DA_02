export class Rota{
    rotaId: number;
    rotaOrigem: string;
    rotaDestino: string;
    rotaDistancia: number;
    rotaTempo: string;
    rotaGastoEnergetico: number;
    rotaTempoCargaExtra: string;

    constructor(rotaId: number,
        rotaOrigem: string,
        rotaDestino: string,
        rotaDistancia: number,
        rotaTempo: string,
        rotaGastoEnergetico: number,
        rotaTempoCargaExtra: string){
            this.rotaId = identificador;
            this.rotaOrigem = designacao;
            this.rotaDestino = codigoPostal;
            this.rotaDistancia = numeroPorta;
            this.rotaTempo = nomeRua;
            this.rotaGastoEnergetico = localidade;
            this.rotaTempoCargaExtra = pais;
        } 
}