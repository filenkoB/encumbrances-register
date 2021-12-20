<template>
  <form class="p-3 border border-secondary border-2 rounded text-start">
    <CreateStatment :editing_status="editing_status" :statement_element="statement_element" v-if="statement_element.typeName == 'Заява про реєстрацію обтяження рухомого майна'"/>
  </form>
</template>

<script>
import CreateStatment from "./statements/statement_for_create.vue"
export default {

  name: 'Statement',
  props: ["statement_element","editing_status"],
  components:{
    CreateStatment
  },
}
</script>