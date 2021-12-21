<template>
  <div>
    <pre>{{application}}</pre>
    <div class="p-3 border border-1 rounded row">
      <div class="row text-center"><p>ПІБ та дата народження</p></div>
      <div class="row">
        <div class="col">
          <div class="row">Прізвище:</div>
          <div class="row">{{application.lastName}}</div>
        </div>
        <div class="col">
          <div class="row">Ім'я:</div>
          <div class="row">{{application.firstName}}</div>
        </div>
        <div class="col">
          <div class="row">По-батькові:</div>
          <div class="row">{{application.patronymic}}</div>
        </div>
        <div class="col">
          <div class="row">Дата народження:</div>
          <div class="row">{{application.birthDate}}</div>
        </div>
      </div>
    </div>
    <div class="p-3 border border-1 rounded row">
      <div class="row text-center"><p>Паспорні дані</p></div>
      <div class="row">
        <div v-if="application.chosenPassType === 'id-card'" class="col">
          <div class="row">Номер документа:</div>
          <div class="row">{{application.passportNumber}}</div>
        </div>
        <div v-else class="col">
          <div class="row">Серія та номер документа:</div>
          <div class="row">{{application.passportInfo.serialNumber}} {{application.passportNumber}}</div>
        </div>
        <div class="col">
          <div class="row">Орган, що видав документ:</div>
          <div class="row">{{application.passportInfo.authorityId}}</div>
        </div>
        <div class="col">
          <div class="row">Дата видачі документа:</div>
          <div class="row">{{application.passportInfo.date}}</div>
        </div>
      </div>
    </div>
    <div class="p-3 border border-1 rounded row">
      <div class="row text-center"><p>Інформація про користувача системи</p></div>
      <div class="row">
        <div class="col">Електронна адреса: {{application.email}}</div>
        <div class="col">Роль у Реєстрі: {{application.userType}}</div>
        <div v-if="application.chosenRole === 'user' && application.authorityAddress" class="col">Працює в уповноваженому органі</div>
        <div v-else-if="application.chosenRole === 'user' && !application.authorityAddress" class="col">Не працює в уповноваженому органі</div>
      </div>
      <div class="border border-1 rounded border-primary mt-3" v-if="application.authorityAddress">
        <div class="row mt-2"><p>Адреса уповноваженого органу:</p></div>
        <Address :path="address.address.path" :editing_status="true"/>
      </div>
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
      this.address = new EncumbranceTierDebtor(null, null, null, null, this.application.authorityAddress);
    }   
  }
}
</script>
