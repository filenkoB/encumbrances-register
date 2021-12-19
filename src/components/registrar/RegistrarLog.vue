<template>
  <div class="row border-top border-4">
    <table class="table table-striped table-bordered">
      <thead>
        <tr>
          <th scope="col">Дата та час</th>
          <th scope="col">IP адреса</th>
          <th scope="col">Час виконання</th>
          <th scope="col">Ідентифікатори сутностей</th>
          <th scope="col">Опис виконуваної операції</th>
        </tr>
      </thead>
      <tbody class="text-start" v-if="get_registrar_logs().length > 0">
        <tr v-for="item in get_registrar_logs()" :key="item.date">
          <td>{{item.date}}</td>
          <td>{{item.ip}}</td>
          <td>{{item.time}}</td>
          <td>{{item.item_id}}</td>
          <td>{{item.action}}</td>
        </tr>
      </tbody>
      <tbody v-else>
        hi
      </tbody>
    </table>
    <Pagination :pagination="pagination"/>
  </div>
</template>s
<script>
import Pagination from "../Pagination.vue"
export default {
  name: 'RegistrarLog',
  data: function () {
    return {
      pagination:{
        active_page: 0,
        max_items_count:5,
        count_page: 0,
      },
      registrar_logs: [],
    };
  },
  props:["registrar"],
  components:{
    Pagination
  },
  methods:{
    get_registrar_logs(){     
      this.pagination.max_items_count = parseInt(this.pagination.max_items_count);
      if (this.pagination.max_items_count < 1) this.pagination.max_items_count = 1;
      if (this.pagination.max_items_count > 5) this.pagination.max_items_count = 5;
      this.pagination.count_page = Math.ceil(this.registrar_logs.length / this.pagination.max_items_count);
      const position = this.pagination.active_page*this.pagination.max_items_count;
      return this.registrar_logs.slice(position, position + this.pagination.max_items_count);
    }
  },
  created(){
    for(let i = 0; i < 10; i++){
      let today = new Date();
      let date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate()+'  '+today.getHours() + ":" + today.getMinutes()+":" + today.getSeconds()+":" + today.getMilliseconds()+i;
      this.registrar_logs.push({
        date:date,
        ip:"123.123.123.213",
        time:"12",
        item_id:"12312312",
        action:"lasldals"
      })
    }
    this.registrar_logs.sort(function (a, b) { 
    if (a.date > b.date) {return -1;}
    if (a.date < b.date) {return 1;}
    return 0;})
  }
}
</script>
<style>
#registrar_logs_area{
  min-height: 430px;
}
</style>