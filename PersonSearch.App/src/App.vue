<template>
  <div id="app">
    <wiring-test greeting="Welcome to the Vue/Dotnetify/EF wiring test page"/>
  </div>
</template>

<script>
    import WiringTest from './components/WiringTest.vue'

export default {
  name: 'App',
  components: {
      WiringTest
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
  margin-top: 40px;
}
</style>
