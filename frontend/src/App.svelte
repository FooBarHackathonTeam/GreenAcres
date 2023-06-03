<script lang="ts">
    import { auth } from "./auth";
    import MainPage from "./components/MainPage.svelte";
    import Map from "./components/Map.svelte";
</script>

 {#if $auth}
     <Map />
 {:else}
     <MainPage />
 {/if}
<!--<Map />-->
