<template>
  <div class="row border-top border-4 text-start">
    <div class="col" v-if="registrator">
      <div class="row">
        <div class="col-5 me-3">
          <div class="row mt-2">
            <div class="col-3 mt-1">
              <label class="col-form-label">Прізвище:</label>
            </div>
            <div class="col-9">
              <input type="text" class="col-6 form-control" :disabled="!change_status" v-model="registrator.lastName">
            </div>
          </div>
          <div class="row mt-2">
            <div class="col-3 mt-1">
              <label class="col-form-label">Ім'я:</label>
            </div>
            <div class="col-9">
              <input type="text" class="col-6 form-control" :disabled="!change_status" v-model="registrator.firstName">
            </div>
          </div>
          <div class="row mt-2">
            <div class="col-3 mt-1">
              <label class="col-form-label">По-батькові:</label>
            </div>
            <div class="col-9">
              <input type="text" class="col-6 form-control" :disabled="!change_status" v-model="registrator.patronymic">
            </div>
          </div>
          <div class="row mt-2">
            <div class="col-4 mt-1">
              <label class="col-form-label">День народження:</label>
            </div>
            <div class="col-auto">
              <input type="date" class="col-6 form-control" :disabled="!change_status" v-model="registrator.birthDate">
            </div>
          </div>
        </div>
        <div class="col-6 ms-3">
          <div class="row mt-2">
            <div class="col-5 mt-1">
              <label class="col-form-label">Дата реєстрації:</label>
            </div>
            <div class="col-auto">
              <input type="date" class="col-6 form-control" disabled v-model="registrator.registeredAt">
            </div>
          </div>
          <div class="row mt-2">
            <div class="col-5 mt-1">
              <label class="col-form-label">Державний орган:</label>
            </div>
            <div class="col-7 mt-1">
              <select class="form-control" :disabled="!change_status" v-model="registrator.authority.name">
                <option v-for="item in authority" :key="item.name">{{item.name}}</option>
              </select>
            </div>
            
          </div>
          <div class="row mt-2">
            <div class="col-5 mt-1">
              <label class="col-form-label">Електронна адреса:</label>
            </div>
            <div class="col-7">
              <input type="text" class="col-6 form-control" :disabled="!change_status" v-model="registrator.email">
            </div>
          </div>
          <div class="row mt-2">
            <div class="col-5 mt-1">
              <label class="col-form-label">Статус:</label>
            </div>
            <div class="col-7">
              <select class="form-control" v-model="registrator.status" :disabled="!change_status">
                <option value="0">Активований</option>
                <option value="1">Деактивований</option>
              </select>
            </div>
          </div>
        </div>
      </div>
      <div class="row border-top border-4">
        <div class="col"></div>
        <div class="col">
          <div class="row mt-2 mb-2">
            <div class="col-1 mt-2">
              <input class="form-check-input" type="checkbox" v-model="change_status" :value="change_status">
            </div>
            <div class="col-6">
              <label class="col-form-label">Редагувати відомості</label>
            </div>
            <div class="col-5">
              <button type="button" class="btn btn-outline-success" v-on:click="save()" :disabled="!change_status">Зберегти зміни</button>
            </div>
          </div>
        </div>
        <div class="col"></div>
      </div>
    </div>
  </div>
</template>s
<script>
import {Admin, Authority} from "../../connect_to_server"
import {Registrator} from "../../classes"
export default {
  name: 'RegistrarInfo',
  data: function () {
    return {
      admin: null,
      registrator: null,
      authority: null,
      change_status: false,
    };
  },
  props:["registrar"],
  methods:{
    pagination_page(item){ this.pagination.active_page = item-1;},
    async save(){
      //this.registrator.authority.id = this.authority.filter(el=>el.name==this.registrator.authority.name)[0].id;
      //await this.admin.UpdateRegistrator(this.registrator.get_info())
    }
  },
  async created(){
    this.admin = new Admin();
    const data = await this.admin.GetRegistratorById(this.registrar);
    this.registrator = new Registrator(data.id, data.firstName, data.lastName, data.patronymic, data.birthDate, data.email, data.registeredAt, data.status, data.authority);
    this.authority = await Authority();
    console.log(this.registrator);
  }
}
</script>
<style>
#registrar_logs_area{
  min-height: 430px;
}
</style>