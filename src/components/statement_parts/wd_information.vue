<template>
  <div class="row">
    <div class="col">
      <div class="row">
        <div class="col-auto">
          <button type="button" :class="button()" v-on:click="change()">{{button_text}}</button>
        </div> 
      </div>
      <hr class="border-secondary border border-2" v-if="item.visible_status">
      <div class="row" v-if="item.visible_status" :class="colour">
        <div class="col">
          <div class="row mb-2">
            <div class="col-auto">
              <label class="col-form-label">Ідентифікаційний номер / Код ЄДРПОУ:</label>
            </div>
            <div class="col-4">
              <input type="text" class="col-6 form-control" :disabled="editing_status"  :value="item.number.data">
            </div>
          </div>

          <hr class="border-secondary border border-2">
          <div class="row mb-2">
            <div class=" col-auto"></div>
            <div class=" col-auto mt-2 form-check">
            <input class="form-check-input" type="checkbox" value="" :checked="item.resident.visible_status" 
              v-on:click="change_address_vs(item.resident)" :disabled="editing_status">
            </div>
            <div class="col-auto">
              <label class="col-form-label">Нерезидент / Іноземець:</label>
            </div>
            <div class="col-9" v-if="item.resident.visible_status">
              <textarea class="form-control" rows="1" :disabled="editing_status" :value="item.resident.data"></textarea>
            </div>
            <div class="col-4" v-else>
              <input type="text" class="col-6 form-control" disabled value="Не застосовується">
            </div>
          </div>
          
          <hr class="border-secondary border border-2">
          <div class="row mb-2">
            <div class="col-auto">
              <label class="col-form-label">ПІБ / Назва:</label>
            </div>
            <div class="col-4">
              <input type="text" class="col-6 form-control" :disabled="editing_status" :value="item.obj_name.data">
            </div>
          </div>
          
          <hr class="border-secondary border border-2">
          <div class="row mb-2">
            <div class="col-auto mt-1">
              <button type="button" class="btn btn-primary"  
              v-on:click="change_address_vs(item.address)">Адреса:</button>
            </div>
            <div class="col-10" :class="colour(item)" 
              v-if="item.address.visible_status">
              <Address :path="item.address.path"/>
            </div>
            <div class="col-4 mt-1" v-else>
              <input type="text" class="col-6 form-control" disabled value="Натисніть кнопку щоб розгорнути">
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Address from "./Address.vue"
import {get_button_colour, get_class_colour, change_item_visible_status} from "../logic";
export default {
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){change_item_visible_status(this.item)},
    change_address_vs(el){change_item_visible_status(el)}
  },
  props:["item", "button_text", "editing_status"],
  components:{ Address },
  name:'WDInformation',  
}
</script>