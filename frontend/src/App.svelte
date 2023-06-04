<script lang="ts">
    import { onMount } from "svelte";
    import { auth } from "./auth";
    import MainPage from "./components/MainPage.svelte";
    import Map from "./components/Map.svelte";

    onMount(() => {
        if (!localStorage.getItem('token')) return;

        const token = localStorage.getItem('token');
        const name = localStorage.getItem('name');
        const email = localStorage.getItem('email');

        auth.set({tokenStr: token, tokenDecoded: { name, email }});
    });
</script>

<!-- {#if $auth} -->
<!--   <Map /> -->
<!-- {:else} -->
<!--   <MainPage /> -->
<!-- {/if} -->
<Map />
