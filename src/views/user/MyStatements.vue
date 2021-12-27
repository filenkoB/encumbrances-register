<template>
  <div>  
    <div v-if="statements.length > 0">
      <div class="row border mt-2 border-2 border-primary rounded">
        <div class="col border-end border-3">
          <label class="col-form-label">Тип заяви</label>
        </div>
        <div class="col">
          <label class="col-form-label">Статус заяви</label>
        </div>
      </div>
      <div id="statements_area">
        <div class="row border mt-2 border-primary rounded text-start" 
          v-for="item in statements" :key="item.number">
          <div class="col border-end border-3 p-2">{{item.statementType}}</div>
          <div class="col border-end border-3 p-2" v-if="item.statementStatus == 0">Надано в обробку</div>
          <div class="col border-end border-3 p-2" v-else-if="item.statementStatus == 1">Прийнято</div>
          <div class="col border-end border-3 p-2" v-else-if="item.statementStatus == 2">Відхилено</div>
          <div class="col border-end border-3 p-2" v-if="item.statementStatus == 1 && item.statementType=='Заява про надання витягу з Державного реєстру обтяжень рухомого майна'">
            <button type="button" class="btn btn-outline-success" v-on:click="extract(item.id)">
              Отримати витяг
            </button>
          </div>
        </div>
      </div>
      <div class="row">
        <Pagination :pagination="pagination" :fun="get_statements"/>
      </div>
    </div>
    <div class="row border border-4 p-3 mt-5 rounded" v-else>
      <div class="col text-center">
        <label>Наразі в системі відсутні ваші заяви, для створення перейдіть до "Створити Заяву".</label>
      </div>
    </div>
  </div> 
</template>
<script>
import Pagination from "../../components/Pagination.vue"
import {User} from "../../connect_to_server"
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
      statements: [],
      user: null
    };
  },
  components:{
    Pagination
  },
  methods:{
    async get_statements(){
      this.pagination.max_items_count = parseInt(this.pagination.max_items_count);
      if (this.pagination.max_items_count < 1) this.pagination.max_items_count = 1;
      if (this.pagination.max_items_count > 7) this.pagination.max_items_count = 7;
      const data = await this.user.GetAllMyStatements(this.pagination.active_page + 1, this.pagination.max_items_count);
      console.log(data);
      if(data.length < this.pagination.max_items_count) this.pagination.max_items_count = data.length
      this.pagination.count_page = Math.ceil(data.length / this.pagination.max_items_count);
      this.statements = data.statements;
    },
    async extract(statement_id){
      await this.main.GetExtract(statement_id, true);
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
    this.$root.$children[0].$children[0].page = 'mystatements';
  },
  async created(){
    this.user = new User();
    await this.get_statements();
  }
}
</script>
<style>
#statements_area{
  min-height: 400px;
}
</style>