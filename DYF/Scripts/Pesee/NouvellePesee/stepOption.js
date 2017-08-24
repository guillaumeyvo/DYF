(function () {
    var $stepCardOptionTemplate = $("#cardAction-template").html();
    var $resetAll, $resetStep, $formDetailNouvellePesee, $step1Loader, $bande, $repartitionBande, $datePesee;
    var $formDetailNouvellePeseeTemplate, $step2Error;

    
    init();

    function init() {

        generateStep1CardOption();
        generateStep2CardOption();
        generateStep3CardOption();
        $step2Error = $("#step2-error");
        $formDetailNouvellePesee = $("#formAddDataPesee");
        $formDetailNouvellePeseeTemplate = $formDetailNouvellePesee.html();
        $step1Loader = $("#step1Loader");
        $resetAll = $(".resetAll");
        $bande = $("#bande");
        $resetStep = $(".resetStep");
        $repartitionBande = $("#repartitionBande");
        $datePesee = $('#datePesee');

        //binding events

        $(document).on("click", ".resetStep", function () {
            resetStep($('.stepper').getActiveStep());
        });

        $(document).on("click", ".resetAll", resetAll);

    }

    function generateStep1CardOption() {

        var data = {
            fieldName: "step1Option",
            option: [{
                className: "resetStep",
                text : "Réinitialiser l'étape en cours"
            },
            {
                className: "resetAll",
                text: "Tout réinitialiser"

            }
            ]
        };
        $("#step1Header").append(Mustache.render($stepCardOptionTemplate, data));
    }

    function generateStep2CardOption() {

        var data = {
            fieldName: "step2Option",
            option: [{
                className: "resetStep",
                text: "Réinitialiser l'étape en cours"
            },
            {
                className: "resetAll",
                text: "Tout réinitialiser"

            }
            ]
        };
        $("#step2Header").append(Mustache.render($stepCardOptionTemplate, data));
    }

    function generateStep3CardOption() {
        var data = {
            fieldName: "step3Option",
            option: [{
                className: "resetAll",
                text: "Tout réinitialiser"
            }
            ]
        };
        $("#step3Header").append(Mustache.render($stepCardOptionTemplate, data));
    }

    function resetStep(stepNumber) {
        console.log("reset");

        if (stepNumber == 1) {
            resetStep1()
        }
        else {
            resetStep2();
        }
        
    }

    function resetStep1() {
        $formDetailNouvellePesee.addClass("loading-opacity");
        $step1Loader.show();
        // reset bande select
        if ($bande.next().hasClass("error")) {
            $bande.next().remove();
            $bande.removeClass("error")
            $bande.removeAttr("aria-describedby");
        }
        $bande.material_select('destroy');
        $bande.val("");
        $bande.material_select();

        // reset bande select
        if ($repartitionBande.next().hasClass("error")) {
            $repartitionBande.next().remove();
            $repartitionBande.removeClass("error")
            $repartitionBande.removeAttr("aria-describedby");
        }
        $repartitionBande.material_select('destroy');
        $repartitionBande.val("");
        $repartitionBande.material_select();

        $datePesee.empty();
        events.emit("step1Reset", "");
        $datePesee.pickadate({
            selectMonths: true, // Creates a dropdown to control month
            selectYears: 15, // Creates a dropdown of 15 years to control year,
            closeOnSelect: false, // Close upon selecting a date,
            hiddenName: true
            , onSet: function (ele) { // trigger validation of field on date selected
                $("#" + $(this.$node).attr("id") + "").valid();
            }
        });

        $formDetailNouvellePesee.removeClass("loading-opacity");
        $step1Loader.fadeOut();
    }

    function resetStep2() {
        $formDetailNouvellePesee.empty();
        $formDetailNouvellePesee.append($formDetailNouvellePeseeTemplate);
        $step2Error.parent().hide();
        detailsPesee.datatable.clear().draw();
        $('#tablePeseeDetails').parent().hide();
        detailsPesee.arrayPoids = [];
        detailsPesee.domInit();
    }

    function resetAll() {
        resetStep1();
        resetStep2();
        $('.stepper').openStep(1);
    }
})();