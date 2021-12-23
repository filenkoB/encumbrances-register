<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row" :class="colour">
          <div class="col">
            <div class="row">
              <div class="col-auto">
                <label class="col-form-label">Інші зміни:</label>
              </div>
              <div class="col-4">
                <select class="form-control" required :disabled="editing_status" @change="fun(item.changes_checked)"  v-model="item.changes_checked">
                  <option v-for="it in changes" :key="it.number" :value="it.number">{{ it.name }}</option>
                </select>
              </div>
            </div>
          </div>
      </div>
    </div>
  </div>
</template>
<script>
import {get_button_colour, get_class_colour, change_item_visible_status} from "../logic";
export default {
  data(){
    return {
      changes: null,
      changeType: null,
      element:null,
      element2:null,
    }
  },
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){change_item_visible_status(this.item)}
  },
  props:["item", "editing_status", "fun"],
  name:'OtherChanges',
  components:{
  },
  created(){
    this.changes = [
      {number: 1, name: "Зареєструвати припинення обтяження"},
      {number: 2, name: "Змінити дані обтяження"},
    ];
  }
}
</script>