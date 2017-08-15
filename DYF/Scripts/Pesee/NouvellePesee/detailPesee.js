var detailsPesee = (function () {
    var arrayPoids = [];
    var $dataTable, $dataTableBody, $addData, $nombreDeSujet, $poids, $datatableWrapper, $formAddDataPesee;

    function init() {
        $dataTable = $('#tablePeseeDetails').DataTable({
            "dom": 'rtip', // hides search and number of rows controls of datatable
            "columnDefs": [
                { "orderable": false, "targets": 2 }
            ]
        });

        // cache dom
        $datatableWrapper = $('#tablePeseeDetails').parent();
        $formAddDataPesee = $("#formAddDataPesee");
        $addData = $("#addData");
        $nombreDeSujet = $("#nombreDeSujet");
        $poids = $("#poids");
        $dataTableBody = $('#tablePeseeDetails tbody');

        // hiding datatable on init
        //$datatableWrapper.hide();


        // binding events
        $dataTableBody.on("click", ".deleteTableRow", removeTableData);
        $addData.on("click", addTableData);
    }

    function addTableData() {
        //console.log("addTableData");

        if ($formAddDataPesee.valid()) {
            if (!$datatableWrapper.is(":visible")) {
                $datatableWrapper.show();

                if ($("#step2-error").parent().is(":visible")) {
                    $("#step2-error").parent().hide();
                }
            }

            $dataTable.row.add([
                $poids.val(),
                $nombreDeSujet.val(),
                '<i class="material-icons deleteTableRow">delete</i>'
            ]).draw();

            arrayPoids.push(parseInt($poids.val()));

            $poids.val("");
            $nombreDeSujet.val("");
        }   
        
    }


    function removeTableData(e) {
        $dataTable.row($(e.target).closest("tr")).remove().draw();
        var poidsRemoved = $(e.target).closest("tr").children(":first").html();
        // #region Reset the form et validation error if any
        var validator = $("#formAddDataPesee").validate();
        validator.resetForm();
        $poids.val("");
        $nombreDeSujet.val("");
        // #endregion
        
        arrayPoids.splice(arrayPoids.indexOf(poidsRemoved), 1);
        if (arrayPoids.length == 0) {
            $datatableWrapper.hide();
        }
        
    }

    function getTableData() {
        var intialTableOrder = $dataTable.order();
        $dataTable.order([0, 'desc']).draw();
        var tableDataOrderInAscendingofPoids = $dataTable.rows().data();
        $dataTable.order(intialTableOrder[0][0], intialTableOrder[0][1]).draw();
        return tableDataOrderInAscendingofPoids;
    }

    return {
        //addTableData: addTableData
        //, removeTableData: removeTableData
        getTableData: getTableData
        //, clearTableData: clearTableData
        , init: init
        , arrayPoids: arrayPoids,
        datatable: $dataTable

    }
})();