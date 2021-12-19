<template>
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
</template>
<script>
import Statement from "../../components/statements/statement_for_create.vue"
export default {
  data(){
    return {
      editing_status: false,
    }
  },
  components:{
    Statement,
  }
}
</script>
<template>
  <div class="row mt-5">
    {{pagination}}
      <div class="col-auto ms-3">
        <label class="col-form-label">Кількісь записів:-</label>
      </div>
      <div class="col-auto me-5">
        <input type="number" class="form-control" @change="test()" style="width: 60px" v-model="pagination.max_items_count" min="1" max="7">
      </div>
      <nav class="col-7">
        <ul class="pagination justify-content-center">
          <span>
            <li class="page-item disabled" v-if="pagination.active_page == 0"><a class="page-link">Previous</a></li>
            <li class="page-item" v-else><a class="page-link" v-on:click="pagination_page(pagination.active_page)">Previous</a></li>
          </span>
          <span>
            <li class="page-item ms-1 me-1" v-if="start_position != 0">
              <a class="page-link" v-on:click="first_page()">1</a>
            </li>
          </span>
          <span v-for="item in max" :key="item">{{}}
            <li class="page-item ms-1 me-1 active" v-if="start_position+item == pagination.active_page+1">
              <a class="page-link" v-on:click="pagination_page(start_position+item)">{{start_position+item}}</a>
            </li>
            <li class="page-item ms-1 me-1" v-else-if="start_position + item <= pagination.count_page">
              <a class="page-link" v-on:click="pagination_page(start_position+item)">{{start_position+item}}</a>
            </li>
          </span>
          <span>
            <li class="page-item ms-1 me-1" v-if="start_position + max < pagination.count_page">
              <a class="page-link" v-on:click="load_next_page()">...</a>
            </li>
          </span>
          <span>
            <li class="page-item disabled" v-if="pagination.active_page+1 == pagination.count_page"><a class="page-link">Next</a></li>
            <li class="page-item" v-else><a class="page-link" v-on:click="pagination_page(pagination.active_page+2)">Next</a></li>
          </span> 
        </ul>
      </nav>
    </div>
</template>
<script>
export default {
  data(){
    return{
      step: 0,
      max: 5,
      start_position: 0,
    }
  },
  name: "Pagination",
  props:["pagination", "fun"],
  methods:{
    pagination_page(item){
      if(this.pagination.active_page == this.start_position && item == this.start_position){
        this.start_position -=this.max;
      }
      if(item - this.start_position > this.max) this.load_next_page();
      this.pagination.active_page = item-1;
      this.fun();
    },
    test(){
      if(this.pagination.active_page >= this.pagination.count_page){
        this.pagination.active_page = this.pagination.count_page -1;
      }
      this.fun();
    },
    load_next_page(){
      this.start_position +=this.max;
      this.pagination.active_page = this.start_position;
      this.fun();
    },
    first_page(){
      this.start_position = 0;
      this.pagination.active_page = 0;
      this.fun();
    }
  }
}
</script>