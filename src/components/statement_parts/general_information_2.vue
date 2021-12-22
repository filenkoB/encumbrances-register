<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row" :class="colour">
          <div class="col">             
              <div class="row">
                <div class="col-auto">
                  <input class="form-check-input" type="radio" v-model="search_type" value="Вихідний номер:">
                </div>
                <div class="col-auto">
                  <label class="col-form-label">Вихідний номер:</label>
                </div>
                <div class="col-2">
                  <input type="text" class="form-control" :disabled="editing_status" v-model="search_info">
                </div>
              </div>
              <div class="row mt-2">
                <div class="col-auto">
                  <input class="form-check-input" type="radio" v-model="search_type" value="Контрольна сума запису:">
                </div>
                <div class="col-auto">
                  <label class="col-form-label">Контрольна сума запису:</label>
                </div>
                <div class="col-2">
                  <input type="text" class="form-control" :disabled="editing_status" v-model="search_info">
                </div>
              </div>
              <div class="row mt-2">
                <div class="col-auto">
                  <input class="form-check-input" type="radio" v-model="search_type" value="Реєстраційний номер запису в Державному реєстрі обтяжень рухомогомайна:">
                </div>
                <div class="col-auto">
                  <label class="col-form-label">Реєстраційний номер запису в Державному реєстрі обтяжень рухомогомайна:</label>
                </div>
                <div class="col-2">
                  <input type="text" class="form-control" :disabled="editing_status" v-model="search_info">
                </div>
              </div>
              <div class="row mt-4" v-if="!visible_status">
                <div class="col text-center">
                  <button class="btn btn-success" type="button">Пошук</button>
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
      search_type: "Вихідний номер:",
      search_info:null
    }
  },
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){change_item_visible_status(this.item)}
  },
  props:["item", "visible_status"],
  name:'GeneralInformation',  
}
</script>