import { IAddressDto } from "./IAddressDto";

export interface IContactDto {
    id : number,
    nif: string,
    name: string,
    middleName: string,
    surname1: string,
    surname2: string,
    birth: object,
    gender: string,
    maritalStatus: string,
    phone: string,
    email: string,
    addresses: Array<IAddressDto>
}