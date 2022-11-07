import { ICamiaoPersistence } from '../../dataschema/ICamiaoPersistence';
import mongoose from 'mongoose';

const CamiaoSchema = new mongoose.Schema(
  {
    matricula: { 
        type: String,
        index: true,
    },

    caracteristica: {
        type: String,
        index: true,
    },

    autonomia: {
        type: Number,
        index: true,
    },

    capacidadeTransporte: {
        type: Number,
        index: true,
    },

      capacidadeBateria: {
          type: Number,
          index: true,
      },

      tara: {
          type: Number,
          index: true,

      },

      tempoCarregamento: {
          type: String,
          index: true,
      },
  },
  { timestamps: true },
);

export default mongoose.model<ICamiaoPersistence & mongoose.Document>('Camiao', CamiaoSchema);
