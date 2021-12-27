<template>
  <li class="list-group-item">
    <div class="row">
      <div class="col-auto">
        <i class="fa fa-hand-o-right" aria-hidden="true"></i>
      </div>
      <div class="col-auto">
        <p>Для створення нової "Заяви", скористайтеся розділом "Створення Заяви".</p>
      </div>
    </div>
    <div class="row ms-5">
      <div class="col-auto">
        <div class="row">
          <div class="col-auto mt-2">
            <i class="fa fa-angle-right fa-lg" aria-hidden="true"></i>
          </div>
          <div class="col-auto mt-2">
            <p>Ви можете знайти даний розділ в верхньому лівому куті головного меню.</p>
          </div>
          <div class="col-auto">
            <button type="button" class="btn btn-outline-dark me-2" disabled>
              <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
              Створити заяву
            </button>
          </div>
        </div>
        <div class="row ms-4">
          <div class="col-auto mt-2">
            <i class="fa fa-angle-double-right fa-lg" aria-hidden="true"></i>
          </div>
          <div class="col-auto mt-2">
            Для обрання типу створюваної "Заяви", оберіть тип в відповідному полі "Оберіть тип Заяви"
          </div>
        </div>
        <div class="row ms-4 mt-2">
          <div class="col">
            <div class="row ms-4 mt-2">
              <div class="col-auto mt-2">
                <i class="fa fa-arrow-right" aria-hidden="true"></i>
              </div>
              <div class="col-auto mt-2">
                  У разі обрання типу "Заява на реєстрацію змін ...", необхідно виконати пошук обтяження, над яким будуть проведені зміни.
              </div>
              <div class="col-auto">
                <button type="button" class="btn btn-outline-success" disabled>
                  Пошук
                </button>
              </div>
            </div>
          </div>
        </div>
        <div class="row ms-4 mt-2">
          <div class="col-auto mt-2">
            <i class="fa fa-angle-double-right fa-lg" aria-hidden="true"></i>
          </div>
          <div class="col-auto mt-2">
            Для проведення перевірки введених даних та подальшої передачі відомостей на реєстрацію, натисніть
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
            Для очищення заповнених відомостей, натисніть
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
  name:"Create"
}
</script>