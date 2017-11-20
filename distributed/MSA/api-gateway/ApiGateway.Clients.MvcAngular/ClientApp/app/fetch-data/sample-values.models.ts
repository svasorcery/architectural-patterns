export class SampleValue {
    id: number;
    code: string;
    name: string;
    description: string;
    created: SampleEvent;
}

export class SampleEvent {
    by: SamplePerson;
    at: Date;
}

export class SamplePerson {
    id: number;
    firstName: string;
    middleName: string;
    lastName: string;
    fullName: string;
}
