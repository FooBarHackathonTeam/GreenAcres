import { writable } from "svelte/store";

export type Lang = 'pl' | 'en';

export const lang = writable<Lang>('pl');
