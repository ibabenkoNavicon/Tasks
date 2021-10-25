var Navicon = Navicon || {}

Navicon.nav_agreement_ribbon = (function () 
{   
    var self = {};

    const Entities = { Credit: "nav_credit" }

    const Elements = {
        Name: "nav_name",
        Date: "nav_date",
        Contact: "nav_contact",
        Auto: "nav_autoid",
        Summa: 'nav_summa',
        Fact:'nav_fact',
        Credit: 'nav_creditid',
        CreditPeriod: 'nav_creditperiod',
        CreditAmount: 'nav_creditamount',
        FullCreditAmount: 'nav_fullcreditamount',
        InitialFee: 'nav_initialfee',
        FactSumma: 'nav_factsumma',
        PaymentPlanDate: 'nav_paymentplandate'
      };

    var calcCreditAmount = function () {
        let summaValue = getValue(Elements.Summa);
        let initialFeeValue = getValue(Elements.InitialFee);

        if (summaValue == null || initialFeeValue == null)
            throw "Сумма и Первоначальный взнос не должны быть пустыми.";

        let creditAmount = summaValue - initialFeeValue;
        setValue(Elements.CreditAmount, creditAmount);
    };

    var calcFullCreditAmount = function () {

        let creditIdValue = getValue(Elements.Credit);

        if (checkRefId(creditIdValue) == false)
            throw "Не выбрана кредитная программа.";

        let creditPeriodValue = getValue(Elements.CreditPeriod);
        let creditAmountValue = getValue(Elements.CreditAmount);

        if (creditPeriodValue == null || creditAmountValue == null)
            throw 'Сумма кредита иили Срок кредита не должны пустыми';

        Xrm.Utility.showProgressIndicator("Загрузка...");
        Xrm.WebApi.retrieveRecord(Entities.Credit, creditIdValue[0].id, '?$select=nav_percent').then(
            (result) => {
                try {
                    let fullCreditAmount = (result.nav_percent / 100 * creditPeriodValue * creditAmountValue) + creditAmountValue;
                    setValue(Elements.FullCreditAmount, fullCreditAmount);
                }
                catch(ex) {
                    console.log(ex);
                }
            },
            (error) => { console.log(error.message) }
        ).finally( () => { Xrm.Utility.closeProgressIndicator() } );
    }

    // На карточку объекта Договор поместить кнопку «Пересчитать кредит». При нажатии на кнопку 
    // ● Пересчитывать поле сумма кредита.
    //   Сумма кредита = [Договор].[Сумма] – [Договор].[Первоначальный взнос]
    // ● Пересчитать поле полная стоимость кредита
    //   полная стоимость кредита = ([Кредитная Программа].[Ставка]/100 * [Договор].[Срок кредита] * 
    //   [Договор].[ Сумма кредита] ) + [Договор].[ Сумма кредита]
    self.reCalcCreditCommand = function()
    {
        try{
            calcCreditAmount();
            calcFullCreditAmount();
        }
        catch(ex) {
            console.log(ex);
            alertDialog("Пересчёт кредита", ex);
        }
    }

    self.onLoad = function(context) {
        try 
        {
            console.log("Navicon.nav_agreement_ribbon.onLoad()");
            this.__proto__ = Navicon.nav_base(context);
        }
        catch(ex) {
            console.error(ex);
            errorDialog(ex);
        }
    }

    return self;
})();