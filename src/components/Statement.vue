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
          <div class="row mb-2">
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Країна:</label>
            </div>
            <div class="col-2">
              <select class="form-control" @change="change_byffer(true, 'country')" :disabled="editing_status" 
              v-model="element.weightlifter_information.address.path.country">
                <option v-if="element.weightlifter_information.address.path.country.length == 0" selected disabled></option>
                <option v-else selected disabled>{{element.weightlifter_information.address.path.country}}</option>
                <option v-for="item in full_address.address" :key="item.name">{{ item.name }}</option>
              </select>
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Область:</label>
            </div>
            <div class="col-3">
              <select class="form-control"  @change="change_byffer(true, 'region')" v-model="element.weightlifter_information.address.path.region" :disabled="editing_status || element.weightlifter_information.address.path.country.length == 0">
                <option v-if="element.weightlifter_information.address.path.region.length == 0" selected disabled></option>
                <option v-else selected disabled>{{element.weightlifter_information.address.path.region}}</option>
                <option v-for="item in byffer.weightlifter_information.region" :key="item.name" >{{ item.name }}</option>
              </select>
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Район:</label>
            </div>
            <div class="col-3">
              <select class="form-control"  @change="change_byffer(true, 'area')" v-model="element.weightlifter_information.address.path.area" :disabled="editing_status || element.weightlifter_information.address.path.region.length == 0">
                <option v-if="element.weightlifter_information.address.path.area.length == 0" selected disabled></option>
                <option v-else selected disabled>{{element.weightlifter_information.address.path.area}}</option>
                <option v-for="item in byffer.weightlifter_information.area" :key="item.name" >{{ item.name }}</option>
              </select>
            </div>
          </div>
          <div class="row mb-2">
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Місто:</label>
            </div>
            <div class="col-2 ms-2">
              <select class="form-control"  @change="change_byffer(true, 'city')" v-model="element.weightlifter_information.address.path.city" 
              :disabled="editing_status || element.weightlifter_information.address.path.area.length == 0">
                <option v-if="element.weightlifter_information.address.path.city.length == 0" selected disabled></option>
                <option v-else selected disabled>{{element.weightlifter_information.address.path.city}}</option>
                <option v-for="item in byffer.weightlifter_information.city" :key="item.name" >{{ item.name }}</option>
              </select>
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Індекс:</label>
            </div>
            <div class="col-2 ms-3 me-">
              <select class="form-control"  @change="change_byffer(true, 'index')" v-model="element.weightlifter_information.address.path.index" :disabled="editing_status || element.weightlifter_information.address.path.city.length == 0">
                <option v-if="element.weightlifter_information.address.path.index.length == 0" selected disabled></option>
                <option v-else selected disabled>{{element.weightlifter_information.address.path.index}}</option>
                <option v-for="item in byffer.weightlifter_information.index" :key="item.name" >{{ item.name }}</option>
              </select>
            </div>
            <div class="col-auto mt-2 ">
              <label class="col-form-label d-inline">Вилиця:</label>
            </div>
            <div class="col-3">
              <select class="form-control"  @change="change_byffer(true)" v-model="element.weightlifter_information.address.path.street" 
              :disabled="editing_status || element.weightlifter_information.address.path.index.length == 0">
                <option v-if="element.weightlifter_information.address.path.street.length == 0" selected disabled></option>
                <option v-else selected disabled>{{element.weightlifter_information.address.path.street}}</option>
                <option v-for="item in byffer.weightlifter_information.street" :key="item.name" >{{ item.name }}</option>
              </select>
            </div>
          </div>
          <div class="row mb-2">
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Будинок:</label>
            </div>
            <div class="col-auto">
               <input type="data" class="form-control d-inline" 
               :disabled="editing_status || element.weightlifter_information.address.path.street.length == 0"
               v-bind:value="element.weightlifter_information.address.path.build">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Корпус:</label>
            </div>
             <div class="col-auto">
               <input type="data" class="form-control d-inline" 
               :disabled="editing_status || element.weightlifter_information.address.path.street.length == 0"
               v-bind:value="element.weightlifter_information.address.path.corps">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Квартира:</label>
            </div>
             <div class="col-auto">
               <input type="data" class="form-control d-inline" 
               :disabled="editing_status || element.weightlifter_information.address.path.street.length == 0"
               v-bind:value="element.weightlifter_information.address.path.flat">
            </div>
          </div>
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
          <div class="row mb-2">
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Країна:</label>
            </div>
            <div class="col-2">
              <select class="form-control" @change="change_byffer(false, 'country')" :disabled="editing_status" 
              v-model="element.debtor_information.address.path.country">
                <option v-if="element.debtor_information.address.path.country.length == 0" selected disabled></option>
                <option v-else selected disabled>{{element.debtor_information.address.path.country}}</option>
                <option v-for="item in full_address.address" :key="item.name">{{ item.name }}</option>
              </select>
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Область:</label>
            </div>
            <div class="col-3">
              <select class="form-control"  @change="change_byffer(false, 'region')" v-model="element.debtor_information.address.path.region" 
              :disabled="editing_status || element.debtor_information.address.path.country.length == 0">
                <option v-if="element.debtor_information.address.path.region.length == 0" selected disabled></option>
                <option v-else selected disabled>{{element.debtor_information.address.path.region}}</option>
                <option v-for="item in byffer.debtor_information.region" :key="item.name" >{{ item.name }}</option>
              </select>
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Район:</label>
            </div>
            <div class="col-3">
              <select class="form-control"  @change="change_byffer(false, 'area')" 
              v-model="element.debtor_information.address.path.area" 
              :disabled="editing_status || element.debtor_information.address.path.region.length == 0">
                <option v-if="element.debtor_information.address.path.area.length == 0" selected disabled></option>
                <option v-else selected disabled>{{element.debtor_information.address.path.area}}</option>
                <option v-for="item in byffer.debtor_information.area" :key="item.name" >{{ item.name }}</option>
              </select>
            </div>
          </div>
          <div class="row mb-2">
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Місто:</label>
            </div>
            <div class="col-2 ms-2">
              <select class="form-control"  @change="change_byffer(false, 'city')" 
              v-model="element.debtor_information.address.path.city" 
              :disabled="editing_status || element.debtor_information.address.path.area.length == 0">
                <option v-if="element.debtor_information.address.path.city.length == 0" selected disabled></option>
                <option v-else selected disabled>{{element.debtor_information.address.path.city}}</option>
                <option v-for="item in byffer.debtor_information.city" :key="item.name" >{{ item.name }}</option>
              </select>
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Індекс:</label>
            </div>
            <div class="col-2 ms-3 me-">
              <select class="form-control"  @change="change_byffer(false, 'index')" 
              v-model="element.debtor_information.address.path.index" 
              :disabled="editing_status || element.debtor_information.address.path.city.length == 0">
                <option v-if="element.debtor_information.address.path.index.length == 0" selected disabled></option>
                <option v-else selected disabled>{{element.debtor_information.address.path.index}}</option>
                <option v-for="item in byffer.debtor_information.index" :key="item.name" >{{ item.name }}</option>
              </select>
            </div>
            <div class="col-auto mt-2 ">
              <label class="col-form-label d-inline">Вилиця:</label>
            </div>
            <div class="col-3">
              <select class="form-control"  @change="change_byffer(false)" 
              v-model="element.debtor_information.address.path.street" 
              :disabled="editing_status || element.debtor_information.address.path.index.length == 0">
                <option v-if="element.debtor_information.address.path.street.length == 0" selected disabled></option>
                <option v-else selected disabled>{{element.debtor_information.address.path.street}}</option>
                <option v-for="item in byffer.debtor_information.street" :key="item.name" >{{ item.name }}</option>
              </select>
            </div>
          </div>
          <div class="row mb-2">
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Будинок:</label>
            </div>
            <div class="col-auto">
               <input type="data" class="form-control d-inline" 
               :disabled="editing_status || element.debtor_information.address.path.street.length == 0"
               v-bind:value="element.debtor_information.address.path.build">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Корпус:</label>
            </div>
             <div class="col-auto">
               <input type="data" class="form-control d-inline" 
               :disabled="editing_status || element.debtor_information.address.path.street.length == 0"
               v-bind:value="element.debtor_information.address.path.corps">
            </div>
            <div class="col-auto mt-2">
              <label class="col-form-label d-inline">Квартира:</label>
            </div>
             <div class="col-auto">
               <input type="data" class="form-control d-inline" 
               :disabled="editing_status || element.debtor_information.address.path.street.length == 0"
               v-bind:value="element.debtor_information.address.path.flat">
            </div>
          </div>
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
        <div class="col-auto">
          <input type="text" class="col-6 form-control" :disabled="editing_status" :value="element.terms.name.data">
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
import {address} from "../data";
export default {
   data: function () {
    return {
      byffer: {
        weightlifter_information:{},
        debtor_information:{}
      },
      full_address: address
    }
  },
  name: 'Statement',
  props: ["element","editing_status"],
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
    },
    change_byffer(marker, key){
      if(key == "country"){
        let test = JSON.parse(JSON.stringify(this.full_address)).address;
        for(let i = 0; i< test.length; i++){
          if(marker){
            if(test[i].name == this.element.weightlifter_information.address.path.country){
              this.byffer.weightlifter_information.region = test[i].region;
              break;
            }
           }
          else{
            if(test[i].name == this.element.debtor_information.address.path.country){
              this.byffer.debtor_information.region = test[i].region;
              break;
            }
          }
        }
      }
      else if(key == "region"){
        let test = null;
        if(marker) test = JSON.parse(JSON.stringify(this.byffer.weightlifter_information.region));
        else test = JSON.parse(JSON.stringify(this.byffer.debtor_information.region));
        for(let i = 0; i< test.length; i++){
          if(marker){
            if(test[i].name == this.element.weightlifter_information.address.path.region){
              this.byffer.weightlifter_information.area = test[i].area;
              break;
            }
           }
          else{
            if(test[i].name == this.element.debtor_information.address.path.region){
              this.byffer.debtor_information.area = test[i].area;
              break;
            }
          }
        }
      }
      else if(key == "area"){
        let test = null;
        if(marker) test = JSON.parse(JSON.stringify(this.byffer.weightlifter_information.area));
        else test = JSON.parse(JSON.stringify(this.byffer.debtor_information.area));
        for(let i = 0; i< test.length; i++){
          if(marker){
            if(test[i].name == this.element.weightlifter_information.address.path.area){
              this.byffer.weightlifter_information.city = test[i].city;
              break;
            }
           }
          else{
            if(test[i].name == this.element.debtor_information.address.path.area){
              this.byffer.debtor_information.city = test[i].city;
              break;
            }
          }
        }
      }
      else if(key == "city"){
        let test = null;
        if(marker) test = JSON.parse(JSON.stringify(this.byffer.weightlifter_information.city));
        else test = JSON.parse(JSON.stringify(this.byffer.debtor_information.city));
        for(let i = 0; i< test.length; i++){
          if(marker){
            if(test[i].name == this.element.weightlifter_information.address.path.city){
              this.byffer.weightlifter_information.index = test[i].index;
              break;
            }
           }
          else{
            if(test[i].name == this.element.debtor_information.address.path.city){
              this.byffer.debtor_information.index = test[i].index;
              break;
            }
          }
        }
      }
      else if(key == "index"){
        let test = null;
        if(marker) test = JSON.parse(JSON.stringify(this.byffer.weightlifter_information.index));
        else test = JSON.parse(JSON.stringify(this.byffer.debtor_information.index));
        for(let i = 0; i< test.length; i++){
          if(marker){
            if(test[i].name == this.element.weightlifter_information.address.path.index){
              this.byffer.weightlifter_information.street = test[i].street;
              break;
            }
           }
          else{
            if(test[i].name == this.element.debtor_information.address.path.index){
              this.byffer.debtor_information.street = test[i].street;
              break;
            }
          }
        }
      }
      if(marker) this.clear_address(this.element.weightlifter_information.address.path, key);
      else this.clear_address(this.element.debtor_information.address.path, key);
      
    },
    clear_address(item, key) {
      if(key == "country"){
        item.region = "",
        this.clear_address(item, "region");
      }
      else if(key == "region"){
        item.area = "",
        this.clear_address(item, "area");
      }
      else if(key == "area"){
        item.city = "";
        this.clear_address(item, "city");
      }
      else if(key == "city"){
        item.index = "";
        this.clear_address(item, "index");
      }
      else if(key == "index"){
        item.street = "";
        this.clear_address(item, "");
      }
      else{
        item.build = "";
        item.corps = "";
        item.flat = "";
      }
    },
    getItems(items, key){
      console.log(items.length, key);
      for(let i = 0; i < items.length; i++){
        console.log(items[i].name, key);
        if(items[i].name == key) return items[i].data;
      }
    }
  },

}
</script>