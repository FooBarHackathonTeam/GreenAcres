<script lang="ts">
  import { createEventDispatcher } from "svelte";
  import { trans } from "../text/translations";
  import { auth } from "../auth";
  import { sendJson } from "../requests/authRequests";

  const dispatch = createEventDispatcher();

  let name = "";
  let email = "";
  let password = "";
  let confirmPassword = "";

  async function handleSubmit() {
    try {
      const data = await sendJson("https://localhost:8001/api/Register", 'POST' ,{
        name,
        email,
        password,
      });
      auth.set({
        tokenStr: data.token,
        tokenDecoded: { name: data.name, email: data.email },
      });
    } catch (error) {
      console.error(error);
    }
  }
</script>

<form on:submit|preventDefault={handleSubmit} class="user-form">
  <label for="name">{$trans.mainPage.username}</label>
  <input type="text" id="name" bind:value={name} required />
  <label for="email">{$trans.mainPage.email}</label>
  <input type="email" id="email" bind:value={email} required />
  <label for="password">{$trans.mainPage.password}</label>
  <input type="password" id="password" bind:value={password} required />
  <label for="confirmPassword">{$trans.mainPage.confirmPassword}</label>
  <input
    type="password"
    id="confirmPassword"
    bind:value={confirmPassword}
    required
  />
  <button type="submit">{$trans.mainPage.registerAction}</button>
  <p class="switch-text">
    {$trans.mainPage.haveAnAccount}
    <button on:click={() => dispatch("switch")} class="switch-btn">
      {$trans.mainPage.switchToLogin}
    </button>
  </p>
</form>
