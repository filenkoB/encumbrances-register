import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'SignIn',
    component: () => 
      import(/* webpackChunkName: "home" */ "../views/SignIn.vue"),
  
  },
  {
    path: "/registration",
    name: "Registration",
    component: () => 
      import(/* webpackChunkName: "registration" */ "../views/Registration.vue"),
  
  },
  {
    path: "/statements",
    name: "Statements",
    component: () =>
      import(/* webpackChunkName: "chats" */ "../views/registrar/Statements.vue"),
  },
  {
    path: "*",
    redirect: "/",
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
