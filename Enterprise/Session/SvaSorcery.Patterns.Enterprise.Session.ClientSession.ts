interface SessionState {
    contractId: number;
    recognizedAt: Date;
}

class SessionService {
    protected _storage: Storage;
    protected _key: string;

    constructor(key: string, storage: Storage = sessionStorage) {
        this._storage = storage;
        this._key = key;
    }

    public clear = (): void =>
        this._storage.clear();

    public set = <T>(value: T): void =>
        this._storage.setItem(this._key, JSON.stringify(value));

    public get = <T>(): T =>
        JSON.parse(this._storage.getItem(this._key)) as T;
}

class HttpClient {
    protected _baseUrl: string;

    constructor(baseUrl: string) {
        this._baseUrl = baseUrl;
    }

    public get = (action: string, successListener, failureListener = null) =>
        this.requst('get', action, successListener, null, failureListener);

    public post = (action: string, form: FormData, successListener, failureListener = null) =>
        this.requst('post', action, form, successListener, failureListener);

    protected requst(method: 'get' | 'post', action: string, body: FormData, successListener, failureListener) {
        const request = new XMLHttpRequest();
        request.onload = successListener;
        request.onerror = failureListener;
        request.open(method, `${this._baseUrl}/${action}`, true);
        request.send(body);
    }
}

class ClientSessionApp {
    protected _revenueRecognitionsClient: HttpClient;
    protected _sessionService: SessionService;

    constructor() {
        const frontControllerBaseUrl = 'http://localhost:50658';
        const key = 'revenuerecognitions';
        const url = `${frontControllerBaseUrl}/${key}`;
        this._revenueRecognitionsClient = new HttpClient(url);
        this._sessionService = new SessionService(key);
    }

    public createRecognitions(contractId: number, recognizedAt: Date, amountDollars: number): void {
        this._sessionService.set<SessionState>({ contractId, recognizedAt });

        const formData: FormData = new FormData();
        formData.set('contractId', contractId.toString());
        formData.set('recognizedAt', recognizedAt.toDateString());
        formData.set('money.amount', amountDollars.toString());
        formData.set('money.currency', 'USD');

        this._revenueRecognitionsClient.post('recognitions', formData,
            (success) => console.log(success.code),
            (error) => console.warn(error.code),
        );
    }

    public getRecognitions(): void {
        const param = this._sessionService.get<SessionState>();

        this._revenueRecognitionsClient.get(`recognitions?contractId=${param.contractId}&recognizedAt=${param.recognizedAt}`,
            (success) => console.log(success.code),
            (error) => console.warn(error.code),
        );
    }
}
