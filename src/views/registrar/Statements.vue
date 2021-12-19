<template>
  <div id="statements_page">
    <div v-if="get_statements().length > 0">
      <div id="statements_area" >
        <div class="row" v-for="item in get_statements()"
        v-bind:key="item.general_information.number.data">
          <div :class="colour(item)">
            <div class="col-auto mt-1">
              <label class="col-form-label">Вихідний номер:</label>
            </div>
            <div class="col-1 border-end border-3 mt-1">
              <label class="col-form-label">{{item.general_information.number.data}}</label>
            </div>
            <div class="col-auto mt-1">
              <label class="col-form-label">Дата заяви:</label>
            </div>
            <div class="col-auto border-end border-3 mt-1">
              <label class="col-form-label">{{item.general_information.date.data}}</label>
            </div>
            <div class="col-auto mt-1">
              <label class="col-form-label">Тип заяви:</label>
            </div>
            <div class="col-3 mt-1">
              <label class="col-form-label">реєстрація обтяженняя...</label>
            </div>
            <div class="col text-right p-1">
              <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                <button type="button" :class="button(item)" v-on:click="show_statement_info(item)">
                  <i class="fa fa-eye" aria-hidden="true"></i>
                  Переглянути все
                </button>
                <button type="button" class="btn btn-outline-success" v-on:click="button_1()" :disabled="!item.visible_status">Підтвертити</button>
                <button  type="button" class="btn btn-outline-danger" v-on:click="button_2()" :disabled="!item.visible_status">Відхилити</button>
              </div>
            </div>
          </div>
          <div class="row mb-2" v-if="item.visible_status">
            <card v-bind:cards="card" :success="remove_statement"/>
          </div>
          <div class="row mb-2" v-if="item.visible_status">
            <Statement :statement_element='item' :editing_status='editing_status'/>
          </div>
        </div>
      </div>
      <Pagination :pagination="pagination"/>
    </div>
    <div v-else class="p-5 m-5 border border-secondary rounded text-center">
      На даний момент всі надані на ухвалення заяви, оброблені.
    </div>
  </div>
</template>s
<script>
import Pagination from "../../components/Pagination.vue"
import Statement from '../../components/Statement.vue';
import Card from '../../components/Card.vue';
import {statement, create_statements, card} from "../../data";
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
      statement: null,
      statements: null,
      active_user: null
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
      if(item.visible_status) return "row p-1 mb-1 border border-primary rounded";
      return "row p-1 mb-1 border border-secondary rounded";
    },
    button(item){
      if(!item.visible_status) return "btn btn-info";
      return "btn btn-outline-secondary";
    },
    getInfo(item){
      this.statement.general_information = item.general_information;
      this.statement.encumbrance_information = item.encumbrance_information;
    },
    show_statement_info(item){
      for(let i = 0; i < this.statements.length; i++){
        if(this.statements[i]!=item) this.statements[i].visible_status = false;
      }
      this.card[0].visible_status = false;
      this.card[1].visible_status = false;
      if(item.visible_status == false){
        item.visible_status = true;
        this.getInfo(item)
      }
      else item.visible_status = false;
      for(let el in this.statement) this.statement[el].visible_status=false
    },
    remove_statement(item){
      item.visible_status = false;
      for(let i = 0; i < this.statements.length; i++){
        if(this.statements[i].general_information == this.statement.general_information){
          ///відправка на сервер, з item взяти type і відповідно до типу можемо дізнатись checked - причину відхилення, якщо відхилена
          this.statements.splice(i, 1);
          this.statement.general_information = null;
          break;
        }
      }
    },
    button_1(){
      this.card[0].visible_status = true;
      if(this.card[1].visible_status) this.card[1].visible_status = false;
    },
    button_2(){
      this.card[1].visible_status = true;
      if(this.card[0].visible_status) this.card[0].visible_status = false;
    },
    get_statements(){
      this.pagination.max_items_count = parseInt(this.pagination.max_items_count);
      if (this.pagination.max_items_count < 1) this.pagination.max_items_count = 1;
      if (this.pagination.max_items_count > 7) this.pagination.max_items_count = 7;
      this.pagination.count_page = Math.ceil(this.statements.length / this.pagination.max_items_count);
      const position = this.pagination.active_page*this.pagination.max_items_count;
      return this.statements.slice(position, position + this.pagination.max_items_count);
    }
  },
  mounted(){
    this.user_status = window.sessionStorage.getItem('user_status');
    if(!this.user_status || this.user_status != 'registrar'){
        this.$router.push({ name: "Info"}).catch(() => {});
    }
  },
  created(){
    this.card = card;
    this.statement = statement,
    this.statements = create_statements(10);
  }
}
</script>
<style>
#statements_area{
  min-height: 430px;
}
</style>