var Navicon = Navicon || {}

Navicon.nav_brand = (function () 
{ 
    var self = {};

    let setBrandCreditsFreme = (context) => {
        let brandId = getId();
        if (brandId == null) return;
            
        var fetchXml = [
            "<fetch distinct='true'>",
                "<entity name='nav_model'>",
                    "<attribute name='nav_modelid' alias='model_id' />",
                    "<attribute name='nav_name' alias='model' />",
                    "<filter>",
                        "<condition attribute='nav_brandid' operator='eq' value='", brandId, "'/>",
                    "</filter>",
                    "<link-entity name='nav_auto' from='nav_modelid' to='nav_modelid' link-type='inner'>",
                        "<link-entity name='nav_nav_auto_nav_credit' from='nav_autoid' to='nav_autoid' link-type='inner' intersect='true'>",
                            "<link-entity name='nav_credit' from='nav_creditid' to='nav_creditid' link-type='inner' intersect='true'>",
                                "<attribute name='nav_name' alias='credit' />",
                                "<attribute name='nav_creditperiod' alias='period' />",
                                "<order attribute='nav_creditperiod' />",
                            "</link-entity>",
                        "</link-entity>",
                    "</link-entity>",
                "</entity>",
            "</fetch>"].join("");


        let resourceCtrl = getCtrl("WebResource_brand_credits_frame").getContentWindow();

        Xrm.Utility.showProgressIndicator("Загрузка...");
        Xrm.WebApi.retrieveMultipleRecords("nav_model", "?fetchXml=" + fetchXml).then(
            result => resourceCtrl.then(
                content => content.setData(result.entities),
                error => console.error(error.message)),          
            error => console.error(error.message)
        ).finally(() => Xrm.Utility.closeProgressIndicator());
    }

    self.onLoad = function(context) {
        try 
        {
            console.log("Navicon.nav_brand.onLoad()");
            this.__proto__ = Navicon.nav_base(context);  

            setBrandCreditsFreme();
        }
        catch(ex)
        {
            console.error(ex);
            errorDialog(ex);
        }
    }

    return self;
})();