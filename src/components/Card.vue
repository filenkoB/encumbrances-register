<template>
<div>
  <div v-for="card in cards" v-bind:key="card.type">
    <div v-if="card.type=='success'">
      <div v-show="card.status">
        <div class="card text-center">
          <div class="card-header">{{card.header}}</div>
          <div class="card-body">
            <h5 class="card-title">{{card.title}}</h5>
            <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
            <button type="button" class="btn btn-outline-success me-3" v-on:click="success(card)">Підтвертити дію</button>
            <button  type="button" class="btn btn-outline-danger ms-3" v-on:click="change(card)">Відмінити дію</button>    
          </div>
          <div class="card-footer text-muted">{{card.footer}}</div>
        </div>
      </div>
    </div>
    <div v-else-if="card.type=='danger'">
      <div v-show="card.status">
        <div class="card text-center">
          <div class="card-header">{{card.header}}</div>
          <div class="card-body">
            <h5 class="card-title">{{card.title}}</h5>
            <div class="row">
              <div class="col-auto me-3">
                <label class="col-form-label">Зазначте причину відхилення:</label>
              </div>
              <div class="col-auto">
                <div class="row mb-1" v-for="item in card.values" v-bind:key="item">
                  <div class=" col-auto mt-2 form-check" >
                    <input class="form-check-input" type="radio"
                    v-model="card.checked" :value="item">
                  </div>
                  <div class="col-auto">
                    <label class="col-form-label">{{item}}</label>
                  </div>
                </div>
              </div>
            </div>

            <button type="button" class="btn btn-outline-success me-3" v-on:click="success(card)">Підтвертити дію</button>
            <button  type="button" class="btn btn-outline-danger ms-3" v-on:click="change(card)">Відмінити дію</button>    
          </div>
          <div class="card-footer text-muted">{{card.footer}}</div>
        </div>
      </div>
    </div>
  </div>
</div>
</template>

<script>
export default {
  props: ["cards", "success"],
  methods:{
    change(item) {
      if(item.status == false){
        item.status = true;
      }
      else{
        item.status = false;
      } 
    }
  }
};
</script>
