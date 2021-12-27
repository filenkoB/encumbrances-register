export const alienationLimit = [
  {
    id:"225e5466-a939-4ab6-8034-af49415bcff5",
    name:"Дозволено відчужувати"
  },
  {
    id:"8fb3df0d-6a9d-4da2-a660-1b28c404d363",
    name:"Відчужувати заборонено"
  },
  {
    id:"82abbf27-b160-484a-91cb-d03554b891c8",
    name:"Відчужувати за погодженням з обтяжувачем"
  }
]
export const encumbranceType =[
  {
    id:1,
    data:[
      {
        id:"5f424124-8e67-48f1-b7cc-57c9be5473c5",
        name:"Податкова застава"
      },
      {
        id:"3a878915-38a9-4825-81b9-71fe45b691a4",
        name:"Арешт"
      }
    ]
  },
  {
    id:2,
    data:[
      {
        id:"9fc001ad-e009-483c-a933-fca3e34953da",
        name:"Звернення стягнення"
      },
      {
        id:"2c2cbcd9-3820-47d6-ac6f-5370a3de52b1",
        name:"Застава рухомого майна"
      }
    ]
  },
  {
    id:3,
    data:[
      {
        id:"cfd465e7-17a7-4f41-b1d6-44cf72ef633b",
        name:"Заборона"
      },
      {
        id:"4b0a5256-60da-4d65-a0ce-3f7a50d85184",
        name:"Інший"
      }
    ]
  }
]
export const registrationType=[
  {
    id:"159fcd68-1c41-425f-89b5-8a3fb5ee24e1",
    name:"Поточна"
  },
  {
    id:"a976a960-3b48-4218-9d58-a12c4b96b94f",
    name:"Попередня"
  }
]
export const currency=[
  {
    id:"7cc9dd85-bc72-487b-85f4-03dff1738a79",
    name:"Гривня",
    sign:"₴"
  },
  {
    id:"b7130dc3-bdef-4ecf-b4f2-abbb71405b3f",
    name:"Долар",
    sign:"$"
  },
  {
    id:"816e6eed-db0a-4b2a-a768-2490fc6344a1",
    name:"Євро",
    sign:"€"  
  },
  {
    id:"7635fe6d-371a-49cd-bdce-44751a08668a",
    name:"Рубль",
    sign:"₽" 
  }
]
export const encumbranceKind=[
  {
    id:"85ad61fc-82e7-4436-a209-b07d1d7105e4",
    name:"Публічне обтяження"
  },
  {
    id:"ff7e3cbb-9868-43d3-b119-748508bf15b7",
    name:"Приватне обтяження"
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
  names: { var: /[А-ЯІЇЄ][а-яіїє]+('[яюєї][а-яіїє]+)?/},
  lastName: { var: /[А-ЯІЇЄ][а-яіїє]+('[яюєї][а-яіїє]+)?(-[А-ЯІЇЄ][а-яіїє]+('[яюєї][а-яіїє]+)?)*/},
  email: { var: /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$/ },
  building: { var: /[1-9][0-9]?[0-9]?/ },
  corps: { var: /([1-9][0-9]?)|[А-Я]/},
  flat: { var: /[1-9][0-9]?[0-9]?[а-яА-Я]?/ },
  text: { var: /[^^=[\]{}@!&~$;:%?*_+\\/]+/},
  money: { var: /[1-9][0-9]*(\.[0-9]|\.[0-9][0-9])?/},
  number: { var: /\d+/},
  serialNum: { var: /\w+/},
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
  minIdPasDate: "2016-01-01",
  minBookPasDate: "1994-01-01",
}
export {validation};