<template>
  <div class="row" v-if="item">
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
                  <div class="row mb-2" v-for="el in item.encumbrance_type.data" v-bind:key="el.number">
                    <div class=" col-auto mt-2 form-check" >
                      <input class="form-check-input" type="radio" v-model="item.encumbrance_type.encumbranceKindId" 
                      :disabled="editing_status" :value="el.number">
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
              <input type="date" class="col-6 form-control" required :max="today" :disabled="editing_status" :value="item.lastEncumbranceOccurrenceDate.split('T')[0]">
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
                  <input class="form-check-input" type="radio"
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
              <textarea class="form-control" rows="1" required :pattern="patterns.text.str" :disabled="editing_status" :value="item.typeDescription"></textarea>
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
  data() { return {} },
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){change_item_visible_status(this.item)}
  },
  props:["item", "editing_status", "info"],
  name:'EncumbranceInformation',
  created() { this.today = validation.today; this.patterns = validation.patterns; }
}
</script>