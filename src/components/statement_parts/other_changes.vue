<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row">
        <div class="col-auto">
          <button type="button" :class="button()" v-on:click="change()">Зміни Обтяжувача або Боржника та Інші зміни:</button>
        </div> 
      </div>
      <hr class="border-secondary border border-2" v-if="item.visible_status">
      <div class="row" v-if="item.visible_status" :class="colour">
          <div class="col">
            <div class="row">
              <div class="col-auto ms-3 border-bottom border-3 border-warning">
                <label class="col-form-label">Інші зміни:</label>
              </div>
              <div class="col-4">
                <select class="form-control" :disabled="editing_status"  v-model="item.changes_checked">
                  <option selected disabled>Оберіть ...</option>
                  <option v-for="it in changes" :key="it.number" :value="it.number">{{ it.name }}</option>
                </select>
              </div>
            </div>
            <hr class="border-secondary border border-2">
            <div class="row mt-2">
              <div class="col-auto ms-3 border-bottom border-3 border-warning">
                <label class="col-form-label">Зміни Обтяжувача або Боржника:</label>
              </div>
            </div>
            <hr class="border-secondary border border-2">
            <div class="row">
              <div class="col-auto">
                <label class="col-form-label">Тип змін:</label>
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
                      <WDInformation :item="element" button_text="" :editing_status="editing_status"/>
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
                      <WDInformation :item="element2" button_text="" :editing_status="editing_status"/>
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
import WDInformation from "./wd_information.vue";
import {EncumbranceTierDebtor} from "../../classes";
export default {
  data(){
    return {
      changes: null,
      changeType: null,
      element:null,
      element2:null,
    }
  },
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){change_item_visible_status(this.item)}
  },
  props:["item", "editing_status"],
  name:'OtherChanges',
  components:{
    WDInformation
  },
  created(){
    this.changes = [
      {number: 1, name: "Зареєструвати припинення обтяження"},
      {number: 2, name: "Зареєструвати звернення стягнення"},
      {number: 3, name: "Продовжити строк  дії  реєстраційного  запису  на   наступні 5 років"},
      {number: 4, name: "Виправити дату виникнення"},
      {number: 5, name: "Дата виникнення"}
    ];
    this.changeType = [
      {number:1, name: "Замінити  Обтяжувача"},
      {number:2, name: "Виправити Обтяжувача"},
      {number:3, name: "Замінити Боржника"},
      {number:4, name: "Вилучити  Боржника"},
      {number:5, name: "Додати  Боржника"},
      {number:6, name: "Виправити Боржника"}
    ];
    this.element = new EncumbranceTierDebtor(null, false, null);
    this.element2 = new EncumbranceTierDebtor(null, false, null);
    this.element.visible_status = true;
    this.element2.visible_status = true;
    this.element.short_info = true;
  }
}
</script>