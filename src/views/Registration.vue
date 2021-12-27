<template>
  <form v-if="registration" @submit.prevent="regIn" class="row">
    <div class="col-2"></div>
    <div class="col-8">

    <!-- ПІБ та дата народження -->

      <div class="row">
        <div class="form-floating">
          <input type="text" v-model="lastName" :pattern="patterns.lastName.str" class="form-control" required placeholder=" " />
          <label class="ms-2 vertical-center">Прізвище</label>
        </div>
      </div>
      <div class="row mt-3">
        <div class="form-floating">
          <input type="text" v-model="firstName" :pattern="patterns.names.str" class="form-control" required placeholder=" " />
          <label class="ms-2 vertical-center">Ім'я</label>
        </div>
      </div>
      <div class="row mt-3">
        <div class="form-floating">
          <input type="text" v-model="parentName" :pattern="patterns.names.str" class="form-control" required placeholder=" " />
          <label class="ms-2 vertical-center">По-батькові</label>
        </div>
      </div>
      <div class="row mt-3">
        <div class="form-floating">
          <input type="date"  v-model="birthDate" required :max="maxBirthDate" class="form-control" placeholder=" " />
          <label class="ms-2 vertical-center">Дата народження</label>
        </div>
      </div>

      <!-- Паспортні дані -->

      <div class="p-3 border border-secondary border-2 rounded mt-3">
        <div class="input-group">
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
              <label class="ms-2 vertical-center">Номер документа</label>
            </div>
          </div>
          <div class="row mt-3">
            <div class="col-auto mt-2">
              <label class="ms-2 vertical-center">Орган, що видав документ</label>
            </div>
            <div class="col-auto">
              <select class="form-control" required v-model="pasAgency">
                <option v-for="el in authorityPassport" :key="el.code" :value="el.code">{{el.code}}-{{el.name}}</option>
              </select>
            </div>
          </div>
        </div>
        <div v-else>
          <div class="input-group mt-3">
            <span class="input-group-text">Серія</span>
            <input class="form-control" required pattern="[А-ЯІЇЄ]{2}" v-model="pasSeriaB" style="max-width: 55px">
            <span class="input-group-text">Номер</span>
            <input class="form-control" required pattern="\d{6}" v-model="pasNumberB">
          </div>
          <div class="row mt-3">
            <div class="col-auto mt-2">
              <label class="ms-2 vertical-center">Орган, що видав документ</label>
            </div>
            <div class="col-auto">
              <select class="form-control" required v-model="pasAgencyB">
                <option v-for="el in authorityPassport" :key="el.code" :value="el.code">{{el.name}}</option>
              </select>
            </div>
          </div>
        </div>
        <div class="row mt-3">
          <div class="form-floating">
            <input type="date"  v-model="pasDate" required :min="minPasDate" :max="today" class="form-control" placeholder=" " />
            <label class="ms-2 vertical-center">Дата видачі паспорта</label>
          </div>
        </div>
      </div>
      <div class="row mt-3">
        <div class="form-floating">
          <input type="text"  v-model="idNumber" required :pattern="patterns.idNumber.str" class="form-control" placeholder=" " />
          <label class="ms-2 vertical-center">Номер картки платника податків</label>
        </div>
      </div>

      <!-- інформація про користувача системи -->

      <div class="row mt-3">
        <div class="form-floating">
          <input type="email" v-model="email" required :pattern="patterns.email.str" class="form-control" placeholder=" " />
          <label class="ms-2 vertical-center">Електронна адреса</label>
        </div>
      </div>
      <div class="row mt-3 text-start">
        <div class="col-auto">
          <label class="form-check-label me-1">Роль:</label>
        </div>
        <div class="col">
          <div class="row" v-for="userType in roles" v-bind:key="userType.id">
            <div class="form-check">
              <input class="form-check-input" type="radio" @change="clearRoleData" v-model="chosenRole" :value="userType.id">
              <label class="form-check-label" :for="userType.id">{{userType.value}}</label>
            </div>
          </div>
        </div>
      </div>
      <div v-if="chosenRole === 'user'">
        <div class="form-check mt-3">
          <input class="form-check-input" type="checkbox" v-model="userIsAuthorized">
          <label class="form-check-label">Працюю в уповноваженому органі</label>
        </div>
      </div>
      <div v-if="((chosenRole !== 'user') || userIsAuthorized) || chosenRole === 'registrar' " class="mt-3 p-3 border border-secondary border-2 rounded">
        <label class="mb-3">Державна установа:</label>
        <select class="form-control" v-model="authorityId">
          <option v-for="el in authority" :key="el.id" :value="el.id">{{el.name}}</option>
        </select>
      </div>
      <div v-if="failedRegistration" class="row mt-3 alert alert-danger fs-7" role="alert">
        {{message}}
      </div>
      <div class="row mt-3">
        <button class="w-100 btn btn-outline-dark" type="submit">Подати заявку на реєстрацію</button>
      </div>
    </div>
    <div class="col">
    </div>
  </form>

  <!-- Сповіщення про здійснення реєстрації -->
  <div v-else>
    <div class="alert alert-success text-center" role="alert">
      <h4 class="alert-heading ">Заявка на реєстрацію була успішно відправлена!</h4>
      <p>Заявка на реєстрацію профілю в "Державному реєстрі обтяженнь рухомого майна" була сформована на основі введенних вами даних та успішно відправлена для розгляду адміністраторами системи.
        Очікуйте результати реєстрації найближчим часом.</p>
      <hr>
      <p class="mb-0">Результати реєстації будуть надіслані на вказану вами під час реєстрації електронну адресу.</p>
    </div>
  </div>
