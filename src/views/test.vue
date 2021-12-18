<template>
  <div>
    <pre>
      {{checked}}
    </pre>

    <div class="input-group mb-3">
      <span class="input-group-text" v-if="checked != 'Оберіть ...'">{{currency_type.filter(el=>el.id==checked)[0].sign}}</span>
      <span class="input-group-text" v-else></span>
      <select class="form-control" :disabled="editing_status"  v-model="checked">
        <option selected disabled>Оберіть ...</option>
        <option v-for="item in currency_type" :key="item.id" :value="item.id">{{ item.name }}</option>
      </select>
    </div>
  </div>
</template>
<script>
//import Address from "../components/Address.vue";
//<Address :path="path"/>

export default {
  data(){
    return {
      path:{
        country: "Оберіть ...",
        region: "Оберіть ...",
        district: "Оберіть ...",
        city: "Оберіть ...",
        index: "Оберіть ...",
        street: "Оберіть ...",
        build: "Оберіть ...",
        corps: "Оберіть ...",
        flat:"Оберіть ..."
      },
      editing_status: false,
      currency_type: [],
      checked: "Оберіть ..."
    }
  },
  components:{
    //Address
    
  },
  methods:{
    get_currncy(event){
      this.checked = event.target.value
    }
  },
  mounted(){
    console.log("mounted");
    fetch(process.env.VUE_APP_HEROKU_PATH + "/CurrencyType")
    .then(response =>{
      if( response.status == 200){
        response.json().then(data=>this.currency_type=data)
      }
    })
  },
  created(){
    console.log("created");
    
    const requestOptions = {
      method: "POST",
      headers: { 'Accept': 'application/json', 'Content-Type': 'application/json' },
      body: JSON.stringify({ login: "User", password: "Test" })
    }
    fetch(process.env.VUE_APP_HEROKU_PATH + "/Auth", requestOptions)
        .then(response =>{
          console.log("Auth", response.json());
        })
      .catch(error => {
        this.errorMessage = error;
        console.error('There was an error!', error);
      })
  }
}
</script>
