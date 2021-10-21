var Navicon = Navicon || {}

Navicon.nav_Base = function (context) 
{   
    var _self = {};
    var _formContext = context.getFormContext();

    var checkArray = (obj) => {
        if ( obj == null || Array.isArray(obj) == false)
            throw `Ощибка: ОбЪект не является массивом.`;
        return obj;
    }

    getCtrl = (name) => {
        if ((obj = _formContext.getControl(name)) == null)
            throw `Ощибка: Нет элемента управления "${name}"`;
        return obj;
    }

    getAttr = (name) => {
        if ((obj = _formContext.getAttribute(name)) == null)
            throw `Ощибка: Нет атрибута "${name}"`;
        return obj;
    }

    getTab = (name) =>  {
        if ((obj = _formContext.ui.tabs.get(name)) == null)
            throw `Ощибка: Нет вкладки "${name}"`;
        return obj;
    }

    getLabel = (name) => getCtrl(name).getLabel();

    setLabel = (name, val) => getCtrl(name).setLabel(val);

    getValue = (name) => getAttr(name).getValue();

    setValue = (name, val) => getAttr(name).setValue(val);

    setFocus = (name) => getCtrl(name).setFocus();

    visibleTab = (names, val) => checkArray(names).forEach((name) => { getTab(name).setVisible(val) });

    visibleCtrl = (names, val) => checkArray(names).forEach((name) => { getCtrl(name).setVisible(val) });

    addOnChange  = (names, func) => checkArray(names).forEach((name) => { getAttr(name).addOnChange(func) });

    removeOnChange  = (names, func) => checkArray(names).forEach((name) => { getAttr(name).removeOnChange(func) });

    fireOnChange = (names)=> checkArray(names).forEach((name) => { getAttr(name).fireOnChange() })

    addOnSave = (func) => _formContext.data.entity.addOnSave(func);

    alertDialog = (title, text) => {
        var alertStrings = { confirmButtonLabel: "Ok", text: text, title: title };
        var alertOptions = { height: 120, width: 300 };
        Xrm.Navigation.openAlertDialog(alertStrings, alertOptions).then(
            (success) => console.log(success),
            (error) => console.log(error.message)); 
    }

    errorDialog = (text) => {
        Xrm.Navigation.openErrorDialog({message: text}).then(
            (success) => console.log(success),
            (error) => console.error(error.message)); 
    }

    return _self;
};