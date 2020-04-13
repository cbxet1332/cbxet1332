<template>
    <div id="person-search-content">
        <p>Person Search Bar Here</p>
    </div>
</template>

<script>
    import dotnetify from 'dotnetify/vue';

    export default {
        name: "person-search-bar",
        created: function () {
            this.vm = dotnetify.vue.connect("PersonSearchBar", this);
        },
        destroyed: function () {
            this.vm.$destroy();
        },
        props: { }
    };
</script>

<style type="text/css">
    #person-search-content {
        margin-top: 2px;
        margin-left: 2px;
        margin-right: 2px;
        text-align: left;
    }
    .bold {
        font-weight: bold;
    }
</style>

