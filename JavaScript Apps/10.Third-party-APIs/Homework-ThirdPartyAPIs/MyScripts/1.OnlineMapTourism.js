/// <reference path="../Scripts/jquery-2.0.2.js" />
$(document).ready(function () {
    var currentCapitalIndex = 0;
    var capitalsCoords = [{ capital: "London", x: "51.51", y: "-0.11" },
    { capital: "Paris", x: "48.86", y: "2.35" },
    { capital: "Madrid", x: "40.42", y: "-3.68" },
    { capital: "Praha", x: "50.08", y: "14.44" },
    { capital: "Moscow", x: "55.75", y: "37.62" }];
    var map;
    var x = parseFloat(capitalsCoords[0].x);
    var y = parseFloat(capitalsCoords[0].y);
    var z = 14;

    function initialize() {
        var mapOptions = {
            zoom: z,
            center: new google.maps.LatLng(x, y),
            mapTypeId: google.maps.MapTypeId.SATELLITE //ROADMAP
        };
        map = new google.maps.Map(document.getElementById('map-canvas'),
            mapOptions);
        $("#capitalNameContainer").text(capitalsCoords[0].capital);
        createMarker(capitalsCoords[0].capital);
    }

    $('#buttonHolderPrev').on('click', function () {
        currentCapitalIndex--;

        if (currentCapitalIndex < 0) {
            currentCapitalIndex = capitalsCoords.length - 1;
        }

        var currentCapital = capitalsCoords[currentCapitalIndex];
        
        console.log(capitalsCoords[currentCapitalIndex]);

        panToOtherCapital(currentCapital);
    });

    $('#buttonHolderNext').on('click', function () {
        currentCapitalIndex++;

        if (currentCapitalIndex > capitalsCoords.length - 1) {
            currentCapitalIndex = 0;
        }

        var currentCapital = capitalsCoords[currentCapitalIndex];
        console.log(capitalsCoords[currentCapitalIndex]);

        panToOtherCapital(currentCapital);
    });

    $('#capitalsList').on('change', function () {
        var selectedCapitalIndex = $('#capitalsList').val();
        currentCapitalIndex = selectedCapitalIndex;
        panToOtherCapital(capitalsCoords[selectedCapitalIndex]);
    });

    function createMarker(currentCapital) {
        var marker = new google.maps.Marker({
            position: new google.maps.LatLng(x, y),
            map: map,
            title: currentCapital
        });

        iconFile = 'http://maps.google.com/mapfiles/ms/icons/' + 'red' + '-dot.png';
        marker.setIcon(iconFile);

        var infowindow = new google.maps.InfoWindow({
            content: currentCapital
        });

        google.maps.event.addListener(marker, 'click', function () {
            infowindow.open(map, marker);
        });
    }

    function panToOtherCapital(capitalObj) {
        x = parseFloat(capitalObj.x);
        y = parseFloat(capitalObj.y);
        z = parseFloat(z);
        $("#capitalNameContainer").text(capitalObj.capital);
        createMarker(capitalObj.capital);
        console.log(x);
        console.log(y);

        if (isNaN(x) || isNaN(y) || isNaN(z)) {
            alert("Invalid parameters. Please, enter numbers!");
        }
        else {
            var pos = new google.maps.LatLng(x, y);
            map.panTo(pos);
            map.setZoom(z);
        }
    }

    google.maps.event.addDomListener(window, 'load', initialize());
});