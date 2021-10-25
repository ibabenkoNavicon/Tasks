
var Navicon = Navicon || {}

Navicon.nav_credit = (function () 
{ 
    var self = {};

    const minYearsCredit = 1;
    const yearsCreditMessage= 'должна быть больше "Даты начала", не менее, чем на год';

    const Elements = {
        Name: "nav_name",
        DateStart: "nav_datestart",
        Bank: "nav_bank",
        DateEnd: "nav_dateend",
        Percent: 'nav_percent'
      };

    var _isNotifiDateEnd = false;

    // 2-5. На объекте Кредитная программа необходимо проверять, чтобы дата окончания была больше даты
    // начала, не менее, чем на год. В случае невыполнения условия, показывать информационное сообщение
    // и блокировать сохранение формы.
    var date_onChange = function() {
        try {
            let dateStartValue = getValue(Elements.DateStart);
            let dateEndValue = getValue(Elements.DateEnd);

            if (dateStartValue == null || dateEndValue == null) return;

            console.log('dateStart = ' +  dateStartValue + '; dateEnd = ' +  dateEndValue);
            dateEndValue.setFullYear(dateEnd.getFullYear() - minYearsCredit) 
            const uniqueId = 'error_dateend_id';

            if (dateEnd < dateStart && _isNotifiDateEnd == false) {
                addNotificationError(Elements.DateEnd, yearsCreditMessage, uniqueId);
                _isNotifiDateEnd = true;
            }
            else if (_isNotifiDateEnd) {
                clearNotification(Elements.DateEnd, uniqueId);
                _isNotifiDateEnd = false;
            }
        }
        catch(ex) {
            console.error(ex);
        }
    }

    var onSave = function(context) {
        try {
            console.log("Navicon.nav_credit.onSave()");
            let saveEvent = context.getEventArgs();
            let dateStart = getValue(Elements.DateStart);
            let dateEnd = getValue(Elements.DateEnd);

            if (saveEvent == null || dateStart == null || dateEnd == null) return;

            console.log('dateStart = ' +  dateStart + '; dateEnd = ' +  dateEnd);
            dateEnd.setFullYear(dateEnd.getFullYear() - minYearsCredit)

            if (dateEnd >= dateStart) return;

            alertDialog("Неправильные данные", yearsCreditMessage);
            saveEvent.preventDefault();
            setFocus(Elements.DateEnd);
        }
        catch(ex) {
            console.error(ex);
        }
    }

    self.onLoad = function(context) {
        try {
            console.log("Navicon.nav_credit.onLoad()");
            this.__proto__ = Navicon.nav_base(context);  

            addOnSave(onSave);
            addOnChange([Elements.DateStart, Elements.DateEnd], date_onChange);

            fireOnChange([Elements.DateEnd]);
        }
        catch(ex) {
            console.error(ex);
            errorDialog(ex);
        }
    }

    return self;
})();