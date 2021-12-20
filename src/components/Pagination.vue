<template>
  <div class="row mt-5">
    <div class="col-auto ms-3">
      <label class="col-form-label">Кількісь записів:</label>
    </div>
    <div class="col-auto me-5">
      <input type="number" class="form-control" @change="first_page()" style="width: 60px" v-model="pagination.max_items_count" min="1" max="7">
    </div>
    <nav class="col-7">
      <ul class="pagination justify-content-center">
        <span>
          <li class="page-item disabled" v-if="pagination.active_page == 0"><a class="page-link">Previous</a></li>
          <li class="page-item" v-else><a class="page-link" v-on:click="pagination_page(pagination.active_page)">Previous</a></li>
        </span>
        <span>
          <li class="page-item ms-1 me-1" v-if="part > 1">
            <a class="page-link" v-on:click="first_page()">1</a>
          </li>
        </span>
        <span v-for="item in pagination.count_page" :key="item">
          <li class="page-item ms-1 me-1 active" v-if="item == pagination.active_page+1">
            <a class="page-link" v-on:click="pagination_page(item)">{{item}}</a>
          </li>
          <li class="page-item ms-1 me-1" v-else-if="item <= part*max && item > (part-1)*max">
            <a class="page-link" v-on:click="pagination_page(item)">{{item}}</a>
          </li>
        </span>
        <span>
          <li class="page-item ms-1 me-1" v-if="part < Math.ceil(pagination.count_page / this.max) ">
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
      max: 5,
      part:1
    }
  },
  name: "Pagination",
  props:["pagination", "fun"],
  methods:{
    pagination_page(item){
      this.part = Math.ceil(item / this.max);
      this.pagination.active_page = item-1;
      this.fun();
    },
    load_next_page(){
      this.pagination.active_page = this.part*this.max;
      this.part +=1;
      this.fun();
    },
    first_page(){
      this.part = 1;
      this.pagination.active_page = 0;
      this.fun();
    }
  }
}
</script>