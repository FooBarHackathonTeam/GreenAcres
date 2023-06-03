<script lang="ts">
    import mapboxgl from "mapbox-gl";
    import { onMount } from "svelte";
    import MapboxDraw from '@mapbox/mapbox-gl-draw';

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
                // When active the map will receive updates to the device's location as it changes. stalking na poziomie
                trackUserLocation: true,
                // Draw an arrow next to the location dot to indicate which direction the device is heading. jak w kazdej nawigacji
                showUserHeading: true
            })
        );

        const draw = new MapboxDraw();
        map.addControl(draw, 'top-left');

        map.on('draw.create', (e) => {
            alert(JSON.stringify(e.features))
        });
    }
</script>

<div id="map-here" class="w-screen h-screen"></div>
