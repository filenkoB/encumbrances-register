<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row">
        <div class="col-auto" v-if="button_vs">
          <button type="button" :class="button()" v-on:click="change()">Опис предмету обтяження:</button>
        </div> 
      </div>
      <hr class="border-secondary border border-2" v-if="item.visible_status && button_vs">
      <div class="row" v-if="item.visible_status" :class="colour">
        <div class="col">
          <div class="row m-1">
            <label>Рухоме майно що має серійні номери:</label>
          </div>
          <div class="row mt-2 m-2 p-2 border border-secondary rounded">
            <div class="col">
              <div class="row">
                <div class="col-auto">
                  <label class="col-form-label">Опис майна:</label>
                </div>
                <div class="col-4">
                  <input type="text" class="col-6 form-control" @change="changed" required :pattern="patterns.text.str" :disabled="editing_status" v-model="item.name">
                </div>
              </div>
              <div class="row mt-2">
                <div class="col-auto">
                  <label class="col-form-label">Серійний номер:</label>
                </div>
                <div class="col-4">
                  <input type="text" class="col-6 form-control" @change="changed" :pattern="patterns.serialNum.str" required :disabled="editing_status" v-model="item.number">
                </div>
              </div>
              <div class="row mt-2">
                <div class="col-auto">
                  <label class="col-form-label">Номер державної реєстрації:</label>
                </div>
                <div class="col-4">
                  <input type="text" class="col-6 form-control" @change="changed" :pattern="patterns.number.str" required :disabled="editing_status" v-model="item.number_2">
                </div>
              </div>
            </div> 
          </div>
          <div class="row m-1">
            <label>Рухоме майно, крім описаного вище за серійними номерами (якщо відсутнє, ввести "Немає"):</label>
          </div>
          <div class="row mt-2 m-2 ">
            <div class="col">
              <div class="row">
                <div class="col-12">
                  <textarea class="form-control" rows="1" @change="changed" required :pattern="patterns.text.str" :disabled="editing_status" v-model="item.value"></textarea>
                </div>
              </div>
            </div> 
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import {get_button_colour, get_class_colour, change_item_visible_status} from "../logic";
import {validation} from "../../data";
export default {
  data(){
    return{
      currency_type: null,
    }
  },
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){change_item_visible_status(this.item)},
    change_status(el){change_item_visible_status(el)},
    changed() {
      this.item.invalid = this.isInvalid();
    },
    isInvalid() {
      if(!this.patterns.text.var.exec(this.item.name)) { return true; }
      if(!this.patterns.serialNum.var.exec(this.item.number)) {  return true; }
      if(!this.patterns.number.var.exec(this.item.number_2)) { return true; }
      if(!this.patterns.text.var.exec(this.item.value)) { return true;}
      return false;
    }
  },
  props:["item", "editing_status", "button_vs"],
  name:'EncumbranceDescriptionSubject',
  created() { this.patterns = validation.patterns; this.item.invalid = this.isInvalid();}  
}
</script>