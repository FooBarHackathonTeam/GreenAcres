<script lang="ts">
    import mapboxgl from "mapbox-gl";
    import { onMount } from "svelte";

    onMount(() => {
        setupMap();
    });

    function setupMap() {
        mapboxgl.accessToken = import.meta.env.VITE_MAPBOX_TOKEN;
        const map = new mapboxgl.Map({
            container: 'map-here'
        });
    }
</script>

<div id="map-here"></div>
