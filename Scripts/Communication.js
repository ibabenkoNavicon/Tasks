var Navicon = Navicon || {}

Navicon.nav_Communication = (function () 
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

    onChangeType = function() {
        try 
        {
             type = etValue(Element.Type);   
             visibleCtrl([Element.Phone], type == Type.Phone);
             visibleCtrl([Element.Email], type == Type.Email);
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

            addOnChange([Element.Type], onChangeType);

            fireOnChange([Element.Type]);
        }
        catch(ex)
        {
            console.error(ex);
            errorDialog(ex);
        }
    }

    return self;
})();