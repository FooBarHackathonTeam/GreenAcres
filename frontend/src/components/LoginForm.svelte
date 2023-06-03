<script lang="ts">
    import { createEventDispatcher } from "svelte/types/runtime/internal/lifecycle";
    import { text, trans } from "../text/translations";

    const dispatch = createEventDispatcher();

    let email = "";
    let password = "";

    function handleSubmit(e: Event) {}
</script>

<form on:submit|preventDefault={handleSubmit}>
    <label for="email">{text($trans.mainPage.email)}</label>
    <input type="email" id="email" bind:value={email} required>
    <label for="password">{text($trans.mainPage.password)}</label>
    <input type="password" id="password" bind:value={password} required>
    <button type="submit">{text($trans.mainPage.loginAction)}</button>
    <p>
        {text($trans.mainPage.notAnAccount)}
        <button on:click={() => dispatch('switch')}>
            {text($trans.mainPage.switchToRegister)}
        </button>
    </p>
</form>
