<template>
  <div>
    <Statement :editing_status="editing_status"/>
  </div>
</template>
<script>
import Statement from "../../components/statements/statement_for_create.vue"
export default {
  data(){
    return {
      editing_status: false,
    }
  },
  components:{
    Statement,
  }
}
</script>
