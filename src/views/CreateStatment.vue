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
          <button type="reset" @click="reset" class="btn btn-outline-danger ms-5">Очистити</button>
        </div> 
      </div>
    </div>
  </form>
</template>
<script>
import Statement from "../components/Statement.vue"
import {CreateStatement} from "../connect_to_server"
export default {
  data(){
    return {
      isvalid: true,
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
    fake_submit() {
      this.isvalid = true;
      let time = 100;
      if (this.statement_type) {
        Object.keys(this.element).forEach( i => { 
          if ( i !== 'generalInfo' && this.isvalid) {
            if (this.element[i].invalid) {
              if (!this.element[i].visible_status) {
                this.element[i].change_visibility();
                time = 500;
              }
              this.isvalid = false;
            }
          }
        });
      }
      else {
        if (this.element.searched) {
          if (this.element.otherChange.changes_checked === 2) {
            Object.keys(this.element).forEach( i => { 
              if ( i !== 'searched' && i !== 'otherChange' && i !== 'generalInfo' && this.isvalid) {
                if (this.element[i].invalid) {
                  if (!this.element[i].visible_status) {
                    this.element[i].change_visibility();
                    time = 500;
                  }
                  this.isvalid = false;
                }
              }
            });
          }
        }
        this.isvalid = false;
      }
      setTimeout(this.click_submit, time);
    },
    click_submit() {
      document.getElementById('submit').click();
    },
    async submit(){
      if(this.isvalid){
        console.log("hi",this.element);
        let el = {
          statementTypeId: "00000000-0000-0000-0000-000000000000",        
          encumbranceTier: this.element.encumbranceTier.get_info(),
          encumbranceDebtor: this.element.encumbranceDebtor.get_info(),
          basisDocument: this.element.basisDocument.get_info(),
          encumbranceInfo: this.element.encumbranceInfo.get_info(),
          encumbranceTerm: this.element.encumbranceTerm.get_info(),
          encumbranceObject: this.element.encumbranceDescriptionSubject.get_info()
        }
        if(this.statement.typeName =="Заява про реєстрацію обтяження рухомого майна") el.statementTypeId = "b231d49d-8c34-4efc-bde2-e398d35a5587";
        else el.statementTypeId = "3c63d55d-4b8f-4c06-8122-6a1c3ac72699";
        await CreateStatement(el)
        console.log(el);
      }
    },
    reset(){
      this.$router.go(0);
    }
  },
  mounted(){
      this.user_status = window.sessionStorage.getItem('user_status');
      if(!this.user_status || this.user_status != 'registrar' && this.user_status !='user'){
      this.$router.push({ name: "Info"}).catch(() => {});
    }
  },
}
</script>
<style>
 .hidden {
   display: none;
 }
</style>