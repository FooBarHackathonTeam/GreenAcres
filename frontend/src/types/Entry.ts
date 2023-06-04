import type mapboxgl from "mapbox-gl";
import type { PlantName } from "./Plant"
import type { Task } from "./Task";

export type Entry = {
    id: string,
    idDB: number,
    plantName: PlantName | string;
    geoJSONStr: string,
    geoJson: GeoJSON.GeoJSON,
    type: 'area' | 'point',
    marker?: mapboxgl.Marker,
    tasks: Task[]
};
