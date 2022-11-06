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
      type: {
        type: String
      }
    },

    caracteristica: {
      type: {
        type: String
      }
    },

    autonomia: {
      type: {
        type: Number
      }
    },

    capacidadeTransporte: {
      type: {
        type: Number
      }
    },

      capacidadeBateria: {
        type: {
          type: Number
        }
      },

      tara: {
        type: {
          type: Number
        }
      },

      tempoCarregamento: {
        type: {
          type: String
        }
      },
  },
  { timestamps: true },
);

export default mongoose.model<ICamiaoPersistence & mongoose.Document>('Camiao', Camiao);
