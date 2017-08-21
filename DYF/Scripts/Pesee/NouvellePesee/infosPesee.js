var infoPesee = (function () {
    var $selectBande, $selectRepartitionBande, $datePesee, $selectTemplate, semaine;

    init();

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

                $('#datePesee').pickadate({
                    selectMonths: true, // Creates a dropdown to control month
                    selectYears: 5, // Creates a dropdown of 15 years to control year,
                    min: new Date(response.year, response.month-1, response.day),
                    hiddenName: true,
                    closeOnSelect: false // Close upon selecting a date,
                    , onSet: function (ele) { // trigger validation of field on date selected
                        $("#" + $(this.$node).attr("id") + "").valid();
                        var dateArrivee = new Date(response.year, response.month-1, response.day);
                        var dateSelected = ele.select;
                        // determining corresponding week number
                        semaine = getnombreDeSemaine(dateArrivee.getTime(), dateSelected);
                        

                    }
                });

                // reassigning the new #datePesee reference
                $datePesee = $("#datePesee");
            }
        });
    }

    function getnombreDeSemaine(date1,date2) {
        var timeDiff = Math.abs(date2 - date1);
        var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24));
        var numberOfWeek = Math.floor(diffDays / 7);
        return numberOfWeek;
    }
    function getData() {
        console.log("ddddddddd");
        return {
            datePesee: $("input[type='hidden'][name='datePesee']").val(),// selector for getting hidden value
            typePesee: $("input[name='typePesee']:checked").attr("value"),
            semaine: semaine,
            idBande: $selectBande.find("option:selected").val(),
            idRepartitionBande: $selectRepartitionBande.find("option:selected").val(),
        };
    }

    return {
        init: init,
        data: getData
    }



})();