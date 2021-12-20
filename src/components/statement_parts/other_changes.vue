<template>
  <div class="row" v-if="item">{{item}}
    <div class="col">
      <div class="row">
        <div class="col-auto">
          <button type="button" :class="button()" v-on:click="change()">Загальні інформація:</button>
        </div> 
      </div>
      <hr class="border-secondary border border-2" v-if="item.visible_status">
      <div class="row" v-if="item.visible_status" :class="colour">
          <div class="col">
              <div class="row">
                <div class="col-auto">
                  <label class="col-form-label">Інші зміни:</label>
                </div>
                <div class="col-4 border-secondary border border-2 p-2">
                  <select class="form-control" :disabled="editing_status"  v-model="item.changes.checked">
                    <option selected disabled>Оберіть ...</option>
                    <option v-for="it in changes.data" :key="it.number" :value="it.number">{{ it.name }}</option>
                  </select>
                </div>
              </div>
              <div class="row mt-2">
                <div class="col-auto">
                  <label class="col-form-label">Зміни Обтяжувача або Боржника:</label>
                </div>
                <div class="col-4 border-secondary border border-2 p-2">
                  <div class="col-auto">
                    <div class="row">
                      <div class="col-auto">
                        <label class="col-form-label">Тип змін:</label>
                      </div>
                      <div class="col-auto">
                        <select class="form-control" :disabled="editing_status"  v-model="item.changeType.checked">
                          <option selected disabled>Оберіть ...</option>
                          <option v-for="it in changeType.data" :key="it.number" :value="it.number">{{ it.name }}</option>
                        </select>
                      </div>
                    </div>
                    <div class="row">
                      <div class="col-auto">
                        <label class="col-form-label">Вилучити:</label>
                      </div>
                    </div>
                    <div class="row">
                      <div class="col-auto">
                        <label class="col-form-label">Додати:</label>
                      </div>
                    </div>
                  </div>
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
  methods:{
    button(){return get_button_colour(this.item)},
    colour(){return get_class_colour(this.item)},
    change(){change_item_visible_status(this.item)}
  },
  props:["item", "editing_status"],
  name:'OtherChanges',  
}
</script>