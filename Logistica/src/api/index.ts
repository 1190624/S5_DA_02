import { Router } from 'express';
import auth from './routes/userRoute';
import user from './routes/userRoute';
import role from './routes/roleRoute';
import rota from './routes/rotaRoute';

export default () => {
	const app = Router();

	auth(app);
	user(app);
	role(app);
	rota(app);
	
	return app
}