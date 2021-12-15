import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: () => 
      import(/* webpackChunkName: "login" */ "../views/Home.vue"),
  
  },
  {
    path: "/statements",
    name: "Statements",
    component: () =>
      import(/* webpackChunkName: "chats" */ "../views/registrar/Statements.vue"),
  },
  {
    path: "/searchinfo",
    name: "SearchInfo",
    component: () =>
      import(/* webpackChunkName: "search info" */ "../views/SearchInfo.vue"),
  },
  {
    path: "*",
    redirect: "home",
  }
]

const router = new VueRouter({
  mode: "hash",
  base: process.env.BASE_URL,
  routes,
})

export default router
