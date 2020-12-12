import { Doctor } from './Doctor';

export class Patient {
    /**
     *
     */
    constructor() {}

    
    id: string
    name: string
    cpf: string
    birthDate: Date
    doctorId: string
    doctor: Doctor
}
