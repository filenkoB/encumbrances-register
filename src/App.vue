<template>
  <div id="app">
    <navigation />
    <main class="flex-shrink-0">
      <div class="container">
        <router-view :navigation="this.$root.$children[0].$children[0]" />
      </div>
    </main>
    <footer class="footer mt-auto py-3 bg-dark">
      <span class="text-muted"
        >Directed by Zverev Kostya. Email: zverevfpm@gmail.com</span
      >
    </footer>
  </div>
</template>

<script>
//import { comands_mutate } from "./constants/graphql-mutation";
import Navigation from "./components/Navigation.vue";
export default {
  name: "app",
  components: {
    Navigation,
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
.container {
  height: auto;
  min-height: 531px;
  margin-top: 60px;
}
.footer {
  position: relative;
  margin-bottom: 0px;
}
</style>
