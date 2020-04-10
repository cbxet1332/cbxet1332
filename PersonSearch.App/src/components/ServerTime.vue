<template>
    <div>
        <h4 class="bold">Server time is: {{ state.ServerDateTime }}</h4>
    </div>
</template>

<script>
    import dotnetify from 'dotnetify/vue';

    export default dotnetify.vue.component({
        name: "server-time",
        props: { }
    }, "ServerTime");
</script>

<style type="text/css">
    .bold {
        font-weight: bold;
    }
</style>

