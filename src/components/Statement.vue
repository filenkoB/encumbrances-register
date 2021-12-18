<template>
  <form class="p-3 border border-secondary border-2 rounded text-start">
    <CreateStatment :editing_status="editing_status"/>
  </form>
</template>

<script>
//import { Weightlifter_Information, Debtor_Information, Basis_Document, Encumbrance_Information, Terms} from '../classes'
import {statement} from "../data";
import CreateStatment from "./statements/statement_for_create.vue"
export default {
  name: 'Statement',
  props: ["statement_element","editing_status"],
  components:{
    CreateStatment
  },
  created(){
    this.element = statement;
  }
}
</script>