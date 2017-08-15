var infoPesee = (function () {
    var $selectBande, $selectRepartitionBande, $datePesee;
    function init() {
        
        $selectBande = $("#bande");
        $selectRepartitionBande = $("#repartitionBande");
        $datePesee = $("#datePesee");

        // bind events
        $selectBande.change(getRepartitionBande);
        $selectRepartitionBande.change(loadDerniereDateDePesee);
    }


    function getRepartitionBande(event) {
        var idBandeSelected = $selectBande.find("option:selected").val();
        $.ajax({
            //type: "POST",
            url: "api/Pesee/RepartitionBande/" + idBandeSelected,
            success: function (response) {
                $selectRepartitionBande.material_select('destroy');
                $selectRepartitionBande.material_select();
                console.log("fine");
            }
        });
        //$("#formDetailNouvellePesee").validate().element("#repartitionBande");
    }

    function loadDerniereDateDePesee(event) {
        $.ajax({
            //type: "POST",
            url: "api/Pesee/RepartitionBande",
            success: function (response) {
                console.log("ok")
            }
        });
    }

    return {
        init : init
    }

    

})();