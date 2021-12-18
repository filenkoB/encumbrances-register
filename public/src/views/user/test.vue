<template>
  <div>
    <Statement :editing_status="editing_status"/>
  </div>
</template>
<script>
import Statement from "../../components/Statement.vue"
export default {
  data(){
    return {
      editing_status: false,
    }
  },
  components:{
    Statement,
    
  },
  methods:{

  },
  mounted(){
    
  },
  created(){
  }
}
</script>
