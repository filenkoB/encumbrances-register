<template>
  <div class="row">
    <div id="applications_area">
      <div class="row m-1 border border-2 border-secondary rounded" v-for="item in get_applications()" :key="item.pasNumber">
        <div class="col-3 text-start border-end border-4 pt-3">Вихідний номер: </div>
        <div class="col-3 text-start border-end border-4 pt-3">Дата заявки: </div>
        <div class="col-auto m-1 text-right">
          <button type="button" class="btn btn-outline-info m-1" @click="get_application_info(item)">Переглянути дані заявки</button>
          <button type="button" class="btn btn-outline-success m-1" :disabled="!item.visible_status" @click="accept()">Підтвердити</button>
          <button type="button" class="btn btn-outline-danger m-1" :disabled="!item.visible_status" @click="decline()">Відхилити</button>
        </div>
        <div v-if="item.visible_status">
          <card :cards="cards" :success="removeApp"/>
          <system-reg-application :application="item"/>
        </div>
      </div>
    </div>
    <div class="row my-3">
      <div class="col-auto">
        <label class="col-form-label">Кількісь записів:</label>
      </div>
      <div class="col-auto me-5">
        <input type="number" class="form-control" style="width: 60px" v-model="pagination.max_items_count" 
        value="pagination.max_items_count" min="1" max="7">
      </div>
      <nav class="col-7">
        <ul class="pagination justify-content-center">
          <span>
            <li class="page-item disabled" v-if="pagination.active_page == 0"><a class="page-link">Previous</a></li>
            <li class="page-item" v-else><a class="page-link" v-on:click="pagination_page(pagination.active_page)">Previous</a></li>
          </span>
          <span v-for="item in pagination.count_page" :key="item">
            <li class="page-item ms-1 me-1 active" v-if="item == pagination.active_page+1"><a class="page-link" v-on:click="pagination_page(item)">{{item}}</a></li>
            <li class="page-item ms-1 me-1" v-else><a class="page-link" v-on:click="pagination_page(item)">{{item}}</a></li>
          </span>
          <span>
            <li class="page-item disabled" v-if="pagination.active_page+1 == pagination.count_page"><a class="page-link">Next</a></li>
            <li class="page-item" v-else><a class="page-link" v-on:click="pagination_page(pagination.active_page+2)">Next</a></li>
          </span> 
        </ul>
      </nav>
    </div>
  </div>
</template>
<script>
import SystemRegApplication from "../../components/SystemRegApplication.vue"
import Card from "../../components/Card.vue"
import {sysAppsCards} from  "../../data"
export default {
  name: 'SystemRegApplications',
  data: function () {
    return {
      pagination:{
        active_page: 0,
        max_items_count:5,
        count_page: 0,
      },
      cards: null,
      applications: null
    };
  },
  components:
  {
    SystemRegApplication,
    Card
  },
  methods:{
    pagination_page(item){ this.pagination.active_page = item-1;},
    get_applications(){
      this.pagination.max_items_count = parseInt(this.pagination.max_items_count);
      if (this.pagination.max_items_count < 1) this.pagination.max_items_count = 1;
      if (this.pagination.max_items_count > 7) this.pagination.max_items_count = 7;
      this.pagination.count_page = Math.ceil(this.applications.length / this.pagination.max_items_count);
      const position = this.pagination.active_page*this.pagination.max_items_count;
      return this.applications.slice(position, position + this.pagination.max_items_count);       
    },
    get_application_info(item){
      this.closeInfo(item);
      item.visible_status = !item.visible_status;
    },
    accept() {
      this.cards[0].visible_status = true;
      this.cards[1].visible_status = false;
    },
    decline() {
      this.cards[0].visible_status = false;
      this.cards[1].visible_status = true;
    },
    closeInfo(item) {
      for(let app of this.applications){
        if (app !== item) app.visible_status = false;
      }
      this.cards[0].visible_status = false;
      this.cards[1].visible_status = false;
    },
    removeApp() {
      //
    }
  },
  mounted(){
    this.user_status = window.sessionStorage.getItem('user_status');
    if(!this.user_status || this.user_status != 'admin'){
        this.$router.push({ name: "Info"}).catch(() => {});
    }
  },
  created(){
    this.applications = [
      { chosenPassType: 'id-card', chosenRole: 'admin', visible_status: false,
      firstName: "Гетеросексуал", lastName: "Останній", parentName: "Міхалич", birthDate: "01-01-1970",
      pasNumber: "000002280", pasSeria: "", email: "sexmachin@ukr.net", agency: "", idNumber: "12381094784256",
      pasAgency: "0476", pasDate: "01-01-2012", userIsAuthorized: false,
      address: { path:{
        country: "Україна",
        region: "Хмельницька",
        district: "Славутський",
        city: "Славута",
        index: "1",
        street: "Вхідна",
        build: "37-А",
        corps: "1",
        flat: ""} }
      },
      { chosenPassType: 'id-card', chosenRole: 'admin', visible_status: false,
      firstName: "Гетеросексуал", lastName: "Останній", parentName: "Міхалич", birthDate: "01-01-1970",
      pasNumber: "00000228", pasSeria: "", email: "sexmachin@ukr.net", agency: "", idNumber: "12381094784256",
      pasAgency: "0476", pasDate: "01-01-2012", userIsAuthorized: false,
      address: { path:{
        country: "Україна",
        region: "Хмельницька",
        district: "Славутський",
        city: "Славута",
        index: "1",
        street: "Вхідна",
        build: "37-А",
        corps: "1",
        flat: ""} }
      },
      { chosenPassType: 'id-card', chosenRole: 'admin', visible_status: false,
      firstName: "Гетеросексуал", lastName: "Останній", parentName: "Міхалич", birthDate: "01-01-1970",
      pasNumber: "00002280", pasSeria: "", email: "sexmachin@ukr.net", agency: "", idNumber: "12381094784256",
      pasAgency: "0476", pasDate: "01-01-2012", userIsAuthorized: false,
      address: { path:{
        country: "Україна",
        region: "Хмельницька",
        district: "Славутський",
        city: "Славута",
        index: "1",
        street: "Вхідна",
        build: "37-А",
        corps: "1",
        flat: ""} }
      },
    ]
    this.cards = sysAppsCards;
  }
}
</script>
<style>
#applications_area{
  min-height: 500px;
}
</style>