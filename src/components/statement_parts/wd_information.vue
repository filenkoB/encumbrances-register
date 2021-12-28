<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row">
        <div class="col-auto" v-if="button_text.length != 0">
          <button type="button" :disabled="animating" :class="button()" v-on:click="change()">{{button_text}}</button>
        </div> 
      </div>
      <hr class="border-secondary border border-2" v-if="item.visible_status && button_text.length != 0">
      <div :id="idname + '-info'" class="row" v-if="item.visible_status" :class="get_collapsed_status()">
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
              <input class="form-control" rows="1" @change="changed" :pattern="patterns.text.str" :disabled="editing_status" v-model="item.typeDescription">
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
  data() {
    return {
      animating: false
    }
  },
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){
      if (!this.editing_status) {
        this.animating = true;
        if(!this.item.visible_status) {
          change_item_visible_status(this.item);
          setTimeout(() => {const content = document.querySelector('#' + this.idname + '-info');
          this.expandElement(content, 'collapsed', this.item, false);}, 100);
        }
        else {
          setTimeout(() => {const content = document.querySelector('#' + this.idname + '-info');
          this.expandElement(content, 'collapsed', this.item, true);}, 100);
        }
      }
      else change_item_visible_status(this.item);
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
        this.animating = false;
      });
    },
    changed() {
      this.item.invalid = this.isInvalid();
    },
    get_collapsed_status() {
        if (!this.editing_status) return " collapsible collapsed";
        else return "";
    },
    isInvalid() {
      if(!this.patterns.idNumber.var.test(this.item.taxpayerAccountCardNumber)) { return true; }
      if(!this.item.name || !this.patterns.text.var.test(this.item.name)) { return true; }
      if(this.item.address.path.invalid) { return true; }
      if(this.item.typeDescription != null && (this.item.typeDescription.length > 0) && !this.patterns.text.var.test(this.item.typeDescription)) { return true; }
      return false;
    },
    foreigner(){
      if(this.item.isForeigner) this.item.isForeigner = false;
      else this.item.isForeigner = true}
  },
  props:["item", "button_text", "editing_status", "idname"],
  components:{ Address },
  name:'WDInformation',
  created() { this.patterns = validation.patterns;
    this.item.invalid = this.isInvalid();
    this.item.address.path.onChanged = this.changed;
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