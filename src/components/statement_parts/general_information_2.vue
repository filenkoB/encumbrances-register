<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row">
        <pre>
          search_type:{{search_type}}
          search_info:{{search_info}}
        </pre>
      </div>
      <div class="row" :class="colour">
          <div class="col">             
              <div class="row">
                <div class="col-auto">
                  <input class="form-check-input" type="radio" @change="clear()"
                  v-model="search_type" value="0">
                </div>
                <div class="col-auto">
                  <label class="col-form-label">Вихідний номер:</label>
                </div>
                <div class="col-2">
                  <input type="text" class="form-control" :disabled="search_type!='0'" v-model="search_info.number">
                </div>
              </div>
              <div class="row mt-2">
                <div class="col-auto">
                  <input class="form-check-input" type="radio" @change="clear()"
                  v-model="search_type" value="1">
                </div>
                <div class="col-auto">
                  <label class="col-form-label">Контрольна сума запису:</label>
                </div>
                <div class="col-2">
                  <input type="text" class="form-control" :disabled="search_type!='1'" v-model="search_info.number1">
                </div>
              </div>
              <div class="row mt-2">
                <div class="col-auto">
                  <input class="form-check-input" type="radio" @change="clear()" 
                  v-model="search_type" value="2">
                </div>
                <div class="col-auto">
                  <label class="col-form-label">Реєстраційний номер запису в Державному реєстрі обтяжень рухомогомайна:</label>
                </div>
                <div class="col-2">
                  <input type="text" class="form-control" :disabled="search_type!='2'" v-model="search_info.number2">
                </div>
              </div>
              <div class="row mt-4">
                <div class="col text-center">
                  <button class="btn btn-success" type="button" @click="button_search({type:search_type, info:search_info})">Пошук</button>
                </div>
              </div>
          </div>
      </div>
    </div>
  </div>
</template>
<script>
import {get_button_colour, get_class_colour, change_item_visible_status} from "../logic";
export default {
  data(){
    return {
      search_type: "1",
      search_info: {}
    }
  },
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){change_item_visible_status(this.item)},
    
    clear(){this.search_info = {}}
  },
  props:["item", "visible_status", "button_search"],
  name:'GeneralInformation',  
}
</script>