<template>
    <form class="row"> 
        <div class="col-3"></div> 
        <div class="col-7"> 
            <div :class="colour(search_filter.first_item.name == search_filter.checked)">
                <div class="row text-start">
                    <div class="col-auto mt-2 ms-1">
                        <input class="form-check-input" type="radio" 
                        v-model="search_filter.checked"
                        v-bind:value="search_filter.first_item.name">
                    </div>
                    <div class="col">
                        <label class="col-form-label">{{search_filter.first_item.name}}</label>
                    </div>
                </div>
                <div class="row mt-1 text-start">
                    <div class="col-1"></div>
                    <div class="col-6">
                        <label class="col-form-label">{{search_filter.first_item.data.name}}</label>
                    </div>
                    <div class="col-5">
                        <input class="form-control" type="text" 
                        v-model="search_filter.first_item.data.value"
                        :disabled="search_filter.first_item.name != search_filter.checked">
                    </div>
                </div>
            </div>
            <div :class="colour(search_filter.second_item.name == search_filter.checked)">
                <div class="row text-start">
                    <div class="col-auto mt-2 ms-1">
                        <input class="form-check-input" type="radio" 
                        v-model="search_filter.checked"
                        v-bind:value="search_filter.second_item.name">
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
                        v-bind:value="search_filter.third_item.name">
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
                        <select class="form-control" v-model="item.value">
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
                    <button type="button" class="btn btn-outline-success me-1" >Підтвертити</button>
                </div>
                <div class="col">
                    <button type="button" class="btn btn-outline-danger ms-1" >Очистити</button>
                </div>
                <div class="col"></div>
            </div>
        </div>
        <div class="col-2"></div> 
    </form>
</template>


<script>
export default {
  name: 'MyStatements',
  data: function () {
    return {
        search_filter:{
            checked: "Реєстраційний номер запису:",
            first_item:{
                name:"Реєстраційний номер запису:",
                data:{
                    name:"Номер обтяження:",
                    value: null
                }
            },
            second_item:{
                name:"Реєстраційні дані предмета обтяження:",
                data:[
                    {
                        name:"Реєстраційний номер майна:",
                        value: null
                    },
                    {
                        name:"Серійний номер об'єкта рухомого майна:",
                        value: null
                    },
                    {
                        name:"Номер державної реєстрацій об'єкта рухомого майна:",
                        value: null
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
                        value: null
                    },
                    {
                        name:"РНОКПП / ЄДРПОУ:",
                        value: null
                    }
                ]
            }
        }
    };
  },
  components:{},
  methods:{
      colour(item){
          if(item) return "row border border-primary rounded p-2";
          return "row border border-white p-2";
      }
  },
  created(){}
}
</script>