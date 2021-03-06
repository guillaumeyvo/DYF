﻿$(document).ready(function () {

    // #region Default plugin values
    
    // Extend the default picker options for all instances.
    $.extend($.fn.pickadate.defaults, {
        monthsFull: ['Janvier', 'Février', 'Mars', 'Avril', 'Mai', 'Juin', 'Juillet', 'Août', 'Septembre', 'Octobre', 'Novembre', 'Décembre'],
        monthsShort: ['Jan', 'Fev', 'Mar', 'Avr', 'Mai', 'Juin', 'Juil', 'Aou', 'Sep', 'Oct', 'Nov', 'Dec'],
        weekdaysFull: ['Dimanche', 'Lundi', 'Mardi', 'Mercredi', 'Jeudi', 'Vendredi', 'Samedi'],
        weekdaysShort: ['Dim', 'Lun', 'Mar', 'Mer', 'Jeu', 'Ven', 'Sam'],
        weekdaysLetter: ['D', 'L', 'M', 'Me', 'J', 'V', 'S'],
        today: 'Aujourd\'hui',
        clear: 'Effacer',
        firstDay: 1,
        format: 'dd mmmm yyyy',
        formatSubmit: 'yyyy/mm/dd'
    })

    
// #endregion
    
    // #region Init datepicker
    var picker = $('#datePesee').pickadate({
        selectMonths: true, // Creates a dropdown to control month
        selectYears: 15, // Creates a dropdown of 15 years to control year,
        closeOnSelect: false, // Close upon selecting a date,
        hiddenName: true
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

    

    // #endregion
    
});
