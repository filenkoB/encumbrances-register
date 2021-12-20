
export class StatmentsPageElement{
  visible_status = false;
  constructor(id, number, date, typeName){
    this.id = id;
    this.number = number;
    this.date = (new Date(Date.parse(date))).toLocaleDateString('en-GB');
    this.typeName = typeName;
  }
}

export class GeneralInfo{
  visible_status = false;
  constructor(number, registrationDate) {
    this.number = number;
    this.registrationDate = registrationDate;
  }
}

export class GeneralInfoType2{
  visible_status = false;
  constructor(number, registrationDate) {
    this.number = number;
    this.registrationDate = registrationDate;
  }
}

export class EncumbranceTierDebtor{
  visible_status = false;
  address = {
    visible_status: true,
    path:{
      country: "",
      region: "",
      district: "",
      city: "",
      index: "",
      street: "",
      build: "",
      corps: "",
      flat:""
    }
  }
  name = null;
  constructor(taxpayerAccountCardNumber, isForeigner, name) {
    this.taxpayerAccountCardNumber = taxpayerAccountCardNumber,
    this.isForeigner = isForeigner;
    this.name = name; 
  }
}

export class BasisDocument{
  visible_status = false;
  constructor(name, number, issuer, issueDate) {
    this.name =name;
    this.number = number;
    this.issuer = issuer;
    this.issueDate = issueDate;
  }
}

export class EncumbranceInfo{
  visible_status = false;
  encumbrance_type = {
    data: [
      {number:1, name:"Публічне обтяження"}, 
      {number:2, name:"Приватне обтяження"}
    ],
    encumbranceKindId: 1
  }

  constructor(encumbranceKindId, registrationTypeId, lastEncumbranceOccurrenceDate, encumbranceTypeId, 
    alienationLimitId, typeDescription) {
    this.encumbrance_type.encumbranceKindId = encumbranceKindId;
    this.registrationTypeId = registrationTypeId;
    this.lastEncumbranceOccurrenceDate = lastEncumbranceOccurrenceDate;
    this.encumbranceTypeId = encumbranceTypeId;
    this.alienationLimitId = alienationLimitId;
    this.typeDescription = typeDescription
  }
}

export class EncumbranceTerm{
  visible_status = false;
  constructor(obligationAmount, termTo, additionalTerms, currencyTypeId) {
    this.obligationAmount = obligationAmount;
    this.termTo = termTo;
    this.additionalTerms = additionalTerms;
    this.currencyTypeId = currencyTypeId;
  }
}


export class DescriptionSubject{
  name = null;
  number = null;
  number_2 = null;
  value = null;
  visible_status = false;
  info={
    data:[
      {number: 1, name: "Рухоме майно що має серійні номери:"},
      {number: 2, name: "Рухоме майно, крім описаного вище за серійними номерами:"},
    ],
    checked: null
  }
  constructor() {
    this.info.checked = 2;
  }
}

export class Changes{
  visible_status = false;
  changes = {
    data: [
      {number: 1, name: "Зареєструвати припинення обтяження"},
      {number: 2, name: "Зареєструвати звернення стягнення"},
      {number: 3, name: "Продовжити строк  дії  реєстраційного  запису  на   наступні 5 років"},
      {number: 4, name: "Виправити дату виникнення"},
      {number: 5, name: "Дата виникнення"}
    ],
    checked: 1
  }
  changeType = {
    data: [
      {number:1, name: "Замінити  Обтяжувача"},
      {number:2, name: "Виправити Обтяжувача"},
      {number:3, name: "Замінити Боржника"},
      {number:4, name: "Вилучити  Боржника"},
      {number:5, name: "Додати  Боржника"},
      {number:6, name: "Виправити Боржника"}
    ],
    checked: 1
  };
  constructor() {
    this.changes.checked = 1;
  }
}
/*
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