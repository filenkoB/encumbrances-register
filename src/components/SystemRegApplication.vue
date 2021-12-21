<template>
  <div>
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
          <div class="row">{{application.parentName}}</div>
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
        <div v-if="application.chosenPassType === 'id-card'" class="col"><div class="row">Номер документа:</div><div class="row">{{application.pasNumber}}</div></div>
        <div v-else class="col">
          <div class="row">Серія та номер документа:</div>
          <div class="row">{{application.pasSeria}} {{application.pasNumber}}</div>
        </div>
        <div class="col">
          <div class="row">Орган, що видав документ:</div>
          <div class="row">{{application.pasAgency}}</div>
        </div>
        <div class="col">
          <div class="row">Дата видачі документа:</div>
          <div class="row">{{application.pasDate}}</div>
        </div>
        <div class="col">
          <div class="row">Номер картки платника податків:</div>
          <div class="row">{{application.idNumber}}</div>
        </div>
      </div>
    </div>
    <div class="p-3 border border-1 rounded row">
      <div class="row text-center"><p>Інформація про користувача системи</p></div>
      <div class="row">
        <div class="col">Електронна адреса: {{application.email}}</div>
        <div class="col">Роль у Реєстрі: {{application.chosenRole}}</div>
        <div v-if="application.chosenRole === 'user' && application.userIsAuthorized" class="col">Працює в уповноваженому органі</div>
        <div v-else-if="application.chosenRole === 'user' && !application.userIsAuthorized" class="col">Не працює в уповноваженому органі</div>
        <div v-if="application.chosenRole === 'user' || application.userIsAuthorized" class="col">Державний орган: {{application.agency}}</div>
      </div>
      <div class="border border-1 rounded border-primary mt-3">
        <div class="row mt-2"><p>Адреса уповноваженого органу:</p></div>
        <div class="row">
          <p>Країна: {{application.address.path.country}},
          oбласть: {{application.address.path.region}},
          pайон: {{application.address.path.district}},
          місто: {{application.address.path.city}},
          індекс: {{application.address.path.index}},
          вулиця: {{application.address.path.street}},
          будинок: {{application.address.path.build}},
          корпус: {{application.address.path.corps}}.</p>
        </div>
      </div>
    </div>
  </div>    
</template>

<script>
import {GetUserStatment} from '../connect_to_server'
export default {
  data(){
    return {
      application: null
    }
  },
  name: "SystemRegApplication",
  props: ["item"],
  
  async beforeCreate(){
    this.application = await GetUserStatment(this.item.id)
  }
}
</script>
