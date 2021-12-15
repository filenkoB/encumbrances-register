<template>
  <div>
    
  </div>
</template>s
<script>
export default {
  name: 'MyStatements',
  data: function () {
    return {
        statments:[
            {
                type: "Реєстрація",
                status: "Прийнята",
                message:""
            },
            {
                type:"Внесення змін",
                status: "Надана в обробку",
                message:""
            },
            {
                type:"Отримання витягу",
                status: "Надано в обробку",
                message:""
            }
        ]
    };
  },
  components:{},
  methods:{},
  created(){}
}
</script>
<style>
#statements_area{
  min-height: 430px;
}
</style>