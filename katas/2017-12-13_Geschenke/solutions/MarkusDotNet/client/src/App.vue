<template>
  <main id="app">
    <img alt="Der Weihnachtsmann" class="the-logo" src="https://upload.wikimedia.org/wikipedia/commons/c/cd/212-Santa-Claus-1.svg">
    <CalculateYourRoute />
  </main>
</template>

<script>
import CalculateYourRoute from './components/CalculateYourRoute.vue'

export default {
  name: 'App',
  components: {
    CalculateYourRoute
  }
}
</script>

<style>
.the-logo {
  max-height:120px;
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 35px;
  height:85vh;
}
</style>
