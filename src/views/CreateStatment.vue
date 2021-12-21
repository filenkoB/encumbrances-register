<template>
  <form @submit.prevent="submit" @reset="reset" id="form" class="row mt-3 border border-3 border-secondary rounded">
    <div class="col">
      <div class="row border-bottom border-3 border-warning p-2">
        <div class="col-auto mt-2">
          <label class="col-form-label d-inline">Оберіть тип заяви:</label>
        </div>
        <div class="col-auto">
          <select class="form-control" v-model="statement_type">
            <option :value="true">Заява про реєстрацію обтяження рухомого майна</option>
            <option :value="false">Заяви про реєстрацію змін обтяження рухомого майна</option>
          </select>
        </div>
      </div>
      <div class="row p-2" v-if="statement_type">
        <Statement :editing_status="false" :statement_element="{id:null, typeName:'Заява про реєстрацію обтяження рухомого майна'}" :info="info" :fun="get_info"/>
      </div>
      <div class="row p-2" v-else>
        <Statement :editing_status="false" :statement_element="{id:null, typeName:'Заяви про реєстрацію змін обтяження рухомого майна'}" :info="info" :fun="get_info"/>
      </div>
      <div class="row m-2">
        <div class="col text-center">
          <button type="submit" id="submit" class="btn btn-outline-success me-5 hidden"></button>
          <button type="button" @click="fake_submit" class="btn btn-outline-success me-5">Підтвердити</button>
          <button type="reset" class="btn btn-outline-danger ms-5">Очистити</button>
        </div> 
      </div>
    </div>
  </form>
</template>
<script>
import Statement from "../components/Statement.vue"
import {EncumbranceType, RegistrationType, AlienationLimit, GetALLCurrency} from "../connect_to_server"
export default {
  data(){
    return {
      user_status: null,
      statement_type: true,
      info:[],
      statement:{},
      element:null,
      checking: false,
    }
  },
  name:'CreateStatment',
  components:{
    Statement
  },
  methods:{
    get_info(item){
      this.element = item;
    },
    get_stetement(){
      this.statement.typeName = "Заяви про реєстрацію змін обтяження рухомого майна";
      if(this.statement_type) this.statement.typeName = "Заява про реєстрацію обтяження рухомого майна";
      this.statement.id = null;
      return this.statement;
    },
    submit() {
      
    },
    fake_submit() {
      if (this.typeName === "Заява про реєстрацію обтяження рухомого майна") {
        if (this.element.encumbranceTier.invalid) {
          this.element.encumbranceTier.visible_status = true;
        }
        else if (this.element.encumbranceDebtor.invalid) {
          this.element.encumbranceDebtor.visible_status = true;
        }
        else if (this.element.basisDocument.invalid) {
          this.element.basisDocument.visible_status = true;
        }
        else if (this.element.encumbranceInfo.invalid) {
          this.element.encumbranceInfo.visible_status = true;
        }
        else if (this.element.encumbranceTerm.invalid) {
          this.element.encumbranceTerm.visible_status = true;
        }
        else if (this.element.encumbranceDescriptionSubject.invalid) {
          this.element.encumbranceDescriptionSubject.visible_status = true;
        }
      }
      else {
        if (this.element.basisDocument.invalid) {
          this.element.basisDocument.visible_status = true;
        }
      }
      setTimeout(this.click_submit, 100);
    },
    click_submit() {
      document.getElementById('submit').click();
    },
    reset() {
    }
  },
  mounted(){
      this.user_status = window.sessionStorage.getItem('user_status');
      if(!this.user_status || this.user_status != 'registrar' && this.user_status !='user'){
      this.$router.push({ name: "Info"}).catch(() => {});
    }
  },

  async created(){
    this.info.encumbranceType = await EncumbranceType();
    this.info.registrationType = await RegistrationType();
    this.info.alienationLimit = await AlienationLimit();
    this.info.currency = await GetALLCurrency();
  }
}
</script>
<style>
 .hidden {
   display: none;
 }
</style>