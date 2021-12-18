<template>
  <header class="row navbar navbar-expand-md navbar-dark fixed-top bg-dark">
    <div class="col text-start ms-3">
      <div class="btn-group" role="group" aria-label="Basic outlined example"
        v-if="user_status != null && user_status == 'user'">
        <button type="button" class="btn btn-outline-light me-2" v-on:click="my_statements">
          Мої заяви
        </button>
        <button type="button" class="btn btn-outline-light" v-on:click="search">
          Пошук обтяження
        </button>
      </div>
      <div class="btn-group" role="group" aria-label="Basic outlined example"
        v-else-if="user_status != null && user_status == 'registrar'">
        <button type="button" class="btn btn-outline-light me-2" v-on:click="statements">
          Підтвердити заяви
        </button>
        <button type="button" class="btn btn-outline-light me-2" v-on:click="search">
          Пошук обтяження
        </button>
      </div>
      <div class="btn-group" role="group" aria-label="Basic outlined example"
        v-else-if="user_status != null && user_status == 'admin'">
        <button type="button" class="btn btn-outline-light me-2" v-on:click="view_registrars">
          Перелік Реєстраторів
        </button>
      </div>
    </div>
    <div class="col text-end me-3">
      <div class="btn-group" role="group" aria-label="Basic outlined example">
        <button type="button" class="btn btn-outline-light me-2" disabled>
          <i class="fa fa-user-circle-o"></i>
          <span v-if="user_status != null" class="ms-2">{{ user_status}}</span>
        </button>
        <button type="button" class="btn btn-outline-light me-2" 
        v-on:click="info" :disabled="!user_status">
          Інформаційна
        </button>
        <button type="button" class="btn btn-outline-light me-2" 
          v-on:click="sign_in" v-if="user_status == null">
          <i class="fa fa-sign-in" ></i> Увійти
        </button>
        <button type="button" class="btn btn-outline-light me-2" 
          v-on:click="sign_in" v-else>
          <i class="fa fa-sign-out" ></i> Вийти
        </button>
        <button type="button" class="btn btn-outline-light" v-on:click="registration">
          <i class="fa fa-rocket"></i> Зареєстуватися
        </button>
      </div>
    </div>
  </header>
</template>

<script>
export default {
  data(){
    return{
      user_status: window.sessionStorage.getItem('user_status')
    }
  },
  methods: {
    info(){
      this.$router.push({ name: "Info"}).catch(() => {});
    },
    sign_in() {
      this.$router.push({ name: "SignIn"}).catch(() => {});
    },
    registration(){
      this.$router.push({ name: "Registration" }).catch(() => {});
    },
    statements() {
      this.$router.push({ name: "Statements"}).catch(() => {});
    },
    search() {
      this.$router.push({ name: "SearchInfo"}).catch(() => {});
    },
    my_statements() {
      this.$router.push({ name: "MyStatements"}).catch(() => {});
    },
    view_registrars() {
      this.$router.push({ name: "ViewRegistrars"}).catch(() => {});
    },
  },
};
</script>
