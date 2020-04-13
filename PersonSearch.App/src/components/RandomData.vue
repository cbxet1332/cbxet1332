<template>
    <div>
        <h4 class="bold">Random Data:</h4>
        <table align="center" width="400px">
            <thead>
                <tr>
                    <th align="right" width="25px">Id</th>
                    <th align="left" width="250px">Person</th>
                    <th align="left" width="125px"><em>Group</em></th>
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
    export default dotnetify.vue.component({
        name: "random-data",
        data() {
            return {
                Data: []
            }
        },
        props: { }
    }, "RandomData");
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

