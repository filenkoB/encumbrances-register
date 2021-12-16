<template>
  <form class="position-absolute top-50 start-50 translate-middle">
    <div class="row">
      <div class="col-auto mt-2 me-3">
        <label for="floatingInput">Логін:</label>
      </div>
      <div class="col-8">
        <input type="text" :class="{'is-invalid': isInvalidLogin}" v-model="login" class="form-control" id="floatingInput" />
        <div class="invalid-feedback">
         Пусте поле логіну!
        </div>
      </div>
    </div>
    <div class="row mt-3">
      <div class="col-auto mt-2">
        <label for="floatingPassword ">Пароль:</label>
      </div>
      <div class="col-8">
        <input type="password" :class="{'is-invalid': isInvalidPassword}" v-model="password" class="form-control" id="floatingPassword"/>
        <div class="invalid-feedback">
          Помилка! Пусте поле паролю!
        </div>
      </div>
    </div>
    <div class="row mt-3">
      <button class="w-100 btn btn-primary" @click="signIn" type="button">Увійти</button>
    </div>
    <div class="row mt-3">
      <button class="w-100 btn btn-outline-dark" @click="regIn" type="button">Реєстрація</button>
    </div>
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

      if (this.isInvalidLogin && this.isInvalidPassword) {
        
        // запит на перевірку логіна та пароля

        // перехід на відповідну сторінку
        
      }
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