var Navicon = Navicon || {}

Navicon.nav_Agreement = (function () 
{   
    var self = {};

    const entityAutoCedit = 'nav_nav_auto_nav_credit';

    const Tab = { Tab1: 'tab_1', Tab2: 'tab_2' };

    const Element = {
        Name: "nav_name",
        Date: "nav_date",
        Contact: "nav_contact",
        Auto: "nav_autoid",
        Summa: 'nav_summa',
        Fact:'nav_fact',
        Credit: 'nav_creditid'
      };


    var onChangeAutoAndContact = function() {
        try 
        {
            const hasValue = getValue(Element.Auto) != null && getValue(Element.Contact) != null

            visibleCtrl([Element.Credit], hasValue);
        }
        catch(ex)
        {
            console.error(ex);
        }
    }

    var onChangeCredit = function() {
        try 
        {
            const hasValue = getValue(Element.Credit) != null;

            visibleTab([Tab.Tab2], hasValue);
            visibleCtrl([Element.Summa, Element.Fact], hasValue);
        }
        catch(ex)
        {
            console.error(ex);
        }
    }

    var onChangeName = function() {
        try 
        {
            var nameValue = etValue(Element.Name); 

            if (nameValue == null) return;

            const regex = /[^0-9-]+/g;
            const nameCleared = nameValue.replaceAll(regex, '');

            setValue(Element.Name, nameCleared);
            console.log(`onChangeName() - before: ${nameValue} after: ${nameCleared}`);
        }
        catch(ex)
        {
            console.error(ex);
        }
    }

    var onChangeAuto = function() {
        try 
        {
            const autoIdValue = getValue(Element.Auto);

            if (autoIdValue == null || Array.isArray(autoIdValue) == false || autoIdValue.lenght == 0 || autoIdValue[0] == null)  return;
            
            const autoRef = autoIdValue[0];
            const filterName = "credit";

            console.log(`autoRef: ${autoRef}`);

            Xrm.WebApi.retrieveMultipleRecords(entityAutoCedit, '?$select=nav_creditid&$filter=nav_autoid eq ' + autoRef.id).then(
                (success) => {
                    try 
                    {
                        var filter = "<filter type='and'><condition attribute='nav_creditid' operator='in'>";
                        success.entities.forEach((obj) => { filter += `<value>${obj.nav_creditid}</value>` });   
                        filter += "</condition></filter>";
                    
                        removeFilterSearch(filterName, Element.Credit, filter);
                        addFilterSearch(filterName, Element.Credit, filter);

                        console.log(`filter: ${filter}`);
                    }
                    catch(ex)
                    {
                        console.error(ex);
                    }
                },
                (error) => console.log(error.message)
            );
        }
        catch(ex)
        {
            console.error(ex);
        }
    }

    self.onLoad = function(context) {
        try 
        {
            console.log("Navicon.nav_Agreement.onLoad()");

            this.__proto__ = Navicon.nav_Base(context);

            addOnChange([Element.Name], onChangeName);
            addOnChange([Element.Credit], onChangeCredit);
            addOnChange([Element.Contact, Element.Auto], onChangeAutoAndContact);
            addOnChange([Element.Auto], onChangeAuto);

            fireOnChange([Element.Contact, Element.Auto, Element.Credit]);
        }
        catch(ex)
        {
            console.error(ex);
            errorDialog(ex);
        }
    }

    return self;
})();