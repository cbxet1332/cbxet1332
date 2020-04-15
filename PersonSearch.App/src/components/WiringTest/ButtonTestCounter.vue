<template>
    <div>
        <p>You have clicked <strong>{{ ButtonClickCount }}</strong> times!</p>
    </div>
</template>

<script>
    export default {
        name: "button-test-counter",
        inject: ['connect'],
        created: function () {
            this.vm = this.connect("ButtonTestHandler.ButtonTestCounter", this);
        },
        destroyed: function () {
            this.vm.$destroy();
        },
        props: { },
        data: function () {
            return { ButtonClickCount: 0 }
        }
    }
</script>

<style type="text/css">
    .bold {
        font-weight: bold;
    }
</style>

