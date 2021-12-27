<template>
  <div class="row">
    <div class="col">
      <GeneralInformation :item="element.generalInfo" :visible_status="visible_status_info" :text="text" :button_search="button_search"/>
      
      <hr class="border-info border border-2" v-if="visible_status_info">
      <OtherChanges :item="element.otherChange" :editing_status="editing_status" v-if="visible_status_info"/>

      <hr class="border-info border border-2" v-if="visible_status_info && (element.otherChange.changes_checked === 2)">
      <CreateStatment :editing_status="editing_status" :statement_element="element"
                      :info="info" :fun="update_element"  v-if="visible_status_info && (element.otherChange.changes_checked === 2)"/>
    </div>
  </div>
</template>
<script>

import GeneralInformation from "../statement_parts/general_information_2.vue"
import CreateStatment from "./statement_for_create.vue"
import OtherChanges from "../statement_parts/other_changes.vue"
import {Registrator, Encumbrance} from "../../connect_to_server"
import {Changes} from "../../classes"
export default {
  data(){
    return {
      text: null,
      registrator: null,
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
      this.visible_status_info = false;
      this.text = null;
      this.element.searched = false;
      const encumbrance = new Encumbrance();
      const info = await encumbrance.EncumbranceRegistrationNumber(item);
      if(info.maxStatements!=0){
        this.visible_status_info = true;
        this.element.searched = this.visible_status_info;
        this.element.searchedInfo = item;
        this.element.encumbranceTier = info.encumbranceTier;
        this.element.encumbranceDebtor = info.encumbranceDebtor;
        this.element.basisDocument = info.basisDocument;
        this.element.encumbranceInfo = info.encumbranceInfo;
        this.element.encumbranceTerm = info.encumbranceTerm;
        this.element.encumbranceDescriptionSubject = info.encumbranceObject;
        this.element.id = null;
        console.log("Info", info);
      }
      else{
        this.text = "За вашим запитом не було знайдено обтяження з номером " + item;
        this.element.searchedInfo = undefined;
      }
      
    },
    reset() {
      this.element = {
        reset: this.reset,
        generalInfo: {},
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
      this.element.encumbranceTier = item.encumbranceTier;
      this.element.encumbranceDebtor = item.encumbranceDebtor;
      this.element.basisDocument = item.basisDocument;
      this.element.encumbranceInfo = item.encumbranceInfo;
      this.element.encumbranceTerm = item.encumbranceTerm;
      this.element.encumbranceDescriptionSubject = item.encumbranceDescriptionSubject;
    }
  },
  async created(){
    this.registrator = new Registrator();
    if(this.statement_element.id != null){
      const data = await this.registrator.GetStatement(this.statement_element.id);
      console.log(data.encumbranceTerm)
      this.element = {
        reset: this.reset,
        generalInfo: {},
        otherChange: new Changes(),
        searched: this.visible_status_info,
        encumbranceTier: null,
        encumbranceDebtor: null,
        basisDocument: null,
        encumbranceInfo: null,
        encumbranceTerm: null,
        encumbranceDescriptionSubject: null,
      }
    }
    else{
      this.element = {
        reset: this.reset,
        generalInfo: {},
        otherChange: new Changes(),
        searched: this.visible_status_info,
        encumbranceTier: null,
        encumbranceDebtor: null,
        basisDocument: null,
        encumbranceInfo: null,
        encumbranceTerm: null,
        encumbranceDescriptionSubject: null,
      }
    }
    this.fun(this.element);
  }
}
</script>