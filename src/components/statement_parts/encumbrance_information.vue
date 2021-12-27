<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row">
        <div class="col-auto">
          <button type="button" :disabled="animating" :class="button()" v-on:click="change()">Відомості про обтяження:</button>
        </div> 
      </div>
      <hr class="border-secondary border border-2" v-if="item.visible_status">
      <div id="encumb-inf" class="row" v-if="item.visible_status" :class="get_collapsed_status()">
        <div class="col">
          <div class="row">
            <div class="col-auto border-end border-3 pe-5">
              <div class="row">
                <div class="col-auto me-3">
                  <label class="col-form-label">Вид обтяження:</label>
                </div>
                <div class="col-auto">
                  <div class="row mb-2" v-for="el in info.encumbranceKind" v-bind:key="el.id">
                    <div class=" col-auto mt-2 form-check" >
                      <input class="form-check-input" type="radio" v-model="item.encumbranceKindId" 
                      :disabled="editing_status" :value="el.id">
                    </div>
                    <div class="col-auto">
                      <label class="col-form-label">{{el.name}}</label>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="col-auto ms-5">
              <div class="row">
                <div class="col-auto me-3">
                  <label class="col-form-label">Тип реєстрації:</label>
                </div>
                <div class="col-auto">
                  <div class="row mb-2" v-for="el in info.registrationType" v-bind:key="el.id">
                    <div class=" col-auto mt-2 form-check" >
                      <input class="form-check-input" type="radio"
                      v-model="item.registrationTypeId" 
                      :disabled="editing_status" :value="el.id">
                    </div>
                    <div class="col-auto">
                      <label class="col-form-label">{{el.name}}</label>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          
          <hr class="border-secondary border border-2">
          <div class="row">
            <div class="col-auto">
              <label class="col-form-label">Дата виникнення попереднього обтяження:</label>
            </div>
            <div class="col-auto">
              <input type="date" class="col-6 form-control" required :max="today" :disabled="editing_status" :value="item.lastEncumbranceOccurrenceDate">
            </div>
          </div>
          
          <hr class="border-secondary border border-2">
          <div class="row">
            <div class="col-auto">
              <label class="col-form-label">Тип обтяження:</label>
            </div>
            <div class="col-auto ms-3 me-5" v-for="it in info.encumbranceType" v-bind:key="it.id">
              <div class="row mb-2" v-for="el in it.data" v-bind:key="el.id">
                <div class=" col-auto mt-2 form-check" >
                  <input class="form-check-input" @change="changed" type="radio"
                  v-model="item.encumbranceTypeId" 
                  :disabled="editing_status" :value="el.id">
                </div>
                <div class="col-auto">
                  <label class="col-form-label">{{el.name}}</label>
                </div>
              </div>
            </div>
          </div>

          <hr class="border-secondary border border-2">
          <div class="row">
            <div class="col-auto">
              <label class="col-form-label">Опис типу обтяження:</label>
            </div>
            <div class="col-9" v-if="item.encumbranceTypeId == '4b0a5256-60da-4d65-a0ce-3f7a50d85184'">
              <textarea class="form-control" rows="1" @change="changed" required :pattern="patterns.text.str" :disabled="editing_status" v-model="item.typeDescription"></textarea>
            </div>
            <div class="col-3" v-else>
              <input type="text" class="col-6 form-control" disabled value="Не застосовується">
            </div>
          </div>
          
          <hr class="border-secondary border border-2">
          <div class="row">
            <div class="col-auto me-3">
              <label class="col-form-label">Відомості про обмеження щодо відчуження:</label>
            </div>
            <div class="col-auto">
              <div class="row mb-2" v-for="it in info.alienationLimit" v-bind:key="it.id">
                <div class=" col-auto mt-2 form-check" >
                  <input class="form-check-input" type="radio" v-model="item.alienationLimitId" 
                  :disabled="editing_status" :value="it.id">
                </div>
                <div class="col-auto">
                  <label class="col-form-label">{{it.name}}</label>
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
  data() {
    return {
      animating: false
    }
  },
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){
      if(!this.editing_status) {
        this.animating = true;
        if(!this.item.visible_status) {
          change_item_visible_status(this.item);
          setTimeout(() => {const content = document.querySelector('#encumb-inf');
          this.expandElement(content, 'collapsed', this.item, false);}, 100);
        }
        else {
          setTimeout(() => {const content = document.querySelector('#encumb-inf');
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
      if(this.item.encumbranceTypeId == '4b0a5256-60da-4d65-a0ce-3f7a50d85184') { return true; }
      return false;
    }
  },
  props:["item", "editing_status", "info"],
  name:'EncumbranceInformation',
  created() { this.today = validation.today;
    this.patterns = validation.patterns;
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