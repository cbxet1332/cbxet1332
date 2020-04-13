<template>
    <div id="test-content">
        <h2 class="bold">Welcome to the Vue/Dotnetify/EF wiring test page</h2>
        <div>
            <p class="indent">
                The purpose of this page is to diagnose wiring and configuration issues using a simple example component. <br/>
                The page should be showing dynamically updating content pushed from the ViewModel without full page refreshes or postbacks. <br/>
                If everything is wired up and configured correctly, you should see 2 items of random data from the database which change on 3 and 5 
                second intervals, and the server time should be updating in real-time.
            </p>
            <random-data />
            <server-time />
            <p class="indent-left">
                As well as proving that Vue and Dotnetify are correctly configured and wired up, and that we have database access through Entity Framework,
                if this page is functioning as descibed, it also proves the following...<br />
                <ul>
                    <li>The database context and repository pattern chosen is thread-safe, and handling multiple concurrent background requests for data.</li>
                    <li>Composite Views are supported with the random data and the server time being 'components' with their own view templates and view models.</li>
                </ul>
            </p>
        </div>
    </div>
</template>

<script>
    import RandomData from './RandomData.vue'
    import ServerTime from './ServerTime.vue'

    export default {
        name: "wiring-test",
        components: { RandomData, ServerTime },
        props: { }
    };
</script>

<style type="text/css">
    #test-content {
        margin-top: 10px;
    }
    .indent {
        margin-left: 100px;
        margin-right: 100px;
    }
    .indent-left {
        margin-left: 125px;
        margin-right: 125px;
        text-align: left;
    }
    .bold {
        font-weight: bold;
    }
</style>

