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
    <div class="row mt-5">
      <div class="col-auto ms-3">
        <label class="col-form-label">Кількісь записів:</label>
      </div>
      <div class="col-auto me-5">
        <input type="number" class="form-control" @change="test()" style="width: 60px" v-model="pagination.max_items_count" min="1" max="5">
      </div>
      <nav class="col-7">
        <ul class="pagination justify-content-center">
          <span>
            <li class="page-item disabled" v-if="pagination.active_page == 0">
              <a class="page-link">Previous</a>
            </li>
            <li class="page-item" v-else><a class="page-link" 
            v-on:click="pagination_page(pagination.active_page)">Previous</a>
            </li>
          </span>
          <span v-for="item in pagination.count_page" :key="item">
            <li class="page-item ms-1 me-1 active" v-if="item == pagination.active_page+1">
              <a class="page-link" v-on:click="pagination_page(item)">{{item}}</a>
            </li>
            <li class="page-item ms-1 me-1" v-else><a class="page-link" 
            v-on:click="pagination_page(item)">{{item}}</a>
            </li>
          </span>
          <span>
            <li class="page-item disabled" v-if="pagination.active_page+1 == pagination.count_page">
              <a class="page-link">Next</a>
            </li>
            <li class="page-item" v-else><a class="page-link" 
            v-on:click="pagination_page(pagination.active_page+2)">Next</a>
            </li>
          </span> 
        </ul>
      </nav>
    </div>
  </div>
</template>s
<script>
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
  methods:{
    pagination_page(item){ this.pagination.active_page = item-1;},
    get_registrar_logs(){     
      this.pagination.max_items_count = parseInt(this.pagination.max_items_count);
      if (this.pagination.max_items_count < 1) this.pagination.max_items_count = 1;
      if (this.pagination.max_items_count > 5) this.pagination.max_items_count = 5;
      this.pagination.count_page = Math.ceil(this.registrar_logs.length / this.pagination.max_items_count);
      const position = this.pagination.active_page*this.pagination.max_items_count;
      return this.registrar_logs.slice(position, position + this.pagination.max_items_count);
    },
    test(){
      if(this.pagination.active_page >= this.pagination.count_page){
        this.pagination.active_page = this.pagination.count_page -1;
      }
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