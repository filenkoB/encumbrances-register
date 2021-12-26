<template>
  <div>
    <form @submit.prevent="submit" @reset.prevent="reset" class="row" v-show="visible_status">
      <div class="col-3"></div> 
      <div class="col-7"> 
          <div :class="colour(search_filter.first_item.name == search_filter.checked)">
              <div class="row text-start">
                  <div class="col-auto mt-2 ms-1">
                      <input class="form-check-input" type="radio" 
                      v-model.trim.number="search_filter.checked"
                      v-bind:value="search_filter.first_item.name"
                      v-on:change="clear()">
                  </div>
                  <div class="col">
                      <label class="col-form-label">{{search_filter.first_item.name}}</label>
                  </div>
              </div>
              <div class="row mt-1 text-start">
                  <div class="col-1"></div>
                  <div class="col-6">
                      <label class="col-form-label">{{search_filter.first_item.data[0].name}}</label>
                  </div>
                  <div class="col-5">
                      <input class="form-control" type="text" required :pattern="patterns.number.str" 
                      v-model="search_filter.first_item.data[0].value"
                      :disabled="(search_filter.first_item.name != search_filter.checked) || waitingForResponse">
                  </div>
              </div>
          </div>
          <div :class="colour(search_filter.second_item.name == search_filter.checked)">
              <div class="row text-start">
                  <div class="col-auto mt-2 ms-1">
                      <input class="form-check-input" type="radio" 
                      v-model="search_filter.checked"
                      v-bind:value="search_filter.second_item.name"
                      v-on:change="clear()">
                  </div>
                  <div class="col">
                      <label class="col-form-label">{{search_filter.second_item.name}}</label>
                  </div>
              </div>
              <div class="row mt-1 text-start" v-for="item in search_filter.second_item.data" :key="item.name">
                  <div class="col-1"></div>
                  <div class="col-6">
                      <label class="col-form-label">{{item.name}}</label>
                  </div>
                  <div class="col-5">
                      <input class="form-control" type="text" 
                      v-model="item.value" required :pattern="item.pattern"
                      :disabled="(search_filter.second_item.name != search_filter.checked) || waitingForResponse">
                  </div>
              </div>
          </div>
          <div :class="colour(search_filter.third_item.name == search_filter.checked)">
              <div class="row text-start">
                  <div class="col-auto mt-2 ms-1">
                      <input class="form-check-input" type="radio" 
                      v-model="search_filter.checked"
                      v-bind:value="search_filter.third_item.name"
                      v-on:change="clear()">
                  </div>
                  <div class="col">
                      <label class="col-form-label">{{search_filter.third_item.name}}</label>
                  </div>
              </div>
              <div class="row mt-1 text-start" v-for="item in search_filter.third_item.data" :key="item.name">
                  <div class="col-1"></div>
                  <div class="col-6">
                    <label class="col-form-label">{{item.name}}</label>
                  </div>
                  <div class="col-5">
                    <input class="form-control" type="text" 
                    v-model="item.value" required :pattern="item.pattern"
                    :disabled="(search_filter.third_item.name != search_filter.checked) || waitingForResponse">
                  </div>
              </div>
          </div>
          <div class="row mt-4 mb-5">
              <div class="col"></div>
              <div v-if="waitingForResponse" class="col">
                <button class="btn btn-success" type="button" disabled>
                  <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                  Пошук...
                </button>
              </div>
              <div v-else class="col">
                  <button type="submit" class="btn btn-outline-success me-1">Підтвертити</button>
              </div>
              <div class="col">
                  <button type="reset" :disabled="waitingForResponse" class="btn btn-outline-danger ms-1">Очистити</button>
              </div>
              <div class="col"></div>
          </div>
      </div>
      <div class="col-2"></div> 
    </form>
    <div class="row">
      <div class="col">
        <div class="row" v-show="!visible_status">
          <div class="col">
            <div :class="colour(!visible_status)">
              <div class="col-2">
                <label class="col-form-label">Параметри запиту:</label>
              </div>
              <div class="col border border-secondary border-1 p-2 rounded">
                <div class="row mb-1 mt-1" v-for="item in search_query.data" :key="item.name">
                  <div class="col"><label class="col-form-label" >{{item.name}}</label></div>
                  <div class="col"><input class="form-control" type="text" disabled :value="item.value"></div>
                </div>
              </div>
              <div class="col-auto text-end">
                <button @click="backToForm" class="btn btn-outline-secondary ms-1">Параметри пошуку</button>
                <button @click="backToForm" class="btn btn-outline-secondary ms-1" v-if="extract_element">Отримати витяг</button>
              </div>
            </div>
          </div>
        </div>
        <div class="row mt-3"  v-if="encumbrances.length > 0">
          <div class="col" id="statements_area">
            <div class="row border border-2 border-primary rounded mb-2" v-for="item in encumbrances" :key="item.id">
              <div class="col-auto border-end border-4 p-3">
                <input class="form-check-input" type="radio" v-model="extract_element" v-bind:value="item.id">
              </div>
              <div class="col-auto p-3">
                Реєстраційний номер запису:
              </div>
              <div class="col-1 border-end border-4 p-3">{{item.number}}</div>
              <div class="col-auto p-3">
                ПІБ / Назва Боржника:
              </div>
              <div class="col border-end border-4 p-3">{{item.tier}}</div>
              <div class="col-auto p-3">
                Дата реєстрації обтяження:
              </div>
              <div class="col-1 p-3">{{item.date.split("T")[0]}}</div>
            </div>
          </div>
          <Pagination :pagination="pagination" :fun="get_encumbrances"/>
        </div>
        <div class="row border border-4 p-3 mt-5 rounded" v-else-if="!visible_status">
          <div class="col text-center">
            <label>Відповідно до заданиних параметрів не знайдено жодного обтяження.</label>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import {validation} from "../data";
