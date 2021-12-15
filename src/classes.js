
export class General_Information{
  constructor() {
    this.visible_status = false;
    this.number = { data: "" };
    this.date = { data: "" };
  }
  set_values(visible_status, number, date){
    this.visible_status = visible_status;
    this.number.data = number;
    this.date.data = date;
  }
}
export class Address{
  constructor(){
    this.address = [
        {
          name:"Україна",
          region:[
            {
              name:"Чернігівська область",
              area:[
                {
                  name:"Чернігівський район",
                  city:[
                    {
                      name:"Чернігів",
                      index:[
                        {
                          name: 12600,
                          street: [
                            {
                              name:"Перемоги",
                              build:"",
                              corps:"",
                              flat:""
                            },
                            {
                              name:"Тараса Шевченка",
                              build:"",
                              corps:"",
                              flat:""
                            }
                          ]
                        },
                        {
                          name: 12400,
                          street: [
                            {
                              name:"Франка",
                              build:"",
                              corps:"",
                              flat:""
                            },
                            {
                              name:"Лесі Українки",
                              build:"",
                              corps:"",
                              flat:""
                            }
                          ]
                        },
                      ]
                    },
                    {
                      name:"Прилуки",
                      index:[
                        {
                          name: 1300,
                          street: [
                            {
                              name:"Перемоги",
                              build:"",
                              corps:"",
                              flat:""
                            },
                            {
                              name:"Тараса Шевченка",
                              build:"",
                              corps:"",
                              flat:""
                            }
                          ]
                        },
                        {
                          name: 400,
                          street: [
                            {
                              name:"Франка",
                              build:"",
                              corps:"",
                              flat:""
                            },
                            {
                              name:"Лесі Українки",
                              build:"",
                              corps:"",
                              flat:""
                            }
                          ]
                        },
                      ]
                    },
                  ]
                },
                {
                  name:"Ніжинський район",
                  city:[
                    {
                      name:"Ніжин",
                      index:[
                        {
                          name: 12200,
                          street: [
                            {
                              name:"Перемоги",
                              build:"",
                              corps:"",
                              flat:""
                            },
                            {
                              name:"Тараса Шевченка",
                              build:"",
                              corps:"",
                              flat:""
                            }
                          ]
                        },
                        {
                          name: 11400,
                          street: [
                            {
                              name:"Франка",
                              build:"",
                              corps:"",
                              flat:""
                            },
                            {
                              name:"Лесі Українки",
                              build:"",
                              corps:"",
                              flat:""
                            }
                          ]
                        },
                      ]
                    },
                    {
                      name:"Бахмач",
                      index:[
                        {
                          name: 12200,
                          street: [
                            {
                              name:"Перемоги",
                              build:"",
                              corps:"",
                              flat:""
                            },
                            {
                              name:"Тараса Шевченка",
                              build:"",
                              corps:"",
                              flat:""
                            }
                          ]
                        },
                        {
                          name: 11400,
                          street: [
                            {
                              name:"Франка",
                              build:"",
                              corps:"",
                              flat:""
                            },
                            {
                              name:"Лесі Українки",
                              build:"",
                              corps:"",
                              flat:""
                            }
                          ]
                        },
                      ]
                    },
                  ]
                }
              ]
            },
            {
              name:"Одеська область",
              area:[
                {
                  name:"Одеський район",
                  city:[
                    {
                      name:"Одеса",
                      index:[
                        {
                          name: 11600,
                          street: [
                            {
                              name:"Перемоги",
                              build:"",
                              corps:"",
                              flat:""
                            },
                            {
                              name:"Тараса Шевченка",
                              build:"",
                              corps:"",
                              flat:""
                            }
                          ]
                        },
                        {
                          name: 124090,
                          street: [
                            {
                              name:"Франка",
                              build:"",
                              corps:"",
                              flat:""
                            },
                            {
                              name:"Лесі Українки",
                              build:"",
                              corps:"",
                              flat:""
                            }
                          ]
                        },
                      ]
                    },
                    {
                      name:"Коблево",
                      index:[
                        {
                          name: 13000,
                          street: [
                            {
                              name:"Перемоги",
                              build:"",
                              corps:"",
                              flat:""
                            },
                            {
                              name:"Тараса Шевченка",
                              build:"",
                              corps:"",
                              flat:""
                            }
                          ]
                        },
                        {
                          name: 4090,
                          street: [
                            {
                              name:"Франка",
                              build:"",
                              corps:"",
                              flat:""
                            },
                            {
                              name:"Лесі Українки",
                              build:"",
                              corps:"",
                              flat:""
                            }
                          ]
                        },
                      ]
                    },
                  ]
                },
              ]
            }
          ]
        },
        {
          name:"Уганда",
          region:[{
            name:"1 область",
            area:[
              {
                name:"1 район",
                city:[
                  {
                    name:"Чернігів",
                    index:[
                      {
                        name: 12600,
                        street: [
                          {
                            name:"Перемоги",
                            build:"",
                            corps:"",
                            flat:""
                          },
                          {
                            name:"Тараса Шевченка",
                            build:"",
                            corps:"",
                            flat:""
                          }
                        ]
                      },
                      {
                        name: 12400,
                        street: [
                          {
                            name:"Франка",
                            build:"",
                            corps:"",
                            flat:""
                          },
                          {
                            name:"Лесі Українки",
                            build:"",
                            corps:"",
                            flat:""
                          }
                        ]
                      },
                    ]
                  },
                  {
                    name:"Прилуки",
                    index:[
                      {
                        name: 1300,
                        street: [
                          {
                            name:"Перемоги",
                            build:"",
                            corps:"",
                            flat:""
                          },
                          {
                            name:"Тараса Шевченка",
                            build:"",
                            corps:"",
                            flat:""
                          }
                        ]
                      },
                      {
                        name: 400,
                        street: [
                          {
                            name:"Франка",
                            build:"",
                            corps:"",
                            flat:""
                          },
                          {
                            name:"Лесі Українки",
                            build:"",
                            corps:"",
                            flat:""
                          }
                        ]
                      },
                    ]
                  },
                ]
              },
              {
                name:"2 район",
                city:[
                  {
                    name:"Ніжин",
                    index:[
                      {
                        name: 12200,
                        street: [
                          {
                            name:"Перемоги",
                            build:"",
                            corps:"",
                            flat:""
                          },
                          {
                            name:"Тараса Шевченка",
                            build:"",
                            corps:"",
                            flat:""
                          }
                        ]
                      },
                      {
                        name: 11400,
                        street: [
                          {
                            name:"Франка",
                            build:"",
                            corps:"",
                            flat:""
                          },
                          {
                            name:"Лесі Українки",
                            build:"",
                            corps:"",
                            flat:""
                          }
                        ]
                      },
                    ]},{
                    name:"Бахмач",
                    index:[
                      {
                        name: 12200,
                        street: [
                          {
                            name:"Перемоги",
                            build:"",
                            corps:"",
                            flat:""
                          },
                          {
                            name:"Тараса Шевченка",
                            build:"",
                            corps:"",
                            flat:""
                          }
                        ]
                      },
                      {
                        name: 11400,
                        street: [
                          {
                            name:"Франка",
                            build:"",
                            corps:"",
                            flat:""
                          },
                          {
                            name:"Лесі Українки",
                            build:"",
                            corps:"",
                            flat:""
                          }
                        ]
                      },
                    ]
                  },
                ]
              }
            ]}]
        }
      ]
  }
}

