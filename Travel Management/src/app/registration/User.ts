export class User {
    public Name: string;
    public Contact: string;
    username?: string;
    password?: string;
}

export enum UserType {
    Customer,
    Employee,
    Admin
}

export enum Brand {
    Ford = 'Ford',
    Tata = 'Tata',
    Mahindra = 'Mahindra',
    Toyota = 'Toyota',
    MaruthiSuzuki = 'MaruthiSuzuki'
}

export enum Model {
    Sedan = 'Sedan',
    Hatchback = 'Hatchback',
    Suv = 'Suv'
}
