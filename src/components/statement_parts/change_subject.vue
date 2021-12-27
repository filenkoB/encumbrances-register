<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row">
        <div class="col-auto">
          <button type="button" :class="button()" v-on:click="change()">Зміни предмета обтяження:</button>
        </div> 
      </div>
      <hr class="border-secondary border border-2" v-if="item.visible_status">
      <div class="row" v-if="item.visible_status" :class="colour">
          <div class="col">
            <div class="row">
              <div class="col-auto">
                <label class="col-form-label">Тип змін предмета обтяження:</label>
              </div>
              <div class="col-auto">
                <select class="form-control" :disabled="editing_status"  v-model="item.changeTypechecked">
                  <option selected disabled>Оберіть ...</option>
                  <option v-for="it in changeType" :key="it.number" :value="it.number">{{ it.name }}</option>
                </select>
              </div>
            </div>
            <hr class="border-secondary border border-2">
            <div class="row">
              <div class="col">
                  <div class="row mt-2">
                    <div class="col-1">
                      <label class="col-form-label">Вилучити:</label>
                    </div>
                    <div class="col-10 border-info border border-2 p-2 rounded" v-if="item.changeTypechecked!=5">
                      <EncumbranceDescriptionSubject :item="element" :button_vs="false" :editing_status="editing_status"/>
                    </div>
                    <div class="col-5 " v-else>
                      <input type="text" class="col-6 form-control" disabled value="Не застосовується">
                    </div>
                  </div>
                  <div class="row mt-2">
                    <div class="col-1">
                      <label class="col-form-label">Додати:</label>
                    </div>
                    <div class="col-10 border-info border border-2 p-2 rounded">
                      <EncumbranceDescriptionSubject :item="element2" :button_vs="false" :editing_status="editing_status"/>
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
import EncumbranceDescriptionSubject from "./encumbrance_description_subject.vue";
import {DescriptionSubject} from "../../classes";
export default {
  data(){
    return {
      changeType: null,
      element:null,
      element2: null
    }
  },
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){change_item_visible_status(this.item)}
  },
  props:["item", "editing_status"],
  name:'ChangeSubject',
  components:{
    EncumbranceDescriptionSubject
  },
  created(){
    this.changeType = [
      {number: 1, name: "Заміна   предмета"},
      {number: 2, name: "Вилучення   предмета"},
      {number: 3, name: "Додавання предмета"},
      {number: 4, name: "Виправлення предмета"},
    ];
    this.element = new DescriptionSubject(),
    this.element2 = new DescriptionSubject(),
    this.element.visible_status = true;
    this.element2.visible_status = true;
  }
}
</script>