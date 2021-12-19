import {Address,  General_Information, Weightlifter_Information, Debtor_Information, Basis_Document, Encumbrance_Information, Terms} from './classes'

export const address = new Address();

export const statement = {
    general_information: new General_Information(),
    encumbrance_information: new Encumbrance_Information(),
    weightlifter_information: new Weightlifter_Information(),
    debtor_information: new Debtor_Information(),
    document: new Basis_Document(),
    terms: new Terms(),
} 
export class Statement{
  constructor(){
    this.general_information = new General_Information();
    this.general_information.set_values(false, new Date(), "2012/12/12");
    this.encumbrance_information = new Encumbrance_Information();
    this.weightlifter_information = new Weightlifter_Information();
    this.debtor_information = new Debtor_Information();
    this.document = new Basis_Document();
    this.terms = new Terms();
  }
} 
export function create_statements(count){
    let statements = []
    for(let i = 0; i < count; i ++){
        statements.push({
          visible_status: false,
          general_information: new General_Information(),
          encumbrance_information: new Encumbrance_Information()
        })
        statements[i].general_information.set_values(false, 12 + i+1000, "2012/12/12");
    }
    return statements;
}
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