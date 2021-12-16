<template>
  <form v-if="registration" class="position-absolute top-50 start-50 translate-middle">
    <div class="row">
      <div class="form-floating">
        <input type="text" v-model="firstName" pattern="[А-ЯІЇЄ][а-яіїє]+" class="form-control" required placeholder=" " />
        <label>Ім'я</label>
      </div>
    </div>
    <div class="row mt-3">
      <div class="form-floating">
        <input type="text" v-model="lastName" pattern="[А-ЯІЇЄ][а-яіїє]+(-[А-ЯІЇЄ][а-яіїє]+)*" class="form-control" required placeholder=" " />
        <label>Прізвище</label>
      </div>
    </div>
    <div class="row mt-3">
      <div class="form-floating">
        <input type="text" v-model="parentName" pattern="[А-ЯІЇЄ][а-яіїє]+" class="form-control" required placeholder=" " />
        <label>По-батькові</label>
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
          <input type="text"  v-model="pasNumber" required pattern="\d{9}" class="form-control" placeholder=" " />
          <label>Номер документа</label>
        </div>
      </div>
    </div>
    <div v-else>
      <div class="input-group mt-3">
        <span class="input-group-text">Серія</span>
        <input class="form-control" required pattern="[А-ЯІЇЄ][А-ЯІЇЄ]" v-model="pasSeriaB" style="max-width: 55px">
        <span class="input-group-text">Номер</span>
        <input class="form-control" required pattern="\d{6}" v-model="pasNumberB">
      </div>
    </div>
    <div class="row mt-3">
      <div class="form-floating">
        <input type="email" v-model="email" required class="form-control" placeholder=" " />
        <label>Електронний адрес</label>
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
        <input v-model="address" required class="form-control" placeholder=" " />
        <label>Державний орган</label>
      </div>
    </div>
    <div class="row mt-3">
      <button class="w-100 btn btn-outline-dark" @click="regIn" type="submit">Подати заявку на реєстрацію</button>
    </div>
  </form>
  <div v-else>
    <div class="alert alert-success" role="alert">
      <h4 class="alert-heading">Заявка на реєстрацію була успішно відправлена!</h4>
      <p>Заявка на реєстрацію профілю в "Державному реєстрі обтяженнь рухомого майна" була сформована на основі введенних вами даних та успішно відправлена для розгляду адміністраторами системи.
        Очікуйте результати реєстрації найближчим часом.</p>
      <hr>
      <p class="mb-0">Результати реєстації будуть надіслані на вказану вами під час реєстрації електронну адресу.</p>
    </div>
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
      pasNumber: "", pasSeriaB: "", pasNumberB: "",
      email: "", address: ""
    }
  },
  methods: {
    regIn() {
      const inputs = document.getElementsByTagName('input')
      console.log(inputs)
      let valid = true
      for (let input of inputs) {
        valid = valid && input.validity.valid
      }
      if (valid)
        this.registration = false;

        // запит на відправку заявки
        
    }
  },
  created() {
    this.roles = [ {id: 'user', value: 'Користувач'},
                  {id: 'registrar', value: 'Реєстратор'},
                  {id: 'admin', value: 'Адміністратор'}]
    this.pasTypes = [ {id: 'pasType-Id', text: 'ID-картка'},
                      {id: 'pasType-Book', text: 'Зразка 1994р.(Книжка)'}]
  },
  watch: {
    registration: function(reg) {
      if (reg) {
        const forms = document.getElementsByTagName('form')
        console.log(forms[0])
        forms[0].addEventListener('submit', e => e.preventDefault())
      }
    }
  }
};
</script>