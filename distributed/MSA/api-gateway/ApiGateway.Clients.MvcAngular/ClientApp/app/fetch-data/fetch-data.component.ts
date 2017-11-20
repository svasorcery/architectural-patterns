import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'fetch-data',
    template: `
        <h2>Sample Values</h2>
        <router-outlet></router-outlet>
    `
})

export class FetchDataComponent implements OnInit {
    constructor() { }

    ngOnInit() { }
}