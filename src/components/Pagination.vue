<template>
  <div class="row mt-5">
      <div class="col-auto ms-3">
        <label class="col-form-label">Кількісь записів:-</label>
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
</template>
<script>
export default {
    name: "Pagination",
    props:["pagination"],
    methods:{
      pagination_page(item){ this.pagination.active_page = item-1;},
      test(){
        if(this.pagination.active_page >= this.pagination.count_page){
        this.pagination.active_page = this.pagination.count_page -1;
      }
    }
    }
}
</script>