import { writable } from "svelte/store";

export type JWTToken = {
    name: string
};

type AuthStoreValue = {
    tokenStr: string,
    tokenDecoded: JWTToken
};

export const auth = writable<AuthStoreValue | undefined>(undefined);
