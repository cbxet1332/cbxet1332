<template>
    <div>
        <table align="center" width="400px">
            <tr>
                <td class="large-bold-text" width="130px">{{ msg }}</td>
                <td class="large-text" width="130px">{{ ServerDate }}</td>
                <td class="large-text" width="140px">{{ ServerTime }}</td>
            </tr>
        </table>
    </div>
</template>

<script>
    export default {
        name: "server-date-time",
        inject: ['connect'],
        created: function () {
            this.vm = this.connect("ServerDateTime", this);
        },
        destroyed: function () {
            this.vm.$destroy();
        },
        props: { 
            msg: String 
        },
        data: function () {
            return { 
                ServerDate: 'loading...',
                ServerTime: 'loading...',
            }
        }
    };
</script>

<style type="text/css">
    .large-text {
        font-size: large;
    }
    .large-bold-text {
        font-size: large;
        font-weight: bold;
    }

</style>

