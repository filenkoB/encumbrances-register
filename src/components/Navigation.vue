<template>
  <header class="row navbar navbar-expand-md navbar-dark fixed-top bg-dark">
    <div class="col text-start ms-3">
      <div class="btn-group" role="group" aria-label="Basic outlined example"
        v-if="user_status != undefined && user_status == 'user'">
        <button type="button" class="btn btn-outline-light me-2" v-on:click="my_statements">
          <i class="fa fa-list-alt" aria-hidden="true"></i>
          Мої заяви
        </button>
        <button type="button" class="btn btn-outline-light me-2" v-on:click="create_statement">
          <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
          Створити заяву
        </button>
        <button type="button" class="btn btn-outline-light" v-on:click="search">
          <i class="fa fa-search" aria-hidden="true"></i>
          Пошук обтяження
        </button>
      </div>
      <div class="btn-group" role="group" aria-label="Basic outlined example"
        v-else-if="user_status != undefined && user_status == 'registrar'">
        <button type="button" class="btn btn-outline-light me-2" v-on:click="statements">
          <i class="fa fa-list-alt" aria-hidden="true"></i>
          Переглянути Заяви
        </button>
        <button type="button" class="btn btn-outline-light me-2" v-on:click="create_statement">
          <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
          Створити заяву
        </button>
        <button type="button" class="btn btn-outline-light me-2" v-on:click="search">
          <i class="fa fa-search" aria-hidden="true"></i>
          Пошук обтяження
        </button>
      </div>
      <div class="btn-group" role="group" aria-label="Basic outlined example"
        v-else-if="user_status != undefined && user_status == 'admin'">
        <button type="button" class="btn btn-outline-light me-2" v-on:click="view_registrars">
          <i class="fa fa-list-alt" aria-hidden="true"></i>
          Перелік Реєстраторів
        </button>
        <button type="button" class="btn btn-outline-light me-2" v-on:click="view_sras">
          <i class="fa fa-address-card" aria-hidden="true"></i>
          Заявки на реєстрацію
        </button>
      </div>
    </div>
    <div class="col-auto text-start" style="width: 325px">
      <div class="row">
        <div class="col-2"><img src="../assets/UkrEmblemaW.png" width="45" /></div>
        <div class="col text-center mt-1"><span class="head-text align-middle"> Державний реєстр обтяження рухомого майна</span></div>
      </div>
    </div>
    <div class="col text-end me-3">
      <div class="btn-group" role="group" aria-label="Basic outlined example">
        <button type="button" class="btn btn-outline-light me-2" disabled>
          <i class="fa fa-user-circle-o"></i>
          <span v-if="user_status != undefined && user_status=='user'" class="ms-2">Користувач</span>
          <span v-if="user_status != undefined && user_status=='registrar'" class="ms-2">Реєстратор</span>
          <span v-if="user_status != undefined && user_status=='admin'" class="ms-2">Адміністратор</span>
        </button>
        <button type="button" class="btn btn-outline-light me-2" 
          v-on:click="info" :disabled="!user_status">
          <i class="fa fa-info" aria-hidden="true"></i>
          Інформаційна
        </button>
        <button type="button" class="btn btn-outline-light me-2" 
          v-on:click="sign_in" v-if="user_status == undefined">
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
    create_statement(){
      this.$router.push({ name: "CreateStatment"}).catch(() => {});
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
    view_sras() {
      this.$router.push({ name: "SystemRegApplications"}).catch(() => {});
    },
  },
};
</script>
<style>
 .head-text {
   font-size: 14pt;
   color: white;
 }
</style>