export class Weightlifter_Information{
  constructor() {
    this.visible_status = true;
    this.number = { data: "" },
    this.resident = {
      data: "",
      visible_status: false
    },
    this.obj_name = { data: ""  };
    this.address = {
      visible_status: false,
      path:{
        country: "",
        region: "",
        area: "",
        city: "",
        index: "",
        street: "",
        build: "",
        corps: "",
        flat: ""
      },
    }
    
  }
  set_values(visible_status, number, resident, address){
    this.visible_status = visible_status;
    this.number.data = number;
    this.resident.data = resident;
    this.address = address;
  }
}
export class Debtor_Information{
  constructor() {
    this.visible_status = true;
    this.number = { data: "" },
    this.resident = {
      data: "",
      visible_status: false
    },
    this.obj_name = { data: ""  };
    this.address = {
      visible_status: false,
      path:{
        country: "",
        region: "",
        area: "",
        city: "",
        index: "",
        street: "",
        build: "",
        corps: "",
        flat: ""
      },
    }
    
  }
  set_values(visible_status, number, resident, address){
    this.visible_status = visible_status;
    this.number.data = number;
    this.resident.data = resident;
    this.address = address;
  }
}

export class Basis_Document{
  constructor() {
    this.visible_status = false;
    this.name = {
      data: "alsdas"
    },
    this.number = {
      data: 2131221
    },
    this.date = {
      data: "12.12.2012"
    },
    this.publisher = {
      data: "lsaldlas"
    }
  }
}

export class Encumbrance_Information{
  constructor() {
    this.visible_status = false;
    this.encumbrance_type = {
      data: ["Публічне обтяження", "Приватне обтяження"],
      checked: "Приватне обтяження"
    },
    this.registration_type = {
      data: ["Поточна", "Попередня"],
      checked: "Поточна"
    },
    this.date = {
      data: "12.12.2012"
    },
    this.type_encumbrance = {
      data: [["Податкова застава", "Арешт"], ["Звернення стягнення", "Застава рухомого майна"], ["Заборона", "Інший"]],
      checked: "Арешт"
    },
    this.type_description = {
      data: "",
      visible_status: true
    },
    this.information = {
      data:["Дозволено відчужувати", "Відчужувати заборонено", "Відчужувати за погодженням з обтяжувачем"],
      checked: "Відчужувати заборонено"
    }
  }
  colour(){
    if(this.visible_status) return " align-items-center p-3 m-1 border border-dark rounded";
    return " align-items-center p-3 m-1 border border-secondary rounded";
  }
  button(){
    if(this.visible_status) return "btn btn-primary m-1";
    return "btn btn-outline-secondary m-1";
  }
}

export class Terms{
  constructor() {
    this.visible_status = false;
    this.name = {
      data: "alsdas"
    },
    this.number = {
      data: 2131221
    },
    this.date = {
      data: "12.12.2012"
    },
    this.publisher = {
      data: "lsaldlas",
      visible_status: true
    }
  }
}
/*
class Encumbrance_Description_Subject{
  constructor(element) {
    this.visible_status = false;
    this.name = "Опис предмета обтяження:";
    this.body = [
      new info_part("Рухоме майно що має серійні номери:", element.part_1, "text"),
      new info_part("Рухоме майно, крім описаного вище за серійними номерами:", element.part_2, "text")
    ]
  }
}

class More_Information{
  constructor(element) {
    this.visible_status = false;
    this.name = "Додаткові відомості:";
    this.body = [
      new info_part("asd", element.part_1, "text"),
    ]
  }
}

class Service_Notes{
  constructor(element) {
    this.visible_status = false;
    this.name = "Службові відмітки:";
    this.body = [
      new info_part("asd", element.part_1, "text"),
    ]
  }
}
*/