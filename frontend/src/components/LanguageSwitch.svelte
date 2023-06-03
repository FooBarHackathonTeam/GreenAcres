<script lang="ts">
    import { lang } from "../text/lang.ts";
</script>

<div class="flex flex-row md:space-x-2 justify-center absolute top-3 right-3">
    <button on:click={() => lang.set("en")}>
        <img src="/languages/en_ek.svg" alt="United Kingdom flag" class="w-10 h-auto">
    </button>
    <button on:click={() => lang.set("en")}>
    <img src="/languages/en_us.svg" alt="US flag" class="w-10 h-auto">
    </button>
    <button on:click={() => {lang.set("pl"); console.log("dziala")}}>
        <img src="/languages/pl_pl.svg" alt="polish flag" class="w-10 h-auto">
    </button>
</div>