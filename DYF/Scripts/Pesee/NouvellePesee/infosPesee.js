var infoPesee = (function () {
    var $selectBande, $selectRepartitionBande, $datePesee,$selectTemplate;
    function init() {
        
        $selectBande = $("#bande");
        $selectRepartitionBande = $("#repartitionBande");
        $datePesee = $("#datePesee");
        $selectTemplate = $("#select-template").html();

        // bind events
        $selectBande.change(getRepartitionBande);
        $selectRepartitionBande.change(loadDerniereDateDePesee);
    }


    function getRepartitionBande(event) {
        var idBandeSelected = $selectBande.find("option:selected").val();
        $.ajax({
            //type: "POST",
            url: "api/Pesee/GetRepartitionBande?idBande=" + idBandeSelected,
            success: function (response) {
                var data = {
                    template: response,
                    defaultValue: "",
                    defaultText: "Choisir un batiment"
                };
                var $selectRepartitionBandeDivError = $selectRepartitionBande.next();
                if ($selectRepartitionBandeDivError.hasClass("error")) {
                    $selectRepartitionBandeDivError.remove();
                    $selectRepartitionBande.removeClass("error");
                }
                $selectRepartitionBande.material_select('destroy');
                $("#repartitionBande").empty();

                $selectRepartitionBande.html(Mustache.render($selectTemplate, data));


                $selectRepartitionBande.material_select();

                console.log("fine");
            }
        });
        //$("#formDetailNouvellePesee").validate().element("#repartitionBande");
    }

    function loadDerniereDateDePesee(event) {
        var idRepartitionBandeSelected = $selectRepartitionBande.find("option:selected").val();
        $.ajax({
            //type: "POST",
            url: "api/Pesee/GetPeseeLastDate?idRepartitionBande=" + idRepartitionBandeSelected,
            success: function (response) {
                var $dateDivError = $datePesee.next();
                if ($dateDivError.hasClass("error")) {
                    $dateDivError.remove();
                    $datePesee.removeClass("error");
                }
                $datePesee.remove();
                var datePeseeHtml = '<input type="text" class="datepicker date-required" id="datePesee" name="datePesee">';
                $("label[for='datePesee']").before(datePeseeHtml)
                if (Object.keys(response) == 0) {
                    $('#datePesee').pickadate({
                        selectMonths: true, // Creates a dropdown to control month
                        selectYears: 5, // Creates a dropdown of 15 years to control year,
                        //min:
                        closeOnSelect: false // Close upon selecting a date,
                        , onSet: function (ele) { // trigger validation of field on date selected
                            $("#" + $(this.$node).attr("id") + "").valid();
                        }
                    });
                }
                else {
                    $('#datePesee').pickadate({
                        selectMonths: true, // Creates a dropdown to control month
                        selectYears: 5, // Creates a dropdown of 15 years to control year,
                        min: new Date(response.year, response.month, response.day),
                        closeOnSelect: false // Close upon selecting a date,
                        , onSet: function (ele) { // trigger validation of field on date selected
                            $("#" + $(this.$node).attr("id") + "").valid();
                        }
                    });
                }

                // reassigning the new #datePesee reference
                $datePesee = $("#datePesee");
                console.log("ok")
            }
        });
    }

    return {
        init : init
    }

    

})();