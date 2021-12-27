<template>
  <div class="row">
    <div class="col" v-if="visible_status">
      <GeneralInformation :item="element.generalInfo" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2" v-if="element.generalInfo">
      <WDInformation :idname="'tier'" :item="element.encumbranceTier" button_text="Відомості про Обтяжувача:" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2">
      <WDInformation :idname="'debtor'" :item="element.encumbranceDebtor" button_text="Відомості про Боржника:" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2">
      <Document :item="element.basisDocument" :editing_status="editing_status"/>
      
      <hr class="border-info border border-2">
      <EncumbranceInformation :item="element.encumbranceInfo" :editing_status="editing_status" :info="info"/>

      <hr class="border-info border border-2">
      <Terms :item="element.encumbranceTerm" :editing_status="editing_status" :info="info"/>

      <hr class="border-info border border-2">
      <EncumbranceDescriptionSubject :item="element.encumbranceDescriptionSubject" :button_vs="true" :editing_status="editing_status"/>
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
import {Registrator} from "../../connect_to_server"
import {GeneralInfo, EncumbranceTierDebtor, BasisDocument, EncumbranceInfo, EncumbranceTerm, DescriptionSubject} from "../../classes"
export default {
  data(){
    return {
      element: {
        generalInfo: {},
        encumbranceTier: {
          address:{
            path:{
              country:'',
              region:'',
              district:'',
              city:'',
              index:'',
              street:'',
              build:'',
              corps:'',
              flat:''
            }
          }
        },
        encumbranceDebtor: {
          address:{
            path:{
              country:'',
              region:'',
              district:'',
              city:'',
              index:'',
              street:'',
              build:'',
              corps:'',
              flat:''
            }
          }
        },
        basisDocument: {},
        encumbranceInfo:{},
        encumbranceTerm: {},
        encumbranceDescriptionSubject: {},
      
      },
      visible_status: true,
    }
  },
  name:'CreateStatment',
  props:["editing_status","statement_element", "info", "fun"],
  components:{
    GeneralInformation,
    WDInformation,
    Document,
    EncumbranceInformation,
    Terms,
    EncumbranceDescriptionSubject
  },
  methods: {
    reset() {
      const time = new Date();
      const address = {countryId:'', regionId:'', districtId:'', cityId:'', indexCode:'', streetId:'', building:'', corps:'',flat:''};
      this.element = {
        reset: this.reset,
        generalInfo: null,
        encumbranceTier: new EncumbranceTierDebtor(null, false, null, "", address),
        encumbranceDebtor: new EncumbranceTierDebtor(null, false, null, "", address),
        basisDocument: new BasisDocument(null, null, null, time.toISOString()),
        encumbranceInfo: new EncumbranceInfo( "85ad61fc-82e7-4436-a209-b07d1d7105e4", "159fcd68-1c41-425f-89b5-8a3fb5ee24e1", time.toISOString(), "5f424124-8e67-48f1-b7cc-57c9be5473c5","225e5466-a939-4ab6-8034-af49415bcff5", null),
        encumbranceTerm: new EncumbranceTerm( null, time.toISOString(), null, null),
        encumbranceDescriptionSubject: new DescriptionSubject(null, null, null, null),
      }
    },
  },
  async created(){
    if(this.statement_element.id != null){
      const registrator = new Registrator();
      const data = await registrator.GetStatementById(this.statement_element.id);
      if(data != null){
        this.visible_status = true;
        this.element = {
          generalInfo: new GeneralInfo(data.generalInfo.number, data.generalInfo.registrationDate),
          encumbranceTier: new EncumbranceTierDebtor(data.encumbranceTier.taxpayerAccountCardNumber, 
                                                    data.encumbranceTier.isForeigner, data.encumbranceTier.name, data.encumbranceTier.additionalInfo, data.encumbranceTier.address, null),
          encumbranceDebtor: new EncumbranceTierDebtor(data.encumbranceDebtor.taxpayerAccountCardNumber, 
                                                    data.encumbranceDebtor.isForeigner, data.encumbranceDebtor.name,data.encumbranceDebtor.additionalInfo, data.encumbranceDebtor.address, null),
          basisDocument: new BasisDocument(data.basisDocument.name, data.basisDocument.number,
                                          data.basisDocument.issuer, data.basisDocument.issueDate, null),
          encumbranceInfo: new EncumbranceInfo(data.encumbranceInfo.encumbranceKindId, data.encumbranceInfo.registrationTypeId, 
                          data.encumbranceInfo.lastEncumbranceOccurrenceDate, data.encumbranceInfo.encumbranceTypeId,
                          data.encumbranceInfo.alienationLimitId, data.encumbranceInfo.typeDescription, null),
          encumbranceTerm: new EncumbranceTerm(data.encumbranceTerm.obligationAmount, data.encumbranceTerm.termTo, data.encumbranceTerm.additionalTerms, data.encumbranceTerm.currencyTypeId, null),
          encumbranceDescriptionSubject: new DescriptionSubject(data.encumbranceObject.objectDescription, data.encumbranceObject.serialNumber, data.encumbranceObject.stateRegistrationNumber, data.encumbranceObject.anotherObjectsDesc, null),
        }
      }
      else{
        this.visible_status = false;
      }
    }
    else{
      const time = new Date();
      const address = {countryId:'', regionId:'', districtId:'', cityId:'', indexCode:'', streetId:'', building:'', corps:'',flat:''};
      if(this.statement_element.encumbranceTier && this.statement_element.encumbranceTier!=null)
      {
        this.element = {
          reset: this.reset,
          generalInfo: null,
          encumbranceTier: new EncumbranceTierDebtor(this.statement_element.encumbranceTier.taxpayerAccountCardNumber, 
                                                    this.statement_element.encumbranceTier.isForeigner, this.statement_element.encumbranceTier.name, this.statement_element.encumbranceTier.additionalInfo, this.statement_element.encumbranceTier.address, this.statement_element.encumbranceTier.id),
          encumbranceDebtor: new EncumbranceTierDebtor(this.statement_element.encumbranceDebtor.taxpayerAccountCardNumber, 
                                                    this.statement_element.encumbranceDebtor.isForeigner, this.statement_element.encumbranceDebtor.name,this.statement_element.encumbranceDebtor.additionalInfo, this.statement_element.encumbranceDebtor.address, this.statement_element.encumbranceDebtor.id),
          basisDocument: new BasisDocument(this.statement_element.basisDocument.name, this.statement_element.basisDocument.number,
                                          this.statement_element.basisDocument.issuer, this.statement_element.basisDocument.issueDate, this.statement_element.basisDocument.id),
          encumbranceInfo: new EncumbranceInfo(this.statement_element.encumbranceInfo.encumbranceKindId, this.statement_element.encumbranceInfo.registrationTypeId, 
                          this.statement_element.encumbranceInfo.lastEncumbranceOccurrenceDate, this.statement_element.encumbranceInfo.encumbranceTypeId,
                          this.statement_element.encumbranceInfo.alienationLimitId, this.statement_element.encumbranceInfo.typeDescription, this.statement_element.encumbranceInfo.id),
          encumbranceTerm: new EncumbranceTerm(this.statement_element.encumbranceTerm.obligationAmount, this.statement_element.encumbranceTerm.termTo, this.statement_element.encumbranceTerm.additionalTerms, this.statement_element.encumbranceTerm.currencyTypeId, this.statement_element.encumbranceTerm.id),
          encumbranceDescriptionSubject: new DescriptionSubject(this.statement_element.encumbranceDescriptionSubject.objectDescription, this.statement_element.encumbranceDescriptionSubject.serialNumber, this.statement_element.encumbranceDescriptionSubject.stateRegistrationNumber, this.statement_element.encumbranceDescriptionSubject.anotherObjectsDesc, this.statement_element.encumbranceDescriptionSubject.id),
        }
        this.fun(this.element);
      }
      else{
        this.element = {
          reset: this.reset,
          generalInfo: null,
          encumbranceTier: new EncumbranceTierDebtor(null, false, null, "", address, null),
          encumbranceDebtor: new EncumbranceTierDebtor(null, false, null, "", address, null),
          basisDocument: new BasisDocument(null, null, null, time.toISOString(), null),
          encumbranceInfo: new EncumbranceInfo( "85ad61fc-82e7-4436-a209-b07d1d7105e4", "159fcd68-1c41-425f-89b5-8a3fb5ee24e1", time.toISOString(), "5f424124-8e67-48f1-b7cc-57c9be5473c5","225e5466-a939-4ab6-8034-af49415bcff5", null, null),
          encumbranceTerm: new EncumbranceTerm( null, time.toISOString(), null, null, null),
          encumbranceDescriptionSubject: new DescriptionSubject(null, null, null, null, null),
        }
        this.fun(this.element);
      }
    }
  }
}
</script>