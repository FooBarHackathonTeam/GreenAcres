import type { PlantName } from "./Plant"

export type Entry = {
    id: string,
    plantName: PlantName | string;
    geoJSON: string
};
