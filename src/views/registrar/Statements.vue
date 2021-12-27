<template>
  <div id="statements_page">
    <div v-if="statements.length > 0">
      <div id="statements_area" >
        <div class="row" v-for="item in statements"
        v-bind:key="item.number">
          <div :class="colour(item)">
            <div class="col-auto pt-1 border-end border-3">
              <label class="col-form-label me-3">Вихідний номер:</label>
              <label class="col-form-label">{{item.number}}</label>
            </div>
            <div class="col-auto pt-1 border-end border-3">
              <label class="col-form-label me-3">Дата заяви:</label>
              <label class="col-form-label">{{item.date}}</label>
            </div>
            <div class="col-auto pt-1">
              <label class="col-form-label me-3">Тип заяви:</label>
              <label class="col-form-label">{{item.typeName}}</label>
            </div>
            <div class="col text-end p-1">
              <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                <button type="button" :class="button(item)" v-on:click="show_statement_info(item)">
                  <span v-if="!item.visible_status">
                    <i class="fa fa-eye" aria-hidden="true"></i>
                    Переглянути все
                  </span>
                  <span v-else>
                    <i class="fa fa-eye-slash" aria-hidden="true"></i>
                  </span>
                </button>
                <button type="button" class="btn btn-outline-success" v-if="item.visible_status"
                v-on:click="button_1(item.id)" :disabled="!item.visible_status">Підтвертити</button>
                <button  type="button" class="btn btn-outline-danger" v-if="item.visible_status"
                v-on:click="button_2(item.id)" :disabled="!item.visible_status">Відхилити</button>
              </div>
            </div>
          </div>
          <div class="row mb-2" v-if="item.visible_status">
            <Statement :statement_element='item' :editing_status='editing_status' />
          </div>
        </div>
      </div>
      <Pagination :pagination="pagination" :fun="get_statements"/>
    </div>
    <div class="row border border-4 p-3 mt-5 rounded" v-else>
      <div class="col text-center">
        <label>Наразі в системі відсутні заяви, котрі необхідно зареєструвати</label>
      </div>
    </div>
  </div>
</template>
<script>
import Pagination from "../../components/Pagination.vue"
import Statement from '../../components/Statement.vue';
import {Registrator} from "../../connect_to_server"
import {StatmentsPageElement} from "../../classes"
export default {
  name: 'App',
  data: function () {
    return {
      editing_status:true,
      pagination:{
        active_page: 0,
        max_items_count:7,
        count_page: 0,
      },
      statements: [],
      registrator: null
    };
  },
  components:
  {
    Pagination,
    Statement,
  },
  methods:{
    colour(item){
      if(item.visible_status) return "row mb-1 border border-primary rounded";
      return "row mb-1 border border-secondary rounded";
    },
    button(item){
      if(!item.visible_status) return "btn btn-info";
      return "btn btn-outline-secondary";
    },
    async show_statement_info(item){
      for(let i = 0; i < this.statements.length; i++){
        if(this.statements[i]!=item) this.statements[i].visible_status = false;
      }
      if(item.visible_status == false){
        item.visible_status = true;
      }
      else item.visible_status = false;
      for(let el in this.statement) this.statement[el].visible_status=false
      
    },
    async button_1(el){
      //await this.registrator.EncumbranceStatementAccept(el);
      console.log(el);
      this.pagination.active_page = 0;
      this.get_statements();
    },
    async button_2(el){
      //await this.registrator.EncumbranceStatementDecline(el);
      console.log(el);
      this.pagination.active_page = 0;
      await this.get_statements();
    },
    async get_statements(){
      this.pagination.max_items_count = parseInt(this.pagination.max_items_count);
      if (this.pagination.max_items_count < 1) this.pagination.max_items_count = 1;
      if (this.pagination.max_items_count > 7) this.pagination.max_items_count = 7;
      const data = await this.registrator.GetAllStatements(this.pagination.active_page + 1, this.pagination.max_items_count);
      if(data.maxStatements < this.pagination.max_items_count) this.pagination.max_items_count = data.maxStatements
      this.pagination.count_page = Math.ceil(data.maxStatements / this.pagination.max_items_count);
      this.statements = [];
      data.statements.forEach(item => this.statements.push(new StatmentsPageElement(item.id, item.number, item.date, item.typeName)))
    }
  },
  mounted(){
    this.user_status = window.sessionStorage.getItem('user_status');
    if(!this.user_status || this.user_status != 'registrar'){
        this.$router.push({ name: "Info"}).catch(() => {});
    }
    this.$root.$children[0].$children[0].page = 'statements';
    window.sessionStorage.setItem('page', 'statements');
  },
  async created(){
    this.registrator = new Registrator();
    await this.get_statements();
  }
}
</script>
<style>
#statements_area{
  min-height: 430px;
}
</style>