import { SwaggerRequester, IRequest, IOperation, settings } from 'src/api-client/vehicle/api-common';
import { handler } from './http-handler';

export default class VehicleRestRequester extends SwaggerRequester {
    async handler(
        request: IRequest & GApiCommon.MergeToRequest,
        input: Record<string, any>,
        operation: IOperation
    ) {
        return handler(request, input, operation, 'vehicle');
    }
}

const vehicleRequester = new VehicleRestRequester();
settings.getRequester = () => vehicleRequester;
