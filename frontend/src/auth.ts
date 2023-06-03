import { writable } from "svelte/store";

export type JWTToken = {
    name: string,
    email: string
};

type AuthStoreValue = {
    tokenStr: string,
    tokenDecoded: JWTToken
};

export const auth = writable<AuthStoreValue | undefined>(undefined);
auth.subscribe(val => {
    if (!val) return;
    localStorage.setItem('token', val.tokenStr);
    localStorage.setItem('name', val.tokenDecoded.name);
    localStorage.setItem('email', val.tokenDecoded.email);
});
