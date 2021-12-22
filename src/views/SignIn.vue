<template>
  <form class="row" @submit.prevent="signIn">
    <div class="col"></div>
    <div class="col">
      <div class="row mb-5 text-center" style="margin-top: 100px">
      </div>
      <div class="row">
        <div class="col-2 mt-2">
          <label for="floatingInput">Логін:</label>
        </div>
        <div class="col-10">
          <input type="text" :class="{'is-invalid': isInvalidLogin}" v-model="reqBody.login" class="form-control" :disabled="waitingForResponse" />
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
          <input type="password" :class="{'is-invalid': isInvalidPassword}" v-model="reqBody.password" class="form-control" :disabled="waitingForResponse" />
          <div class="invalid-feedback">
            Пусте поле паролю!
          </div>
        </div>
      </div>
      <div v-if="failedAuthorization" class="row mt-3 alert alert-danger fs-7" role="alert">
        Неправильний логін або пароль! Будь ласка, спробуйте ще раз!
      </div>
      <div v-if="failedResponse" class="row mt-3 alert alert-warning fs-7" role="alert">
        Наразі серевер не може обробити ваш запит, будь ласка спробуйте пізніше.
      </div>
      <div class="row mt-3">
        <div v-if="waitingForResponse" class="col">
          <button class="w-100 btn btn-primary" type="button" disabled>
            <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
            Вхід...
          </button>
        </div>
        <div v-else class="col">
          <button class="w-100 btn btn-primary" type="submit">Увійти</button>
        </div>
        <div class="col">
          <button class="w-100 btn btn-outline-dark" @click="regIn" :disabled="waitingForResponse" type="button">Реєстрація</button>
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
      wasClicked: false, waitingForResponse: false,
      failedAuthorization: false, failedResponse: false,
      reqBody: { login: "", password: "" }
    }
  },
  methods: {
    signIn() {
      this.wasClicked = true; this.waitingForResponse = true;
      this.failedAuthorization = false; this.failedResponse = false;
      if (!this.isInvalidLogin && !this.isInvalidPassword) {
        const requestOptions = {
          method: "POST",
          headers: { "Content-type": "application/json" },
          body: JSON.stringify(this.reqBody)
        };
        fetch(process.env.VUE_APP_HEROKU_PATH + "/Auth", requestOptions)
              .then(async res => {
                  if(res.status === 200) {
                    const data = await res.json();
                    window.sessionStorage.setItem('token', data.token);
                    let user_status = "";
                    switch (data.userType) {
                      case 1: user_status = "admin"; break
                      case 2: user_status = "registrar"; break
                      case 3: user_status = "user"; break
                      default: console.log("Who are you?");
                    }
                    window.sessionStorage.setItem('user_status', user_status);
                    this.$root.$children[0].$children[0].user_status = user_status;
                    this.$router.push({ name: "Info" }).catch(() => {});
                  }
                  else if(res.status === 400)  this.failedAuthorization = true;
                  else this.failedResponse = true;
                  this.waitingForResponse = false;
                }
              )
              .catch(error => {
                this.failedResponse = true;
                this.waitingForResponse = false;
                this.errorMessage = error;
                console.error('There was an error!', error);
              });
      }
      else this.waitingForResponse = false;
    },
    async regIn() {
      this.$router.push({ name: "Registration" }).catch(() => {});
    }
  },
  created() {
    const sessionStorage = window.sessionStorage;
    if (sessionStorage.getItem('token')) sessionStorage.removeItem('token');
    if (sessionStorage.getItem('user_status')) sessionStorage.removeItem('user_status');
    this.$root.$children[0].$children[0].user_status = null;
    this.$root.$children[0].$children[0].page = 'signin';
  },
  computed: {
    isInvalidLogin: function() {
      return (this.reqBody.login === "") && this.wasClicked;
    },
    isInvalidPassword: function() {
      return (this.reqBody.password === "") && this.wasClicked;
    }
  }
};
</script>

<style>
  .fs-7 {
    font-size: 12px;
  }
</style>