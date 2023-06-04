<script lang="ts">
    import mapboxgl, { type MapboxGeoJSONFeature } from "mapbox-gl";
    import { onMount } from "svelte";
    import MapboxDraw from '@mapbox/mapbox-gl-draw';
    import type { Entry } from "../types/Entry";
    import { plants, type PlantName } from "../types/Plant";
    import PlantPicker from "./PlantPicker.svelte";
    import MapTypePicker from "./MapTypePicker.svelte";
    import EntrySidepanel from "./EntrySidepanel.svelte";
    import center from '@turf/center';
    import UserBar from "./UserBar.svelte";

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
            mDiv.style.padding = '10px'
            mDiv.style.backgroundColor = 'white';
            mDiv.style.borderRadius = '50%';
            mDiv.classList.add('shadow');
            mDiv.innerHTML = `
                <img src="${plants[entry.plantName]}" alt="icon" />
            `;

            if (type == 'point') {
                entry.marker = new mapboxgl.Marker(mDiv).setLngLat(feature.geometry.coordinates);
                entry.marker.addTo(map);
            } else {
                //@ts-ignore
                entry.marker = new mapboxgl.Marker(mDiv).setLngLat(center(feature).geometry.coordinates);
            }

            plantEntries = [...plantEntries, entry];
        });

        map.on('draw.update', (e) => {
            const feature = e.features[0];
            const entry = plantEntries.find(x => x.id == feature.id);
            entry.geoJson = feature;
            entry.geoJSONStr = JSON.stringify(feature);

            if (entry.type == 'point') {
                entry.marker.setLngLat(feature.geometry.coordinates);
            } else {
                //@ts-ignore
                entry.marker.setLngLat(center(feature).geometry.coordinates);
            }

            plantEntries = plantEntries.map(x => x.id == entry.id ? entry : x);
        });

        map.on('draw.delete', (e) => {
            const feature = e.features[0];
            const entry = plantEntries.find(x => x.id == feature.id);

            entry.marker.remove();

            plantEntries = plantEntries.filter(x => x.id != entry.id);
        });

        map.on('draw.selectionchange', (e) => {
            if (e.features.length == 0) {
                selectedEntry = undefined;
                return;
            }
            selectedEntry = plantEntries.find(x => x.id == e.features[0].id);
        });

        // let pressing = false;
        // map.on('mousedown', () => pressing = true);
        // map.on('touchstart', () => pressing = true);
        // map.on('mouseup', () => pressing = false);
        // map.on('touchend', () => pressing = false);
        // map.on('mousemove', () => {
        //     if (pressing == false || selectedEntry == undefined) return;
        //
        //     if (selectedEntry.type == 'point') {
        //         //@ts-ignore
        //         selectedEntry.marker.setLngLat(selectedEntry.geoJson.geometry.coordinates);
        //     } else {}
        // });
        // map.on('touchmove', () => {
        //     if (pressing == false || selectedEntry == undefined) return;
        //
        //     if (selectedEntry.type == 'point') {
        //         //@ts-ignore
        //         selectedEntry.marker.setLngLat(selectedEntry.geoJson.geometry.coordinates);
        //     } else {}
        // });

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

    let currentPlant: PlantName = 'apple'; 
    let plantEntries: Entry[] = [];
    let selectedEntry: Entry | undefined = undefined;
</script>

<div class="flex">
    {#if selectedEntry}
        <EntrySidepanel entry={selectedEntry}/>
    {/if}
    <div id="map-here" class="w-screen h-screen">
        <MapTypePicker bind:map={map}/>
    </div>
</div>
<PlantPicker bind:plantType={currentPlant}/>
<!-- <UserBar /> -->
