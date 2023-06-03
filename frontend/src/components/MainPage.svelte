<script lang="ts">
    import { trans } from '../text/translations';
    import LoginForm from './LoginForm.svelte';
    import RegisterForm from './RegisterForm.svelte';
    import LanguageSwitch from "./LanguageSwitch.svelte";

    let currentForm: 'login' | 'register' = 'register';
</script>

<main class="flex flex-col space-y-10 md:flex-row md:space-x-10 justify-center mt-20">
    <div>
        <div class="flex items-center space-x-2">
            <img src="/logo.svg" alt="logo">
            <h1 class="font-bold text-3xl">GREENAcres</h1>
        </div>
        <p class="mt-4 text-xl max-w-sm">{$trans.mainPage.description}</p>
    </div>
    {#if currentForm == 'register' }
        <RegisterForm on:switch={() => currentForm = 'login'}/>
    {:else}
        <LoginForm on:switch={() => currentForm = 'register'}/>
    {/if}

</main>
<LanguageSwitch />
