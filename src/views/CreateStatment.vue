<template>
  <div>
    <form v-if="!succeeded" @submit.prevent="submit" @reset.prevent="reset" id="form" class="row mt-3 border border-3 border-secondary rounded">
      <div class="col">
        <div class="row border-bottom border-3 border-warning p-2">
          <div class="col-auto mt-2">
            <label class="col-form-label d-inline">Оберіть тип заяви:</label>
          </div>
          <div class="col-auto">
            <select class="form-control" v-model="statement_type">
              <option :value="true">Заява про реєстрацію обтяження рухомого майна</option>
              <option :value="false">Заява про реєстрацію змін обтяження рухомого майна</option>
            </select>
          </div>
        </div>
        <div class="row p-2" v-if="statement_type">
          <Statement :editing_status="false" :statement_element="{id:null, typeName:'Заява про реєстрацію обтяження рухомого майна'}" :info="info" :fun="get_info"/>
        </div>
        <div class="row p-2" v-else>
          <Statement :editing_status="false" :statement_element="{id:null, typeName:'Заява про реєстрацію змін обтяження рухомого майна'}" :info="info" :fun="get_info"/>
        </div>
        <div class="row m-2">
            <button type="submit" id="submit" class="btn btn-outline-success me-5 hidden"></button>
            <div class="col"></div>
            <div v-if="waitingForResponse" class="col">
              <button class="btn btn-success" type="button" disabled>
                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                Відправка...
              </button>
            </div>
            <div v-else class="col">
                <button type="button" @click="fake_submit" class="btn btn-outline-success me-5">Підтвердити</button>
            </div>
            <div class="col">
                <button :disabled="waitingForResponse" type="reset" class="btn btn-outline-danger ms-5">Очистити</button>
            </div>
            <div class="col"></div>
        </div>
      </div>
    </form>
    <div v-else>
      <div class="alert alert-success text-center" role="alert">
        <h4 class="alert-heading ">{{message.title}}</h4>
        <p>{{message.text}}</p>
      </div>
      <button @click="backToForm" class="btn btn-outline-secondary mt-2">Повернутися до створення заяв</button>
    </div>
  </div>
