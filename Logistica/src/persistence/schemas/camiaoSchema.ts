import { ICamiaoPersistence } from '../../dataschema/ICamiaoPersistence';
import mongoose from 'mongoose';

const Camiao = new mongoose.Schema(
  {
    /*
        matricula: Matricula
    caracteristica: Caracteristica
    autonomia: Autonomia
    capacidadeTransporte: CapacidadeTransporte
    capacidadeBateria: CapacidadeBateria
    tara: Tara
    tempoCarregamento: TempoCarregamento
    */
    matricula: { 
      type: String,
      unique: true
    },

    caracteristica: {
      type: String,
      required: [true, 'Por favor insira uma caracteristica do camião.'],
      index: true,
    },

    autonomia: {
      type: Number,
      required: [true, 'Por favor insira a autonomia correspondente.'],
      index: true,
    },

    capacidadeTransporte: {
        type: Number,
        required: [true, 'Por favor insira a capacidade de transporte correspondente.'],
        index: true,
      },

      capacidadeBateria: {
        type: Number,
        required: [true, 'Por favor insira a capacidade de bateria correspondente.'],
        index: true,
      },

      tara: {
        type: Number,
        required: [true, 'Por favor insira a tara correspondente.'],
        index: true,
      },

      tempoCarregamento: {
        type: Number,
        required: [true, 'Por favor insira o tempo de carregamento do camião.'],
        index: true,
      },
  },
  { timestamps: true },
);

export default mongoose.model<ICamiaoPersistence & mongoose.Document>('Camiao', Camiao);
