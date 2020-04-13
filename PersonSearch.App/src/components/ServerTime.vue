<template>
    <div>
        <h4 class="bold">Server time is: {{ ServerDateTime }}</h4>
    </div>
</template>

<script>
    import dotnetify from 'dotnetify/vue';

    export default {
        name: "server-time",
        created: function () {
            this.vm = dotnetify.vue.connect("ServerTime", this);
        },
        destroyed: function () {
            this.vm.$destroy();
        },
        props: { },
        data: function () {
            return { ServerDateTime: 'loading...' }
        }
    };
</script>

<style type="text/css">
    .bold {
        font-weight: bold;
    }
</style>

