<script lang="ts">
    import type { Entry } from "../types/Entry";
    import { plants } from "../types/Plant";

    export let entry: Entry;

    let taskName = '';
    function addTask() {
        entry.tasks.push({
            text: taskName,
            completed: false
        });
    }
</script>

<div class="h-screen bg-white pl-4 pr-16 py-2">
    <div class="flex items-center space-x-2">
        <img src={plants[entry.plantName]} alt={entry.plantName}>
        <h1 class="text-xl font-bold">{entry.plantName}</h1>
    </div>
    {#if entry.plantName == 'cucumber'}
    <p class="mt-4">Some usefull data</p>
    <img src="https://media.tenor.com/x8v1oNUOmg4AAAAd/rickroll-roll.gif" alt="xd">
    {/if}

    <h3 class="text-lg mt-4">Todo</h3>
    <form on:submit|preventDefault={addTask} class="mt-2">
        <input type="text" placeholder="New item" class="px-4 py-2 bg-gray-100 rounded">
    </form>
    <ul class="mt-2">
    {#each entry.tasks.filter(t => !t.completed) as todo}
        <li class="flex items-center space-x-2">
            <input type="checkbox" id={todo.text}>
            <label for={todo.text}>{todo.text}</label>
        </li>
    {/each}
    </ul>

    <h3 class="text-lg mt-4">Completed</h3>
    <ul class="mt-2">
        {#each entry.tasks.filter(t => t.completed) as item}
        <li class="flex items-center space-x-2">
            <p class="font-light">{item.date}</p>
            <p>{item.text}</p>
        </li>
        {/each}
    </ul>
</div>
