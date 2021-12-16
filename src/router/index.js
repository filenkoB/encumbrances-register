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
    path: "/searchinfo",
    name: "SearchInfo",
    component: () =>
      import(/* webpackChunkName: "search info" */ "../views/SearchInfo.vue"),
  },
  {
    path: "/mystatements",
    name: "MyStatements",
    component: () =>
      import(/* webpackChunkName: "search info" */ "../views/user/MyStatements.vue"),
  },
  {
    path: "/viewregistrars",
    name: "ViewRegistrars",
    component: () =>
      import(/* webpackChunkName: "search info" */ "../views/admin/ViewRegistrars.vue"),
  },
  {
    path: "*",
    redirect: "/",
  }
]

const router = new VueRouter({
  mode: "hash",
  base: process.env.BASE_URL,
  routes,
})

export default router
