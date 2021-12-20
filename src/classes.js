
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
    this.registrationDate = registrationDate.split('T')[0];
  }
}

export class GeneralInfoType2{
  visible_status = false;
  constructor(number, registrationDate) {
    this.number = number;
    this.registrationDate = registrationDate.split('T')[0];
  }
}

export class EncumbranceTierDebtor{
  visible_status = false;
  short_info = false;
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
    this.issueDate = issueDate.split('T')[0];
  }
}

export class EncumbranceInfo{
  visible_status = false;
  constructor(encumbranceKindId, registrationTypeId, lastEncumbranceOccurrenceDate, encumbranceTypeId, 
    alienationLimitId, typeDescription) {
    this.encumbranceKindId = encumbranceKindId;
    this.registrationTypeId = registrationTypeId;
    this.lastEncumbranceOccurrenceDate = lastEncumbranceOccurrenceDate.split('T')[0];
    this.encumbranceTypeId = encumbranceTypeId;
    this.alienationLimitId = alienationLimitId;
    this.typeDescription = typeDescription
  }
}

export class EncumbranceTerm{
  visible_status = false;
  constructor(obligationAmount, termTo, additionalTerms, currencyTypeId) {
    this.obligationAmount = obligationAmount;
    this.termTo = termTo.split('T')[0];
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
  changes_checked = 1;
  changeTypechecked = 1
  constructor() {
  }
}
export class SubjectChange{
  visible_status = false;
  changeTypechecked = 1
  constructor() {
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