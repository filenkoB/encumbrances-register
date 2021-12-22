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
                  <div class="col-5" v-if="item.name !='Тип особи:'">
                      <input class="form-control" type="text" 
                      v-model="item.value" required :pattern="item.pattern"
                      :disabled="(search_filter.third_item.name != search_filter.checked) || waitingForResponse">
                  </div>
                  <div class="col-5" v-else>
                      <select class="form-control" v-model="item.value" required @change="typeChanged(item.value)"
                      :disabled="(search_filter.third_item.name != search_filter.checked) || waitingForResponse">
                          <option v-if="item.value.length != 0" selected disabled>{{item.value}}</option>
                          <option v-else></option>
                          <option v-for="el in item.data" :key="el">{{el}}</option>
                      </select>
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
    <div class="row" v-show="!visible_status">
      <div class="col text-start">
        <div class="statements_area">
          <div :class="colour(!visible_status)">
            <div class="col-2 border-end border-secondary border-4">
              <label class="col-form-label">Параметри запиту:</label>
            </div>
            <div class="col-8">
              <div class="row mb-2" v-for="item in search_query.data" :key="item.name">
                <div class="col"><label class="col-form-label" >{{item.name}}</label></div>
                <div class="col"><input class="form-control" type="text" disabled :value="item.value"></div>
              </div>
            </div>
          </div>
        </div>
        <div class="row">
            <div class="col-4"/>
            <div class="col">
              <button @click="backToForm" class="btn btn-outline-secondary ms-1">Поверутися до параметрів пошуку</button>
            </div>
            <div class="col-4"/>
          </div>
      </div>
    </div>
  </div>
</template>


<script>
import {validation} from "../data";
export default {
  name: 'MyStatements',
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
                // {
                //     name:"Реєстраційний номер майна:",
                //     value: "",
                //     pattern:
                // },
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
                    name:"Тип особи:",
                    data:["Фізична особа", "Юридична особа"],
                    value: ""
                },
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
      active_user: null,
      waitingForResponse: false
    };
  },
  components:{},
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
        this.search_filter.first_item.data.value = "";
        this.search_filter.third_item.data.map(el=>el.value = ""); 
      }
      else{
        this.search_filter.first_item.data.value = "";
        this.search_filter.second_item.data.map(el=>el.value = ""); 
      }
    },
    submit(){
      this.waitingForResponse = true;
      setTimeout( () => {
        this.visible_status = false;
        if(this.search_filter.checked == this.search_filter.first_item.name){
          this.search_query = this.search_filter.first_item;
          //this.$router.push({ name: "Home", params:  this.search_filter.first_item}).catch(() => {});
        }
        else if(this.search_filter.checked == this.search_filter.second_item.name){
          this.search_query = this.search_filter.second_item;
          //this.$router.push({ name: "Home", params:  this.search_filter.second_item}).catch(() => {});
        }
        else{
          this.search_query = this.search_filter.third_item;
          //this.$router.push({ name: "Home", params:  this.search_filter.third_item}).catch(() => {});
        }
        this.waitingForResponse = false;
      }, 500);
    },
    reset() {
      this.search_filter.first_item.data[0].value = "";
      this.search_filter.second_item.data.map(el=>el.value = ""); 
      this.search_filter.third_item.data.map(el=>el.value = "");
    },
    backToForm() {
      this.visible_status = true;
    },
    typeChanged(type) {
      console.log(type);
      if (type === 'Фізична особа') {
        this.search_filter.third_item.data[1].pattern =
        validation.patterns.lastName.str + " " + validation.patterns.names.str + " " + validation.patterns.names.str;
      }
      else if (type === 'Юридична особа') {
        this.search_filter.third_item.data[1].pattern = validation.patterns.text.str;
      }
    }
  },
  mounted(){
    this.user_status = window.sessionStorage.getItem('user_status');
    if(!this.user_status){
        this.$router.push({ name: "SignIn"}).catch(() => {});
    }
  }
}
</script>
<style>
.statements_area{
  min-height: 430px;
}
</style>