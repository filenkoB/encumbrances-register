<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row">
        <div class="col-auto">
          <button type="button" :class="button()" v-on:click="change()">Документ-підстава:</button>
        </div> 
      </div>
      <hr class="border-secondary border border-2" v-if="item.visible_status">
      <div id="document" class="row collapsible collapsed" v-if="item.visible_status" :class="colour">
        <div class="col">
          <div class="row mb-2">
            <div class="col-auto">
              <label class="col-form-label">Назва документу:</label>
            </div>
            <div class="col-10">
              <input type="text" class="col-6 form-control" @change="changed" required :pattern="patterns.text.str" :disabled="editing_status" v-model="item.name">
            </div>
          </div>

          <div class="row mb-2">
            <div class="col-auto">
              <label class="col-form-label">Номер документу:</label>
            </div>
            <div class="col-4">
              <input type="text" class="col-6 form-control" required @change="changed" :pattern="patterns.number.str" :disabled="editing_status" v-model="item.number">
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
              <input type="text" class="col-6 form-control" required @change="changed" :pattern="patterns.text.str" :disabled="editing_status" v-model="item.issuer">
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
        setTimeout(() => {const content = document.querySelector('#document');
        this.expandElement(content, 'collapsed', this.item, false);}, 100);
      }
      else {
        setTimeout(() => {const content = document.querySelector('#document');
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
    changed() {
      this.item.invalid = this.isInvalid();
    },
    isInvalid() {
      if(!this.patterns.text.var.exec(this.item.name)) { return true; }
      if(!this.patterns.number.var.exec(this.item.number)) {  return true; }
      if(!this.patterns.text.var.exec(this.item.issuer)) { return true; }
      return false;
    }
  },
  props:["item", "editing_status"],
  name:'Document',
  created() {
    this.patterns = validation.patterns;
    this.today = validation.today;
    this.item.invalid = this.isInvalid();
    this.item.change_visibility = this.change;
  },
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