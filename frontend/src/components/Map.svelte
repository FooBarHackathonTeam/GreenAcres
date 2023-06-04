<script lang="ts">
    import mapboxgl, { type MapboxGeoJSONFeature } from "mapbox-gl";
    import { onMount } from "svelte";
    import MapboxDraw from '@mapbox/mapbox-gl-draw';
    import type { Entry } from "../types/Entry";
    import type { PlantName } from "../types/Plant";
    import PlantPicker from "./PlantPicker.svelte";
    import MapTypePicker from "./MapTypePicker.svelte";
    import EntrySidepanel from "./EntrySidepanel.svelte";
    import turf from '@turf/turf';

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
            const type = e.features[0].geometry.type == 'Point' ? 'point' : 'area';
            const feature = e.features[0];
            const entry: Entry = {
                id: feature.id,
                geoJSONStr: JSON.stringify(feature),
                geoJson: feature,
                plantName: currentPlant,
                type
            };

            const mDiv = document.createElement('div');
            mDiv.style.width = '50px';
            mDiv.style.height = '50px';
            mDiv.style.backgroundColor = 'red';

            if (type == 'point') {
                entry.marker = new mapboxgl.Marker(mDiv).setLngLat(feature.geometry.coordinates);
            } else {
                //@ts-ignore
                entry.marker = new mapboxgl.Marker(mDiv).setLngLat(turf.center(feature).geometry.coordinates);
            }
            entry.marker.addTo(map);

            plantEntries = [...plantEntries, entry];
        });



        map.on('draw.selectionchange', (e) => {
            if (e.features.length == 0) {
                selectedEntry = undefined;
                return;
            }
            selectedEntry = plantEntries.find(x => x.id == e.features[0].id);
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
    let selectedEntry: Entry | undefined = undefined;
</script>

<div id="map-here" class="w-screen h-screen relative">
    <MapTypePicker bind:map={map}/>
</div>
<div class="flex">
    {#if selectedEntry}
        <EntrySidepanel entry={selectedEntry}/>
    {/if}
    <div id="map-here" class="w-screen h-screen"></div>
</div>
<PlantPicker bind:plantType={currentPlant}/>


