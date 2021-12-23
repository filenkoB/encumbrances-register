<template>
  <div class="row">
    <div class="col">
      <GeneralInformation :item="element.generalInfo" :visible_status="visible_status_info" :button_search="button_search"/>
      
      <hr class="border-info border border-2" v-if="visible_status_info">
      <OtherChanges :item="element.otherChange" :editing_status="editing_status"  v-if="visible_status_info"/>

      <hr class="border-info border border-2" v-if="visible_status_info && (element.otherChange.changes_checked === 2)">
      <CreateStatment :editing_status="editing_status" :statement_element="statement_element"
                      :info="info" :fun="update_element"  v-if="visible_status_info && (element.otherChange.changes_checked === 2)"/>
    </div>
  </div>
</template>
<script>

import GeneralInformation from "../statement_parts/general_information_2.vue"
import CreateStatment from "./statement_for_create.vue"
import OtherChanges from "../statement_parts/other_changes.vue"
import {GetStatement, RegistrationNumber} from "../../connect_to_server"
import {GeneralInfoType2, Changes} from "../../classes"
export default {
  data(){
    return {
      element: {},
      visible_status_info: false
    }
  },
  name:'ChangeStatment',
  props:["editing_status","statement_element", "fun", "info"],
  components:{
    GeneralInformation,
    OtherChanges,
    CreateStatment
  },
  methods:{
    async button_search(item){
      this.visible_status_info = !this.visible_status_info;
      this.element.searched = this.visible_status_info;
      const info = await RegistrationNumber(item);
      console.log(info);
      console.log(item);
    },
    reset() {
      const time = new Date();
      this.element = {
        reset: this.reset,
        generalInfo: new GeneralInfoType2(null, time.toISOString()),
        otherChange: new Changes(),
        searched: this.visible_status_info,
        encumbranceTier: null,
        encumbranceDebtor: null,
        basisDocument: null,
        encumbranceInfo: null,
        encumbranceTerm: null,
        encumbranceDescriptionSubject: null,
      }
      this.fun(this.element);
    },
    update_element(item){
      Object.keys(item).forEach( i => {
        if (i !== 'generalInfo') {
          this.element[i] = item[i];
        }
      });
      console.log(this.element);
    }
  },
  async created(){
    if(this.statement_element.id != null){
      const data = await GetStatement(this.statement_element.id);
      console.log(data.encumbranceTerm)
      this.element = {
          generalInfo: new GeneralInfoType2(data.generalInfo.number, data.generalInfo.registrationDate),
          otherChange: new Changes(),
      }
    }
    else{
      const time = new Date();
      this.element = {
        reset: this.reset,
        generalInfo: new GeneralInfoType2(null, time.toISOString()),
        otherChange: new Changes(),
        searched: this.visible_status_info,
        encumbranceTier: null,
        encumbranceDebtor: null,
        basisDocument: null,
        encumbranceInfo: null,
        encumbranceTerm: null,
        encumbranceDescriptionSubject: null,
      }
      this.fun(this.element);
    }
  }
}
</script>