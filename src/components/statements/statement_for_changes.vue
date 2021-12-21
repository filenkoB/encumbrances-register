<template>
  <div class="row">
    <div class="col">
      <GeneralInformation :item="element.generalInfo" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2">
      <OtherChanges :item="element.otherChange" :editing_status="editing_status"/>

      <hr class="border-info border border-2">
      <CreateStatment :editing_status="editing_status" :statement_element="statement_element" :info="info" :fun="fun"/>
    </div>
  </div>
</template>
<script>

import GeneralInformation from "../statement_parts/general_information_2.vue"
import CreateStatment from "./statement_for_create.vue"
import OtherChanges from "../statement_parts/other_changes.vue"
import {GetStatement} from "../../connect_to_server"
import {GeneralInfoType2, Changes} from "../../classes"
export default {
  data(){
    return {
      element: {}
    }
  },
  name:'ChangeStatment',
  props:["editing_status","statement_element", "fun", "info"],
  components:{
    GeneralInformation,
    OtherChanges,
    CreateStatment
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
        generalInfo: new GeneralInfoType2(null, time.toISOString()),
        otherChange: new Changes(),
      }
      this.fun(this.element);
    }
  }
}
</script>