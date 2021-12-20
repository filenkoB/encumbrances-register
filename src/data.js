
export const card = [
    {
      type: "success",
      visible_status: false,
      header:"Вікно підтвердження відповідності даних.",
      title:"title",
      footer:"Після підтвердження даного вікна, даний запис \"Відомості про заяву\" будуть вилучені зі сторінки \"Активних заяв\".",
    },
    {
      type: "danger",
      visible_status: false,
      header:"Вікно відхилиння наданих даних",
      title:"title",
      footer:"Після підтвердження даного вікна, даний запис \"Відомості про заяву\" будуть вилучені зі сторінки \"Активних заяв\".",
      values:["Недостовірність даних", "бла бла бла", "Інше"],
      checked: "Інше"
    }
  ]
export const sysAppsCards = [
    {
      type: "success",
      visible_status: true,
      header:"Вікно підтвердження реєстрації користувача системи",
      title:"title",
      footer:"Після підтвердження даного вікна, даний запис \"Відомості про заяву\" будуть вилучені зі сторінки \"Активних заяв\".",
    },
    {
      type: "danger",
      visible_status: false,
      header:"Вікно відхилиння реєстрації користувача системи",
      title:"title",
      footer:"Після підтвердження даного вікна, даний запис \"Відомості про заяву\" будуть вилучені зі сторінки \"Активних заяв\".",
      values:["Недостовірність даних", "бла бла бла", "Інше"],
      checked: "Інше"
    }
  ]

const patterns = {
  names: { var: /[А-ЯІЇЄ][а-яіїє]+('[а-яіїє]+)?/},
  lastName: { var: /[А-ЯІЇЄ][а-яіїє]+('[а-яіїє]+)?(-[А-ЯІЇЄ][а-яіїє]+('[а-яіїє]+)?)*/},
  email: { var: /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$/ },
  building: { var: /[1-9][0-9]?[0-9]?/ },
  corps: { var: /([1-9][0-9]?)|[А-Я]/},
  flat: { var: /[1-9][0-9]?[0-9]?[а-яА-Я]?/ },
  text: { var: /[^^=[\]{}@!&~$;:%?*_+\\/]/},
  money: { var: /[1-9][0-9]*(\.[0-9]|\.[0-9][0-9])?/},
  number: { var: /\d+/},
  serialNum: { var: /[\s]+/},
  idNumber: { var: /\d{12}/},
};
Object.keys(patterns).forEach( i => patterns[i].str = String(patterns[i].var).slice(1, String(patterns[i].var).length-1));

const dateNow = new Date(Date.now()); const format = "yyyy-mm-dd"
const maxBirthDate = format.replace('yyyy', dateNow.getFullYear() - 18)
                    .replace('mm', dateNow.getMonth() + 1)
                    .replace('dd', dateNow.getDate());
const tomorrow = format.replace('yyyy', dateNow.getFullYear())
                    .replace('mm', dateNow.getMonth() + 1)
                    .replace('dd', dateNow.getDate() + 1);
const decadeAfter = format.replace('yyyy', dateNow.getFullYear() + 10)
                    .replace('mm', dateNow.getMonth() + 1)
                    .replace('dd', dateNow.getDate());
const today = format.replace('yyyy', dateNow.getFullYear())
                    .replace('mm', dateNow.getMonth() + 1)
                    .replace('dd', dateNow.getDate());

const validation = {
  patterns: patterns,
  today: today,
  maxBirthDate: maxBirthDate,
  tomorrow: tomorrow,
  decadeAfter: decadeAfter,
}
export {validation};