</template>

<script>
import {validation} from "../data";
import {Main, GetRequestOptions} from "../connect_to_server"
export default {
  name: "registration",
  data() {
    return {
      main: null,
      registration_serve: null,
      authorityPassport: null,
      authority: null,
      authorityId: null,
      registration: true,
      chosenPassType: 'pasType-Id', chosenRole: 'user',
      firstName: "", lastName: "", parentName: "", birthDate: "",
      pasNumber: "", pasNumberB: "", pasSeriaB: "", 
      email: "", agency: "", idNumber: "",
      pasAgency: "", pasAgencyB: "", pasDate: "", userIsAuthorized: false,
      failedRegistration: false, message: ""
    }
  },
  methods: {
    async regIn() {
      const inputs = document.getElementsByTagName('input');
      let valid = true;
      for (let input of inputs) {
        if (input.validity.valid === false) {
          valid = false; break;
        }
      }

      if (valid) {
        let passport = null;
        if(this.chosenPassType == 'pasType-Id'){
          passport = {
              passportNumber: this.pasNumber,
              SerialNumber: "",
              AuthorityId: this.pasAgency,
              date: this.pasDate
          }
        }
        else{
          passport = {
              passportNumber: this.pasNumberB,
              SerialNumber: this.pasSeriaB,
              AuthorityId: this.pasAgencyB,
              date: this.pasDate
          }
        } 
        
        // fetch запит на відправку заявки
        const final_element = {
            firstName: this.firstName,
            lastName: this.lastName,
            patronymic: this.parentName,
            birthDate: this.birthDate,
            email: this.email,
            passportInfo: passport,
            taxpayerAccountCardNumber: this.idNumber,
            taxpayerACNAbsenceReason: "",
            authorityId: this.authorityId
        }
        if(this.chosenRole == 'user') {
          fetch(process.env.VUE_APP_HEROKU_PATH + "/Registration/User/Statement", GetRequestOptions("POST", final_element))
                    .then(async res => await this.checkRegistration(res));
        }
        else if(this.chosenRole == 'registrar') {
          fetch(process.env.VUE_APP_HEROKU_PATH + "/Registration/Registrator/Statement", GetRequestOptions("POST", final_element))
                    .then(async res => await this.checkRegistration(res));
        }
      }
    },
    async checkRegistration(res) {
      if (res.status == 200) {
        this.registration = false;
      }
      else {
        const data = await res.json();
        this.message = data.error;
        this.failedRegistration = true;
      }
    },
    clearPasData(type) {
      if (type === 'pasType-Id') {
        this.pasSeriaB = ""; this.pasNumberB = ""; this.pasAgencyB = "";
      }
      else {
        this.pasAgency = ""; this.pasNumber = "";
      }
      this.pasDate = ""
    },
    clearRoleData() {
      this.agency = "";
        this.userIsAuthorized = false;
    }
  },
  watch: {
    chosenPassType: function (type) {
      this.clearPasData(type);
      if (type === 'pasType-Id') this.minPasDate = validation.minIdPasDate;
      else this.minPasDate = validation.minBookPasDate;
    }    
  },
  async created() {
    this.main = new Main();
    // this.registration_serve = new Registration();
    const sessionStorage = window.sessionStorage;
    if (sessionStorage.getItem('token')) sessionStorage.removeItem('token');
    if (sessionStorage.getItem('user_status')) sessionStorage.removeItem('user_status');
    this.$root.$children[0].$children[0].user_status = null;
    this.$root.$children[0].$children[0].page = 'registration';

    this.patterns = validation.patterns;
    this.today = validation.today;
    this.maxBirthDate = validation.maxBirthDate;
    this.minPasDate = validation.minIdPasDate;
    this.roles = [ {id: 'user', value: 'Користувач'},
                  {id: 'registrar', value: 'Реєстратор'}];
    this.pasTypes = [ {id: 'pasType-Id', text: 'ID-картка'},
                      {id: 'pasType-Book', text: 'Зразка 1994р.(Книжка)'}];

    this.authorityPassport = await this.main.AuthorityPassport();
    this.authority = await this.main.Authority()
  }
};
</script>
<style>
 .form-select {
   max-width: 97%;
   margin-left: 1.5%
 }
 .vertical-center {
   display: flex;
   align-items: center;
 }
</style>