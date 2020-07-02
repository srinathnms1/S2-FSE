import { SwaggerRequester, IRequest, IOperation, settings } from 'src/api-client/auth/api-common';
import { handler } from './http-handler';

export default class AuthRestRequester extends SwaggerRequester {
    async handler(
        request: IRequest & GApiCommon.MergeToRequest,
        input: Record<string, any>,
        operation: IOperation
    ) {
        return handler(request, input, operation, 'auth');
    }
}

const authRequester = new AuthRestRequester();
settings.getRequester = () => authRequester;
