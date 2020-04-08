<template>
    <div>
        <img alt="Vue logo" src="../assets/logo.png">
        <h2 class="bold">{{ greeting }}</h2>
        <div>
            <p>If you can see the server time changing below then things are wired up correctly <br/>and the ViewModel is pushing live updates to the View.</p>
            <h4 class="bold">Server time is: {{ state.ServerTime }}</h4>
        </div>
    </div>
</template>

<script>
    import dotnetify from 'dotnetify/vue';
    export default dotnetify.vue.component({
        name: "wiring-test",
        props: { greeting: String }
    }, "WiringTest");
</script>

<style type="text/css">
    .bold {
        font-weight: bold;
    }
</style>

