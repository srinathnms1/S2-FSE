import { IRequest, IOperation } from 'src/api-client/auth/api-common';

const BACKEND_URL = 'http://localhost:7000/';

// tslint:disable-next-line: max-line-length
export async function handler(request: IRequest & GApiCommon.MergeToRequest, input: Record<string, any>, operation: IOperation, serviceUrl: string) {
    const url = new URL(BACKEND_URL + serviceUrl + request.url);
    const params = request.query || {};
    Object.keys(params).forEach(key =>
        url.searchParams.append(key, params[key])
    );
    const stored = localStorage.getItem('currentUser') || '{}';
    const claim = JSON.parse(stored);
    const token = claim.token;

    const body = ['GET', 'DELETE'].includes(request.verb)
        ? undefined
        : JSON.stringify(request.body);
    const fetchResp = await fetch(url.href, {
        method: request.verb,
        body,
        headers: {
            'Content-Type': 'application/json',
            Authorization: token ? `Bearer ${token}` : (undefined as any)
        }
    });
    if (fetchResp.status === 204) { return {}; }
    return fetchResp.ok ? fetchResp.json() : null;
}
