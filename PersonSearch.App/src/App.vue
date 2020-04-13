<template>
  <div id="app">
    <div id="main">
        <div id="side">
            <div id="sidebar-top">
                <div id="logo-container">
                    <img id="logo" src="./assets/logo.png" />
                </div>
                <div id="app-name">
                    <p>PERSON-SEARCH<br />by Simon Edwards</p>
                </div>
            </div>
            <div id="main-menu">
                <hr/>
                <p><strong><u>Menu</u></strong></p>
                <nav>
                    <router-link to="/persons">Persons</router-link><br/><br/>
                    <router-link to="/groups">Groups</router-link><br/><br/>
                </nav>
            </div>
            <div id="sidebar-bottom">
                <div id="bottom-menu">
                    <router-link to="/test">Load Wiring Test Page</router-link><br />
                </div>
                <hr />
                <div id="small-print">
                    <p>
                        <strong>(c) 2020 Simon Edwards</strong><br />
                        All rights reserved. This software and related source code (the software), are provided as-is under the LGNU3 Licence.
                        Save for where explicitly specified otherwise in the LGNU3 Licence, No part of the software may be reproduced,
                        distributed, or transmitted in any form or by any means, including photocopying, recording, or other electronic
                        or mechanical methods, without the prior written permission of the author, except uses permitted by copyright law.
                        For permission requests, email the author at the address below.<br />
                        <a href="mailto:cbxet1332@controlbox.co.uk">cbxet1332@controlbox.co.uk</a><br />
                        <a href="https://github.com/cbxet1332/cbxet1332">github.com/cbxet1332/cbxet1332</a>
                    </p>
                </div>
            </div>
        </div>
        <div id="content-area">
            <section>
                <router-view />
            </section>
        </div>
    </div>
  </div>
</template>

<script>

export default {
  name: 'App',
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
</style>
