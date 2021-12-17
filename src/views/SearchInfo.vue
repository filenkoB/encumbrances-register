<template>
  <div>
    <div class="row" v-show="visible_status">
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
                      <input class="form-control" type="text" 
                      v-model="search_filter.first_item.data[0].value"
                      :disabled="search_filter.first_item.name != search_filter.checked">
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
                      v-model="item.value"
                      :disabled="search_filter.second_item.name != search_filter.checked">
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
                      v-model="item.value"
                      :disabled="search_filter.third_item.name != search_filter.checked">
                  </div>
                  <div class="col-5" v-else>
                      <select class="form-control" v-model="item.value"
                      :disabled="search_filter.third_item.name != search_filter.checked">
                          <option v-if="item.value.length != 0" selected disabled>{{item.value}}</option>
                          <option v-else></option>
                          <option v-for="el in item.data" :key="el">{{el}}</option>
                      </select>
                  </div>
              </div>
          </div>
          <div class="row mt-4 mb-5">
              <div class="col"></div>
              <div class="col">
                  <button type="button" class="btn btn-outline-success me-1" 
                  v-on:click="submit()">Підтвертити</button>
              </div>
              <div class="col">
                  <button type="button" class="btn btn-outline-danger ms-1" >Очистити</button>
              </div>
              <div class="col"></div>
          </div>
      </div>
      <div class="col-2"></div> 
    </div>
    <div class="row" v-show="!visible_status">
      <div class="col text-start">
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
    </div>
  </div>
</template>


<script>
export default {
  name: 'MyStatements',
  data: function () {
    return {
      visible_status: true,
      search_query: "",
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
                    name:"Реєстраційний номер майна:",
                    value: ""
                },
                {
                    name:"Серійний номер об'єкта рухомого майна:",
                    value: ""
                },
                {
                    name:"Номер державної реєстрацій об'єкта рухомого майна:",
                    value: ""
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
                    value: ""
                },
                {
                    name:"РНОКПП / ЄДРПОУ:",
                    value: ""
                }
            ]
        }
      },
      active_user: null
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
        this.search_filter.first_item.data.value = ""
        this.search_filter.third_item.data.map(el=>el.value = ""); 
      }
      else{
        this.search_filter.first_item.data.value = ""
        this.search_filter.second_item.data.map(el=>el.value = ""); 
      }
    },
    submit(){
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
    }
  },
  created(){
    this.active_user = this.$route.params.active_user;
    if(this.active_user == null || this.active_user == undefined || !(this.active_user.user_status == "registrar"|| this.active_user.user_status == "user")){
      this.$router.push({ name: "SignIn"}).catch(() => {});
    }
  }
}
</script>