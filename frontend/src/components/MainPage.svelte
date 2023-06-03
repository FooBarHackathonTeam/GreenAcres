<script lang="ts">
    import { text, trans } from '../text/translations';
    import LoginForm from './LoginForm.svelte';
    import RegisterForm from './RegisterForm.svelte';

    let currentForm: 'login' | 'register' = 'register';
</script>

<main class="flex flex-col space-y-4 md:flex-row md:space-x-6  w-screen h-screen">
    <div>
        <div class="flex items-center space-x-2">
            <img src="/logo.svg" alt="logo">
            <h1 class="font-bold text-3xl">GREENAcre</h1>
        </div>
        <p class="mt-4">{text($trans.mainPage.description)}</p>
    </div>
    {#if currentForm == 'register' }
        <RegisterForm on:switch={() => currentForm = 'login'}/>
    {:else}
        <LoginForm on:switch={() => currentForm = 'register'}/>
    {/if}
</main>
