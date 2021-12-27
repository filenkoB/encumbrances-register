<template>
  <div id="app" >
    <navigation />
    <main class="container" style="margin-top: 80px; margin-bottom: 80px;">
      <router-view />
    </main>
    <footer class="footer p-3 bg-dark">
      <div class="container">
        <span class="text-muted">КПІ, ФПМ, КП-93 Звєрєв, Федорчук, Філенко.</span>
      </div>
    </footer>
  </div>
</template>

<script>
import Navigation from "./components/Navigation.vue";
export default {
  name: "app",
  data(){
    return {
    }
  },
  components: {
    Navigation,
  },
  methods:{
  }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
.footer {
  position: absolute;
  bottom: 0;
  width: 100%;
  text-align: center;
}
</style>
