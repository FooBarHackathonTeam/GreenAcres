<script lang="ts">
    import mapboxgl from "mapbox-gl";
    import { onMount } from "svelte";
    import MapboxDraw from '@mapbox/mapbox-gl-draw';
    import type { Entry } from "../types/Entry";
    import type { PlantName } from "../types/Plant";
    import PlantPicker from "./PlantPicker.svelte";
    import EntrySidepanel from "./EntrySidepanel.svelte";

    onMount(() => {
        setupMap();
    });

    function setupMap() {
        mapboxgl.accessToken = import.meta.env.VITE_MAPBOX_TOKEN;
        const map = new mapboxgl.Map({
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
        });

        map.on('draw.selectionchange', (e) => {
            if (e.features.length == 0) {
                selectedEntry = undefined;
                return;
            }
            selectedEntry = plantEntries.find(x => x.id == e.features[0].id);
        });
    }

    let currentPlant: PlantName = 'wheat'; 
    let plantEntries: Entry[] = [];
    let selectedEntry: Entry | undefined = undefined;
</script>

<div class="flex">
    {#if selectedEntry}
        <EntrySidepanel entry={selectedEntry}/>
    {/if}
    <div id="map-here" class="w-screen h-screen"></div>
</div>
<PlantPicker bind:plantType={currentPlant}/>
