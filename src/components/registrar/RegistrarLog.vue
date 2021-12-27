<template>
  <div class="row border-top border-4">
    <div class="col">
      <div class="row" v-if="actions.length > 0">
        <table class="table table-striped table-bordered">
          <thead>
            <tr>
              <th scope="col">Дата та час</th>
              <th scope="col">IP адреса</th>
              <th scope="col">Ідентифікатори сутностей</th>
              <th scope="col">Опис виконуваної операції</th>
            </tr>
          </thead>
          <tbody class="text-start" >
            <tr v-for="item in actions" :key="item.date">
              <td>{{item.date.split('T')[0]}} | {{item.date.split('T')[1]}}</td>
              <td>{{item.ipAddress}}</td>
              <td>{{item.objectId}}</td>
              <td>{{item.description}}</td>
            </tr>
          </tbody>
        </table>
        <Pagination :pagination="pagination" :fun="get_registrar_logs"/>
      </div>
      <div class="row p-2" v-else>
        <div class="col text-center">
          <label>Наразі в системі відсутні журнальні записи відносно даного реєстратора</label>
        </div>
      </div>
    </div>
  </div>
</template>s
<script>
import Pagination from "../Pagination.vue"
import {Admin} from "../../connect_to_server"
export default {
  name: 'RegistrarLog',
  data: function () {
    return {
      pagination:{
        active_page: 0,
        max_items_count:5,
        count_page: 0,
      },
      actions: [],
    };
  },
  props:["registrar"],
  components:{
    Pagination
  },
  methods:{
    async get_registrar_logs(){     
      this.pagination.max_items_count = parseInt(this.pagination.max_items_count);
      if (this.pagination.max_items_count < 1) this.pagination.max_items_count = 1;
      if (this.pagination.max_items_count > 7) this.pagination.max_items_count = 7;
      const data = await this.admin.GetRegistratorActions(this.registrar, this.pagination.active_page + 1, this.pagination.max_items_count);
      if(data.length < this.pagination.max_items_count) this.pagination.max_items_count = data.length
      this.pagination.count_page = Math.ceil(data.length / this.pagination.max_items_count);
      this.actions = data.actions;
    }
  },
  created(){
    this.admin = new Admin();
    this.get_registrar_logs();
  }
}
</script>
<style>
#registrar_logs_area{
  min-height: 430px;
}
</style>