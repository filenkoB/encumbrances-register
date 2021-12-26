<template>
  <div>
    <div v-if="registrators.length > 0">
      <div id="registrars_area">
        <div class="row m-1 border border-2 border-primary rounded" v-for="item in registrators" :key="item.item">
          <div class="col">
            <div class="row">
              <div class="col-auto pt-3">ПІБ:</div>
              <div class="col-3 text-start border-end border-4 pt-3">{{item.name}}</div>
              <div class="col-auto pt-3">Email:</div>
              <div class="col-3 text-start border-end border-4 pt-3">{{item.email}}</div>
              <div class="col text-end">
                <div class="row">
                  <div class="col m-1">
                    <button type="button" class="btn btn-outline-info" v-on:click="get_registrar_logs(item)">
                      <i class="fa fa-table" aria-hidden="true"></i>
                      Переглянути активність
                    </button>
                  </div>
                  <div class="col m-1">
                    <button type="button" class="btn btn-outline-primary" v-on:click="get_registrar_info(item)">
                      <i class="fa fa-eye" aria-hidden="true"></i>
                      Інформація
                    </button>
                  </div>
                </div>
              </div>
            </div>
            <div class="row" v-if="item.logs_visible_status">
              <div class="col"><RegistrarLog :registrar='item.id'/></div>
            </div>
            <div class="row" v-if="item.info_visible_status">
              <div class="col"><RegistrarInfo :registrar='item.id'/></div>
            </div>
          </div>
        </div>
        <div class="row">
          <Pagination :pagination="pagination" :fun="get_registrators"/>
        </div>
      </div>
    </div>
    <div class="row border border-4 p-3 mt-5 rounded" v-else>
      <div class="col text-center">
        <label>Наразі в системі відсутні записи реєстраторів</label>
      </div>
    </div>
  </div>
</template>s
<script>
import Pagination from "../../components/Pagination.vue"
import RegistrarLog from "../../components/registrar/RegistrarLog.vue"
import RegistrarInfo from "../../components/registrar/RegistrarInfo.vue"
import {Admin} from "../../connect_to_server"
import {RegistrarsPageElement} from "../../classes"
export default {
  name: 'ViewRegistrars',
  data: function () {
    return {
      admin:null,
      pagination:{
        active_page: 0,
        max_items_count:5,
        count_page: 0,
      },
      registrators: [],
      registrator_id: null,
    };
  },
  components:
  {
    Pagination,
    RegistrarLog,
    RegistrarInfo
  },
  methods:{
    async get_registrators(){
      this.pagination.max_items_count = parseInt(this.pagination.max_items_count);
      if (this.pagination.max_items_count < 1) this.pagination.max_items_count = 1;
      if (this.pagination.max_items_count > 7) this.pagination.max_items_count = 7;
      const data = await this.admin.GetAllRegistrators(this.pagination.active_page + 1, this.pagination.max_items_count);
      console.log(data);
      if(data.length < this.pagination.max_items_count) this.pagination.max_items_count = data.length
      this.pagination.count_page = Math.ceil(data.length / this.pagination.max_items_count);
      this.registrators = [];
      data.registrators.forEach(item => this.registrators.push(new RegistrarsPageElement(item.id, item.name, item.email, item.registeredAt, item.status)))
    },
    get_registrar_logs(item){
      console.log("item",item);
      this.registrator_id = item.id;
      if(!item.logs_visible_status) item.logs_visible_status = true;
      else item.logs_visible_status = false;
    },
    get_registrar_info(item){
      this.registrator_id = item.id;
      if(!item.info_visible_status) item.info_visible_status = true;
      else item.info_visible_status = false;
    }
  },
  mounted(){
    this.user_status = window.sessionStorage.getItem('user_status');
    if(!this.user_status || this.user_status != 'admin'){
        this.$router.push({ name: "Info"}).catch(() => {});
    }
    this.$root.$children[0].$children[0].page = 'registrars';
  },
  async created(){
    this.admin = new Admin();
    await this.get_registrators();
  }
}
</script>
<style>
#registrars_area{
  min-height: 420px;
}
</style>