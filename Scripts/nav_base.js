var Navicon = Navicon || {}

Navicon.nav_base = function (context) 
{   
    var self = {};
    
    FormTypes =  { Undefined: 0, Create: 1, Update: 2, ReadOnly: 3, Disabled: 4, BulkEdit: 6 }
    
    formContext = context.getFormContext();

    let checkArray = (obj) => {
        if ( obj == null || Array.isArray(obj) == false)
            throw `Ощибка: ОбЪект не является массивом.`;
        return obj;
    }

    checkRefId = (value) => value != null && Array.isArray(value) == true && value.length > 0 && value[0] != null;

    getId = () => formContext?.data.entity?.getId();

    getCtrl = (element) => {
        if ((obj = formContext?.getControl(element)) == null)
            throw `Ощибка: Нет элемента управления "${element}"`;
        return obj;
    }

    getAttr = (element) => {
        if ((obj = formContext?.getAttribute(element)) == null)
            throw `Ощибка: Нет атрибута "${element}"`;
        return obj;
    }

    getTab = (element) =>  {
        if ((obj = formContext?.ui.tabs.get(element)) == null)
            throw `Ощибка: Нет вкладки "${element}"`;
        return obj;
    }

    getLabel = (element) => getCtrl(element).getLabel();

    setLabel = (element, value) => getCtrl(element).setLabel(value);

    getValue = (element) => getAttr(element).getValue();

    setValue = (element, value) => getAttr(element).setValue(value);

    setFocus = (element) => getCtrl(element).setFocus();

    visibleTab = (elements, value) => checkArray(elements).forEach(element => getTab(element).setVisible(value));

    visibleCtrl = (elements, value) => checkArray(elements).forEach(element => getCtrl(element).setVisible(value));

    disableTab = (elements, value) => checkArray(elements).forEach(element => getTab(element).setDisable(value));

    disableCtrl = (elements, value) => checkArray(elements).forEach(element=> getCtrl(element).setDisable(value));

    addOnChange  = (elements, func) => checkArray(elements).forEach(element => getAttr(element).addOnChange(func));

    removeOnChange = (elements, func) => checkArray(elements).forEach(element => getAttr(element).removeOnChange(func));

    fireOnChange = (elements)=> checkArray(elements).forEach(element => getAttr(element).fireOnChange())

    addOnSave = (func) => formContext.data.entity.addOnSave(func);

    getFormType = () => formContext.ui.getFormType();

    addNotificationError = (element, message, uniqueId) => {
        let control = getCtrl(element);
        control.addNotification({
            messages: [message],
            notificationLevel: 'ERROR',
            uniqueId: uniqueId,
            actions: [{ 
                message: message, 
                actions:[() => control.clearNotification(uniqueId)] 
            }]
        });
    }

    clearNotification = (element, uniqueId) => getCtrl(element).clearNotification(uniqueId);

    alertDialog = (title, text) => {
        let alertStrings = { confirmButtonLabel: "Ok", text: text, title: title };
        let alertOptions = { height: 120, width: 300 };
        Xrm.Navigation.openAlertDialog(alertStrings, alertOptions).then(
            success => console.log(success),
            error => console.log(error.message)); 
    }

    errorDialog = (text) => {
        Xrm.Navigation.openErrorDialog({message: text}).then(
            success => console.log(success),
            error => console.log(error.message)); 
    }

    return self;
};