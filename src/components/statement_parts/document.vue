<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row">
        <div class="col-auto">
          <button type="button" :class="button()" v-on:click="change()">Документ-підстава:</button>
        </div> 
      </div>
      <hr class="border-secondary border border-2" v-if="item.visible_status">
      <div class="row" v-if="item.visible_status" :class="colour">
        <div class="col">
          <div class="row mb-2">
            <div class="col-auto">
              <label class="col-form-label">Назва документу:</label>
            </div>
            <div class="col-10">
              <input type="text" class="col-6 form-control" required :pattern="patterns.text.str" :disabled="editing_status" v-model="item.name">
            </div>
          </div>

          <div class="row mb-2">
            <div class="col-auto">
              <label class="col-form-label">Номер документу:</label>
            </div>
            <div class="col-4">
              <input type="text" class="col-6 form-control" required :pattern="patterns.number.str" :disabled="editing_status" v-model="item.number">
            </div>
            <div class="col-auto">
              <label class="col-form-label">Дата документу:</label>
            </div>
            <div class="col-auto">
              <input type="date" class="col-6 form-control" required :max="today" :disabled="editing_status" v-model="item.issueDate">
            </div>
          </div>

          <div class="row mb-2">
            <div class="col-auto">
              <label class="col-form-label">Видавець документу:</label>
            </div>
            <div class="col-9">
              <input type="text" class="col-6 form-control" required :pattern="patterns.text.str" :disabled="editing_status" v-model="item.issuer">
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import {get_button_colour, get_class_colour, change_item_visible_status} from "../logic";
import {validation} from "../../data"
export default {
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){change_item_visible_status(this.item)}
  },
  props:["item", "editing_status"],
  name:'Document',
  created() {
    this.patterns = validation.patterns;
    this.today = validation.today;
  }  
}
</script>