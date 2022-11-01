import { Service, Inject } from 'typedi';


import { Document, FilterQuery, Model } from 'mongoose';

import ICamiaoRepo from '../services/IRepos/ICamiaoRepo';
import { Camiao } from '../domain/camião/Camiao';
import { Matricula } from '../domain/camião/Matricula';
import { ICamiaoPersistence } from '../dataschema/ICamiaoPersistence';
import { CamiaoMap } from '../mappers/CamiaoMap';

@Service()
export default class camiaoRepo implements ICamiaoRepo {
    private models: any;

    constructor(
        @Inject('postSchema') private postSchema: Model<ICamiaoPersistence & Document>,
    ) { }


    public async findAll(): Promise<Camiao[]> {
        const camiaoRecord = await this.postSchema.find(Camiao);
        return camiaoRecord !== null ? camiaoRecord.map((postRecord) => CamiaoMap.toDomain(postRecord)): null  
    }


    public async findByDomainMatricula(matricula: string | Matricula): Promise<Camiao> {
        const query = { domainId: matricula};
        const camiaoRecord = await this.postSchema.findOne( query as FilterQuery<ICamiaoPersistence & Document> );
    
        if( camiaoRecord != null) {
          return CamiaoMap.toDomain(camiaoRecord);
        }
        else
          return null;
    }


    public async findAllByMatricula(matricula: Matricula): Promise<Camiao[]> {
            const matriculaX = matricula.value;
            const query = { matricula: matriculaX }
            const feedRecord = await this.postSchema.find(query as FilterQuery<ICamiaoPersistence & Document>, null, { sort: { matricula: -1 }})
            return feedRecord !== null ? feedRecord.map((postRecord) => CamiaoMap.toDomain(postRecord)): null  
      
        }

    

    public async exists(t: Camiao): Promise<boolean> {
        const idX = t.matricula instanceof Matricula ? (<Matricula>t.matricula).value : t.matricula;

        const query = { domainId: idX };
        const camiaoDocument = await this.postSchema.findOne(query as FilterQuery<ICamiaoPersistence & Document>);

        return !!camiaoDocument === true;
    }

    private createBaseQuery(): any {
        return {
            where: {},
        }
    }
 
    public async save(c: Camiao): Promise<Camiao> {
        const query = { domainId: c.id.toValue()};

        const camiaoDocument = await this.postSchema.findOne(query);

        try {
            if (camiaoDocument === null) {
                const rawcamiao: any = CamiaoMap.toPersistence(c);
                const camiaoCreated = await this.postSchema.create(rawcamiao);

                return CamiaoMap.toDomain(camiaoCreated);
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