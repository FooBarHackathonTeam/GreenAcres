import type mapboxgl from "mapbox-gl";
import type { PlantName } from "./Plant"

export type Entry = {
    id: string,
    plantName: PlantName | string;
    geoJSONStr: string,
    geoJson: GeoJSON.GeoJSON,
    type: 'area' | 'point',
    marker?: mapboxgl.Marker
};
