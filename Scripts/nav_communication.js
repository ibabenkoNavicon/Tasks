var Navicon = Navicon || {}

Navicon.nav_communication = (function () 
{ 
    var self = {};

    const Type = { Phone: 1, Email: 2 };

    const Element = {
        Name: "nav_name",
        ContactId: "nav_contactid",
        Email: "nav_email",
        Phone: "nav_phone",
        Type: 'nav_type',
        Main: 'nav_main'
      };

    // 2-7. На форме объекта Средство связи, при создании поля Телефон и Email скрыты. При выборе
    // пользователем значения в поле Тип, необходимо отображать соответствующее поле: 
    //      Если тип = Телефон, отображать поле Телефон
    //      Если тип = E-mail, отображать поле Email.  
    var type_onChange = function() {
        try {
            const typeValue = getValue(Element.Type);   

            if (typeValue != null) 
            {
                visibleCtrl([Element.Phone], typeValue == Type.Phone);
                visibleCtrl([Element.Email], typeValue == Type.Email);
                visibleCtrl([Element.Main], true);
            }
            else 
                visibleCtrl([Element.Phone, Element.Email, Element.Main], false);
        }
        catch(ex) {
            console.error(ex);
        }
    }

    self.onLoad = function(context) {
        try {
            console.log("Navicon.nav_Credit.onLoad()");
            this.__proto__ = Navicon.nav_base(context);  

            addOnChange([Element.Type], type_onChange);
            fireOnChange([Element.Type]);
        }
        catch(ex) {
            console.error(ex);
            errorDialog(ex);
        }
    }

    return self;
})();