import mongoose from 'mongoose';
import { IRotaPersistence } from '../../dataschema/IRotaPersistence';

const RotaSchema = new mongoose.Schema(
  {
    domainId: {
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
      type: Number,
      index: true,
    },

    tempo: {
      type: String,
      index: true,
    },

    gastoEnergetico: {
      type: Number,
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