</template>
<script>
import Statement from "../components/Statement.vue"
import {Registrator, Main} from "../connect_to_server"
export default {
  data(){
    return {
      registrator: null,
      main: null,
      isvalid: true,
      user_status: null,
      statement_type: true,
      info:[],
      statement:{},
      element:null,
      checking: false,
      waitingForResponse: false,
      succeeded: false,
      message: { title: "", text: ""}
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
      this.statement.typeName = "Заява про реєстрацію змін обтяження рухомого майна";
      if(this.statement_type) this.statement.typeName = "Заява про реєстрацію обтяження рухомого майна";
      this.statement.id = null;
      return this.statement;
    },
    fake_submit() {
      this.isvalid = true;
      let time = 100;
      if (this.statement_type) {
        Object.keys(this.element).forEach( i => { 
          if ( i !== 'generalInfo' && i !=='reset' && this.isvalid) {
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
              if ( i !== 'searched' && i !== 'otherChange' && i !== 'generalInfo' && i !== 'reset' && i !== 'id' && i !== 'searchedInfo' && this.isvalid) {
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
        else this.isvalid = false;
      }
      setTimeout(this.click_submit, time);
    },
    click_submit() {
      document.getElementById('submit').click();
    },
    async submit(){
      this.waitingForResponse = true;
      if (!this.statement_type) {
        if(this.element.otherChange.changes_checked && this.element.otherChange.changes_checked==1 && this.element.searchedInfo!=undefined){
          let el = {
            statementTypeId: "beca126e-1e23-4db3-865a-a4645baf0428",        
            encumbranceTier: this.element.encumbranceTier.get_info(),
            encumbranceDebtor: this.element.encumbranceDebtor.get_info(),
            basisDocument: this.element.basisDocument.get_info(),
            encumbranceInfo: this.element.encumbranceInfo.get_info(),
            encumbranceTerm: this.element.encumbranceTerm.get_info(),
            encumbranceObject: this.element.encumbranceDescriptionSubject.get_info()
          }
          console.log(el)
          const new_id = await this.main.CreateStatement(el);
          if(this.user_status == 'registrar'){
            await this.registrator.EncumbranceRemoveStatementAccept(new_id.id);
            this.message.title ="Заява про припинення обтяження була успішно зареєстрована!";
            this.message.text ="Заява про реєстрацію змін обтяження рухомого майна (припинення обтяження) була успішно зареєстрована у Реєстрі.";
            this.waitingForResponse = false;
            this.succeeded = true;
          }
          else {
            this.message.title ="Заява про припинення обтяження була успішно відправлена на реєстрацію!";
            this.message.text ="Заява про реєстрацію змін обтяження рухомого майна (припинення обтяження) була успішно відправлена на реєстрацію у Реєстрі. " + this.user_message;
            this.waitingForResponse = false;
            this.succeeded = true;
          }
        }
        else{
          this.waitingForResponse = false
        }
      }
      if(this.isvalid){
        if(this.statement_type){
          let el = {
            statementTypeId: "b231d49d-8c34-4efc-bde2-e398d35a5587",        
            encumbranceTier: this.element.encumbranceTier.get_info(),
            encumbranceDebtor: this.element.encumbranceDebtor.get_info(),
            basisDocument: this.element.basisDocument.get_info(),
            encumbranceInfo: this.element.encumbranceInfo.get_info(),
            encumbranceTerm: this.element.encumbranceTerm.get_info(),
            encumbranceObject: this.element.encumbranceDescriptionSubject.get_info()
          };
          const new_id = await this.main.CreateStatement(el)
          if(this.user_status == 'registrar'){
            await this.registrator.EncumbranceRegisterStatementAccept(new_id.id);
            this.message.title ="Заява про реєстрацію обтяження була успішно зареєстрована!";
            this.message.text ="Заява про реєстрацію обтяження рухомого майна була успішно зареєстрована у Реєстрі.";
            this.waitingForResponse = false;
            this.succeeded = true;
          }
          else {
            this.message.title ="Заява про реєстрацію обтяження була успішно відправлена на реєстрацію!";
            this.message.text ="Заява про реєстрацію обтяження рухомого майна  була успішно відправлена на реєстрацію у Реєстрі. " + this.user_message;
            this.waitingForResponse = false;
            this.succeeded = true;
          }
        }
        else{
          if(this.element.otherChange.changes_checked == 2 && this.element.encumbranceTier!=null){
            let el = {
              statementTypeId: "3c63d55d-4b8f-4c06-8122-6a1c3ac72699",        
              encumbranceTier: this.element.encumbranceTier.get_info(),
              encumbranceDebtor: this.element.encumbranceDebtor.get_info(),
              basisDocument: this.element.basisDocument.get_info(),
              encumbranceInfo: this.element.encumbranceInfo.get_info(),
              encumbranceTerm: this.element.encumbranceTerm.get_info(),
              encumbranceObject: this.element.encumbranceDescriptionSubject.get_info()
            }
            const new_id = await this.main.CreateStatement(el);
            if(this.user_status == 'registrar'){
              await this.registrator.EncumbranceUpdateStatementAccept(new_id.id);
              this.message.title ="Заява про реєстрацію змін обтяження була успішно зареєстрована!";
              this.message.text ="Заява про реєстрацію змін обтяження рухомого майна була успішно зареєстрована у Реєстрі.";
              this.waitingForResponse = false;
              this.succeeded = true;
            }
            else {
              this.message.title ="Заява про реєстрацію змін обтяження була успішно відправлена на реєстрацію!";
              this.message.text ="Заява про реєстрацію змін обтяження рухомого майна була успішно відправлена на реєстрацію у Реєстрі. " + this.user_message;
              this.waitingForResponse = false;
              this.succeeded = true;
            }
          }
        }
      }
      else setTimeout(() => {this.waitingForResponse = false;}, 100);
    },
    reset(){
      if (this.statement_type) {
        this.element.reset();
      }
      else {
        if (this.element.searched) {
          this.element.reset();
        }
      }
    },
    backToForm() {
      this.reset();
      this.succeeded = false;
    }
  },
  mounted(){
    this.user_status = window.sessionStorage.getItem('user_status');
    if(!this.user_status || this.user_status != 'registrar' && this.user_status !='user'){
      this.$router.push({ name: "Info"}).catch(() => {});
    }
    this.$root.$children[0].$children[0].page = 'create-statement';
    this.user_message =  "Тепер ця заява буде відображатися у розділі \"Мої заяви\", де після розгляду її реєстраторами її статус зміниться на \"Прийнято\" або \"Відхилено\"."
  },
  created(){
    this.registrator = new Registrator();
    this.main = new Main();
  }
}
</script>
<style>
 .hidden {
   display: none;
 }
</style>