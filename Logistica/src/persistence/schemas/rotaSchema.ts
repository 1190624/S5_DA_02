import mongoose from 'mongoose';
import { IRotaPersistence } from '../../dataschema/IRotaPersistence';

const RotaSchema = new mongoose.Schema(
  {
    rotaId: {
      type: String,
      unique: true,
    },

    origem: {
      type: String,
      index: true,
    },

    destino: {
      type: String,
      index: true,
    },

    distancia: {
      type: String,
      index: true,
    },

    tempo: {
      type: String,
      index: true,
    },

    gastoEnergetico: {
      type: String,
      index: true,
    },

    tempoCargaExtra: {
      type: String,
      index: true,
    },
  },
  { timestamps: true },
);

export default mongoose.model<IRotaPersistence & mongoose.Document>('Rota', RotaSchema);