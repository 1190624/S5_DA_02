import { Service, Inject } from 'typedi';


import { Document, FilterQuery, Model } from 'mongoose';

import ICamiaoRepo from '../services/IRepos/ICamiaoRepo';
import { Matricula } from '../domain/camião/Matricula';
import { ICamiaoPersistence } from '../dataschema/ICamiaoPersistence';
import { CamiaoMapper } from '../mappers/CamiaoMapper';
import { Camiao } from '../domain/camião/Camiao';

@Service()
export default class camiaoRepo implements ICamiaoRepo {
    private models: any;

    constructor(
        @Inject('camiaoSchema') private camiaoSchema: Model<ICamiaoPersistence & Document>,
    ) { }


    public async findAll(): Promise<Camiao[]> {
        const camiaoRecord = await this.camiaoSchema.find(Camiao);
        return camiaoRecord !== null ? camiaoRecord.map((postRecord) => CamiaoMapper.toDomain(postRecord)): null  
    }


    public async findByDomainMatricula(matricula: string | Matricula): Promise<Camiao> {
        const query = { domainId: matricula};
        const camiaoRecord = await this.camiaoSchema.findOne( query as FilterQuery<ICamiaoPersistence & Document> );
    
        if( camiaoRecord != null) {
          return CamiaoMapper.toDomain(camiaoRecord);
        }
        else
          return null;
    }


    public async exists(t: Camiao): Promise<boolean> {
        const idX = t.matricula instanceof Matricula ? (<Matricula>t.matricula).value : t.matricula;

        const query = { domainId: idX };
        const camiaoDocument = await this.camiaoSchema.findOne(query as FilterQuery<ICamiaoPersistence & Document>);

        return !!camiaoDocument === true;
    }

    private createBaseQuery(): any {
        return {
            where: {},
        }
    }
 
    public async save(c: Camiao): Promise<Camiao> {
        const query = { domainId: c.id.toValue()};

        const camiaoDocument = await this.camiaoSchema.findOne(query);

        try {
            if (camiaoDocument === null) {
                const rawcamiao: any = CamiaoMapper.toPersistence(c);
                const camiaoCreated = await this.camiaoSchema.create(rawcamiao);

                return CamiaoMapper.toDomain(camiaoCreated);
            } else {
                camiaoDocument.matricula = c.matricula.toString();
                camiaoDocument.caracteristica = c.caracteristica.toString();
                camiaoDocument.autonomia = c.autonomia.props.value;
                camiaoDocument.capacidadeTransporte = c.capacidadeTransporte.props.value;
                camiaoDocument.capacidadeBateria= c.capacidadeBateria.props.value;
                camiaoDocument.tara = c.tara.props.value;
                camiaoDocument.tempoCarregamento = c.tempoCarregamento.props.value;
                await camiaoDocument.save();
                return c;
            }
        } catch (err) {
            throw err;
        }
    }
}