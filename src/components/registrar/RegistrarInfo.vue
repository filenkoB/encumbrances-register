<template>
  <div class="row border-top border-4 text-start">
    <div class="col">
      <div class="row">
        <div class="col-5 me-3">
          <div class="row mt-2">
            <div class="col-3 mt-1">
              <label class="col-form-label">Прізвище:</label>
            </div>
            <div class="col-9">
              <input type="text" class="col-6 form-control" :disabled="!change_status" v-model="registrar.lastName">
            </div>
          </div>
          <div class="row mt-2">
            <div class="col-3 mt-1">
              <label class="col-form-label">Ім'я:</label>
            </div>
            <div class="col-9">
              <input type="text" class="col-6 form-control" :disabled="!change_status" v-model="registrar.firstName">
            </div>
          </div>
          <div class="row mt-2">
            <div class="col-3 mt-1">
              <label class="col-form-label">По-батькові:</label>
            </div>
            <div class="col-9">
              <input type="text" class="col-6 form-control" :disabled="!change_status" v-model="registrar.parentName">
            </div>
          </div>
          <div class="row mt-2">
            <div class="col-auto mt-1">
              <label class="col-form-label">Дата реєстрації:</label>
            </div>
            <div class="col-auto">
              <input type="date" class="col-6 form-control" disabled v-model="registrar.date">
            </div>
          </div>
        </div>
        <div class="col-6 ms-3">
          <div class="row mt-2">
            <div class="col-5 mt-1">
              <label class="col-form-label">Державний орган:</label>
            </div>
            <div class="col-7 mt-1">
              <select class="form-control"
              :disabled="!change_status" v-model="registrar.workplace">
                <option>lsllsl</option>
              </select>
            </div>
            
          </div>
          <div class="row mt-2">
            <div class="col-5 mt-1">
              <label class="col-form-label">Електронна адреса:</label>
            </div>
            <div class="col-7">
              <input type="text" class="col-6 form-control" :disabled="!change_status" v-model="registrar.email">
            </div>
          </div>
          <div class="row mt-2">
            <div class="col-5 mt-1">
              <label class="col-form-label">Статус:</label>
            </div>
            <div class="col-7">
              <select class="form-control" v-model="registrar.status" :disabled="!change_status">
                <option value="true">Активований</option>
                <option value="false">Деактивований</option>
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
              <button type="button" class="btn btn-outline-success" :disabled="!change_status">Зберегти зміни</button>
            </div>
          </div>
        </div>
        <div class="col"></div>
      </div>
    </div>
  </div>
</template>s
<script>
export default {
  name: 'RegistrarInfo',
  data: function () {
    return {
      pagination:{
        active_page: 0,
        max_items_count:5,
        count_page: 0,
      },
      registrar_logs: [],
      change_status: false,
    };
  },
  props:["registrar"],
  methods:{
    pagination_page(item){ this.pagination.active_page = item-1;},
    get_registrar_logs(){     
      this.pagination.max_items_count = parseInt(this.pagination.max_items_count);
      if (this.pagination.max_items_count < 1) this.pagination.max_items_count = 1;
      if (this.pagination.max_items_count > 5) this.pagination.max_items_count = 5;
      this.pagination.count_page = Math.ceil(this.registrar_logs.length / this.pagination.max_items_count);
      const position = this.pagination.active_page*this.pagination.max_items_count;
      return this.registrar_logs.slice(position, position + this.pagination.max_items_count);
    },
    test(){
      if(this.pagination.active_page >= this.pagination.count_page){
        this.pagination.active_page = this.pagination.count_page -1;
      }
    }
  },
  created(){}
}
</script>
<style>
#registrar_logs_area{
  min-height: 430px;
}
</style>