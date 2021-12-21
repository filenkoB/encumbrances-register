<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row">
        <div class="col-auto">
          <button type="button" :class="button()" v-on:click="change()">Умови:</button>
        </div> 
      </div>
      <hr class="border-secondary border border-2" v-if="item.visible_status">
      <div class="row collapsible collapsed" v-if="item.visible_status" :class="colour">
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
                <span class="input-group-text" v-if="item.currencyTypeId">{{info.currency.filter(el=>el.id==item.currencyTypeId)[0].sign}}</span>
                <span class="input-group-text" v-else><i class="fa fa-money"></i></span>
                <select class="form-control" required @change="changed" :disabled="editing_status"  v-model="item.currencyTypeId">
                  <option v-for="it in info.currency" :key="it.id" :value="it.id">{{ it.name }}</option>
                </select>
              </div>
            </div>
          </div>

          <div class="row mb-2">
            <div class="col-auto">
              <label class="col-form-label">Строк виконання зобов'язання до:</label>
            </div>
            <div class="col-auto">
              <input type="date" class="col-6 form-control" required :min="tomorrow" :max="decadeAfter" :disabled="editing_status" v-model="item.termTo">
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
    change(){
      if(!this.item.visible_status) {
        change_item_visible_status(this.item);
        setTimeout(() => {const content = document.querySelector('.collapsible');
        this.expandElement(content, 'collapsed', this.item, false);}, 100);
      }
      else {
        setTimeout(() => {const content = document.querySelector('.collapsible');
        this.expandElement(content, 'collapsed', this.item, true);}, 100);
      }
    },
    expandElement(elem, collapseClass, item, hiding) {
      // debugger;
      elem.style.height = '';
      elem.style.transition = 'none';
      
      const startHeight = window.getComputedStyle(elem).height;
      
      // Remove the collapse class, and force a layout calculation to get the final height
      elem.classList.toggle(collapseClass);
      const height = window.getComputedStyle(elem).height;
      
      // Set the start height to begin the transition
      elem.style.height = startHeight;
      
      // wait until the next frame so that everything has time to update before starting the transition
      requestAnimationFrame(() => {
        elem.style.transition = '';
        
        requestAnimationFrame(() => {
            elem.style.height = height
        })
      })
      
      // Clear the saved height values after the transition
      elem.addEventListener('transitionend', () => {
        elem.style.height = '';
        elem.removeEventListener('transitionend', () => {});
        if (hiding) { change_item_visible_status(item); }
      });
    },
    change_status(el){change_item_visible_status(el)},
    changed() {
      this.item.invalid = this.isInvalid();
    },
    isInvalid() {
      if(!this.patterns.money.var.exec(this.item.obligationAmount)) { return true; }
      if(!this.item.currencyTypeId) { return true; }
      if(!this.patterns.text.var.exec(this.item.additionalTerms)) { return true;}
      return false;
    }
  },
  props:["item", "editing_status", "info"],
  name:'Terms',
  created() {
    this.patterns = validation.patterns;
    this.tomorrow = validation.tomorrow;
    this.decadeAfter = validation.decadeAfter;
    this.item.invalid = this.isInvalid();
    this.item.change_visibility = this.change;
  }
}
</script>
<style>
  .collapsible {
    overflow: hidden;
    transition: all 0.5s ease-in-out;
    height: auto;
  }

  .collapsible.collapsed {
    height: 0;
  }
</style>