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
          <select class="form-control" required @change="clear_address('region')" v-on:change="get_district"
            :disabled="editing_status || path.country == undefined || path.country.length == 0" v-model="path.region">
            <option v-for="item in this.address.region" :key="item.id" :value="item.id">
              {{ item.name }}
            </option>
          </select>
        </div>
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Район:</label>
        </div>
        <div class="col-3">
          <select class="form-control" required @change="clear_address('district')" v-on:change="get_city"
            :disabled="editing_status || path.region == ''" v-model="path.district">
            <option v-for="item in address.district" :key="item.id" :value="item.id">{{ item.name }}</option>
          </select>
        </div>
      </div>
      <div class="row mb-2">
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Місто:</label>
        </div>
        <div class="col-2">
          <select class="form-control" required @change="clear_address('city')" v-on:change="get_street_index"
            :disabled="editing_status || path.district == ''" v-model="path.city">
            <option v-for="item in address.city" :key="item.id" :value="item.id">{{ item.name }}</option>
          </select>
        </div>
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Індекс:</label>
        </div>
        <div class="col-2">
          <select class="form-control"
            :disabled="editing_status || path.city == ''" required v-model="path.index">
            <option v-for="item in address.index" :key="item" :value="item">{{ item }}</option>
          </select>
        </div>
        <div class="col-1"></div>
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Вулиця:</label>
        </div>
        <div class="col-3">
          <select class="form-control" 
            :disabled="editing_status || path.city == ''" required v-model="path.street">
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
            :disabled="editing_status || path.street == ''" @change="changed" required :pattern="patterns.building.str" v-model="path.build">
        </div>
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Корпус:</label>
        </div>
        <div class="col-2">
          <input type="data" class="form-control d-inline" 
            :disabled="editing_status || path.street == ''" @change="changed" :pattern="patterns.corps.str" v-model="path.corps">
        </div>
        <div class="col-1"></div>
        <div class="col-1 mt-2">
          <label class="col-form-label d-inline">Квартира:</label>
        </div>
        <div class="col-2">
          <input type="data" class="form-control d-inline" 
            :disabled="editing_status || path.street == ''" @change="changed" :pattern="patterns.flat.str" v-model="path.flat">
        </div>
      </div>
    </div>
</div>
</template>
<script>
import {Address} from "../../connect_to_server"
import {validation} from "../../data";
export default {
  data(){
    return {
      address_sevre: null,
      address:{
        country: {},
        region: null,
        district: null,
        city: null,
        index: null,
        street: null
      },
      justOpened: true,
    }
  },
  props:["path", "editing_status"],
  name: 'Address',
  methods:{
    changed() {
      if (!this.editing_status) {
        this.path.invalid = this.isInvalid();
        this.path.onChanged();
      }
    },
    isInvalid() {
      if(!this.patterns.building.var.exec(this.path.build)) { return true; }
      if((this.path.corps.length > 0) && !this.patterns.corps.var.exec(this.path.corps))  { return true; }
      if((this.path.flat.length > 0) && !this.patterns.flat.var.exec(this.path.flat)) { return true; }
      return false;
    },
    async get_region(item){
      this.path.country = item;
      this.clear_address('region');
      this.address.region = await this.address_sevre.GetRegionByCountry(this.path.country)
    },
    async get_district(event){
      this.path.region = event.target.value;
      this.clear_address('district');
      this.address.district = await this.address_sevre.GetDistrictByRegion(event.target.value);
    },
    async get_city(event){
      this.path.district = event.target.value;
      this.clear_address('city');
      this.address.city = await this.address_sevre.GetCityByDistrict(event.target.value);
    },
    async get_street_index(event){
      this.path.city = event.target.value;
      this.address.street = await this.address_sevre.GetStreetByCity(event.target.value);
      this.address.index = await this.address_sevre.GetIndexByCity(event.target.value);
    },
    clear_address(key) {
      if (this.justOpened) return;
      if(key == "cauntry"){
        this.path.region = "",
        this.clear_address("region");
      }
      else if(key == "region"){
        this.path.district = "",
        this.clear_address("district");
      }
      else if(key == "district"){
        this.path.city = "";
        this.clear_address("city");
      }
      else if(key == "city"){
        this.path.index = "";
        this.path.street = "";
        this.path.build = "";
        this.path.corps = "";
        this.path.flat = "";
      }
    }
  },
  async created(){
    this.address_sevre = new Address();
    this.patterns = validation.patterns;
    this.address.country.name = "Завантаження...";
    this.address.country = (await this.address_sevre.GetALLCountry())[0];
    this.get_region(this.address.country.id);
    if (this.path.region !== "") {
      this.address.district = await this.address_sevre.GetDistrictByRegion(this.path.region);
      if (this.path.district !== "") {
        this.address.city = await this.address_sevre.GetCityByDistrict(this.path.district);
        if (this.path.city !== "") {
          this.address.street = await this.address_sevre.GetStreetByCity(this.path.city);
          this.address.index = await this.address_sevre.GetIndexByCity(this.path.city);
          this.justOpened = false;
          if(!this.editing_status) this.path.invalid = this.isInvalid();
        }
        else {this.path.invalid = true;}
      }
      else {this.path.invalid = true;}
    }
    else {this.path.invalid = true;}
  }
}
</script>