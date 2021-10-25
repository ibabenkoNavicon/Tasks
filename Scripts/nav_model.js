var Navicon = Navicon || {}

Navicon.nav_model = (function () 
{ 
    var self = {};

    const Tabs = { General: 'nav_general' };

    // 3-1.	Создавать модели могут все. Изменять поля в объекте Модель может только пользователь с ролью 
    // Системный Администратор. 
    var setFieldForFormUpdate = function() {
        if (getFormType() != FormTypes.Update) 
            return;

        const roleAdmin= "Системный администратор";
        var userRoles = Xrm.Utility.getGlobalContext().userSettings.roles.getAll();
        var isAdmin = userRoles.some((obj) => obj.name == roleAdmin );

        if (isAdmin == false)
        {
            formContext.ui.controls.forEach((obj) => {
                if (obj != null && obj.setDisabled)
                    obj.setDisabled(true);
            });
        }
    }

    self.onLoad = function(context) {
        try 
        {
            console.log("Navicon.nav_model.onLoad()");
            this.__proto__ = Navicon.nav_base(context);  

            setFieldForFormUpdate();
        }
        catch(ex)
        {
            console.error(ex);
            errorDialog(ex);
        }
    }

    return self;
})();