import {Encumbrance} from "../connect_to_server"
import Pagination from "../components/Pagination.vue"
export default {
  name: 'SearchEncumbrances',
  data: function () {
    return {
      visible_status: true,
      search_query: "",
      patterns: validation.patterns,
      search_filter:{
        checked: "Реєстраційний номер запису:",
        first_item:{
            name:"Реєстраційний номер запису:",
            data:[{
                name:"Номер обтяження:",
                value: ""
            }]
        },
        second_item:{
            name:"Реєстраційні дані предмета обтяження:",
            data:[
                {
                    name:"Серійний номер об'єкта рухомого майна:",
                    value: "",
                    pattern: validation.patterns.serialNum.str
                },
                {
                    name:"Номер державної реєстрацій об'єкта рухомого майна:",
                    value: "",
                    pattern: validation.patterns.number.str
                }
            ]
        },
        third_item:{
            name:"Відомості про Боржника:",
            data:[
                {
                    name:"ПІБ / Назва суб'єкту:",
                    value: "",
                    pattern: validation.patterns.text.str
                },
                {
                    name:"РНОКПП / ЄДРПОУ:",
                    value: "",
                    pattern: validation.patterns.idNumber.str
                }
            ]
        }
      },
      pagination:{
        active_page: 0,
        max_items_count:5,
        count_page: 0,
      },
      search_element_value:{},
      encumbrances: [],
      extract_element: null,
      active_user: null,
      waitingForResponse: false
    };
  },
  components:{
    Pagination
  },
  methods:{
    colour(item){
      if(item) return "row border border-primary rounded p-2";
      return "row border border-white p-2";
    },
    clear(){
      if(this.search_filter.checked == this.search_filter.first_item.name){
        this.search_filter.second_item.data.map(el=>el.value = ""); 
        this.search_filter.third_item.data.map(el=>el.value = ""); 
      }
      else if(this.search_filter.checked == this.search_filter.second_item.name){
        this.search_filter.first_item.data[0].value = "";
        this.search_filter.third_item.data.map(el=>el.value = ""); 
      }
      else{
        this.search_filter.first_item.data[0].value = "";
        this.search_filter.second_item.data.map(el=>el.value = ""); 
      }
    },
    async submit(){
      this.waitingForResponse = true;
      this.search_element_value = {
        encumbranceNumber: "",
        objectSerialNumber: "",
        objectStateRegNumber: "",
        name: "",
        idNumber: ""
      }
      if(this.search_filter.checked == this.search_filter.first_item.name){
        this.search_query = this.search_filter.first_item;
        this.search_element_value.encumbranceNumber = this.search_filter.first_item.data[0].value;
      }
      else if(this.search_filter.checked == this.search_filter.second_item.name){
        this.search_query = this.search_filter.second_item;
        this.search_element_value.objectSerialNumber = this.search_filter.second_item.data[0].value;
        this.search_element_value.objectStateRegNumber = this.search_filter.second_item.data[1].value;
      }
      else{
        this.search_query = this.search_filter.third_item;
        this.search_element_value.name = this.search_filter.third_item.data[0].value;
        this.search_element_value.idNumber = this.search_filter.third_item.data[1].value;
      }
      this.get_encumbrances();
    },
    async get_encumbrances(){
      
      this.visible_status = false;
      this.waitingForResponse = false;
      this.pagination.max_items_count = parseInt(this.pagination.max_items_count);
      if (this.pagination.max_items_count < 1) this.pagination.max_items_count = 1;
      if (this.pagination.max_items_count > 5) this.pagination.max_items_count = 5;
      const test_data = await Encumbrance(this.search_element_value, this.pagination.active_page + 1, this.pagination.max_items_count);
      if(test_data.length < this.pagination.max_items_count) this.pagination.max_items_count = test_data.length;
      this.pagination.count_page = Math.ceil(test_data.length / this.pagination.max_items_count);
      this.encumbrances = test_data.encumbrances;
      console.log(test_data.encumbrances);
      if(this.encumbrances[0].id) this.extract_element = this.encumbrances[0].id
    },
    reset() {
      this.search_filter.first_item.data[0].value = "";
      this.search_filter.second_item.data.map(el=>el.value = ""); 
      this.search_filter.third_item.data.map(el=>el.value = "");
    },
    backToForm() {
      this.visible_status = true;
      this.encumbrances = [];
    }
  },
  mounted(){
    this.user_status = window.sessionStorage.getItem('user_status');
    if(!this.user_status){
        this.$router.push({ name: "SignIn"}).catch(() => {});
    }
    this.$root.$children[0].$children[0].page = 'search';
  }
}
</script>
<style>
#statements_area{
  min-height: 350px;
}
</style>