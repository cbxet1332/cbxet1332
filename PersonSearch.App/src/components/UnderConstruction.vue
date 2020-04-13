<template>
    <div id="uc-content">
        <h1 class="bold">Under Construction</h1>
        <h4 class="bold">We haven't finished building this bit of the app yet, check back later.</h4>
        <br />
        <br />
        <router-link to="/">Home</router-link>
    </div>
</template>

<script>
    export default {
        name: "under-construction",
        props: { }
    };
</script>

<style type="text/css">
    #uc-content {
        margin-top: 100px;
        margin-bottom: 100px;
        text-align: center;
    }
    .bold {
        font-weight: bold;
    }
</style>

