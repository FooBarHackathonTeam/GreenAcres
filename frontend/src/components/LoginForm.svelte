<script lang="ts">
    import { createEventDispatcher } from "svelte";
    import { trans } from "../text/translations";
    import { auth } from "../auth";
  import { sendPOSTJSON } from "../requests/authRequests";

    const dispatch = createEventDispatcher();

    let email = "";
    let password = "";

    async function handleSubmit() {
        try {
            const data = await sendPOSTJSON('https://localhost:8001/api/Login', {email, password});
            auth.set({tokenStr: data.token, tokenDecoded: {name: data.userName, email: data.email}});
        } catch (error) {
            console.error(error)
        }
    }
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
