<script lang="ts">
    import { createEventDispatcher } from "svelte";
    import { text, trans } from "../text/translations";
    import { auth } from "../auth";

    const dispatch = createEventDispatcher();

    let name = "";
    let email = "";
    let password = "";
    let confirmPassword = "";

    function handleSubmit(e: Event) {
        auth.set({tokenStr: 'xd', tokenDecoded: {name: 'Mikson'}})
    }
</script>

<form on:submit|preventDefault={handleSubmit} class="user-form">
    <label for="name">{text($trans.mainPage.username)}</label>
    <input type="text" id="name" bind:value={name} required>
    <label for="email">{text($trans.mainPage.email)}</label>
    <input type="email" id="email" bind:value={email} required>
    <label for="password">{text($trans.mainPage.password)}</label>
    <input type="password" id="password" bind:value={password} required>
    <label for="confirmPassword">{text($trans.mainPage.confirmPassword)}</label>
    <input type="confirmPassword" id="confirmPassword" bind:value={confirmPassword} required>
    <button type="submit">{text($trans.mainPage.registerAction)}</button>
    <p class="switch-text">
        {text($trans.mainPage.haveAnAccount)}
        <button on:click={() => dispatch('switch')} class="switch-btn">
            {text($trans.mainPage.switchToLogin)}
        </button>
    </p>
</form>
