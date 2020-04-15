<template>
        <div id="test-content">
            <h2 class="bold">Welcome to the Vue/Dotnetify/EF wiring test page</h2>
            <div>
                <p class="indent">
                    The purpose of this page is to diagnose wiring and configuration issues using a simple example component. <br />
                    The page should be showing dynamically updating content pushed from the ViewModel without full page refreshes or postbacks. <br />
                    If everything is wired up and configured correctly, you should see 2 items of random data from the database which change on 3 and 5
                    second intervals, the server time should be updating, and button clicks should update the counter in real-time.
                </p>
                <random-data class="spaced" msg="Random Data:" />
                <server-date-time class="spaced" msg="Server Time"/>
                <div class="spaced">
                    <button-test />
                    <button-test-counter />
                </div>
                <div id="info">
                    <p class="indent-left">
                        As well as proving that Vue and Dotnetify are correctly configured and wired up, and that we have database access through Entity Framework,
                        if this page is functioning as descibed, it also proves the following...<br />
                        <ul>
                            <li>Reponsive UI - data is being constantly updated while buttons and links remain active.</li>
                            <li>
                                The database context and repository pattern chosen is thread-safe...
                                <ul>
                                    <li class="level-2">Timers excute concurrently every 15 seconds.</li>
                                    <li class="level-2">Background data fetches excute within their own context.</li>
                                    <li class="level-2">Background fetches happen simultaneously.</li>
                                </ul>
                            </li>
                            <li>
                                'Components' and Composite Views are supported...<br />
                                <ul>
                                    <li class="level-2">Random data, server time, and button are all seperate 'Components'.</li>
                                    <li class="level-2">These 'Components' have their own view templates and view models.</li>
                                    <li class="level-2">Parent-child VM 'scoping' effectively allows one VM to talk to another.</li>
                                </ul>
                            </li>
                        </ul>
                    </p>
                </div>
            </div>
        </div>
</template>

<script>
    import RandomData from './RandomData.vue'
    import ServerDateTime from './ServerDateTime.vue'
    import ButtonTest from './ButtonTest.vue'
    import ButtonTestCounter from './ButtonTestCounter.vue'

    export default {
        name: "wiring-test",
        components: {
            RandomData, 
            ServerDateTime, 
            ButtonTest,
            ButtonTestCounter
        },
        props: { }
    };
</script>

<style type="text/css">
    .spaced {
        margin-top: 15px;
        margin-bottom: 25px;
    }
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
    #info ul .level-2
    {
        font-size: small;
    }
</style>

