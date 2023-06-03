<script lang="ts">
    import mapboxgl from "mapbox-gl";
    import { onMount } from "svelte";
    import MapboxDraw from '@mapbox/mapbox-gl-draw';
    import type { Entry } from "../types/Entry";
    import type { PlantName } from "../types/Plant";
    import PlantPicker from "./PlantPicker.svelte";
    import MapTypePicker from "./MapTypePicker.svelte";

    onMount(() => {
        setupMap();
    });

    let map: mapboxgl.Map;

    function setupMap() {
        mapboxgl.accessToken = import.meta.env.VITE_MAPBOX_TOKEN;
        map = new mapboxgl.Map({
            container: 'map-here',
            style: 'mapbox://styles/mapbox/streets-v12',
            center: [18.6667, 54.35],
            zoom: 13
        });

        map.addControl(
            new mapboxgl.GeolocateControl({
                positionOptions: {
                    enableHighAccuracy: true
                },
                trackUserLocation: true,
                showUserHeading: true
            })
        );
        
        const draw = new MapboxDraw({
            modes: Object.assign(MapboxDraw.modes)
        });
        map.addControl(draw, 'top-left');

        map.on('draw.create', (e) => {
            plantEntries = [...plantEntries, {
                id: e.features[0].id,
                geoJSON: JSON.stringify(e.features[0]),
                plantName: currentPlant
            }];
            alert(JSON.stringify(e.features))
        });

        // MAPA 3D
        /*map.on('style.load', () => {
            map.addSource('mapbox-dem', {
                'type': 'raster-dem',
                'url': 'mapbox://mapbox.mapbox-terrain-dem-v1',
                'tileSize': 512,
                'maxzoom': 14
            });
// add the DEM source as a terrain layer with exaggerated height
            map.setTerrain({ 'source': 'mapbox-dem', 'exaggeration': 5 });
            console.log("miało być 3de");
        });*/
    }

    let currentPlant: PlantName = 'wheat'; 
    let plantEntries: Entry[] = [];
</script>

<div id="map-here" class="w-screen h-screen relative">
    <MapTypePicker bind:map={map}/>
</div>
<PlantPicker bind:plantType={currentPlant}/>


