<template>
  <div class="row">
    <div class="col">
      <div class="row mb-2">
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Країна:</label>
        </div>
        <div class="col-2">
          <input type="data" class="form-control d-inline"  disabled v-bind:value="address.country.name">
        </div>
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Область:</label>
        </div>
        <div class="col-3">
          <select class="form-control" @change="clear_address('region')" v-on:change="get_district"
            :disabled="editing_status || path.country == undefined || path.country.length == 0" v-model="path.region">
            <option selected disabled>Оберіть ...</option>
            <option v-for="item in this.address.region" :key="item.id" :value="item.id">
              {{ item.name }}
            </option>
          </select>
        </div>
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Район:</label>
        </div>
        <div class="col-3">
          <select class="form-control" @change="clear_address('district')" v-on:change="get_city"
            :disabled="editing_status || path.region == 'Оберіть ...'" v-model="path.district">
            <option selected disabled>Оберіть ...</option>
            <option v-for="item in address.district" :key="item.id" :value="item.id">{{ item.name }}</option>
          </select>
        </div>
      </div>
      <div class="row mb-2">
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Місто:</label>
        </div>
        <div class="col-2">
          <select class="form-control" @change="clear_address('city')" v-on:change="get_street_index"
            :disabled="editing_status || path.district == 'Оберіть ...'" v-model="path.city">
            <option selected disabled>Оберіть ...</option>
            <option v-for="item in address.city" :key="item.id" :value="item.id">{{ item.name }}</option>
          </select>
        </div>
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Індекс:</label>
        </div>
        <div class="col-2">
          <select class="form-control"
            :disabled="editing_status || path.city == 'Оберіть ...'" v-model="path.index">
            <option selected disabled>Оберіть ...</option>
            <option v-for="item in address.index" :key="item" :value="item">{{ item }}</option>
          </select>
        </div>
        <div class="col-1"></div>
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Вилиця:</label>
        </div>
        <div class="col-3">
          <select class="form-control" 
            :disabled="editing_status || path.city == 'Оберіть ...'" v-model="path.street">
            <option selected disabled>Оберіть ...</option>
            <option v-for="item in address.street" :key="item.id" :value="item.id">{{ item.name }}</option>
          </select>
        </div>
      </div>
      <div class="row">
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Будинок:</label>
        </div>
        <div class="col-2">
          <input type="data" class="form-control d-inline" 
            :disabled="editing_status || path.street == 'Оберіть ...'" v-model="path.build">
        </div>
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Корпус:</label>
        </div>
        <div class="col-2">
          <input type="data" class="form-control d-inline" 
            :disabled="editing_status || path.street == 'Оберіть ...'" v-model="path.corps">
        </div>
        <div class="col-1"></div>
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Квартира:</label>
        </div>
        <div class="col-2">
          <input type="data" class="form-control d-inline" 
            :disabled="editing_status || path.street == 'Оберіть ...'" v-model="path.flat">
        </div>
      </div>
    </div>
</div>
</template>
<script>
import {GetRegionByCountry, GetDistrictByRegion, GetCityByDistrict, GetStreetByCity, GetIndexByCity} from "../../connect_to_server"
export default {
  data(){
    return {
      address:{
        country: "Завантаження ...",
        region: null,
        district: null,
        city: null,
        index: null,
        street: null
      },
    }
  },
  props:["path", "editing_status"],
  name: 'Address',
  methods:{
    async get_region(item){
      this.path.country = item;
      this.clear_address('region');
      this.address.region = await GetRegionByCountry(this.path.country)
    },
    async get_district(event){
      this.path.region = event.target.value;
      this.clear_address('district');
      this.address.district = await GetDistrictByRegion(event.target.value);
    },
    async get_city(event){
      this.path.district = event.target.value;
      this.clear_address('city');
      this.address.city = await GetCityByDistrict(event.target.value)
    },
    async get_street_index(event){
      this.path.city = event.target.value;
      this.address.street = await GetStreetByCity(event.target.value);
      this.address.index = await GetIndexByCity(event.target.value);
    },
    clear_address(key) {
      if(key == "cauntry"){
        this.path.region = "Оберіть ...",
        this.clear_address("region");
      }
      else if(key == "region"){
        this.path.district = "Оберіть ...",
        this.clear_address("district");
      }
      else if(key == "district"){
        this.path.city = "Оберіть ...";
        this.clear_address("city");
      }
      else if(key == "city"){
        this.path.index = "Оберіть ...";
        this.path.street = "Оберіть ...";
        this.path.build = "";
        this.path.corps = "";
        this.path.flat = "";
      }
    }
  },
  created(){
    this.clear_address("cauntry");
    this.address.country = "Завантаження"
    fetch(process.env.VUE_APP_HEROKU_PATH + "/Country")
      .then(async response =>{
        if(response.status == 200){
          const data = await response.json();
          this.address.country = data[0];
          this.get_region(data[0].id)
        }
        else if(response.status != 200){
          console.log(response.status)
        }
      }
    )
  }
}
</script>