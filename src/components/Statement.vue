<template>
  <div class="p-3 border border-secondary border-2 rounded text-start">
    <CreateStatment :editing_status="editing_status" :statement_element="statement_element" :info="info" :fun="fun" v-if="statement_element.typeName == 'Заява про реєстрацію обтяження рухомого майна'"/>
    <ChangeStatment :editing_status="editing_status" :statement_element="statement_element" :info="info" :fun="fun" v-if="statement_element.typeName == 'Заяви про реєстрацію змін обтяження рухомого майна'"/>
  </div>
</template>

<script>
import CreateStatment from "./statements/statement_for_create.vue"
import ChangeStatment from "./statements/statement_for_changes.vue"
import {alienationLimit, encumbranceType, registrationType, currency, encumbranceKind} from '../data'
export default {
  data(){
    return {
      info:[]
    }
  },
  name: 'Statement',
  props: ["statement_element","editing_status", "fun"],
  components:{
    CreateStatment,
    ChangeStatment
  },
  async created(){
    this.info.encumbranceType = encumbranceType;
    this.info.encumbranceKind = encumbranceKind;
    this.info.registrationType = registrationType;
    this.info.alienationLimit = alienationLimit;
    this.info.currency = currency;
  }
}
</script>