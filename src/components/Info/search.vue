<template>
  <li class="list-group-item">
    <div class="row">
        <div class="col-auto">
        <i class="fa fa-hand-o-right" aria-hidden="true"></i>
        </div>
        <div class="col-auto">
        Для пошуку обтяження скористайтеся розділом "Пошук обтяження".</div>
    </div>
    <div class="row ms-5">
      <div class="col-auto">
        <div class="row mt-2">
          <div class="col-auto mt-2">
            <i class="fa fa-angle-right fa-lg" aria-hidden="true"></i>
            </div>
            <div class="col-auto mt-2">
            <p>Ви можете знайти даний розділ в верхньому лівому куті головного меню.</p>
            </div>
            <div class="col-auto">
            <button type="button" class="btn btn-outline-dark me-2" disabled>
              <i class="fa fa-search" aria-hidden="true"></i>
              Пошук обтяження
            </button>
          </div>
        </div>
        <div class="row ms-4 mt-2">
          <div class="col-auto mt-2">
            <i class="fa fa-angle-double-right fa-lg" aria-hidden="true"></i>
          </div>
          <div class="col-auto mt-2">
            Для проведення перевірки введених даних та подальшого пошуку обтяжень, натисніть
          </div>
          <div class="col-auto">
            <button type="button" class="btn btn-outline-success" disabled>
              Підтвердити
            </button>
          </div>
        </div>
        <div class="row ms-4 mt-2">
          <div class="col-auto mt-2">
            <i class="fa fa-angle-double-right fa-lg" aria-hidden="true"></i>
          </div>
          <div class="col-auto mt-2">
            Для очищення заповнених полів, натисніть
          </div>
          <div class="col-auto">
            <button type="button" class="btn btn-outline-danger" disabled>
              Очистити
            </button>
          </div>
        </div>
      </div>
    </div>
  </li>
</template>
<script>
export default {
    name:"Search"
}
</script>