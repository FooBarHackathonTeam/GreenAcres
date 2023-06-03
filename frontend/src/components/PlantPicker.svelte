<script lang="ts">
    import { plants, type PlantName } from "../types/Plant";

    export let plantType: PlantName | string;
    let displayMenu = false;
    $: currentIcon = plantType in plants ? plants[plantType] : '/icon.svg';

    const plantNames = Object.keys(plants);

    function selectPlant(name: PlantName | string) {
        plantType = name;
        displayMenu = false;
    }
</script>

{#if !displayMenu}
    <button on:click={() => displayMenu = true} class="absolute bottom-3 right-3 rounded shadow flex items-center space-x-2 px-4 py-2 bg-white justify-center" style="min-width: 150px;">
        <img src={currentIcon} alt="current plant">
        <p>{plantType}</p>
    </button>
{:else}
    <div class="absolute bottom-3 right-3 rounded shadow bg-white overflow-y-auto" style="max-height: 70vh; min-width: 150px;">
        <button on:click={() => displayMenu = false} class="mt-2 ml-2">
            <img src="/back.svg" alt="back">
        </button>
        <ul class="mt-6">
            {#each plantNames as name}
                <li>
                    <button on:click={() => selectPlant(name)} class="flex items-center px-4 py-2 space-x-2 justify-center">
                        <img src={plants[name]} alt={name}>
                        <p>{name}</p>
                    </button>
                </li>
            {/each}
        </ul>
    </div>
{/if}

