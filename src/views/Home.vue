<template>
  <div class="text-start">Hi
    <pre>{{data}}</pre>
  </div>
</template>
<script>

export default {
  data(){
    return{
      data: null,
    }
  },
  mounted() {
    this.data = this.$route.params;
  }
}
</script>
