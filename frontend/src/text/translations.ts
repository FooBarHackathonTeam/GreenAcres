import { get, writable } from "svelte/store";
import { mainPageTranslations } from "./mainPageTranslations";
import {Lang, lang} from "./lang";

const allTrans = {mainPage: mainPageTranslations};
export const trans = writable(getCurrentTranslations('en'));

type TranslationObject = {
    pl?: string,
    en?: string
};

lang.subscribe(val => {
    trans.set(getCurrentTranslations(val));
});

function getCurrentTranslations(currentLang: Lang) {
    const result = {};
    for (const key in allTrans) {
        result[key] = {};
        for (const innerKey in allTrans[key]) {
            result[key][innerKey] = allTrans[key][innerKey][currentLang];
        }
    }
    return result;
}