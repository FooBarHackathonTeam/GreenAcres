import { get, writable } from "svelte/store";
import { mainPageTranslations } from "./mainPageTranslations";
import { lang } from "./lang";

export const trans = writable({
    mainPage: mainPageTranslations
});

type TranslationObject = {
    pl?: string,
    en?: string
};

export function text(obj: TranslationObject): string {
    let currentLang = get(lang);

    if (currentLang in obj)
        return obj[currentLang];
    else {
        for (const key in obj) {
            return obj[key];
        }
    }
}
