<template>
  <div class="calculateYourRoute">
    <h1>Ho Ho Ho!</h1>
    <h2>Alles wegen dieses betrunkenen Elfleins!</h2>
    <div class="form-container">
      <form @submit.prevent="callMS">
        <div class="form-row">
          <label for="route-input">Gib die geflogene Route bitte hier ein</label>
          <input v-model="routeText" type=text id="route-input" />
        </div>
        <div class="form-row">
          <button type="submit">Und jetzt berechne ich die Route</button>
        </div>
      </form>
    </div>
    <div class="here-be-the-result">
      <ResultVisualizer v-if="hasResult" v-bind="result" />
    </div>
  </div>
</template>

<script>
import ResultVisualizer from "./ResultVisualizer.vue";

export default {
  name: 'HelloWorld',
  components: {ResultVisualizer},
  data() {
    return {
      result: null,
      routeText: "",
      loading: false
    }
  },
  computed: {
    hasResult() {
      return this.result !== null;
    }
  },
  methods: {
    async callMS() {
      this.loading = true;

      try {
        const result = await fetch("http://localhost:1337/GetRoutefromString?route=" + encodeURIComponent(this.routeText));
        const visitedHomes = await result.json();
        if(visitedHomes) {
          this.result = visitedHomes
          this.loading = false;
        }
      } catch(err) {
        console.error("Something went wrong!");
        console.error(err)
      }
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.calculateYourRoute {
  height: 50vh;
  width: 100%;
  display: flex;
  flex-direction: column;
}
.form-container {
  margin:auto;
  /* border: 1px solid black; */
  border-radius: 8px;
  width: 95%;
  padding:2rem;
  background: repeating-linear-gradient(45deg, #ff0000, #ff0000 20px, #00ff00 20px, #00ff00 40px);
}
@media screen and (min-width:640px) {
  .form-container {
    width: 75%;
  }
}
@media screen and (min-width:1024px) {
  .form-container {
    width: 55%;
  }}
@media screen and (min-width:1280px) {
  .form-container {
    width: 45%;
  }}
.form-container>form {
  border-radius: 10px;
  background: white;
}
.form-row {
  padding: 0.5rem 1rem;
}
.form-row>label {
  margin:auto;
  box-sizing: border-box;
  padding: 0.25rem;
  display: block;
  width:100%;
}
.form-row>input {
  margin:auto;
  box-sizing: border-box;
  display: block;
  padding: 0.5rem 0.25rem;
  width: 100%;
}
.here-be-the-result {
  min-height:1.2rem;
}
</style>
