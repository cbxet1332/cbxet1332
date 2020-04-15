<template>
  <div id="app">
    <div id="main">
        <div id="side">
            <div id="sidebar-top">
                <div id="logo-container">
                    <router-link to="/"><img id="logo" src="./assets/logo.png" /></router-link>
                </div>
                <div id="app-name">
                    <p>PERSON-SEARCH<br />by Simon Edwards</p>
                </div>
            </div>
            <div id="main-menu">
                <hr/>
                <p><strong><u>Menu</u></strong></p>
                <nav>
                    <div class="menulink"><router-link to="/persons">Persons</router-link></div>
                    <div class="menulink"><router-link to="/groups">Groups</router-link></div>
                </nav>
            </div>
            <div id="sidebar-bottom">
                <div id="bottom-menu">
                    <div class="menulink"><router-link to="/test">Wiring Test</router-link></div>
                </div>
                <hr />
                <div id="small-print">
                    <p>
                        <strong>(c) 2020 Simon Edwards</strong><br />
                        All rights reserved. This software and related source code (the software), are provided as-is under the
                        <a class="external-link" href="https://www.gnu.org/licenses/lgpl-3.0.en.html" target="_blank">Lesser GNU Public Licence v3</a> (LGPL3).
                        Save for where explicitly specified otherwise in the LGPL3, or permitted under copyright law,
                        no part of the software may be reproduced, distributed, or transmitted in any form or by any means,
                        including photocopying, recording, or other electronic or mechanical methods, without the prior written
                        permission of the author. For permission requests, email the author at the address below.<br />
                        <a class="external-link" href="mailto:cbxet1332@controlbox.co.uk">cbxet1332@controlbox.co.uk</a><br />
                        <a class="external-link" href="https://github.com/cbxet1332/cbxet1332" target="_blank">github.com/cbxet1332/cbxet1332</a>
                    </p>
                </div>
            </div>
        </div>
        <div id="content-area">
            <section>
                <scope vm="RootScope">
                    <router-view />
                </scope>
            </section>
        </div>
    </div>
  </div>
</template>

<script>
    import dotnetify from 'dotnetify/vue';

    export default {
        name: 'App',
        components: {
            'scope': dotnetify.vue.Scope
        }
    }
</script>

<style>
    #app {
      font-family: Avenir, Helvetica, Arial, sans-serif;
      -webkit-font-smoothing: antialiased;
      -moz-osx-font-smoothing: grayscale;
      text-align: center;
      color: #2c3e50;
    }
    #main {
        display: flex;
        min-height: calc(100vh - 20px);
    }
    #side {
        text-align: left;
        width: 200px;
        background-color: slategrey;
        color: white;
        padding-top: 15px;
        padding-bottom: 10px;
        position: relative;
        min-height: calc(100vh - 40px);
        max-height: calc(100vh - 40px);
    }
    #logo-container {
        text-align: center;
        width: 200px;
    }
    #logo {
        text-align: center;
        width: 100px;
    }
    #app-name {
        text-align: center;
        font-size: x-small
    }
    #main-menu {
        text-align: center;
        font-size: medium;
    }
    #bottom-menu {
        text-align: center;
    }
    #content-area {
        flex-grow: 1;
    }
    #sidebar-bottom {
        position: absolute; bottom: 0;
    }
    #small-print {
        font-size: xx-small;
        text-align: left;
        margin-left: 5px;
        margin-right: 4px;
    }
    .menulink {
        margin-top: 5px;
        margin-bottom: 5px;
    }
    .menulink a,
    .menulink a:visited
    {
        color: white;
        text-decoration: none;
    }
    .menulink a:hover {
        color: blue;
        font-weight: bold;
        text-decoration: underline;
    }
    .external-link,
    .external-link:visited {
        color: cyan;
    }
    .external-link:hover {
        color: blue;
    }
    #small-print .external-link {
        text-decoration: underline;
    }
</style>
