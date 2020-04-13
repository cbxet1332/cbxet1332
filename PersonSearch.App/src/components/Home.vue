<template>
    <div id="home-content">
        <h1 class="bold">Welcome to the Person-Search App</h1>
        <h3 class="bold">by Simon Edwards</h3>
        <br />
        <br />
        <p><a href="https://github.com/cbxet1332/cbxet1332">Get the source code</a></p>
        <p><a href="https://cbxet1332.atlassian.net/browse/ET">Track the project on Jira</a></p>
    </div>
</template>

<script>
    import dotnetify from 'dotnetify/vue';

    export default dotnetify.vue.component({
        name: "home",
        props: { }
    });
</script>

<style type="text/css">
    #home-content {
        margin-top: 100px;
        margin-bottom: 100px;
        text-align: center;
    }
    .bold {
        font-weight: bold;
    }
</style>

