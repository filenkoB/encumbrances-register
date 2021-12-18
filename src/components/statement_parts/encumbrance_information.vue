<template>
  <div class="row">
    <div class="col">
      <div class="row">
        <div class="col-auto">
          <button type="button" :class="button()" v-on:click="change()">Відомості про обтяження:</button>
        </div> 
      </div>
      <hr class="border-secondary border border-2" v-if="item.visible_status">
      <div class="row" v-if="item.visible_status" :class="colour">
        <div class="col">
          <div class="row">
            <div class="col-auto border-end border-3 pe-5">
              <div class="row">
                <div class="col-auto me-3">
                  <label class="col-form-label">Вид обтяження:</label>
                </div>
                <div class="col-auto">
                  <div class="row mb-2" v-for="el in item.encumbrance_type.data" v-bind:key="el">
                    <div class=" col-auto mt-2 form-check" >
                      <input class="form-check-input" type="radio" v-model="item.encumbrance_type.checked" 
                      :disabled="editing_status" :value="el">
                    </div>
                    <div class="col-auto">
                      <label class="col-form-label">{{el}}</label>
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
                  <div class="row mb-2" v-for="el in item.registration_type.data" v-bind:key="el">
                    <div class=" col-auto mt-2 form-check" >
                      <input class="form-check-input" type="radio"
                      v-model="item.registration_type.checked" 
                      :disabled="editing_status" :value="el">
                    </div>
                    <div class="col-auto">
                      <label class="col-form-label">{{el}}</label>
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
              <input type="date" class="col-6 form-control" :disabled="editing_status" :value="item.date.data">
            </div>
          </div>
          
          <hr class="border-secondary border border-2">
          <div class="row">
            <div class="col-auto">
              <label class="col-form-label">Тип обтяження:</label>
            </div>
            <div class="col-auto ms-3 me-5" v-for="it in item.type_encumbrance.data" v-bind:key="it">
              <div class="row mb-2" v-for="el in it" v-bind:key="el">
                <div class=" col-auto mt-2 form-check" >
                  <input class="form-check-input" type="radio"
                  v-model="item.type_encumbrance.checked" 
                  :disabled="editing_status" :value="el">
                </div>
                <div class="col-auto">
                  <label class="col-form-label">{{el}}</label>
                </div>
              </div>
            </div>
          </div>
          
          <hr class="border-secondary border border-2">
          <div class="row">
            <div class="col-auto me-3">
              <label class="col-form-label">Відомості про обмеження щодо відчуження:</label>
            </div>
            <div class="col-auto">
              <div class="row mb-2" v-for="it in item.information.data" v-bind:key="it">
                <div class=" col-auto mt-2 form-check" >
                  <input class="form-check-input" type="radio" v-model="item.information.checked" 
                  :disabled="editing_status" :value="it">
                </div>
                <div class="col-auto">
                  <label class="col-form-label">{{it}}</label>
                </div>
              </div>
            </div>
          </div>

          <hr class="border-secondary border border-2">
          <div class="row">
            <div class="col-auto"></div>
            <div class=" col-auto mt-2 form-check">
              <input class="form-check-input" type="checkbox" value="" 
              :checked="item.type_description.visible_status" 
              v-on:click="change(item.type_description)"
              :disabled="editing_status">
            </div>
            <div class="col-auto">
              <label class="col-form-label">Опис типу обтяження:</label>
            </div>
            <div class="col-9" v-if="item.type_description.visible_status">
              <textarea class="form-control" rows="1" :disabled="editing_status" :value="item.type_description.data"></textarea>
            </div>
            <div class="col-3" v-else>
              <input type="text" class="col-6 form-control" disabled value="Не застосовується">
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
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){change_item_visible_status(this.item)}
  },
  props:["item", "editing_status"],
  name:'EncumbranceInformation',  
}
</script>