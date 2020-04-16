<template>
    <div id="search-content">
        <input type="text"
               class="form-control col-sm-6"
               v-model="SearchText"
               :placeholder="placeholder" />
    </div>
</template>

<script>
    export default {
        name: "search-bar",
        inject: ['connect'],
        created: function () {
            this.vm = this.connect("SearchBar", this, {
                watch: [
                    'SearchText']
                });
        },
        destroyed: function () {
            this.vm.$destroy();
        },
        data() {
            return {
                SearchText: ''
            }
        },
        props: { 
            placeholder: String 
        }
    };
</script>

<style type="text/css">
    .small {
        font-size: small
    }
</style>

