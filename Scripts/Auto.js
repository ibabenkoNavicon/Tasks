
var Navicon = Navicon || {}

Navicon.nav_Auto = (function () 
{ 
    var self = {};

    const Element = {
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

    var onChangeUsed = function() {
        try 
        {
             const usedValue = getValue(Element.Used);   

             visibleCtrl([Element.OwnersCount, Element.KM, Element.IsDamaged], usedValue == true);
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

            this.__proto__ = Navicon.nav_Base(context);  

            addOnChange([Element.Used], onChangeUsed);
            fireOnChange([Element.Used]);
        }
        catch(ex)
        {
            console.error(ex);
            errorDialog(ex);
        }
    }

    return self;
})();