<template>
  <div class="row">
    <div class="col">
      <GeneralInformation :item="element.generalInfo" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2">
      <WDInformation :item="element.encumbranceTier" button_text="Відомості про Обтяжувача:" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2">
      <WDInformation :item="element.debtor_information" button_text="Відомості про Боржника:" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2">
      <Document :item="element.document" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2">
      <EncumbranceInformation :item="element.encumbrance_information" :editing_status="editing_status"/>

      <hr class="border-info border border-2">
      <Terms :item="element.terms" :editing_status="editing_status"/>
    </div>
  </div>
</template>
<script>
import EncumbranceInformation from "../statement_parts/encumbrance_information.vue"
import GeneralInformation from "../statement_parts/general_information.vue"
import WDInformation from "../statement_parts/wd_information.vue"
import Document from "../statement_parts/document.vue"
import Terms from "../statement_parts/terms.vue"
import {GetStatement} from "../../connect_to_server"
import {GeneralInfo, EncumbranceTier} from "../../classes"
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
    WDInformation,
    Document,
    EncumbranceInformation,
    Terms
  },
  async created(){
    const data = await GetStatement(this.statement_element.id);
    console.log(data.encumbranceTier)
    this.element = {
      generalInfo: new GeneralInfo(data.generalInfo.number, data.generalInfo.registrationDate),
      encumbranceTier: new EncumbranceTier(data.encumbranceTier.taxpayerAccountCardNumber, data.encumbranceTier.isForeigner, data.encumbranceTier.name),
    }
    console.log(this.element.encumbranceTier);
    
  }
}
</script>