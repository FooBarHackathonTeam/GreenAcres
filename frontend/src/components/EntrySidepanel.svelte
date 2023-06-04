<script lang="ts">
    import { onMount } from "svelte/types/runtime/internal/lifecycle";
    import { auth } from "../auth";
    import { getJsonAuth, sendJsonAuth } from "../requests/authRequests";
    import type { Entry } from "../types/Entry";
    import { plants } from "../types/Plant";

    export let entry: Entry;

    onMount(async () => {
        entry.tasks = await getJsonAuth('https://localhost:8001/api/Task', $auth.tokenStr);
        entry = entry;
    });

    let taskName = '';
    async function addTask() {
        const data = await sendJsonAuth('https://localhost:8001/api/Task', 'POST', $auth.tokenStr, {
            name: taskName,
        });
        entry.tasks = [...entry.tasks, data];
        entry = entry;
        taskName = '';

        // entry.tasks.push({
        //     text: taskName,
        //     completed: false
        // });
        // entry = entry;
    }

    async function removeTask(id: number) {
        const response = await sendJsonAuth('https://localhost:8001/api/Task', 'DELETE', $auth.tokenStr, {
            id,
        });

        entry.tasks = entry.tasks.filter(t => t.id != id);
        entry = entry;
    }

    async function completeTask(id: number) {
        const response = await sendJsonAuth('https://localhost:8001/api/Task', 'PUT', $auth.tokenStr, {
            id,
            completed: true
        });

        entry.tasks.find(t => t.id == id).completed = true;
        entry = entry;
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
            <input type="checkbox" id={todo.text} on:change={() => completeTask(todo.id)}>
            <label for={todo.text}>{todo.text}</label>
            <button on:click={() => removeTask(todo.id)} class="px-4 py-2 font-bold rounded bg-red-500 text-white">x</button>
        </li>
    {/each}
    </ul>

    <h3 class="text-lg mt-4">Completed</h3>
    <ul class="mt-2">
        {#each entry.tasks.filter(t => t.completed) as item}
        <li class="flex items-center space-x-2">
            <p class="font-light">{item.date}</p>
            <p>{item.text}</p>
            <button on:click={() => removeTask(item.id)} class="px-4 py-2 font-bold rounded bg-red-500 text-white">x</button>
        </li>
        {/each}
    </ul>
</div>
