<template>
    <div>
        <button class="btn btn-secondary" type="button" @click="onButtonClick">Click me</button>
    </div>
</template>

<script>
    export default {
        name: "button-test",
        inject: ['connect'],
        created: function () {
            this.vm = this.connect("ButtonTestHandler.ButtonTest", this);
        },
        destroyed: function () {
            this.vm.$destroy();
        },
        props: { },
        data: function () {
            return { ClickCount: 0 }
        },
        methods: {
            onButtonClick: function () {
                this.vm.$dispatch({ ButtonClicked: true });
            }
        }
    }
</script>

<style type="text/css">
    .bold {
        font-weight: bold;
    }
</style>

