<template>
  <form class="p-3 border border-secondary border-2 rounded text-start">
    <CreateStatment :editing_status="editing_status" :statement_element="statement_element" :info="info" :fun="fun" v-if="statement_element.typeName == 'Заява про реєстрацію обтяження рухомого майна'"/>
    <ChangeStatment :editing_status="editing_status" :statement_element="statement_element" :info="info" :fun="fun" v-if="statement_element.typeName == 'Заяви про реєстрацію змін обтяження рухомого майна'"/>
  </form>
</template>

<script>
import CreateStatment from "./statements/statement_for_create.vue"
import ChangeStatment from "./statements/statement_for_changes.vue"
import {EncumbranceType, EncumbranceKind, RegistrationType, AlienationLimit, GetALLCurrency} from "../connect_to_server"
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
    this.info.encumbranceType = await EncumbranceType();
    this.info.encumbranceKind = await EncumbranceKind();
    this.info.registrationType = await RegistrationType();
    this.info.alienationLimit = await AlienationLimit();
    this.info.currency = await GetALLCurrency();
  }
}
</script>