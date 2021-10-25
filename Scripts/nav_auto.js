
var Navicon = Navicon || {}

Navicon.nav_auto = (function () 
{ 
    var self = {};

    const Elements = {
        Name: "nav_name",
        BrandId: "nav_brandid ",
        Modelid: "nav_modelid",
        VIN: "nav_vin",
        VechcleNumber: 'nav_vechclenumber',
        Details: 'nav_details',
        Used: 'nav_used',
        OwnersCount: 'nav_ownerscount',
        KM: 'nav_km',
        IsDamaged: 'nav_isdamaged',
        Amount: 'nav_amount'
      };

    // 2-8. Поля на объекте Автомобиль new_auto: Пробег, Количество владельцев, был в ДТП отображаются только
    // при значении в поле С пробегом(new_used)=true.
    var used_onChange = function() {
        try 
        {
             const usedValue = getValue(Elements.Used);   

             visibleCtrl([Elements.OwnersCount, Elements.KM, Elements.IsDamaged], usedValue == true);
        }
        catch(ex)
        {
            console.error(ex);
        }
    }

    self.onLoad = function(context) {
        try 
        {
            console.log("Navicon.nav_Credit.onLoad()");
            this.__proto__ = Navicon.nav_base(context);  

            addOnChange([Elements.Used], used_onChange);
            fireOnChange([Elements.Used]);
        }
        catch(ex)
        {
            console.error(ex);
            errorDialog(ex);
        }
    }

    return self;
})();