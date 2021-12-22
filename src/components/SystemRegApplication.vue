<template>
  <div class="row">
    <div class="border border-4 col">
      <div class="row">
        <div class="col-4 border-end border-4">
          <div class="row border-bottom border-2 border-warning">
            <div class="col text-center">
              <label class="col-form-label">ПІБ та Дата народження</label>
            </div>
          </div>
          <div class="row border-bottom border-2">
            <div class="col-5">
              <label class="col-form-label">Прізвище:</label>
            </div>
            <div class="col-7 ">
              <label class="col-form-label">{{application.lastName}}</label>
            </div>
          </div>
          <div class="row border-bottom border-2">
            <div class="col-5">
              <label class="col-form-label">Ім'я:</label>
            </div>
            <div class="col-7">
              <label class="col-form-label">{{application.firstName}}</label>
            </div>
          </div>
          <div class="row border-bottom border-2">
            <div class="col-5">
              <label class="col-form-label">По-батькові:</label>
            </div>
            <div class="col-7">
              <label class="col-form-label">{{application.patronymic}}</label>
            </div>
          </div>
          <div class="row ">
            <div class="col-5">
              <label class="col-form-label">Дата народження:</label>
            </div>
            <div class="col-7">
              <label class="col-form-label">{{application.birthDate.split('T')[0]}}</label>
            </div>
          </div>
        </div>
        <div class="col">
          <div class="row border-bottom border-2 border-warning">
            <div class="col text-center">
              <label class="col-form-label">Паспортні дані</label>
            </div>
          </div>
          <div class="row border-bottom border-2">
            <div class="col-5">
              <label class="col-form-label">Номер документа:</label>
            </div>
            <div class="col-7">
              <label class="col-form-label">{{application.passportInfo.passportNumber}}</label>
            </div>
          </div>
          <div class="row border-bottom border-2" v-if="application.passportInfo.serialNumber">
            <div class="col-5">
              <label class="col-form-label">Серія:</label>
            </div>
            <div class="col-7">
              <label class="col-form-label">{{application.passportInfo.serialNumber}}</label>
            </div>
          </div>
          <div class="row border-bottom border-2">
            <div class="col-5">
              <label class="col-form-label">Дата видачі документа:</label>
            </div>
            <div class="col-7">
              <label class="col-form-label">{{application.passportInfo.date.split('T')[0]}}</label>
            </div>
          </div>
          <div class="row">
            <div class="col-5">
              <label class="col-form-label">Орган, що видав документ:</label>
            </div>
            <div class="col-7">
              <label class="col-form-label">{{application.passportInfo.authorityId}}</label>
            </div>
          </div>
        </div>
      </div>
      <div class="row border-secondary border-top border-2">
        <div class="col text-center border-bottom border-2 border-warning">
          <label class="col-form-label">Інформація про користувача системи</label>
        </div>
      </div>
      <div class="row border-bottom border-2">
        <div class="col-5">
          <label class="col-form-label">Електронна адреса:</label>
        </div>
        <div class="col-7">
          <label class="col-form-label">{{application.email}}</label>
        </div>
      </div>
      <div class="row border-bottom border-2">
        <div class="col-5">
          <label class="col-form-label">Роль у Реєстрі:</label>
        </div>
        <div class="col-7">
          <label class="col-form-label" v-if="application.userType == 2">Реєстратор</label>
          <label class="col-form-label" v-else-if="application.userType == 3">Користувач</label>
        </div>
      </div>
      <div class="row border-bottom border-2" >
        <div class="col" v-if="application.authorityAddress">
          <label class="col-form-label" >Працює в уповноваженому органі:</label>
        </div>
        <div class="col" v-else>
          <label class="col-form-label">Не працює в уповноваженому органі</label>
        </div>
      </div>
      <div class="row mt-2" v-if="application.authorityAddress"><p>Адреса уповноваженого органу:</p></div>
      <Address :path="address.address.path" :editing_status="true" v-if="application.authorityAddress"/>
    </div>
  </div>    
</template>

<script>
import {UserStatementsInfo} from '../connect_to_server'
import Address from './statement_parts/Address.vue'
import {EncumbranceTierDebtor} from '../classes'
export default {
  data(){
    return {
      application: null,
      address: null
    }
  },
  name: "SystemRegApplication",
  props: ["item"],
  components:{
    Address
  },
  async created(){
    this.application = await UserStatementsInfo(this.item.id);
    console.log(this.application);
    if(this.application.authorityAddress != null)
    {
      console.log("hi");
      this.address = new EncumbranceTierDebtor(null, null, null, null, this.application.authorityAddress);
    }   
  }
}
</script>
