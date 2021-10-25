var Navicon = Navicon || {}

Navicon.nav_agreement = (function () 
{   
    var self = {};

    const Entities = { Model: "nav_model", Auto: "nav_auto", Credit: "nav_credit" };
    const Tabs = { Tab1: 'tab_1', Tab2: 'tab_2' };
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

    var _isNotifiCredit = false;

    // 2-1. При создании объекта Договор, сразу после открытия карточки доступны для редактирования поля: номер,
    // дата договора, контакт и модель. Остальные поля - скрыты. Вкладка с данными по кредиту скрыта.
    var setFieldAfterCreatingObject = function() {
        if (getFormType() != FormTypes.Create) 
            return;
        visibleTab([Tabs.Tab2], false);
        visibleCtrl([Elements.Credit, Elements.Fact], false);
    }

    // 2-2.  На объекте Договор, после выбора значения в полях контакт и автомобиль, становиться доступной
    // вкладка кредитная программа.
    var autoOrContact_OnChange = function() {
        try 
        {
            const hasValue = getValue(Elements.Auto) != null && getValue(Elements.Contact) != null
            visibleCtrl([Elements.Credit], hasValue);
        }
        catch(ex) {
            console.error(ex);
        }
    }

    // 2-3.  На объекте Договор, после выбора кредитной программы, становятся доступными для редактирования 
    // поля, связанные с расчетом кредита.
    var credit_onChange = function() {
        try 
        {
            const hasValue = getValue(Elements.Credit) != null;

            visibleTab([Tabs.Tab2], hasValue);
            visibleCtrl([Elements.Fact], hasValue);

            checkCreditEndDate();
            setCreditPeriod();
        }
        catch(ex) {
            console.error(ex);
        }
    }

    // 3-3. При выборе объекта Автомобиль в объекте Договор, стоимость должна подставляться 
    // Автоматически в соответствии с правилом:
    //  ● Если автомобиль с пробегом, стоимость берется из поля Сумма на объекте Автомобиль
    //  ● Если автомобиль без пробега, стоимость берется из поля сумма объекта Модель, указанной 
    //    на Автомобиле.
    var auto_onChange = function() {
        try 
        {
            const autoIdValue = getValue(Elements.Auto);
            const creditIdValue = getValue(Elements.Credit);
        
            if (checkRefId(autoIdValue) == false)
            {
                setValue(Elements.Credit, null);
                fireOnChange([Elements.Credit]); 
                return;
            }

            const autoRefId = autoIdValue[0].id;

            var arrPromises = [Xrm.WebApi.retrieveRecord(Entities.Auto, autoRefId,  
                "?$select=nav_used,nav_amount&$expand=nav_modelid($select=nav_recommendedamount)")];

            if (checkRefId(creditIdValue) == true)
            {
                const creditRefId = creditIdValue[0].id;
                arrPromises.push(Xrm.WebApi.retrieveMultipleRecords('nav_nav_auto_nav_credit', 
                    `?$filter=nav_autoid eq ${autoRefId} and nav_creditid eq ${creditRefId}`))
            }

            Xrm.Utility.showProgressIndicator("Загрузка...");
            Promise.all(arrPromises).then(   
                (results) => {    
                    try {
                        if (results[0] != null)
                        {
                            let vals = results[0]; 
                            setValue(Elements.Summa, vals.nav_used ? vals.nav_amount : vals.nav_modelid.nav_recommendedamount);
                        }  
                        if (results[1] != null && results[1].length == 0)
                        {
                            setValue(Elements.Credit, null);
                            fireOnChange([Elements.Credit]); 
                        }
                    }            
                    catch(ex) {
                        console.log(ex);
                    }
                },
                (error) => { console.log(error.message) }
            ).finally( () => { Xrm.Utility.closeProgressIndicator() } );
    
            //setAutoAmount();
        }
        catch(ex) {
            console.error(ex);
        }
    }

    // 2-4.  На объекте Договор, поскольку кредитные программы связаны с объектом Автомобиль отношением N:N
    // то в договоре при выборе кредитной программы в списке лукап поля должны быть доступны только программы,
    // связанные  с выбранным объектом Автомобиль.
    var setFilterCredit = function() {
        try 
        {
            const autoValue = getValue(Elements.Auto);
            const viewName = "small_nav_credit";
            const viewId = '{51645BA7-072F-48C6-AC4D-9E64E8C167FB}';
            const autoRefId = checkRefId(autoValue) ? autoValue[0].id : '';

            const fetchXml = [ 
            "<fetch>",
                "<entity name='nav_credit'>",
                    "<all-attributes />",
                    "<link-entity name='nav_nav_auto_nav_credit' from='nav_creditid' to='nav_creditid' intersect='true'>",
                        "<link-entity name='nav_auto' from='nav_autoid' to='nav_autoid' intersect='true' />",
                            "<filter>",
                                `<condition attribute='nav_autoid' operator='eq' value='${autoRefId}'/>`,
                            "</filter>",
                        "</link-entity>",
                    "</link-entity>",
                "</entity>",
            "</fetch>"].join("");

            const preGridXml = [
            '<grid name="nav_credits" jump="nav_name" select="1" icon="1" preview="0">',
                '<row name="nav_credit" id="nav_creditid">',
                    '<cell name="nav_name" width="300" />',
                    '<cell name="createdon" width="125" />',
                '</row>',
            '</grid>'].join("");

            getCtrl(Elements.Credit).addCustomView(viewId, Entities.Credit, viewName, fetchXml, preGridXml, true);
        }
        catch(ex) {
            console.error(ex);
        }
    }

    // 2-6.  На объекте Договор, реализовать функцию для поля номер договора - по завершении ввода, оставлять
    // только цифры и тире. 
    var name_onChange = function() {
        try 
        {
            var nameValue = getValue(Elements.Name); 

            if (nameValue == null) return;

            const regex = /[^0-9-]+/g;
            const nameCleared = nameValue.replaceAll(regex, '');

            setValue(Elements.Name, nameCleared);
            console.log(`onChangeName() - before: ${nameValue} after: ${nameCleared}`);
        }
        catch(ex) {
            console.error(ex);
        }
    }

    // 3-1.	Объект Договор: после выбора значения в поле кредитная программа, проверять ее срок действия
    // относительно даты договора. Если срок истек, система должна показывать пользователю сообщение и
    // блокировать сохранение формы.
    var checkCreditEndDate = function() {
        const uniqueId = "credit_error_id";
        const creditValue = getValue(Elements.Credit);
        const dateValue = getValue(Elements.Date);

        if (checkRefId(creditValue) == false || dateValue == null) return;

        Xrm.Utility.showProgressIndicator("Загрузка...");
        Xrm.WebApi.retrieveRecord(Entities.Credit, creditValue[0].id, "?$select=nav_dateend").then(
            (result) => {
                try {
                    let dateEnd = Date.parse(result.nav_dateend);
                    if (dateValue > dateEnd && _isNotifiCredit == false) {
                        addNotificationError(Elements.Credit, "Истек срок действия кредитной программы.", uniqueId);
                        _isNotifiCredit = true;
                    }
                    else if (_isNotifiCredit) {
                        clearNotification(Elements.Credit, uniqueId);
                        _isNotifiCredit = false;
                    }
                }            
                catch(ex) {
                    console.log(ex);
                }
            },
            (error) => { console.log(error.message) }
        ).finally( () => { Xrm.Utility.closeProgressIndicator() } );
    }

    // 3-2.	Объект Договор: после выбора значения в поле кредитная программа, срок кредита должен
    // подставляться из выбранной кредитной программы в договор.
    var setCreditPeriod = function () {    
        const creditValue = getValue(Elements.Credit);
        
        if (checkRefId(creditValue) == false) return;

        Xrm.Utility.showProgressIndicator("Загрузка...");
        Xrm.WebApi.retrieveRecord(Entities.Credit, creditValue[0].id, "?$select=nav_creditperiod").then(
            (result) => {
                try {
                 setValue(Elements.CreditPeriod, result.nav_creditperiod) 
                }            
                catch(ex) {
                     console.log(ex);
                }
            },
            (error) => { console.log(error.message) }
        ).finally( () => { Xrm.Utility.closeProgressIndicator() } );
    }

    self.onLoad = function(context) {
        try 
        {
            console.log("Navicon.nav_Agreement.onLoad()");
            this.__proto__ = Navicon.nav_base(context);

            setFieldAfterCreatingObject();

            addOnChange([Elements.Name], name_onChange);
            addOnChange([Elements.Credit, Elements.Date], credit_onChange);
            addOnChange([Elements.Contact, Elements.Auto], autoOrContact_OnChange);
            addOnChange([Elements.Auto], auto_onChange);

            getCtrl(Elements.Credit).addPreSearch(() => { setFilterCredit() });

            fireOnChange([Elements.Contact, Elements.Credit]);
        }
        catch(ex) {
            console.error(ex);
            errorDialog(ex);
        }
    }

    return self;
})();