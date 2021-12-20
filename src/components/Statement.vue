<template>
  <form class="p-3 border border-secondary border-2 rounded text-start">
    <CreateStatment :editing_status="editing_status" :statement_element="statement_element" :info="info" :fun="fun" v-if="statement_element.typeName == 'Заява про реєстрацію обтяження рухомого майна'"/>
    <ChangeStatment :editing_status="editing_status" :statement_element="statement_element" v-if="statement_element.typeName == 'Зява про реєстрацію обтяження рухомого майна'"/>
  </form>
</template>

<script>
import CreateStatment from "./statements/statement_for_create.vue"
import ChangeStatment from "./statements/statement_for_changes.vue"
export default {

  name: 'Statement',
  props: ["statement_element","editing_status", "info", "fun"],
  components:{
    CreateStatment,
    ChangeStatment
  },
}
</script>