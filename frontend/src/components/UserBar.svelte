<script lang="ts">
    import { get } from "svelte/store";
    import { auth } from "../auth";

    function logout() {
        auth.set(undefined);
        localStorage.removeItem('token');
    }
</script>

<div class="absolute bottom-3 right-20 flex items-center space-x-2 bg-white rounded shadow">
    <img src="/user.svg" alt="user">
    <p>{get(auth)}</p>
    <button on:click={logout} class="text-green-500">Logout</button>
</div>
