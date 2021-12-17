<template>
  <form class="row">
    <div class="col"></div>
    <div class="col">
      <div class="row mb-5 text-center" style="margin-top: 100px">
        <label>Державний реєстр обтяженнь рухомого майна</label>
      </div>
      <div class="row">
        <div class="col-2 mt-2">
          <label for="floatingInput">Логін:</label>
        </div>
        <div class="col-10">
          <input type="text" :class="{'is-invalid': isInvalidLogin}" v-model="login" class="form-control" id="floatingInput" />
          <div class="invalid-feedback">
          Пусте поле логіну!
          </div>
        </div>
      </div>
      <div class="row mt-3">
        <div class="col-2 mt-2">
          <label for="floatingPassword ">Пароль:</label>
        </div>
        <div class="col-10">
          <input type="password" :class="{'is-invalid': isInvalidPassword}" v-model="password" class="form-control" id="floatingPassword"/>
          <div class="invalid-feedback">
            Помилка! Пусте поле паролю!
          </div>
        </div>
      </div>
      <div class="row mt-3">
        <div class="col">
          <button class="w-100 btn btn-primary" @click="signIn" type="button">Увійти</button>
        </div>
        <div class="col">
          <button class="w-100 btn btn-outline-dark" @click="regIn" type="button">Реєстрація</button>
        </div>
      </div>
    </div>
    <div class="col"></div>
  </form>
</template>

<script>
export default {
  name: "sign-in",
  data() {
    return {
      wasClicked: false,
      login: "",
      password: "",
    }
  },
  methods: {
    signIn() {
      this.wasClicked = true;
      console.log("signIn");
      //if (this.isInvalidLogin && this.isInvalidPassword) {
        const res = this.$root.$children[0].sign_in({login: this.login, password: this.password});
        console.log(res);
      //}
    },
    async regIn() {
      this.$router.push({ name: "Registration" }).catch(() => {});
    }
  },
  computed: {
    isInvalidLogin: function() {
      return (this.login === "") && this.wasClicked
    },
    isInvalidPassword: function() {
      return (this.password === "") && this.wasClicked
    }
  }
};
</script>