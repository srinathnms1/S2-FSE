import { SwaggerRequester, IRequest, IOperation, settings } from 'src/api-client/booking/api-common';
import { handler } from './http-handler';

export default class BookingRestRequester extends SwaggerRequester {
    async handler(
        request: IRequest & GApiCommon.MergeToRequest,
        input: Record<string, any>,
        operation: IOperation
    ) {
        return handler(request, input, operation, 'booking');
    }
}

const bookingRequester = new BookingRestRequester();
settings.getRequester = () => bookingRequester;
