<template>
  <header class="row navbar navbar-expand-md navbar-dark fixed-top bg-dark">
    <div class="col text-start ms-3">
      <div class="btn-group" role="group" aria-label="Basic outlined example"
        v-if="user != null && user.user_status == 'user'">
        <button type="button" class="btn btn-outline-light me-2" v-on:click="my_statements">
          Мої заяви
        </button>
        <button type="button" class="btn btn-outline-light" v-on:click="search">
          Пошук обтяження
        </button>
      </div>
      <div class="btn-group" role="group" aria-label="Basic outlined example"
        v-else-if="user != null && user.user_status == 'registrar'">
        <button type="button" class="btn btn-outline-light me-2" v-on:click="statements">
          Підтвердити заяви
        </button>
        <button type="button" class="btn btn-outline-light me-2" v-on:click="search">
          Пошук обтяження
        </button>
      </div>
      <div class="btn-group" role="group" aria-label="Basic outlined example"
        v-else-if="user != null && user.user_status == 'admin'">
        <button type="button" class="btn btn-outline-light me-2" v-on:click="view_registrars">
          Перелік Реєстраторів
        </button>
      </div>
    </div>
    <div class="col text-end me-3">
      <div class="btn-group" role="group" aria-label="Basic outlined example">
        <button type="button" class="btn btn-outline-light me-2" disabled>
          <i class="fa fa-user-circle-o"></i>
          <span v-if="user != null" class="ms-2">{{ user.login }}</span>
        </button>
        <button type="button" class="btn btn-outline-light me-2" 
          v-on:click="sign_in" v-if="user == null">
          <i class="fa fa-sign-in" ></i> Увійти
        </button>
        <button type="button" class="btn btn-outline-light me-2" 
          v-on:click="sign_out" v-else>
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
  props:["user", "SignOut"],
  methods: {
    async sign_in() {
      this.SignOut();
      this.$router.push({ name: "SignIn"}).catch(() => {});
    },
    async sign_out() {
      this.SignOut();
      this.$router.push({ name: "SignIn" }).catch(() => {});
    },
    async registration(){
      this.SignOut();
      this.$router.push({ name: "Registration" }).catch(() => {});
    },
    async statements() {
      this.$router.push({ name: "Statements", params: {active_user: this.user}}).catch(() => {});
    },
    async search() {
      this.$router.push({ name: "SearchInfo", params: {active_user: this.user}}).catch(() => {});
    },
    async my_statements() {
      this.$router.push({ name: "MyStatements", params: {active_user: this.user}}).catch(() => {});
    },
    async view_registrars() {
      this.$router.push({ name: "ViewRegistrars", params: {active_user: this.user}}).catch(() => {});
    },
  },
};
</script>
