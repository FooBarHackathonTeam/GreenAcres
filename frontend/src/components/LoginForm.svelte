<script lang="ts">
    import { createEventDispatcher } from "svelte";
    import { trans } from "../text/translations";

    const dispatch = createEventDispatcher();

    let email = "";
    let password = "";

    function handleSubmit(e: Event) {}
</script>

<form on:submit|preventDefault={handleSubmit} class="user-form">
    <label for="email">{$trans.mainPage.email}</label>
    <input type="email" id="email" bind:value={email} required>
    <label for="password">{$trans.mainPage.password}</label>
    <input type="password" id="password" bind:value={password} required>
    <button type="submit">{$trans.mainPage.loginAction}</button>
    <p class="switch-text">
        {$trans.mainPage.notAnAccount}
        <button on:click={() => dispatch('switch')} class="switch-btn">
            {$trans.mainPage.switchToRegister}
        </button>
    </p>
</form>
