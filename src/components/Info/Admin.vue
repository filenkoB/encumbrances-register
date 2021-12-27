<template>
  <div class="row p-2 border border-secondary border-4 rounded">
    <div class="col">
      <div class="row pt-4 tb-4">
        <div class="text-center fs-2 mb-4">
          <img src="../../assets/Ukrherb.png" width="35"/>
          <span> Державний реєстр обтяженнь рухомого майна</span>
        </div>
        <p class="text-start fs-5">
          Вітаємо, ви успішно авторизовані в системі, як адміністратор. Нижче зазначено доступний вам функціонал системи.
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
                <p>Для перегляду списку всіх зареєстрованих Реєстраторів в системі, скористайтеся розділом "Перелік Реєстраторів".</p>
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
                      <i class="fa fa-list-alt" aria-hidden="true"></i>
                      Перелік Реєстраторів
                    </button>
                  </div>
                </div>
                <div class="row ms-4">
                  <div class="col-auto mt-2">
                    <p>Кожен елемент, що охарактеризовує подану на реєстрацію заявку має свій функціонал, а саме:</p>
                  </div>
                </div>
                <div class="row ms-4">
                  <div class="col-auto mt-2">
                    <i class="fa fa-angle-double-right fa-lg" aria-hidden="true"></i>
                  </div>
                  <div class="col-auto mt-2">
                    Для перегляду активності обраного "Реєстратора", натисніть
                  </div>
                  <div class="col-auto">
                    <button type="button" class="btn btn-outline-info" disabled>
                      <i class="fa fa-table" aria-hidden="true"></i>
                      Переглянути активність
                    </button>
                  </div>
                </div>
                <div class="row ms-4 mt-2">
                  <div class="col-auto mt-2">
                    <i class="fa fa-angle-double-right fa-lg" aria-hidden="true"></i>
                  </div>
                  <div class="col-auto mt-2">
                    Для перегляду детільної інформації обраного "Реєстратора", натисніть
                  </div>
                  <div class="col-auto">
                    <button type="button" class="btn btn-outline-primary" disabled>
                      <i class="fa fa-eye" aria-hidden="true"></i>
                      Переглянути інформацію
                    </button>
                  </div>
                </div>
                <div class="row ms-4 mt-2">
                  <div class="col ms-5">
                    <div class="row">
                      <div class="col-auto mt-2">
                        <i class="fa fa-arrow-right" aria-hidden="true"></i>
                      </div>
                      <div class="col-auto mt-2">
                        Для розблокування можливості редагування даних "Реєстратора", необхідно активувати селектор
                      </div>
                      <div class="col-auto mt-2">
                        <i class="fa fa-check-square" aria-hidden="true"></i>
                        Редагувати відомості
                      </div>
                    </div>
                  </div>
                </div>
                <div class="row ms-4 mt-2">
                  <div class="col ms-5">
                    <div class="row">
                      <div class="col-auto mt-2">
                        <i class="fa fa-arrow-right" aria-hidden="true"></i>
                      </div>
                      <div class="col-auto mt-2">
                        Для збереження відредагованих даних "Реєстратора", скористайтеся
                      </div>
                      <div class="col-auto">
                        <button type="button" class="btn btn-outline-success" disabled>
                          Зберегти
                        </button>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </li>
          <li class="list-group-item">
            <div class="row">
              <div class="col-auto">
                <i class="fa fa-hand-o-right" aria-hidden="true"></i>
              </div>
              <div class="col-auto">
                <p>Для перегляду списку поданих на реєстрацію доступу до ДРОРМ заявок, скористайтеся розділом "Заявки на реєстрацію".</p>
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
                      <i class="fa fa-address-card" aria-hidden="true"></i>
                      Заявки на реєстрацію
                    </button>
                  </div>
                </div>
                <div class="row ms-4">
                  <div class="col-auto mt-2">
                    <p>Кожен елемент, що охарактеризовує подану на реєстрацію заявку має свій функціонал, а саме:</p>
                  </div>
                </div>
                <div class="row ms-4">
                  <div class="col-auto mt-2">
                    <i class="fa fa-angle-double-right fa-lg" aria-hidden="true"></i>
                  </div>
                  <div class="col-auto mt-2">
                    Для перегляду всіх відомостей, натисніть
                  </div>
                  <div class="col-auto">
                    <button type="button" class="btn btn-outline-info" disabled>
                      <i class="fa fa-eye" aria-hidden="true"></i>
                      Переглянути дані заявки
                    </button>
                  </div>
                  <div class="col-auto mt-2">
                    Після чого ви зможете "Підтвердити" або "Відхилити" дану заявку.
                  </div>
                </div>
                <div class="row ms-4 mt-2">
                  <div class="col-auto mt-2">
                    <i class="fa fa-angle-double-right fa-lg" aria-hidden="true"></i>
                  </div>
                  <div class="col-auto mt-2">
                    Для підтвердження реєстріції відомостей, натисніть
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
                    Для відхилення реєстріції відомостей, натисніть
                  </div>
                  <div class="col-auto">
                    <button type="button" class="btn btn-outline-danger" disabled>
                      Відхилити
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </li>
          <main-info />
        </ul>
      </div>
    </div>
  </div>
</template>
<script>
import MainInfo from './maininfo.vue'
export default {
    name: 'Admin',
    components:{
      MainInfo
    }
}
</script>
