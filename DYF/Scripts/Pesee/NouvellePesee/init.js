$(document).ready(function () {

    // #region Init datepicker
    var picker = $('.datepicker').pickadate({
        selectMonths: true, // Creates a dropdown to control month
        selectYears: 15, // Creates a dropdown of 15 years to control year,
        today: 'Today',
        clear: 'Clear',
        close: 'Ok',
        closeOnSelect: false // Close upon selecting a date,
        , onSet: function (ele) { // trigger validation of field on date selected
            $("#" + $(this.$node).attr("id") + "").valid();
        }
    });
   
    //picker.start();
    // #endregion

    // #region Init of stepper
    $('.stepper').activateStepper({
        linearStepsNavigation: false, //allow navigation by clicking on the next and previous steps on linear steppers
        //autoFocusInput: true, //since 2.1.1, stepper can auto focus on first input of each step
        //autoFormCreation: true, //control the auto generation of a form around the stepper (in case you want to disable it)
        showFeedbackLoader: true //set if a loading screen will appear while feedbacks functions are running
    });
    // #endregion

    // #region Init of DataTable

    // Default value
    $.extend(true, $.fn.dataTable.defaults, {
        language: {
            processing: "Traitement en cours...",
            search: "Rechercher&nbsp;:",
            lengthMenu: "Afficher _MENU_ &eacute;l&eacute;ments",
            info: "Affichage de l'&eacute;lement _START_ &agrave; _END_ sur _TOTAL_ &eacute;l&eacute;ments",
            infoEmpty: "Affichage de l'&eacute;lement 0 &agrave; 0 sur 0 &eacute;l&eacute;ments",
            infoFiltered: "(filtr&eacute; de _MAX_ &eacute;l&eacute;ments au total)",
            infoPostFix: "",
            loadingRecords: "Chargement en cours...",
            zeroRecords: "Aucun &eacute;l&eacute;ment &agrave; afficher",
            emptyTable: "Aucune donnée disponible dans le tableau",
            paginate: {
                first: "Premier",
                previous: "Pr&eacute;c&eacute;dent",
                next: "Suivant",
                last: "Dernier"
            },
            aria: {
                sortAscending: ": activer pour trier la colonne par ordre croissant",
                sortDescending: ": activer pour trier la colonne par ordre décroissant"
            }
        }
    });

    detailsPesee.init();
    stats.init();
    infoPesee.init();

    // #endregion
    $('.tooltipped').tooltip({ delay: 50 });
});
