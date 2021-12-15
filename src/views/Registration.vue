<template>
  <div v-if="registration">
    <form class="position-absolute top-50 start-50 translate-middle">
      <div class="row">
        <div class="form-floating">
          <input type="text" v-model="firstName" class="form-control" placeholder=" " />
          <label>Ім'я</label>
          <div class="invalid-feedback">
            Помилка! Пусте поле паролю!
          </div>
        </div>
      </div>
      <div class="row mt-3">
        <div class="form-floating">
          <input type="text" v-model="lastName" class="form-control" placeholder=" " />
          <label>Прізвище</label>
          <div class="invalid-feedback">
            Помилка! Пусте поле паролю!
          </div>
        </div>
      </div>
      <div class="row mt-3">
        <div class="form-floating">
          <input type="text" v-model="parentName" class="form-control" placeholder=" " />
          <label>По-батькові</label>
          <div class="invalid-feedback">
            Помилка! Пусте поле паролю!
          </div>
        </div>
      </div>
      <div class="input-group mt-3">
        <label class="form-check-label me-1">Тип паспорта:</label>
        <div v-for="pasType in pasTypes" v-bind:key="pasType.id">
          <div class="form-check form-check-inline">
            <input class="form-check-input" type="radio" v-model="chosenPassType" :value="pasType.id">
            <label class="form-check-label" :for="pasType.id">{{pasType.text}}</label>
          </div>
        </div>
      </div>
      <div v-if="chosenPassType === 'pasType-Id'">
        <div class="row mt-3">
          <div class="form-floating">
            <input type="text"  v-model="pasNumber" class="form-control" placeholder=" " />
            <label>Номер документа</label>
            <div class="invalid-feedback">
              Помилка! Пусте поле паролю!
            </div>
          </div>
        </div>
      </div>
      <div v-else>
        <div class="input-group mt-3">
          <span class="input-group-text">Серія</span>
          <input class="form-control" v-model="pasSeriaB" style="max-width: 50px">
          <span class="input-group-text">Номер</span>
          <input class="form-control" v-model="pasNumberB">
        </div>
      </div>
      <div class="row mt-3">
        <div class="form-floating">
          <input type="email" v-model="email" class="form-control" placeholder=" " />
          <label>Електронний адрес</label>
          <div class="invalid-feedback">
            Помилка! Пусте поле паролю!
          </div>
        </div>
      </div>
      <div class="row mt-3 text-start">
        <div class="col-auto">
          <label class="form-check-label me-1">Роль:</label>
        </div>
        <div class="col">
          <div class="row" v-for="userType in roles" v-bind:key="userType.id">
            <div class="form-check">
              <input class="form-check-input" type="radio" v-model="chosenRole" :value="userType.id">
              <label class="form-check-label" :for="userType.id">{{userType.value}}</label>
            </div>
          </div>
        </div>
      </div>
      <div v-if="chosenRole === 'registrar'">
        <div class="form-floating">
          <input v-model="address" class="form-control" placeholder=" " />
          <label>Державний орган</label>
          <div class="invalid-feedback">
            Помилка! Пусте поле паролю!
          </div>
        </div>
      </div>
      <div class="row mt-3">
        <button class="w-100 btn btn-outline-dark" @click="regIn" type="button">Подати заявку на реєстрацію</button>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  name: "registration",
  data() {
    return {
      registration: true,
      chosenPassType: 'pasType-Id', chosenRole: 'user',
      firstName: "", lastName: "", parentName: "",
      email: "", pasNumber: "", pasSeriaB: "", pasNumberB: "",
    }
  },
  methods: {
    regIn() {
      this.registration = false;
    }
  },
  created() {
    this.roles = [ {id: 'user', value: 'Користувач'},
                  {id: 'registrar', value: 'Реєстратор'},
                  {id: 'admin', value: 'Адміністратор'} ]
    this.pasTypes = [ {id: 'pasType-Id', text: 'ID-картка'},
                      {id: 'pasType-Book', text: 'Книжечка'} ]
  }
};
</script>