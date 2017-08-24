var stats = (function () {

    events.on('endOfDetailsPesee', render);

    var $template, $endOfThirdStep, stats;
    var totalSujets = 0;
    var totalPoids = 0;
    
    init();

    function init() {
        $template = $("#step3Card-template").html();
        $endOfThirdStep = $("#endOfThirdStep");

        // bind events
        $endOfThirdStep.on("click", save);
    }

    function render(tableData) {
        
        $statsResults = $("#statsResults");
        $statsGraph = $("#statsGraph");
        var data = _getStats(tableData);
        $statsResults.html(Mustache.render($template, data));
        Highcharts.chart('statsGraph', data.graphData);

    }

    function _getStats(tableData) {
        var arrayPoids = [];
        var arraySujets = [];
        totalSujets = 0;
        totalPoids = 0;

        for (var i = 0; i < tableData.length; i++) {
            arrayPoids.push(parseInt(tableData[i][0]));
            arraySujets.push(parseInt(tableData[i][1]));
            totalSujets += parseInt(tableData[i][1]);
            totalPoids += parseInt(tableData[i][0]) * parseInt(tableData[i][1]);
        }
        var poidsMoyen = calculPoidsMoyen(totalPoids, totalSujets);
        var homogeneite = calculHomogeneite(parseFloat(poidsMoyen), totalSujets, arrayPoids, arraySujets);

        stats = {
            template: [
                {
                    statsName: "Nombre de sujets pésés",
                    value: totalSujets,
                    icon: "equalizer",
                    color: "#3F51B5"
                },
                {
                    statsName: "Poids moyen",
                    value: poidsMoyen + " g",
                    icon: "gps_fixed",
                    color: "#d24b4b" 

                },
                {
                    statsName: "Hommogeneité",
                    value: homogeneite + " %",
                    icon: "pie_chart",
                    color: "#ffb814"


                }
            ],
            data: {
                arrayPoids: arrayPoids,
                arraySujets: arraySujets,
                homogeneite: homogeneite,
                poidsMoyen: poidsMoyen,
                totalSujets: totalSujets,
                totalPoids: totalPoids
            },
            graphData: getGraph(arrayPoids, arraySujets)

        };

        //console.log("stats", stats);

        return stats;
    }

    function calculPoidsMoyen(totalPoids, totalSujets) {

        var poidsMoyen = totalPoids / totalSujets;
        return Math.round(poidsMoyen * 100) / 100;
    }

    function calculHomogeneite(poidsMoyen, totalSujets, arrayPoids, arraySujets) {

        var borneInferieure = poidsMoyen - poidsMoyen * 0.1;
        var borneSuperieure = poidsMoyen + poidsMoyen * 0.1;
        var nombreDeSujetsDansLaFourchette = 0;
        for (var i = 0; i < arrayPoids.length; i++) {
            if (borneInferieure <= parseFloat(arrayPoids[i]) && parseFloat(arrayPoids[i]) <= borneSuperieure) {
                nombreDeSujetsDansLaFourchette += parseInt(arraySujets[i]);
            }
        }

        var homogeneite = nombreDeSujetsDansLaFourchette / totalSujets * 100;
        return Math.round(homogeneite * 100) / 100;
    }

    function getGraph(arrayPoids, arraySujets) {
        var graphObject = {
            chart: {
                type: 'bar',
                //height: 200,
            },
            title: {
                text: 'Vue graphique de la pésée'
            },
            //subtitle: {
            //    text: 'Source: <a href="https://en.wikipedia.org/wiki/World_population">Wikipedia.org</a>'
            //},
            xAxis: {
                categories: arrayPoids,
                title: {
                    text: "Poids (g)"
                }
            },
            yAxis: {
                min: 0,
                title: {
                    text: 'Nombre de sujet',
                    align: 'high'
                },
                labels: {
                    overflow: 'justify'
                }
            },
            tooltip: {
                useHTML: true,
                formatter: function () {
                    return "Poids:" + this.key + " g" + "</br>Nombre de sujets :" + this.y + "";
                }
            },
            colors: ['red'],
            plotOptions: {
                bar: {
                    dataLabels: {
                        enabled: true
                    }
                }
            },

            credits: {
                enabled: false
            },
            series: [{
                name: "Nombre de sujets",
                data: arraySujets
            }]
        };

        return graphObject;

    }

    function save() {
        var info = infoPesee.data();
        var peseeData = {
            poidsData: stats.data.arrayPoids.join(";"),
            sujetsData: stats.data.arraySujets.join(";"),
            totalPoids: stats.data.totalPoids,
            poidsMoyen: stats.data.poidsMoyen,
            homogeneite: stats.data.homogeneite,
            nombreDeSujetsPeses: stats.data.totalSujets,
            idRepartitionBande: info.idRepartitionBande,
            idBande: info.idBande,
            datePesee: info.datePesee,
            ageDesSujetEnSemaine: info.semaine,
            idTypePesee: info.typePesee
        };
        console.log(peseeData);

        $.ajax({
            type: "POST",
            url: "api/Pesee/SavePesee",
            data: peseeData,
            success: function (response) {
            }
        });
    }

    return {
        init: init
    }
})();