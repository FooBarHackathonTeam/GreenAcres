<script lang="ts">
    import type { Entry } from "../types/Entry";
    import { plants } from "../types/Plant";

    export let entry: Entry;
</script>

<div class="h-screen bg-white pl-4 pr-16 py-2">
    <div class="flex items-center space-x-2">
        <img src={plants[entry.plantName]} alt={entry.plantName}>
        <h1 class="text-xl">{entry.plantName}</h1>
    </div>
    <p class="mt-4">Some usefull data</p>
    <img src="https://media.tenor.com/x8v1oNUOmg4AAAAd/rickroll-roll.gif" alt="xd">
</div>
