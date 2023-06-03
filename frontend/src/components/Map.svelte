<script lang="ts">
    import mapboxgl from "mapbox-gl";
    import { onMount } from "svelte";

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
    }
</script>

<div id="map-here" class="w-screen h-screen"></div>
