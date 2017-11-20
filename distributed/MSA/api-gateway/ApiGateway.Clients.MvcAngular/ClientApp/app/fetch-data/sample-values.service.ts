import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import "rxjs/Rx";

import { SampleValue } from './sample-values.models';

@Injectable()
export class SampleValuesService {
    private _url: string;

    constructor(
        private _http: Http,
        @Inject('BASE_URL')baseUrl: string
    ) {
        this._url = baseUrl + 'api/samplevalues';
    }

    getList(): Observable<SampleValue[]> {
        return this._http.get(this._url)
            .map((response: any) => response.json() as SampleValue[]);
    }
}
