<template>
    <div>
        <h4 class="bold">{{ msg }}</h4>
        <table align="center" width="475px">
            <thead>
                <tr>
                    <th align="right" width="50px">Id</th>
                    <th align="left" width="275px">Person</th>
                    <th align="left" width="150px"><em>Group</em></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="data in Data" :key="data.Index">
                    <td align="right">{{ data.Id }}</td>
                    <td align="left">{{ data.Person }}</td>
                    <td align="left"><em>{{ data.Group }}</em></td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import dotnetify from 'dotnetify/vue';

    export default {
        name: "random-data",
        created: function () {
            this.vm = dotnetify.vue.connect("RandomData", this);
        },
        destroyed: function () {
            this.vm.$destroy();
        },
        props: { 
            msg: String 
        },
        data() {
            return {
                Data: []
            }
        }
    };
</script>

<style type="text/css">
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

