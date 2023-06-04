<script lang="ts">
    import { plants, type PlantName } from "../types/Plant";
    import {trans} from "../text/translations";

    export let plantType: PlantName | string;
    let displayMenu = false;
    $: currentIcon = plantType in plants ? plants[plantType] : '/logo.svg';

    const plantNames = Object.keys(plants);

    function selectPlant(name: PlantName | string) {
        plantType = name;
        displayMenu = false;
    }

    let newPlantName = '';
    function addPlant() {
        plantType = newPlantName;
        displayMenu = false;
        plants[newPlantName] = '/logo.svg';
        plantNames.push(newPlantName);
        newPlantName = '';
    }
</script>

{#if !displayMenu}
    <button on:click={() => displayMenu = true} class="absolute bottom-3 right-3 rounded shadow flex items-center space-x-2 px-4 py-2 bg-white justify-center" style="min-width: 150px;">
        <img src={currentIcon} alt="current plant">
        {#if plants[plantType] == '/logo.svg'}
             <p>{plantType}</p>
        {:else}
                <p>{$trans.plantsTrans[plantType]}</p>
        {/if}
    </button>
{:else}
    <div class="absolute bottom-3 right-3 rounded shadow bg-white" style="min-width: 150px;">
        <button on:click={() => displayMenu = false} class="mt-2 ml-2">
            <img src="/back.svg" alt="back">
        </button>
        <ul class="mt-6 overflow-y-auto" style="max-height: 70vh">
            {#each plantNames as name}
                {#if plants[name] == '/logo.svg' || name in $trans.plantsTrans}
                    <li>
                        <button on:click={() => selectPlant(name)} class="flex items-center px-4 py-2 space-x-2 justify-center">
                            <img src={plants[name]} alt={name}>
                                {#if plants[name] == '/logo.svg'}
                                    <p>{name}</p>
                                {:else}
                                    <p>{$trans.plantsTrans[name]}</p>
                                {/if}
                        </button>
                    </li>
                {/if}
            {/each}
        </ul>
        <form on:submit|preventDefault={addPlant} >
            <input type="text" placeholder="New type" bind:value={newPlantName} class="px-4 py-2 bg-gray-100">
        </form>
    </div>
{/if}

