<template>
  <div>
    <div id="statements_area" >  
      <div class="row text-start ">
        <div class="col-auto border border-end-0 border-2 border-warning rounded-start">
          <label class="col-form-label">Останнє оновлення:</label>
        </div>
        <div class="col-auto border border-start-0 border-2 border-warning rounded-end">
          <label class="col-form-label">{{date}}</label>
        </div>
      </div>
      <div class="row border mt-2 border-2 border-primary rounded">
        <div class="col border-end border-3">
          <label class="col-form-label">Тип заяви</label>
        </div>
        <div class="col border-end border-3">
          <label class="col-form-label">Статус заяви</label>
        </div>
        <div class="col border-end border-3">
          <label class="col-form-label">Коментар</label>
        </div>
        <div class="col">
          <label class="col-form-label">Можливі дії</label>
        </div>
      </div>
      <div class="row border mt-2 border-primary rounded text-start" 
        v-for="item in get_statements()" :key="item.number">
        <div class="col border-end border-3 p-2">{{item.type}}</div>
        <div class="col border-end border-3 p-2">{{item.status}}</div>
        <div class="col border-end border-3 p-2">{{item.message}}</div>
        <div class="col p-2 text-center">
          <button type="button" class="btn btn-outline-secondary m-1" v-if="tools(item)">
            Отримати витяг
          </button>
        </div>
      </div>
    </div>
    <Pagination :pagination="pagination"/>
  </div>
</template>s
<script>
import Pagination from "../../components/Pagination.vue"
export default {
  name: 'MyStatements',
  data: function () {
    return {
      pagination:{
        active_page: 0,
        max_items_count:5,
        count_page: 0,
      },
      date: null,
      statements: null,
      active_user: null
    };
  },
  components:{
    Pagination
  },
  methods:{
    get_statements(){
      this.pagination.max_items_count = parseInt(this.pagination.max_items_count);
      if (this.pagination.max_items_count < 1) this.pagination.max_items_count = 1;
      if (this.pagination.max_items_count > 5) this.pagination.max_items_count = 5;
      this.pagination.count_page = Math.ceil(this.statements.length / this.pagination.max_items_count);
      const position = this.pagination.active_page*this.pagination.max_items_count;
      return this.statements.slice(position, position + this.pagination.max_items_count);
    },
    tools(item){
      if(item.type == "Отримання витягу" && item.status == "Прийнята") return true;
      return false;
    },
  },
  mounted(){
    this.user_status = window.sessionStorage.getItem('user_status');
    if(!this.user_status || this.user_status != 'user'){
        this.$router.push({ name: "Info"}).catch(() => {});
    }
  },
  created(){
    let today = new Date();
    this.date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate()+'  '+today.getHours() + ":" + today.getMinutes();
    this.statements = [
          {
              number: 213122,
              type: "Реєстрація asdlkasnd aslndlkasnd asldnklasndlas daslkdnask",
              status: "Прийнята",
              message:""
          },
          {
              number: 213123,
              type:"Внесення змін",
              status: "Надана в обробку",
              message:"вфіфіфі"
          },
          {
              number: 213124,
              type:"Отримання витягу",
              status: "Прийнята",
              message:""
          },
          {
              number: 2131221,
              type: "Реєстрація asdlkasnd aslndlkasnd asldnklasndlas daslkdnask",
              status: "Прийнята",
              message:""
          },
          {
              number: 2131231,
              type:"Внесення змін",
              status: "Надана в обробку",
              message:"вфіфіфі"
          },
          {
              number: 2131241,
              type:"Отримання витягу",
              status: "Прийнята",
              message:""
          },
          {
              number: 2131225,
              type: "Реєстрація asdlkasnd aslndlkasnd asldnklasndlas daslkdnask",
              status: "Прийнята",
              message:""
          },
          {
              number: 2131235,
              type:"Внесення змін",
              status: "Надана в обробку",
              message:"вфіфіфі"
          },
          {
              number: 2131245,
              type:"Отримання витягу",
              status: "Прийнята",
              message:""
          }
      ]
  }
}
</script>
<style>
#statements_area{
  min-height: 430px;
}
</style>