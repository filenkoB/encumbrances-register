import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'SignIn',
    component: () => 
      import(/* webpackChunkName: "signin" */ "../views/SignIn.vue"),
  },
  {
    path: "/info",
    name: "Info",
    component: () => 
      import(/* webpackChunkName: "home" */ "../views/Info.vue"),
  },
  {
    path: "/registration",
    name: "Registration",
    component: () => 
      import(/* webpackChunkName: "registration" */ "../views/Registration.vue"),
  },
  {
    path: "/regapplications",
    name: "SystemRegApplications",
    meta: { auth: true },
    component: () => 
      import(/* webpackChunkName: "regapplications" */ "../views/admin/SystemRegApplications.vue"),
  },
  {
    path: "/statements",
    name: "Statements",
    meta: { auth: true },
    component: () =>
      import(/* webpackChunkName: "Statments" */ "../views/registrar/Statements.vue"),
  },
  {
    path: "/createstatment",
    name: "CreateStatment",
    meta: { auth: true },
    component: () =>
      import(/* webpackChunkName: "Statments" */ "../views/CreateStatment.vue"),
  },
  {
    path: "/searchinfo",
    name: "SearchInfo",
    meta: { auth: true },
    component: () =>
      import(/* webpackChunkName: "search info" */ "../views/SearchInfo.vue"),
  },
  {
    path: "/mystatements",
    name: "MyStatements",
    meta: { auth: true },
    component: () =>
      import(/* webpackChunkName: "search info" */ "../views/user/MyStatements.vue"),
  },
  {
    path: "/viewregistrars",
    name: "ViewRegistrars",
    meta: { auth: true },
    component: () =>
      import(/* webpackChunkName: "search info" */ "../views/admin/ViewRegistrars.vue"),
  },
  {
    path: "*",
    redirect: "/info",
  }
]

const router = new VueRouter({
  mode: "hash",
  base: process.env.BASE_URL,
  routes,
})

export default router
