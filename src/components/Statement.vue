<template>
  <form class="p-3 border border-secondary border-2 rounded text-start">
    
    <button type="button" :class="element.general_information.button()" v-on:click="change(element.general_information)">
      Загальні інформація:
    </button>

    <div v-if="element.general_information.status" :class="element.general_information.colour()">
      <div class="row">
        <div class="col-auto">
          <label class="col-form-label">Вихідний номер:</label>
        </div>
        <div class="col-4">
          <input type="text" class="col-6 form-control" :disabled="element.editing_status" :value="element.general_information.number.data">
        </div>
        <div class="col-auto ms-5">
          <label class="col-form-label">Дата заяви:</label>
        </div>
        <div class="col-4">
          <input type="date" class="col-6 form-control" :disabled="element.editing_status" :value="element.general_information.date.data">
        </div>
      </div>
    </div>

    <hr class="border-primary border border-2">
    <button type="button" :class="element.weightlifter_information.button()" v-on:click="change(element.weightlifter_information)">
      Відомості про Обтяжувача:
    </button>

    <div v-if="element.weightlifter_information.status" :class="element.weightlifter_information.colour()">
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">Ідентифікаційний номер / Код ЄДРПОУ:</label>
        </div>
        <div class="col-4">
          <input type="text" class="col-6 form-control" :disabled="element.editing_status"  :value="element.weightlifter_information.number.data">
        </div>
      </div>
      <hr class="border-secondary border border-2">
      <div class="row mb-2">
        <div class=" col-auto"></div>
        <div class=" col-auto mt-2 form-check">
          <input class="form-check-input" type="checkbox" value="" 
          :checked="element.weightlifter_information.resident.status" 
          v-on:click="change(element.weightlifter_information.resident)"
          :disabled="element.editing_status">
        </div>
        <div class="col-auto">
          <label class="col-form-label">Нерезидент / Іноземець:</label>
        </div>
        <div class="col-9" v-if="element.weightlifter_information.resident.status">
          <textarea class="form-control" rows="1" :disabled="element.editing_status" :value="element.weightlifter_information.resident.data"></textarea>
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
          <input type="text" class="col-6 form-control" :disabled="element.editing_status" :value="element.weightlifter_information.obj_name.data">
        </div>
      </div>
      <hr class="border-secondary border border-2">
      <div class="row mb-2">
        <div class="col-auto mt-1">
          <button type="button" class="btn btn-primary"  v-on:click="change(element.weightlifter_information.address)">Адреса:</button>
        </div>
        <div class="col-10" :class="element.weightlifter_information.colour()" v-if="element.weightlifter_information.address.status">
          <div class="row mb-2">
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Країна:</label>
            </div>
             <div class="col-auto">
               <input type="data" class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.country.data">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Індекс:</label>
            </div>
             <div class="col-auto">
               <input type="data"class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.index.data">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Область:</label>
            </div>
             <div class="col-4">
               <input type="data" class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.region.data">
            </div>
          </div>

          <hr class="border-secondary border border-1">
          <div class="row mb-2">
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Район:</label>
            </div>
             <div class="col-3">
               <input type="text" class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.area.data">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Місто/селище:</label>
            </div>
            <div class="col-auto">
               <input type="text" class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.city.data">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Вилиця:</label>
            </div>
            <div class="col-auto">
               <input type="text" class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.street.data">
            </div>
          </div>

          <hr class="border-secondary border border-1">
          <div class="row mb-2">
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Будинок:</label>
            </div>
            <div class="col-auto">
               <input type="data" class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.build.data">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Корпус:</label>
            </div>
             <div class="col-auto">
               <input type="data" class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.corps.data">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Квартира:</label>
            </div>
             <div class="col-auto">
               <input type="data" class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.flat.data">
            </div>
          </div>
        </div>
        <div class="col-4 mt-1" v-else>
          <input type="text" class="col-6 form-control" disabled value="Натисніть кнопку щоб розгорнути">
        </div>
      </div>
    </div>

    <hr class="border-info border border-2">
    <button type="button" :class="element.debtor_information.button()"  v-on:click="change(element.debtor_information)">
      Відомості про Боржника:
    </button>

    <div v-if="element.debtor_information.status" :class="element.debtor_information.colour()">
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">Ідентифікаційний номер / Код ЄДРПОУ:</label>
        </div>
        <div class="col-4">
          <input type="text" class="col-6 form-control" :disabled="element.editing_status" :value="element.debtor_information.number.data">
        </div>
      </div>
      <hr class="border-secondary border border-2">
      <div class="row mb-2">
        <div class=" col-auto"></div>
        <div class=" col-auto mt-2 form-check">
          <input class="form-check-input" type="checkbox" value="" 
          :checked="element.debtor_information.resident.status" 
          v-on:click="change(element.debtor_information.resident)"
          :disabled="element.editing_status">
        </div>
        <div class="col-auto">
          <label class="col-form-label">Нерезидент / Іноземець:</label>
        </div>
        <div class="col-9" v-if="element.debtor_information.resident.status">
          <textarea class="form-control" rows="1" :disabled="element.editing_status" :value="element.debtor_information.resident.data"></textarea>
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
          <input type="text" class="col-6 form-control" :disabled="element.editing_status" :value="element.debtor_information.obj_name.data">
        </div>
      </div>
      <hr class="border-secondary border border-2">
      <div class="row mb-2">
        <div class="col-auto mt-1">
          <button type="button" class="btn btn-primary"  v-on:click="change(element.debtor_information.address)">Адреса:</button>
        </div>
        <div class="col-10" :class="element.debtor_information.colour()" v-if="element.debtor_information.address.status">
          <div class="row mb-2">
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Країна:</label>
            </div>
             <div class="col-auto">
               <input type="text" class="form-control d-inline" :disabled="element.editing_status" :value="element.debtor_information.address.country.data">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Індекс:</label>
            </div>
             <div class="col-auto">
               <input type="number" class="form-control d-inline" :disabled="element.editing_status" :value="element.debtor_information.address.index.data">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Область:</label>
            </div>
             <div class="col-4">
               <input type="text" class="form-control d-inline" :disabled="element.editing_status" :value="element.debtor_information.address.region.data">
            </div>
          </div>

          <hr class="border-secondary border border-1">
          <div class="row mb-2">
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Район:</label>
            </div>
             <div class="col-3">
               <input type="text" class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.area.data">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Місто/селище:</label>
            </div>
            <div class="col-auto">
               <input type="text" class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.city.data">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Вилиця:</label>
            </div>
            <div class="col-auto">
               <input type="text" class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.street.data">
            </div>
          </div>

          <hr class="border-secondary border border-1">
          <div class="row mb-2">
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Будинок:</label>
            </div>
            <div class="col-auto">
               <input type="data" class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.build.data">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Корпус:</label>
            </div>
             <div class="col-auto">
               <input type="data" class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.corps.data">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Квартира:</label>
            </div>
             <div class="col-auto">
               <input type="data" class="form-control d-inline" :disabled="element.editing_status" :value="element.weightlifter_information.address.flat.data">
            </div>
          </div>
        </div>
        <div class="col-4 mt-1" v-else>
          <input type="text" class="col-6 form-control" disabled value="Натисніть кнопку щоб розгорнути">
        </div>
      </div>
    </div>

    <hr class="border-primary border border-2">
    <button type="button" :class="element.document.button()"  v-on:click="change(element.document)">
      Документ-підстава:
    </button>

    <div v-if="element.document.status" :class="element.document.colour()">
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">Назва документу:</label>
        </div>
        <div class="col-10">
          <input type="text" class="col-6 form-control" :disabled="element.editing_status" :value="element.document.name.data">
        </div>
      </div>
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">Номер документу:</label>
        </div>
        <div class="col-4">
          <input type="text" class="col-6 form-control" :disabled="element.editing_status" :value="element.document.number.data">
        </div>
        <div class="col-auto">
          <label class="col-form-label">Дата документу:</label>
        </div>
        <div class="col-4">
          <input type="date" class="col-6 form-control" :disabled="element.editing_status" :value="element.document.date.data">
        </div>
      </div>
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">Видавець документу:</label>
        </div>
        <div class="col-9">
          <input type="text" class="col-6 form-control" :disabled="element.editing_status" :value="element.document.publisher.data">
        </div>
      </div>
    </div>

    <hr class="border-info border border-2">
    <button type="button" :class="element.encumbrance_information.button()"  v-on:click="change(element.encumbrance_information)">
      Відомості про обтяження:
    </button>

    <div v-if="element.encumbrance_information.status" :class="element.encumbrance_information.colour()">
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
                  :disabled="element.editing_status" :value="item">
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
                  :disabled="element.editing_status" :value="item">
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
          <input type="date" class="col-6 form-control" :disabled="element.editing_status" :value="element.encumbrance_information.date.data">
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
                  :disabled="element.editing_status" :value="el">
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
              :disabled="element.editing_status" :value="item">
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
          :checked="element.encumbrance_information.type_description.status" 
          v-on:click="change(element.encumbrance_information.type_description)"
          :disabled="element.editing_status">
        </div>
        <div class="col-auto">
          <label class="col-form-label">Опис типу обтяження:</label>
        </div>
        <div class="col-9" v-if="element.encumbrance_information.type_description.status">
          <textarea class="form-control" rows="1" :disabled="element.editing_status" :value="element.encumbrance_information.type_description.data"></textarea>
        </div>
        <div class="col-3" v-else>
          <input type="text" class="col-6 form-control" disabled value="не застосовується">
        </div>
      </div>
    </div>

    <hr class="border-primary border border-2">
    <button type="button" :class="element.terms.button()"  v-on:click="change(element.terms)">
      Умови:
    </button>

    <div v-if="element.terms.status" :class="element.terms.colour()">
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">Розмір зобов'язання або вимоги:</label>
        </div>
        <div class="col-auto">
          <input type="text" class="col-6 form-control" :disabled="element.editing_status" :value="element.terms.number.data">
        </div>
        <div class="col-auto">
          <label class="col-form-label">Вид валюти:</label>
        </div>
        <div class="col-auto">
          <input type="text" class="col-6 form-control" :disabled="element.editing_status" :value="element.terms.name.data">
        </div>
        
      </div>
      <div class="row mb-2">
        <div class="col-auto">
          <label class="col-form-label">Строк виконання зобов'язання до:</label>
        </div>
        <div class="col-auto">
          <input type="date" class="col-6 form-control" :disabled="element.editing_status" :value="element.terms.date.data">
        </div>
      </div>
      <div class="row">
        <div class="col-auto"></div>
        <div class=" col-auto mt-2 form-check">
          <input class="form-check-input" type="checkbox" value="" 
          :checked="element.terms.publisher.status" 
          v-on:click="change(element.terms.publisher)"
          :disabled="element.editing_status">
        </div>
        <div class="col-auto">
          <label class="col-form-label">Додаткові умови, у тому числі відомості про особу, на користь якої встановлено публічне обтяження:</label>
        </div>
        <div class="col-9" v-if="element.terms.publisher.status">
          <textarea class="form-control" rows="1" :disabled="element.editing_status" :value="element.terms.publisher.data"></textarea>
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
export default {
  name: 'Statement',
  props: ["element"],
  methods: {
    change: function (pos) {
      if(pos.status == false) pos.status = true;
      else pos.status = false;
    }
  },
  /*created(){
    this.element.weightlifter_information = new Weightlifter_Information();
    this.element.debtor_information = new Debtor_Information();
    this.element.document = new Basis_Document();
    this.element.encumbrance_information = new Encumbrance_Information();
    this.element.terms = new Terms();
  }*/

}
</script>