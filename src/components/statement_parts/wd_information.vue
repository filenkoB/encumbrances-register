<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row">
        <div class="col-auto" v-if="button_text.length != 0">
          <button type="button" :class="button()" v-on:click="change()">{{button_text}}</button>
        </div> 
      </div>
      <hr class="border-secondary border border-2" v-if="item.visible_status && button_text.length != 0">
      <div class="row" v-if="item.visible_status" :class="colour">
        <div class="col">
          <div class="row mb-2">
            <div class="col-auto">
              <label class="col-form-label">Ідентифікаційний номер / Код ЄДРПОУ:</label>
            </div>
            <div class="col-4">
              <input type="text" class="col-6 form-control" @change="changed" required :pattern="patterns.idNumber.str" :disabled="editing_status"  v-model="item.taxpayerAccountCardNumber">
            </div>
          </div>

          <hr class="border-secondary border border-2">
          <div class="row mb-2">
            <div class=" col-auto"></div>
            <div class=" col-auto mt-2 form-check">
            <input class="form-check-input" type="checkbox" value="" :checked="item.isForeigner" 
              v-on:click="foreigner()" :disabled="editing_status">
            </div>
            <div class="col-auto">
              <label class="col-form-label">Нерезидент / Іноземець:</label>
            </div>
            <div class="col-4" v-if="item.isForeigner">
              <input type="text" class="col-6 form-control" disabled value="Застосовується">
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
              <input type="text" class="col-6 form-control" @change="changed" required :pattern="patterns.text.str" :disabled="editing_status" v-model="item.name">
            </div>
          </div>
          
          <hr class="border-secondary border border-2">
          <div class="row mb-2 mt-1">
            <div class="col-10" :class="colour(item)">
              <div class="col-auto mb-3">
                <label>Адреса:</label>
              </div>
              <Address :path="item.address.path" :editing_status="editing_status"/>
            </div>
          </div>

          <hr class="border-secondary border border-2"  v-if="!item.short_info">
          <div class="row mb-2"  v-if="!item.short_info">
            <div class="col-auto">
              <label class="col-form-label">Додаткові відомості:</label>
            </div>
            <div class="col-9">
              <textarea class="form-control" rows="1" required :disabled="editing_status" v-model="item.typeDescription"></textarea>
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
import {validation} from "../../data";
export default {
  data() { return {} },
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){change_item_visible_status(this.item)},
    changed() {
      this.item.invalid = this.isInvalid();
      console.log(this.item.invalid);
    },
    isInvalid() {
      if(!this.patterns.idNumber.var.exec(this.item.taxpayerAccountCardNumber)) { return true; }
      if(!this.item.name || !this.patterns.text.var.exec(this.item.name)) { return true; }
      if(this.item.address.path.invalid) { return true; }
      return false;
    },
    foreigner(){
      if(this.item.isForeigner) this.item.isForeigner = false;
      else this.item.isForeigner = true}
  },
  props:["item", "button_text", "editing_status"],
  components:{ Address },
  name:'WDInformation',
  created() { this.patterns = validation.patterns;
  this.item.invalid = this.isInvalid();
  this.item.address.path.onChanged = this.changed;}
}
</script>