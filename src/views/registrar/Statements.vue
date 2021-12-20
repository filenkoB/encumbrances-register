<template>
  <div id="statements_page">
    <div>
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
                v-on:click="button_1()" :disabled="!item.visible_status">Підтвертити</button>
                <button  type="button" class="btn btn-outline-danger" v-if="item.visible_status"
                v-on:click="button_2()" :disabled="!item.visible_status">Відхилити</button>
              </div>
            </div>
          </div>
          <div class="row mb-2" v-if="item.visible_status">
            <card v-bind:cards="card" :success="remove_statement"/>
          </div>
          <div class="row mb-2" v-if="item.visible_status">
            <Statement :statement_element='item' :editing_status='editing_status' :info="info"/>
          </div>
        </div>
      </div>
      <Pagination :pagination="pagination" :fun="get_statements"/>
    </div>
  </div>
</template>
<script>
import Pagination from "../../components/Pagination.vue"
import Statement from '../../components/Statement.vue';
import Card from '../../components/Card.vue';
import {card} from "../../data";
import {GetStatements, EncumbranceType, RegistrationType, AlienationLimit} from "../../connect_to_server"
import {StatmentsPageElement} from "../../classes"
export default {
  name: 'App',
  data: function () {
    return {
      editing_status:false,
      pagination:{
        active_page: 0,
        max_items_count:7,
        count_page: 0,
      },
      card: null ,
      statements: [],
      info:[]
    };
  },
  components:
  {
    Pagination,
    Statement,
    Card
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
      this.card[0].visible_status = false;
      this.card[1].visible_status = false;
      if(item.visible_status == false){
        item.visible_status = true;
        //this.getInfo(item)
      }
      else item.visible_status = false;
      for(let el in this.statement) this.statement[el].visible_status=false
      
    },
    remove_statement(item){
      item.visible_status = false;
    },
    button_1(){
      this.card[0].visible_status = true;
      if(this.card[1].visible_status) this.card[1].visible_status = false;
    },
    button_2(){
      this.card[1].visible_status = true;
      if(this.card[0].visible_status) this.card[0].visible_status = false;
    },
    async get_statements(){
      this.pagination.max_items_count = parseInt(this.pagination.max_items_count);
      if (this.pagination.max_items_count < 1) this.pagination.max_items_count = 1;
      if (this.pagination.max_items_count > 7) this.pagination.max_items_count = 7;
      const data = await GetStatements(this.pagination.active_page + 1, this.pagination.max_items_count);
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
    
  },
  async created(){
    await this.get_statements();
    this.card = card;
    this.info.encumbranceType = await EncumbranceType();
    this.info.registrationType = await RegistrationType();
    this.info.alienationLimit = await AlienationLimit();
  }
}
</script>
<style>
#statements_area{
  min-height: 430px;
}
</style>