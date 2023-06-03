<script lang="ts">
    import mapboxgl from "mapbox-gl";

    export let map: mapboxgl.Map;
</script>

<div class="flex flex-row md:space-x-2 justify-center absolute bottom-9 left-3 z-10 rounded shadow bg-gray-500 space-x-1 px-2 py-2">
    <button on:click={() => map.setStyle('mapbox://styles/mapbox/satellite-streets-v12')} class="rounded shadow flex items-center space-x-1 px-4 py-2 bg-white">
        <img src="/terrain.svg" alt="satellite view" class="w-10 h-auto">
    </button>
    <button on:click={() => map.setStyle('mapbox://styles/mapbox/streets-v12')} class="rounded shadow flex items-center space-x-1 px-4 py-2 bg-white">
        <img src="/maps.svg" alt="map view" class="w-10 h-auto">
    </button>
</div>