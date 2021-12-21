<template>
  <div class="row p-2 border border-secondary border-4 rounded">
    <div class="col">
      <div class="row pt-4 tb-4">
        <div class="text-center fs-2 mb-4">
          <img src="../../assets/Ukrherb.png" width="35"/>
          <span> Державний реєстр обтяженнь рухомого майна</span>
        </div>
        <p class="text-start fs-5">
          Вітаємо, ви успішно авторизовані в системі, як реєстратор. Нижче зазначено доступний вам функціонал системи.
        </p>
      </div>
      <div class="row p-2 mt-2 ">
        <ul class="list-group fs-6">
          <li class="list-group-item">
            <div class="row">
              <div class="col-auto">
                <i class="fa fa-hand-o-right" aria-hidden="true"></i>
              </div>
              <div class="col-auto">
                <p>Для перегляду списку поданий на реєстрацію "Заяв" скористайтеся розділом "Переглянути Заяви".</p>
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
                    <button type="button" class="btn btn-outline-dark" disabled>
                      <i class="fa fa-list-alt" aria-hidden="true"></i>
                      Переглянути Заяви
                    </button>
                  </div>
                </div>
                <div class="row ms-4">
                  <div class="col-auto mt-2">
                    <p>Кожен елемент, що охарактеризовує "Заяву" має свій функціонал, а саме:</p>
                  </div>
                </div>
                <div class="row ms-4">
                  <div class="col-auto mt-2">
                    <i class="fa fa-angle-double-right fa-lg" aria-hidden="true"></i>
                  </div>
                  <div class="col-auto mt-2">
                    Для перегляду всіх відомостей "Заяви", натисніть
                  </div>
                  <div class="col-auto">
                    <button type="button" class="btn btn-outline-info" disabled>
                      <i class="fa fa-eye" aria-hidden="true"></i>
                      Переглянути все
                    </button>
                  </div>
                </div>
                <div class="row ms-4 mt-2">
                  <div class="col-auto mt-2">
                    <i class="fa fa-angle-double-right fa-lg" aria-hidden="true"></i>
                  </div>
                  <div class="col-auto mt-2">
                    Для підтвердження реєстріції відомостей "Заяви", натисніть
                  </div>
                  <div class="col-auto">
                    <button type="button" class="btn btn-outline-success" disabled>
                      Підтвердити
                    </button>
                  </div>
                  <div class="col-auto mt-2">
                    та підтвердьте або відхиліть вашу дію в спливаючому вікні.
                  </div>
                </div>
                <div class="row ms-4 mt-2">
                  <div class="col-auto mt-2">
                    <i class="fa fa-angle-double-right fa-lg" aria-hidden="true"></i>
                  </div>
                  <div class="col-auto mt-2">
                    Для відхилення реєстріції відомостей "Заяви", натисніть
                  </div>
                  <div class="col-auto">
                    <button type="button" class="btn btn-outline-danger" disabled>
                      Відхилити
                    </button>
                  </div>
                  <div class="col-auto mt-2">
                    та підтвердьте або відхиліть вашу дію в спливаючому вікні.
                  </div>
                </div>
              </div>
            </div>
          </li>
          <li class="list-group-item">
            <div>
              <i class="fa fa-hand-o-right" aria-hidden="true"></i>
              Для перегляду активності "Реєстраторів" скористайтеся розділом "Перелік Реєстраторів".
            </div>
            <div class="ms-3 mt-2">
              <i class="fa fa-chevron-right" aria-hidden="true"></i>
              Ви можете знайти даний розділ в верхньому лівому куті головного меню.
              <button type="button" class="btn btn-outline-dark ms-2" disabled>
                Перелік Реєстраторів
              </button>
            </div>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>
<script>
export default {
    name: 'Registrar',
}
</script>
