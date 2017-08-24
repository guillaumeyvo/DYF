(function () {
    // #region Custom validation 

    // required for preventing validation of hidden fields
    $.validator.setDefaults({
        ignore: []
    });



    // #region Rules specific for step 1 formDetailNouvellePesee

    // for date
    $.validator.addMethod("date-required",
        function (value, element, arg) {
            return value !== "";
        });

    $.validator.addMethod("repartitionBande-required",
        function (value, element, arg) {
            return $("#repartitionBande option:selected").val() != "";
        });

    $.validator.addMethod("bande-required",
        function (value, element, arg) {
            return $("#bande option:selected").val() != "";
        });

    // for required select
    $.validator.addMethod("select-required",
        function (value, element, arg) {

            return value !== null;
        });
    // #endregion


    // #region Rules for step 2 
    $.validator.addMethod("poids-uniqueValue",
        function (value, element, arg) {
            //console.log("detailsPesee.arrayPoids",detailsPesee.arrayPoids);
            if (detailsPesee.arrayPoids.length == 0 || detailsPesee.arrayPoids.indexOf(parseInt(value)) == -1) {
                return true;
            }
            return false
        });
    // #endregion


    // #endregion

    // #region Validation rules

    // Default rules
    $.validator.setDefaults({
        errorElement: 'div',
        errorPlacement: function (error, element) {

            // if the field to be validated is a select
            if ($(element).is("select")) {
                //console.log("errorPlacement select", error, element);

                $(element).prev().prev().addClass("no-margin");
                var placement = $(element).data('error');
                if (placement) {
                    $(placement).append(error)
                } else {
                    error.insertAfter(element);
                }
            }
            // if the field to be validated is a datepicker then add class to the root field
            else if ($(element).prev().hasClass("picker") && $(element).attr("type") == "hidden") {
                //console.log("errorPlacement date", $(element), $(element).attr("class"), $(element).attr("type"));

                //$(element).prev().prev().addClass("no-margin")
                var placement = $(element).data('error');
                console.log("inside no margin picker", $(element), placement);

                if (placement) {
                    $(placement).append(error)
                } else {
                    $(element).prev().prev().addClass("no-margin");
                    error.insertAfter($(element).next());
                }
            }
            else {
                //console.log("errorPlacement other", error, element);

                $(element).addClass("no-margin");

                var placement = $(element).data('error');
                if (placement) {
                    $(placement).append(error)
                } else {
                    error.insertAfter(element);
                }
            }

        },
        unhighlight: function (element, errorClass, validClass) {
            if ($(element).is("select")) {
                //console.log("unhighlight", $(element).prev().prev(), $(element).prev().prev().hasClass("no-margin"));
                $(element).prev().prev().removeClass("no-margin");
            }
            else {

                $(element).removeClass("no-margin");
            }
        },
        submitHandler: function (form) {
            console.log('form ok');
        }
    });

    $("#formAddDataPesee").validate({
        //debug: true,
        rules: {
            poids: {
                required: true,
                digits: true,
                min: 1,
                "poids-uniqueValue": true
            }
            , nombreDeSujet: {
                required: true,
                digits: true,
                min: 1
            }

        },
        messages: {
            poids: {
                required: "Veuillez spécifier une valeur",
                digits: "Veuillez spécifier une nombre",
                min: "Veuillez spécifier une valeur superieure à 0",
                number: "Veuillez spécifier un nombre valide",
                "poids-uniqueValue": "Cette valeur est deja spécifiée"
            }
            , nombreDeSujet: {
                required: "Veuillez spécifier une valeur",
                digits: "Veuillez spécifier une nombre",
                min: "Veuillez spécifier une valeur superieure à 0",
                number: "Veuillez spécifier un nombre valide"

            }
        }

    });

    // formDetailNouvellePesee rules
    $("#formDetailNouvellePesee").validate({
        //debug: true,
        rules: {
            bande: {
                "select-required": true
            }
            , repartitionBande: {
                "bande-required": true,
                "select-required": true

            }
            , datePesee: {
                "repartitionBande-required": true,
                "date-required": true

            }
            , typePesee: "required"
        },
        messages: {
            bande: "Veuillez selectionner une bande",
            repartitionBande: {
                "bande-required": "Veuillez spécifier une bande",
                "select-required": "Veuillez spécifier un batiment"

            },
            datePesee: {
                "date-required": "Veuillez selectionner une date",
                "repartitionBande-required": "Veuillez spécifier une repartition de bande"
            }

        }

    });
    // #endregion

    // #region Validation Triggers

    $("select.select-required").each(function (index, element) {
        $(element).change(function () {
            $(this).valid();
        });
    });

    // validation of first step's data
    $("#endOfFirstStep").click(function (e) {
        if ($("#formDetailNouvellePesee").valid()) {
            $('.stepper').nextStep();
        }
    });

    // validation of second step's data
    $("#endOfSecondStep").click(function (e) {
        if ($("#tablePeseeDetails").is(":visible")) {
            $('.stepper').activateFeedback();
            events.emit("endOfDetailsPesee", detailsPesee.getTableData());
            $('.stepper').nextStep();
        }
        else {
            $("#step2-error").parent().show();
        }
    });

    // #endregion
})();