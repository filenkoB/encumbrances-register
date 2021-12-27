<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row" :class="colour">
          <div class="col">             
              <div class="row mt-2">
                <div class="col-auto">
                  <label class="col-form-label">Реєстраційний номер запису в Державному реєстрі обтяжень рухомого майна:</label>
                </div>
                <div class="col-2">
                  <input type="text" class="form-control" v-model="search_info">
                </div>
              </div>
              <div class="row mt-4">
                <div class="col text-center">
                  <button class="btn btn-success" type="button" @click="button_search(search_info)">Пошук</button>
                </div>
              </div>
              <div class="row border border-4 p-3 mt-2 rounded" v-if="text!=null">
                <div class="col text-center">
                  <label>{{text}}</label>
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
      search_info: null
    }
  },
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){change_item_visible_status(this.item)},
    
    clear(){this.search_info = {}}
  },
  props:["item", "visible_status", "button_search", "text"],
  name:'GeneralInformation',  
}
</script>