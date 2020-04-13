<template>
    <div id="persons-content">
        <h1 class="bold">Persons</h1>
        <div id="search-bar">
            <person-search-bar/>
        </div>
        <div id="persons-list">
            <p>Showing {{ PersonCount }} Persons</p>
            <table align="left">
                <thead>
                    <tr>
                        <th align="right">Id</th>
                        <th align="left">Person</th>
                        <th align="left"><em>Group</em></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="data in Data" :key="data.Id">
                        <td align="right"><router-link :to="'/person/' + data.Id">{{ data.Id }}</router-link></td>
                        <td align="left">{{ data.Forenames }} {{ data.Surname }}</td>
                        <td align="left"><em>{{ data.Group.Name }}</em></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
    import dotnetify from 'dotnetify/vue';
    import PersonSearchBar from './PersonSearchBar.vue'

    export default {
        name: "persons",
        created: function () {
            this.vm = dotnetify.vue.connect("Persons", this);
        },
        destroyed: function () {
            this.vm.$destroy();
        },
        components: { PersonSearchBar },
        data() {
            return {
                Data: [],
                PersonCount: 0
            }
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
    table {
        border-collapse: collapse;
    }
    table td, table th {
        border: 1px solid #888;
        padding: 8px;
    }
    table th {
        background-color: burlywood
    }
</style>

