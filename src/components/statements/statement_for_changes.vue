<template>
  <div class="row">
    <div class="col">
      <GeneralInformation :item="element.generalInfo" :editing_status="editing_status"/>

      <hr class="border-info border border-2">
      <Document :item="element.basisDocument" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2">
      <OtherChanges :item="element.otherChange" :editing_status="editing_status"/>
      
      </div>
  </div>
</template>
<script>
//import EncumbranceDescriptionSubject from "../statement_parts/encumbrance_description_subject.vue"
//import EncumbranceInformation from "../statement_parts/encumbrance_information.vue"
import GeneralInformation from "../statement_parts/general_information_2.vue"
import OtherChanges from "../statement_parts/other_changes.vue"
import Document from "../statement_parts/document.vue"
//import Terms from "../statement_parts/terms.vue"
import {GetStatement} from "../../connect_to_server"
import {GeneralInfoType2, BasisDocument, Changes} from "../../classes"
export default {
  data(){
    return {
      element: {}
    }
  },
  name:'CreateStatment',
  props:["editing_status","statement_element"],
  components:{
    GeneralInformation,
    Document,
    OtherChanges
  },
  async created(){
    const data = await GetStatement(this.statement_element.id);
    console.log(data.encumbranceTerm)
    this.element = {
        generalInfo: new GeneralInfoType2(data.generalInfo.number, data.generalInfo.registrationDate),
        basisDocument: new BasisDocument(data.basisDocument.name, data.basisDocument.number, data.basisDocument.issuer, data.basisDocument.issueDate),
        otherChange: new Changes()
      
    }
    console.log(this.element.encumbranceTier);
    
  }
}
</script>