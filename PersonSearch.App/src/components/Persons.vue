<template>
    <div id="persons-content">
        <h1 class="bold">Persons</h1>
        <div id="child-components">
            <scope vm="PersonsScope">
                <search-bar placeholder="Enter part of Person or Group to search for"/>
                <person-list />
            </scope>
        </div>
    </div>
</template>

<script>
    import dotnetify from 'dotnetify/vue';
    import SearchBar from './SearchBar.vue'
    import PersonList from './PersonList.vue'

    export default {
        name: "persons",
        //created: function () {
        //    this.vm = dotnetify.vue.connect("Persons", this);
        //},
        //destroyed: function () {
        //    this.vm.$destroy();
        //},
        components: { 
            'scope': dotnetify.vue.Scope,
            SearchBar, 
            PersonList 
        },
        props: { }
    };
</script>

<style type="text/css">
    #persons-content {
        margin-top: 10px;
        margin-left: 20px;
        margin-right: 15px;
        text-align: left;
    }
    .bold {
        font-weight: bold;
    }
</style>

