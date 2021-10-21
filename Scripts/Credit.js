
var Navicon = Navicon || {}

Navicon.nav_Credit = (function () 
{ 
    var self = {};

    const minYearsCredit = 1;
    const yearsCreditMessage= 'должна быть больше "Даты начала", не менее, чем на год';

    const Element = {
        Name: "nav_name",
        DateStart: "nav_datestart",
        Bank: "nav_bank",
        DateEnd: "nav_dateend",
        Percent: 'nav_percent'
      };

    onChangeDate = function() {
        try 
        {
            if ((dateStart = getValue(Element.DateStart)) == null || (dateEnd = getValue(Element.DateEnd)) == null)
                return;

            console.log('dateStart = ' +  dateStart + '; dateEnd = ' +  dateEnd);
            dateEnd.setFullYear(dateEnd.getFullYear() - minYearsCredit) 

            const unique_id = 'error_dateend_id';
            var control = getCtrl(Element.DateEnd);

            if (dateEnd < dateStart)
            {
                control.addNotification({
                    messages: [yearsCreditMessage],
                    notificationLevel: 'ERROR',
                    uniqueId: unique_id,
                    actions: [{ 
                        message: yearsCreditMessage,
                        actions:[() => control.clearNotification(unique_id)]
                    }]
                });
            }
            else 
                control.clearNotification(unique_id);
        }
        catch(ex)
        {
            console.error(ex);
        }
    }

    self.onSave = function(context) {
        try {
            console.log("Navicon.nav_Credit.onSave()");

            if ((saveEvent = context.getEventArgs()) == null)
                return;

            this.__proto__ = Navicon.nav_Base(context);

            if ((dateStart = getValue(Element.DateStart)) == null || (dateEnd = getValue(Element.DateEnd)) == null)
                return;

            console.log('dateStart = ' +  dateStart + '; dateEnd = ' +  dateEnd);
            dateEnd.setFullYear(dateEnd.getFullYear() - minYearsCredit)

            if (dateEnd >= dateStart)
                return;

            alertDialog("Неправильные данные", yearsCreditMessage);
            saveEvent.preventDefault();
            setFocus(Element.DateEnd);
        }
        catch(ex)
        {
            console.error(ex);
        }
    }

    self.onLoad = function(context) {
        try {
            console.log("Navicon.nav_Credit.onLoad()");

            this.__proto__ = Navicon.nav_Base(context);  

            addOnChange([Element.DateStart, Element.DateEnd], onChangeDate);

            fireOnChange([Element.DateEnd]);
        }
        catch(ex)
        {
            console.error(ex);
            errorDialog(ex);
        }
    }

    return self;
})();