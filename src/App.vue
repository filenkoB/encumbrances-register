<template>
  <div id="app" >
    <navigation :user="user" :SignOut="sign_out"/>
    <main class="container" style="margin-top: 80px; margin-bottom: 80px;">
      <router-view />
    </main>
    <footer class="footer p-3 bg-dark">
      <div class="container">
        <span class="text-muted">Directed by Zverev Kostya. Email: zverevfpm@gmail.com</span>
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
      user: null
    }
  },
  components: {
    Navigation,
  },
  methods:{
    sign_in(item){
      const users = [
        {
          login: "u1",
          password: "u",
          user_status: "user"
        },
        {
          login: "u2",
          password: "u",
          user_status: "user"
        },
        {
          login: "r1",
          password: "r",
          user_status: "registrar"
        },
        {
          login: "r2",
          password: "r",
          user_status: "registrar"
        },
        {
          login: "a1",
          password: "a",
          user_status: "admin"
        },
        {
          login: "a2",
          password: "a",
          user_status: "admin"
        }
      ];
      this.user = users.filter(el=>(el.login == item.login && el.password == item.password));
      if(this.user.length == 0) this.user = null;
      else this.user = this.user[0];
      return this.user;
    },
    sign_out(){
      this.user = null;
    }
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
