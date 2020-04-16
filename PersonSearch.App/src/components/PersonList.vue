<template>
    <div id="person-list-content">
        <p>Showing {{ PersonCount }} {{ PersonCountSuffix }}</p>
        <table align="left">
            <thead>
                <tr>
                    <th align="right">Id</th>
                    <th align="left">Person</th>
                    <th align="left">Group</th>
                    <th align="left"><em>Date Added</em></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="data in Data" :key="data.Id">
                    <td align="right"><router-link :to="'/person/' + data.Id">{{ data.Id }}</router-link></td>
                    <td align="left">{{ data.Name }}</td>
                    <td align="left">{{ data.Group.Name }}</td>
                    <td align="left" class="read-only"><em>{{ data.CreatedLocal | formatDate }}</em></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    export default {
        name: "person-list",
        inject: ['connect'],
        created: function () {
            this.vm = this.connect("PersonList", this);
        },
        destroyed: function () {
            this.vm.$destroy();
        },
        data() {
            return {
                Data: [],
                PersonCount: 0,
                PersonCountSuffix: 'people'
            }
        },
        props: {}
    };
</script>

<style type="text/css">
    #person-list-content {
        margin-top: 20px;
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
    table .read-only {
        color: darkgrey;
    }
</style>

