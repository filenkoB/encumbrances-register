<template>
  <div class="row">
    <div class="col">
      <GeneralInformation :item="element.generalInfo" :editing_status="editing_status"/>

      <hr class="border-info border border-2">
      <Document :item="element.basisDocument" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2">
      <OtherChanges :item="element.otherChange" :editing_status="editing_status"/>     

      <hr class="border-info border border-2">
      <ChangeSubject :item="element.changeSubject" :editing_status="editing_status"/>
      </div>
  </div>
</template>
<script>

import GeneralInformation from "../statement_parts/general_information_2.vue"
import OtherChanges from "../statement_parts/other_changes.vue"
import ChangeSubject from "../statement_parts/change_subject.vue"
import Document from "../statement_parts/document.vue"
import {GetStatement} from "../../connect_to_server"
import {GeneralInfoType2, BasisDocument, Changes, SubjectChange} from "../../classes"
export default {
  data(){
    return {
      element: {}
    }
  },
  name:'CreateStatment',
  props:["editing_status","statement_element", "fun"],
  components:{
    GeneralInformation,
    Document,
    OtherChanges,
    ChangeSubject
  },
  async created(){
    if(this.statement_element.id != null){
      const data = await GetStatement(this.statement_element.id);
      console.log(data.encumbranceTerm)
      this.element = {
          generalInfo: new GeneralInfoType2(data.generalInfo.number, data.generalInfo.registrationDate),
          basisDocument: new BasisDocument(data.basisDocument.name, data.basisDocument.number, data.basisDocument.issuer, data.basisDocument.issueDate),
          otherChange: new Changes(),
          changeSubject: new SubjectChange()
      }
    }
    else{
      const time = new Date();
      this.element = {
        generalInfo: new GeneralInfoType2(null, time.toISOString()),
        basisDocument: new BasisDocument(null, null, null, time.toISOString()),
        otherChange: new Changes(),
        changeSubject: new SubjectChange()
      }
      this.fun(this.element);
    }
  }
}
</script>