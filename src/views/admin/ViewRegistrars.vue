<template>
  <div class="row">
    <div id="registrars_area">
      <div class="row m-1 border border-2 border-primary rounded" v-for="item in get_registrars()" :key="item.item">
        <div class="col-2 text-start border-end border-4"></div>
        <div class="col-2 text-start border-end border-4"></div>
        <div class="col-1 text-start border-end border-4"></div>
        <div class="col-auto m-1 text-start">
          <button type="button" class="btn btn-outline-info" v-on:click="get_registrar_logs(item)">Переглянути активність Реєстратора</button>
        </div>
        <div class="col-auto m-1 text-start">
          <button type="button" class="btn btn-outline-primary" v-on:click="get_registrar_info(item)">Переглянути інформацію про Реєстратора</button>
        </div>
        <div v-if="item.logs_visible_status">
          <RegistrarLog :registrar='item'/>
        </div>
        <div v-if="item.info_visible_status">
          <RegistrarInfo :registrar='item'/>
        </div>
      </div>
    </div>
    <Pagination :pagination="pagination"/>
  </div>
</template>s
<script>
import Pagination from "../../components/Pagination.vue"
import RegistrarLog from "../../components/registrar/RegistrarLog.vue"
import RegistrarInfo from "../../components/registrar/RegistrarInfo.vue"
export default {
  name: 'ViewRegistrars',
  data: function () {
    return {
      pagination:{
        active_page: 0,
        max_items_count:5,
        count_page: 0,
      },
      registrar: null,
      registrars: null,
      active_user: null
    };
  },
  components:
  {
    Pagination,
    RegistrarLog,
    RegistrarInfo
  },
  methods:{
    get_registrars(){
      this.pagination.max_items_count = parseInt(this.pagination.max_items_count);
      if (this.pagination.max_items_count < 1) this.pagination.max_items_count = 1;
      if (this.pagination.max_items_count > 7) this.pagination.max_items_count = 7;
      this.pagination.count_page = Math.ceil(this.registrars.length / this.pagination.max_items_count);
      const position = this.pagination.active_page*this.pagination.max_items_count;
      return this.registrars.slice(position, position + this.pagination.max_items_count);
    },
    get_registrar_logs(item){
      if(!item.logs_visible_status) item.logs_visible_status = true;
      else item.logs_visible_status = false;
    },
    get_registrar_info(item){
      if(!item.info_visible_status) item.info_visible_status = true;
      else item.info_visible_status = false;
    }
  },
  mounted(){
    this.user_status = window.sessionStorage.getItem('user_status');
    if(!this.user_status || this.user_status != 'admin'){
        this.$router.push({ name: "Info"}).catch(() => {});
    }
  },
  created(){
    this.registrars = [
      {
        item:"1", 
        logs_visible_status: false,
        info_visible_status: false
      },
      {
        item:"2", 
        logs_visible_status: false,
        info_visible_status: false
      },
      {
        item:"3", 
        logs_visible_status: false,
        info_visible_status: false
      }, 
      {
        item:"4", 
        logs_visible_status: false,
        info_visible_status: false
      }, 
      {
        item:"5", 
        logs_visible_status: false,
        info_visible_status: false
      },
      {
        item:"6", 
        logs_visible_status: false,
        info_visible_status: false
      },
      {
        item:"7", 
        logs_visible_status: false,
        info_visible_status: false
      },
      {
        item:"8", 
        logs_visible_status: false,
        info_visible_status: false
      },
      {
        item:"9", 
        logs_visible_status: false,
        info_visible_status: false
      },
      {
        item:"10", 
        logs_visible_status: false,
        info_visible_status: false
      }
    ]
  }
}
</script>
<style>
#registrars_area{
  min-height: 430px;
}
</style>