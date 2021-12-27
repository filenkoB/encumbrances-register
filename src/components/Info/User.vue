<template>
  <div class="row p-2 border border-secondary border-4 rounded">
    <div class="col">
      <div class="row pt-4 tb-4">
        <div class="text-center fs-2 mb-4">
          <img src="../../assets/Ukrherb.png" width="35"/>
          <span> Державний реєстр обтяженнь рухомого майна</span>
        </div>
        <p class="text-start fs-5">
          Вітаємо, ви успішно авторизовані в системі, як користувач. Нижче зазначено доступний вам функціонал системи.
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
                <p>Для перегляду списку поданих користувачем "Заяв" скористайтеся розділом "Мої заяви".</p>
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
                      Мої заяви
                    </button>
                  </div>
                </div>
                <div class="row ms-4">
                  <div class="col-auto mt-2">
                    <p>Кожен елемент, що охарактеризовує "Заяву" зазначає стан заяв в системі.</p>
                  </div>
                </div>
              </div>
            </div>
          </li>
          <Create />
          <Search />
          <MainInfo />
        </ul>
      </div>
    </div>
  </div>
</template>
<script>
import MainInfo from './maininfo.vue'
import Create from './create.vue'
import Search from './search.vue'
export default {
    name: 'User',
    components:{
      Create,
      MainInfo,
      Search
    }
}
</script>
