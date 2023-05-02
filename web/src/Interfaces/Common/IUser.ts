import { Dispatch, SetStateAction } from "react";

export interface IUser
{
    userName : string;
    email : string | undefined;
    token : string;
    roles : Array<string> | undefined;
    theme: string | undefined;
}
export interface IGlobalContext {
    User: IUser | undefined;
    setUser : Dispatch<SetStateAction<IUser>>
}