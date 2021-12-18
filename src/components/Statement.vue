<template>
  <form class="p-3 border border-secondary border-2 rounded text-start">
    <button type="button" :class="button(element.general_information)" v-on:click="change(element.general_information)">
      Загальні інформація:
    </button>

    <div v-if="element.general_information.visible_status" :class="colour(element.general_information)">
      <div class="row">
        <div class="col-auto">
          <label class="col-form-label">Вихідний номер:</label>
        </div>
        <div class="col-4">
          <input type="text" class="col-6 form-control" :disabled="editing_status" :value="element.general_information.number.data">
        </div>
        <div class="col-auto ms-5">
          <label class="col-form-label">Дата заяви:</label>
        </div>
        <div class="col-4">
          <input type="date" class="col-6 form-control" :disabled="editing_status" :value="element.general_information.date.data">
        </div>
      </div>
    </div>

    <hr class="border-primary border border-2">
    <button type="button" :class="button(element.weightlifter_information)" v-on:click="change(element.weightlifter_information)">
      Відомості про Обтяжувача:
    </button>

    <div v-if="element.weightlifter_information.visible_status" :class="colour(element.weightlifter_information)">
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">Ідентифікаційний номер / Код ЄДРПОУ:</label>
        </div>
        <div class="col-4">
          <input type="text" class="col-6 form-control" :disabled="editing_status"  :value="element.weightlifter_information.number.data">
        </div>
      </div>
      <hr class="border-secondary border border-2">
      <div class="row mb-2">
        <div class=" col-auto"></div>
        <div class=" col-auto mt-2 form-check">
          <input class="form-check-input" type="checkbox" value="" 
          :checked="element.weightlifter_information.resident.visible_status" 
          v-on:click="change(element.weightlifter_information.resident)"
          :disabled="editing_status">
        </div>
        <div class="col-auto">
          <label class="col-form-label">Нерезидент / Іноземець:</label>
        </div>
        <div class="col-9" v-if="element.weightlifter_information.resident.visible_status">
          <textarea class="form-control" rows="1" :disabled="editing_status" :value="element.weightlifter_information.resident.data"></textarea>
        </div>
        <div class="col-4" v-else>
          <input type="text" class="col-6 form-control" disabled value="не застосовується">
        </div>
      </div>
      <hr class="border-secondary border border-2">
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">ПІБ / Назва:</label>
        </div>
        <div class="col-4">
          <input type="text" class="col-6 form-control" :disabled="editing_status" :value="element.weightlifter_information.obj_name.data">
        </div>
      </div>
      <hr class="border-secondary border border-2">
      <div class="row mb-2">
        <div class="col-auto mt-1">
          <button type="button" class="btn btn-primary"  
          v-on:click="change(element.weightlifter_information.address)">Адреса:</button>
        </div>
        <div class="col-10" :class="colour(element.weightlifter_information)" 
          v-if="element.weightlifter_information.address.visible_status">
          <Address :path="element.weightlifter_information.address.path"/>
        </div>
        <div class="col-4 mt-1" v-else>
          <input type="text" class="col-6 form-control" disabled value="Натисніть кнопку щоб розгорнути">
        </div>
      </div>
    </div>

    <hr class="border-info border border-2">
    <button type="button" :class="button(element.debtor_information)"  v-on:click="change(element.debtor_information)">
      Відомості про Боржника:
    </button>

    <div v-if="element.debtor_information.visible_status" :class="colour(element.debtor_information)">
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">Ідентифікаційний номер / Код ЄДРПОУ:</label>
        </div>
        <div class="col-4">
          <input type="text" class="col-6 form-control" :disabled="editing_status" :value="element.debtor_information.number.data">
        </div>
      </div>
      <hr class="border-secondary border border-2">
      <div class="row mb-2">
        <div class=" col-auto"></div>
        <div class=" col-auto mt-2 form-check">
          <input class="form-check-input" type="checkbox" value="" 
          :checked="element.debtor_information.resident.visible_status" 
          v-on:click="change(element.debtor_information.resident)"
          :disabled="editing_status">
        </div>
        <div class="col-auto">
          <label class="col-form-label">Нерезидент / Іноземець:</label>
        </div>
        <div class="col-9" v-if="element.debtor_information.resident.visible_status">
          <textarea class="form-control" rows="1" :disabled="editing_status" :value="element.debtor_information.resident.data"></textarea>
        </div>
        <div class="col-4" v-else>
          <input type="text" class="col-6 form-control" disabled value="не застосовується">
        </div>
      </div>
      <hr class="border-secondary border border-2">
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">ПІБ / Назва:</label>
        </div>
        <div class="col-4">
          <input type="text" class="col-6 form-control" :disabled="editing_status" :value="element.debtor_information.obj_name.data">
        </div>
      </div>
      <hr class="border-secondary border border-2">
      <div class="row mb-2">
        <div class="col-auto mt-1">
          <button type="button" class="btn btn-primary"  v-on:click="change(element.debtor_information.address)">Адреса:</button>
        </div>
        <div class="col-10" :class="colour(element.debtor_information)" 
          v-if="element.debtor_information.address.visible_status">
          <Address :path="element.debtor_information.address.path"/>
        </div>
        <div class="col-4 mt-1" v-else>
          <input type="text" class="col-6 form-control" disabled value="Натисніть кнопку щоб розгорнути">
        </div>
      </div>
    </div>

    <hr class="border-primary border border-2">
    <button type="button" :class="button(element.document)"  v-on:click="change(element.document)">
      Документ-підстава:
    </button>

    <div v-if="element.document.visible_status" :class="colour(element.document)">
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">Назва документу:</label>
        </div>
        <div class="col-10">
          <input type="text" class="col-6 form-control" :disabled="editing_status" :value="element.document.name.data">
        </div>
      </div>
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">Номер документу:</label>
        </div>
        <div class="col-4">
          <input type="text" class="col-6 form-control" :disabled="editing_status" :value="element.document.number.data">
        </div>
        <div class="col-auto">
          <label class="col-form-label">Дата документу:</label>
        </div>
        <div class="col-4">
          <input type="date" class="col-6 form-control" :disabled="editing_status" :value="element.document.date.data">
        </div>
      </div>
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">Видавець документу:</label>
        </div>
        <div class="col-9">
          <input type="text" class="col-6 form-control" :disabled="editing_status" :value="element.document.publisher.data">
        </div>
      </div>
    </div>

    <hr class="border-info border border-2">
    <button type="button" :class="button(element.encumbrance_information)"  v-on:click="change(element.encumbrance_information)">
      Відомості про обтяження:
    </button>

    <div v-if="element.encumbrance_information.visible_status" :class="colour(element.encumbrance_information)">
      <div class="row">
        <div class="col-auto border-end border-3 pe-5">
          <div class="row">
            <div class="col-auto me-3">
              <label class="col-form-label">Вид обтяження:</label>
            </div>
            <div class="col-auto">
              <div class="row mb-2" v-for="item in element.encumbrance_information.encumbrance_type.data" v-bind:key="item">
                <div class=" col-auto mt-2 form-check" >
                  <input class="form-check-input" type="radio"
                  v-model="element.encumbrance_information.encumbrance_type.checked" 
                  :disabled="editing_status" :value="item">
                </div>
                <div class="col-auto">
                  <label class="col-form-label">{{item}}</label>
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
              <div class="row mb-2" v-for="item in element.encumbrance_information.registration_type.data" v-bind:key="item">
                <div class=" col-auto mt-2 form-check" >
                  <input class="form-check-input" type="radio"
                  v-model="element.encumbrance_information.registration_type.checked" 
                  :disabled="editing_status" :value="item">
                </div>
                <div class="col-auto">
                  <label class="col-form-label">{{item}}</label>
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
          <input type="date" class="col-6 form-control" :disabled="editing_status" :value="element.encumbrance_information.date.data">
        </div>
      </div>
      <hr class="border-secondary border border-2">

      <div class="row">
        <div class="col-auto">
          <div class="row">
            <div class="col-auto">
              <label class="col-form-label">Тип обтяження:</label>
            </div>
            <div class="col-auto ms-3 me-5" v-for="item in element.encumbrance_information.type_encumbrance.data" v-bind:key="item">
              <div class="row mb-2" v-for="el in item" v-bind:key="el">
                <div class=" col-auto mt-2 form-check" >
                  <input class="form-check-input" type="radio"
                  v-model="element.encumbrance_information.type_encumbrance.checked" 
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
        <div class="col-auto me-3">
          <label class="col-form-label">Відомості про обмеження щодо відчуження:</label>
        </div>
        <div class="col-auto">
          <div class="row mb-2" v-for="item in element.encumbrance_information.information.data" v-bind:key="item">
            <div class=" col-auto mt-2 form-check" >
              <input class="form-check-input" type="radio"
              v-model="element.encumbrance_information.information.checked" 
              :disabled="editing_status" :value="item">
            </div>
            <div class="col-auto">
              <label class="col-form-label">{{item}}</label>
            </div>
          </div>
        </div>
      </div>
      <hr class="border-secondary border border-2">

      <div class="row">
        <div class="col-auto"></div>
        <div class=" col-auto mt-2 form-check">
          <input class="form-check-input" type="checkbox" value="" 
          :checked="element.encumbrance_information.type_description.visible_status" 
          v-on:click="change(element.encumbrance_information.type_description)"
          :disabled="editing_status">
        </div>
        <div class="col-auto">
          <label class="col-form-label">Опис типу обтяження:</label>
        </div>
        <div class="col-9" v-if="element.encumbrance_information.type_description.visible_status">
          <textarea class="form-control" rows="1" :disabled="editing_status" :value="element.encumbrance_information.type_description.data"></textarea>
        </div>
        <div class="col-3" v-else>
          <input type="text" class="col-6 form-control" disabled value="не застосовується">
        </div>
      </div>
    </div>

    <hr class="border-primary border border-2">
    <button type="button" :class="button(element.terms)"  v-on:click="change(element.terms)">
      Умови:
    </button>

    <div v-if="element.terms.visible_status" :class="colour(element.terms)">
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">Розмір зобов'язання або вимоги:</label>
        </div>
        <div class="col-auto">
          <input type="text" class="col-6 form-control" :disabled="editing_status" :value="element.terms.number.data">
        </div>
        <div class="col-auto">
          <label class="col-form-label">Вид валюти:</label>
        </div>
        <div class="col-2">
          <div class="input-group mb-3">
            <span class="input-group-text" v-if="element.terms.currency_type != 'Оберіть ...'">{{currency_type.filter(el=>el.id==element.terms.currency_type)[0].sign}}</span>
            <span class="input-group-text" v-else><i class="fa fa-money"></i></span>
            <select class="form-control" :disabled="editing_status"  v-model="element.terms.currency_type">
              <option selected disabled>Оберіть ...</option>
              <option v-for="item in currency_type" :key="item.id" :value="item.id">{{ item.name }}</option>
            </select>
          </div>
        </div>
      </div>
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">Строк виконання зобов'язання до:</label>
        </div>
        <div class="col-auto">
          <input type="date" class="col-6 form-control" :disabled="editing_status" :value="element.terms.date.data">
        </div>
      </div>
      <div class="row">
        <div class="col-auto"></div>
        <div class=" col-auto mt-2 form-check">
          <input class="form-check-input" type="checkbox" value="" 
          :checked="element.terms.publisher.visible_status" 
          v-on:click="change(element.terms.publisher)"
          :disabled="editing_status">
        </div>
        <div class="col-auto">
          <label class="col-form-label">Додаткові умови, у тому числі відомості про особу, на користь якої встановлено публічне обтяження:</label>
        </div>
        <div class="col-9" v-if="element.terms.publisher.visible_status">
          <textarea class="form-control" rows="1" :disabled="editing_status" :value="element.terms.publisher.data"></textarea>
        </div>
        <div class="col-3" v-else>
          <input type="text" class="col-6 form-control" disabled value="не застосовується">
        </div>
      </div>
    </div>
  </form>
</template>

<script>
//import { Weightlifter_Information, Debtor_Information, Basis_Document, Encumbrance_Information, Terms} from '../classes'
import {address, statement} from "../data";
import Address from "./Address.vue"
export default {
   data: function () {
    return {
      byffer: {
        weightlifter_information:{},
        debtor_information:{}
      },
      element:null,
      full_address: address,
      currency_type: []
    }
  },
  name: 'Statement',
  props: ["statement_element","editing_status"],
  components:{
    Address
  },
  methods: {
    change: function (pos) {
      if(!pos.visible_status) pos.visible_status = true;
      else pos.visible_status = false;
    },
    colour(item){
      if(item.visible_status) return " align-items-center p-3 m-1 border border-dark rounded";
      return " align-items-center p-3 m-1 border border-secondary rounded";
    },
    button(item){
      if(item.visible_status) return "btn btn-primary m-1";
      return "btn btn-outline-secondary m-1";
    }
  },
  created(){
    fetch(process.env.VUE_APP_HEROKU_PATH + "/CurrencyType")
    .then(response =>{
      if( response.status == 200){
        response.json().then(data=>this.currency_type=data)
      }
    })
    this.element = statement;
  }
}
</script>