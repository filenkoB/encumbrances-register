<template>
  <div class="row" v-if="item">
    <div class="col">
      <div class="row" :class="colour">
          <div class="col">
              <div class="row">
                <div class="col-auto">
                  <label class="col-form-label">Вихідний номер:</label>
                </div>
                <div class="col-2">
                  <input type="text" class="form-control" :disabled="editing_status" :value="item.number">
                </div>
                <div class="col-auto ms-5">
                  <label class="col-form-label">Дата заяви:</label>
                </div>
                <div class="col-auto">
                  <input type="date" class="form-control" :disabled="editing_status" :value="item.number">
                </div>
                <div class="col-auto ms-5">
                  <label class="col-form-label">Контрольна сума запису:</label>
                </div>
                <div class="col-auto">
                  <input type="text" class="form-control" :disabled="editing_status" :value="item.registrationDate">
                </div>
              </div>
              <div class="row mt-2">
                <div class="col-auto">
                  <label class="col-form-label">Реєстраційний номер запису в Державному реєстрі обтяжень рухомого майна:</label>
                </div>
                <div class="col-4">
                  <input type="text" class="col-6 form-control" :disabled="editing_status" :value="item.number">
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
  name:'GeneralInformation',  
}
</script>