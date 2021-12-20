<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row">
        <div class="col-auto">
          <button type="button" :class="button()" v-on:click="change()">Умови:</button>
        </div> 
      </div>
      <hr class="border-secondary border border-2" v-if="item.visible_status">
      <div class="row" v-if="item.visible_status" :class="colour">
        <div class="col">
          <div class="row mb-2">
            <div class="col-auto">
              <label class="col-form-label">Розмір зобов'язання або вимоги:</label>
            </div>
            <div class="col-auto">
              <input type="text" class="col-6 form-control" @change="changed" required :pattern="patterns.money.str" :disabled="editing_status" v-model="item.obligationAmount">
            </div>
            <div class="col-auto">
              <label class="col-form-label">Вид валюти:</label>
            </div>
            <div class="col-2">
              <div class="input-group mb-3">
                <span class="input-group-text" v-if="item.currencyTypeId">{{currency_type.filter(el=>el.id==item.currencyTypeId)[0].sign}}</span>
                <span class="input-group-text" v-else><i class="fa fa-money"></i></span>
                <select class="form-control" required :disabled="editing_status"  v-model="item.currencyTypeId">
                  <option v-for="it in currency_type" :key="it.id" :value="it.id">{{ it.name }}</option>
                </select>
              </div>
            </div>
          </div>

          <div class="row mb-2">
            <div class="col-auto">
              <label class="col-form-label">Строк виконання зобов'язання до:</label>
            </div>
            <div class="col-auto">
              <input type="date" class="col-6 form-control" required :min="tomorrow" :max="decadeAfter" :disabled="editing_status" v-model="item.termTo.split('T')[0]">
            </div>
          </div>

          <div class="row">
            <div class="col-auto">
              <label class="col-form-label">Додаткові умови, у тому числі відомості про особу, на користь якої встановлено публічне обтяження:</label>
            </div>
            <div class="col-9">
              <textarea class="form-control" rows="1" @change="changed" required :pattern="patterns.text.str" :disabled="editing_status" v-model="item.additionalTerms"></textarea>
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
    change(){change_item_visible_status(this.item)},
    change_status(el){change_item_visible_status(el)},
    changed() {
      this.item.invalid = this.isInvalid();
    },
    isInvalid() {
      if(!this.patterns.money.var.exec(this.item.obligationAmount)) { return true; }
      if(!this.currencyTypeId) { return true; }
      if(!this.patterns.text.var.exec(this.item.additionalTerms)) { return true;}
      return false;
    }
  },
  props:["item", "editing_status", "currency_type"],
  name:'Terms',
  created() {
    this.patterns = validation.patterns;
    this.tomorrow = validation.tomorrow;
    this.decadeAfter = validation.decadeAfter;
    this.item.invalid = this.isInvalid();
    }
}
</script>