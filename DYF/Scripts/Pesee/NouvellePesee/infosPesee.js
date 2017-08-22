var infoPesee = (function () {
    var $selectBande, $selectRepartitionBande, $datePesee, $datePickerDiv, $selectTemplate, $datePickerTemplate, semaine;
    var datePeseeData = {
        fieldName: "datePesee",
        label: "Selectionner la date de la pesée"
    };

    init();

    function init() {

        $selectBande = $("#bande");
        $selectRepartitionBande = $("#repartitionBande");
        $datePesee = $("#datePesee");
        $datePickerDiv = $("#datePeseeDiv");
        $selectTemplate = $("#select-template").html();
        $datePickerTemplate = $("#datePicker-template").html();
        generateDatePeseeDatePicker();
        // bind events
        $selectBande.change(getRepartitionBande);
        $selectRepartitionBande.change(loadDerniereDateDePesee);
    }


    function generateDatePeseeDatePicker() {
        $datePickerDiv.html(Mustache.render($datePickerTemplate, datePeseeData));
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
                var date;
                if (Object.keys(response.dateDernierePesee).length == 0) {
                    date = response.dateArriveBande;
                }
                else {
                    date = response.dateDernierePesee;
                }
                
                $datePickerDiv.empty();
                generateDatePeseeDatePicker();

                $('#datePesee').pickadate({
                    selectMonths: true, // Creates a dropdown to control month
                    selectYears: 5, // Creates a dropdown of 15 years to control year,
                    min: new Date(date.year, date.month - 1, date.day),
                    hiddenName: true,
                    closeOnSelect: false // Close upon selecting a date,
                    , onSet: function (ele) { // trigger validation of field on date selected
                        $("#" + $(this.$node).attr("id") + "").valid();
                        var dateArrivee = new Date(response.dateArriveBande.year, response.dateArriveBande.month - 1, response.dateArriveBande.day);
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