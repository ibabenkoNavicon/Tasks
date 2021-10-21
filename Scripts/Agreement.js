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

            if (autoIdValue == null || Array.isArray(autoIdValue) == false || 
                autoIdValue.lenght == 0 || autoIdValue[0] == null)  return;
            
            const autoRef = autoIdValue[0];
            
            uodateFilterCredit(autoRef.id);
            console.log(`autoRef: ${autoRef}`);
        }
        catch(ex)
        {
            console.error(ex);
        }
    }

    var uodateFilterCredit = function(autoRefId) {
        const viewName = "small_nav_credit";
        const viewId =  '{00000000-0000-0000-0000-000000000001}';

        const fetchXml = [ 
            "<fetch>",
            "<entity name='nav_credit'>",
            "<all-attributes />",
            "<link-entity name='nav_nav_auto_nav_credit' from='nav_creditid' to='nav_creditid' intersect='true'>",
            "<link-entity name='nav_auto' from='nav_autoid' to='nav_autoid' intersect='true'>",
            "<filter>",
            "<condition attribute='nav_autoid' operator='eq' value='", autoRefId, "'/>",
            "</filter>",
            "</link-entity>",
            "</link-entity>",
            "</entity>",
            "</fetch>"].join("");

        const preGridXml = '<grid name="nav_credits" jump="nav_name" select="1" icon="1" preview="0">' +
            '<row name="nav_credit" id="nav_creditid"><cell name="nav_name" width="300" /><cell name="createdon" width="125" /></row></grid>'

        getCtrl(Element.Credit).addCustomView(viewId, "nav_credit", viewName, fetchXml, preGridXml, true);
        setValue(Element.Credit, null);
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