<template>
    <div id="persons-content">
        <h1 class="bold">Persons</h1>
        <div id="child-components">
            <scope vm="PersonsScope">
                <table class="no-border" cellspacing="0" cellpadding="0">
                    <tr class="no-border">
                        <td class="no-border"><search-bar placeholder="Start entering a Person or Group to search" /></td>
                    </tr>
                    <tr class="no-border">
                        <td class="no-border"><person-list /></td>
                    </tr>
                    <tr class="no-border">
                        <td class="no-border"><list-pager /></td>
                    </tr>
                </table>
            </scope>
        </div>
    </div>
</template>

<script>
    import dotnetify from 'dotnetify/vue';
    import SearchBar from './SearchBar.vue'
    import PersonList from './PersonList.vue'
    import ListPager from './ListPager.vue'

    export default {
        name: "persons",
        components: { 
            'scope': dotnetify.vue.Scope,
            SearchBar, 
            PersonList,
            ListPager
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
    .no-border {
        border-collapse: collapse;
        border: none;   
    }
</style>

