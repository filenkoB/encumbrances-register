<template>
  <div class="row">
    <div id="applications_area">
      <div class="row m-1 border border-2 border-secondary rounded" v-for="item in applications" :key="item.number">
        <div class="col-auto text-start pt-3">Вихідний номер: </div>
        <div class="col-2 text-start border-end border-4 pt-3">{{item.number}}</div>
        <div class="col-auto text-start pt-3">Дата заявки: </div>
        <div class="col-2 text-start border-end border-4 pt-3">{{item.date}}</div>
        <div class="col m-1 text-end">
          <button type="button" class="btn btn-outline-info m-1" @click="get_application_info(item)">Переглянути дані заявки</button>
          <button type="button" class="btn btn-outline-success m-1" :disabled="!item.visible_status" @click="accept()">Підтвердити</button>
          <button type="button" class="btn btn-outline-danger m-1" :disabled="!item.visible_status" @click="decline()">Відхилити</button>
        </div>
        <div v-if="item.visible_status">
          <system-reg-application :item="item"/>
        </div>
      </div>
    </div>
    <div class="row my-3">
      <pagination :pagination="pagination" :fun="get_applications"/>
    </div>
  </div>
</template>
<script>
import {UsersStatementsList} from '../../connect_to_server'
import {StatmentsPageElement} from '../../classes'
import Pagination from '../../components/Pagination.vue';
import SystemRegApplication from "../../components/SystemRegApplication.vue";
export default {
  name: 'SystemRegApplications',
  data: function () {
    return {
      pagination:{
        active_page: 0,
        max_items_count:5,
        count_page: 0,
      },
      applications: null,
      statements: null
    };
  },
  components:
  {
    SystemRegApplication,
    Pagination,
  },
  methods:{
    pagination_page(item){ this.pagination.active_page = item-1;},
    async get_applications(){
      this.pagination.max_items_count = parseInt(this.pagination.max_items_count);
      if (this.pagination.max_items_count < 1) this.pagination.max_items_count = 1;
      if (this.pagination.max_items_count > 7) this.pagination.max_items_count = 7;
      const data = await UsersStatementsList(this.pagination.active_page + 1, this.pagination.max_items_count);
      if(data.maxStatements < this.pagination.max_items_count) this.pagination.max_items_count = data.maxStatements
      this.pagination.count_page = Math.ceil(data.maxStatements / this.pagination.max_items_count);
      this.applications = [];
      data.statements.forEach(item => this.applications.push(new StatmentsPageElement(item.id, item.number, item.date, null)))
    },
    get_application_info(item){
      this.closeInfo(item);
      item.visible_status = !item.visible_status;
    },
    accept() {
    },
    decline() {
    },
    closeInfo(item) {
      for(let app of this.applications){
        if (app !== item) app.visible_status = false;
      }
    },
  },
  mounted(){
    this.user_status = window.sessionStorage.getItem('user_status');
    if(!this.user_status || this.user_status != 'admin'){
        this.$router.push({ name: "Info"}).catch(() => {});
    }
  },
  async created(){
    this.get_applications();
  }
}
</script>
<style>
#applications_area{
  min-height: 500px;
}
</style>