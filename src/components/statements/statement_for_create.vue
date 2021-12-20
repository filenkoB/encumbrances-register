<template>
  <div class="row">
    <div class="col">
      <GeneralInformation :item="element.generalInfo" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2">
      <WDInformation :item="element.encumbranceTier" button_text="Відомості про Обтяжувача:" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2">
      <WDInformation :item="element.encumbranceDebtor" button_text="Відомості про Боржника:" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2">
      <Document :item="element.basisDocument" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2">
      <EncumbranceInformation :item="element.encumbranceInfo" :editing_status="editing_status" :info="info"/>

      <hr class="border-info border border-2">
      <Terms :item="element.encumbranceTerm" :editing_status="editing_status" :currency_type="info.currency"/>

      <hr class="border-info border border-2">
      <EncumbranceDescriptionSubject :item="element.encumbranceDescriptionSubject" :editing_status="editing_status"/>
    </div>
  </div>
</template>
<script>
import EncumbranceDescriptionSubject from "../statement_parts/encumbrance_description_subject.vue"
import EncumbranceInformation from "../statement_parts/encumbrance_information.vue"
import GeneralInformation from "../statement_parts/general_information.vue"
import WDInformation from "../statement_parts/wd_information.vue"
import Document from "../statement_parts/document.vue"
import Terms from "../statement_parts/terms.vue"
import {GetStatement} from "../../connect_to_server"
import {GeneralInfo, EncumbranceTierDebtor, BasisDocument, EncumbranceInfo, EncumbranceTerm, DescriptionSubject} from "../../classes"
export default {
  data(){
    return {
      element: {}
    }
  },
  name:'CreateStatment',
  props:["editing_status","statement_element", "info"],
  components:{
    GeneralInformation,
    WDInformation,
    Document,
    EncumbranceInformation,
    Terms,
    EncumbranceDescriptionSubject
  },
  async created(){
    const data = await GetStatement(this.statement_element.id);

    this.element = {
      generalInfo: new GeneralInfo(data.generalInfo.number, data.generalInfo.registrationDate),
      encumbranceTier: new EncumbranceTierDebtor(data.encumbranceTier.taxpayerAccountCardNumber, 
                                                data.encumbranceTier.isForeigner, data.encumbranceTier.name),
      encumbranceDebtor: new EncumbranceTierDebtor(data.encumbranceDebtor.taxpayerAccountCardNumber, 
                                                data.encumbranceDebtor.isForeigner, data.encumbranceDebtor.name),
      basisDocument: new BasisDocument(data.basisDocument.name, data.basisDocument.number,
                                       data.basisDocument.issuer, data.basisDocument.issueDate),
      encumbranceInfo: new EncumbranceInfo(data.encumbranceInfo.encumbranceKindId, data.encumbranceInfo.registrationTypeId, 
                      data.encumbranceInfo.lastEncumbranceOccurrenceDate, data.encumbranceInfo.encumbranceTypeId,
                      data.encumbranceInfo.alienationLimitId, data.encumbranceInfo.typeDescription),
      encumbranceTerm: new EncumbranceTerm(data.encumbranceTerm.obligationAmount, data.encumbranceTerm.termTo, data.encumbranceTerm.additionalTerms, data.encumbranceTerm.currencyTypeId),
      encumbranceDescriptionSubject: new DescriptionSubject(),
    }
    console.log(this.element.encumbranceTier);
    
  }
}
</script>