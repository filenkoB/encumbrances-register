<template>
  <form v-if="registration" @submit.prevent="regIn" class="row">
    <div class="col-2"></div>
    <div class="col-8">

    <!-- ПІБ та дата народження -->

      <div class="row">
        <div class="form-floating">
          <input type="text" v-model="lastName" pattern="[А-ЯІЇЄ][а-яіїє]+(-[А-ЯІЇЄ][а-яіїє]+)*" class="form-control" required placeholder=" " />
          <label class="ms-2 vertical-center">Прізвище</label>
        </div>
      </div>
      <div class="row mt-3">
        <div class="form-floating">
          <input type="text" v-model="firstName" pattern="[А-ЯІЇЄ][а-яіїє]+" class="form-control" required placeholder=" " />
          <label class="ms-2 vertical-center">Ім'я</label>
        </div>
      </div>
      <div class="row mt-3">
        <div class="form-floating">
          <input type="text" v-model="parentName" pattern="[А-ЯІЇЄ][а-яіїє]+" class="form-control" required placeholder=" " />
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
            <div class="form-floating">
              <input type="text"  v-model="pasAgency" required pattern="\d{4}" class="form-control" placeholder=" " />
              <label class="ms-2 vertical-center">Орган, що видав документ</label>
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
          <div class="row mt-3">
            <label>Орган, що видав документ:</label>
            <select  v-model="pasAgencyB" required class="form-select mt-3">
              <option v-for="pAgency in pasAgencies" :key="pAgency">{{pAgency}}</option>
            </select>
          </div>
        </div>
        <div class="row mt-3">
          <div class="form-floating">
            <input type="date"  v-model="pasDate" required :max="today" class="form-control" placeholder=" " />
            <label class="ms-2 vertical-center">Дата видачі паспорта</label>
          </div>
        </div>
      </div>
      <div class="row mt-3">
        <div class="form-floating">
          <input type="text"  v-model="idNumber" required pattern="\d{12}" class="form-control" placeholder=" " />
          <label class="ms-2 vertical-center">Номер картки платника податків</label>
        </div>
      </div>

      <!-- інформація про користувача системи -->

      <div class="row mt-3">
        <div class="form-floating">
          <input type="email" v-model="email" required class="form-control" placeholder=" " />
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
      <div v-if="chosenRole === 'registrar'">
        <div class="form-floating mt-3">
          <input v-model="agency" required class="form-control" placeholder=" " />
          <label class="vertical-center">Державний орган</label>
        </div>
      </div>
      <div v-if="(chosenRole !== 'user') || userIsAuthorized" class="mt-3 p-3 border border-secondary border-2 rounded">
        <label class="mb-3">Адреса державної установи:</label>
        <Address :path="address.path"/>
      </div>
      <div class="row mt-3">
        <button class="w-100 btn btn-outline-dark" type="submit">Подати заявку на реєстрацію</button>
      </div>
    </div>
    <div class="col"></div>
  </form>

  <!-- Сповіщення про здійснення реєстрації -->
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
import Address from "../components/Address.vue"
export default {
  name: "registration",
  data() {
    return {
      registration: true,
      chosenPassType: 'pasType-Id', chosenRole: 'user',
      firstName: "", lastName: "", parentName: "", birthDate: "",
      pasNumber: "", pasSeriaB: "", pasNumberB: "",
      email: "", agency: "", idNumber: "",
      pasAgency: "", pasAgencyB: "", pasDate: "", userIsAuthorized: false,
      address: { path:{
        country: "Оберіть ...",
        region: "Оберіть ...",
        district: "Оберіть ...",
        city: "Оберіть ...",
        index: "Оберіть ...",
        street: "Оберіть ...",
        build: "",
        corps: "",
        flat: ""}
      }
    }
  },
  components:{
    Address
  },
  methods: {
    regIn() {
      const inputs = document.getElementsByTagName('input');
      let valid = true;
      for (let input of inputs) {
        if (input.validity.valid === false) {
          valid = false; break;
        }
      }

      if (valid) {
        this.registration = false;

        // fetch запит на відправку заявки
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
      this.address.path = {
        country: "Оберіть ...",
        region: "Оберіть ...",
        district: "Оберіть ...",
        city: "Оберіть ...",
        index: "Оберіть ...",
        street: "Оберіть ...",
        build: "",
        corps: "",
        flat: ""}
      this.agency = "";
        this.userIsAuthorized = false;
    }
  },
  watch: {
    chosenPassType: function (type) {
      this.clearPasData(type);
    },
    // chosenRole: function (role) {
    //   this.clearRoleData(role);
    // }
  },
  created() {
    const sessionStorage = window.sessionStorage;
    if (sessionStorage.getItem('token')) sessionStorage.removeItem('token');
    if (sessionStorage.getItem('user_status')) sessionStorage.removeItem('user_status');
    this.$root.$children[0].$children[0].user_status = null;

    this.roles = [ {id: 'user', value: 'Користувач'},
                  {id: 'registrar', value: 'Реєстратор'},
                  {id: 'admin', value: 'Адміністратор'}];
    this.pasTypes = [ {id: 'pasType-Id', text: 'ID-картка'},
                      {id: 'pasType-Book', text: 'Зразка 1994р.(Книжка)'}];
    const today = new Date(Date.now()); const format = "yyyy-mm-dd"
    this.today = format.replace('yyyy', today.getFullYear())
                        .replace('mm', today.getMonth() + 1)
                        .replace('dd', today.getDate());
    this.maxBirthDate = format.replace('yyyy', today.getFullYear() - 18)
                        .replace('mm', today.getMonth() + 1)
                        .replace('dd', today.getDate());
    this.pasAgencies = ["Якась шарага", "Печінка"];
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