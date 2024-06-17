let map;

function initMap() {
    var myCenter = { lat: 40.7065983, lng: -74.0107104 };
    var mapProp = {
        center: myCenter,
        scrollwheel: false,
        zoom: 11,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

    var marker = new google.maps.Marker({
        position: myCenter,
        map: map,
    });

    var styles = [
        {
            "stylers": [
                {
                    "hue": "#baf4c4"
                },
                {
                    "saturation": 10
                }
            ]
        },
        {
            "featureType": "water",
            "stylers": [
                {
                    "color": "#effefd"
                }
            ]
        },
        {
            "featureType": "all",
            "elementType": "labels",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "administrative",
            "elementType": "labels",
            "stylers": [
                {
                    "visibility": "on"
                }
            ]
        },
        {
            "featureType": "road",
            "elementType": "all",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        },
        {
            "featureType": "transit",
            "elementType": "all",
            "stylers": [
                {
                    "visibility": "off"
                }
            ]
        }
    ];

    map.setOptions({ styles: styles });
}

window.addEventListener('load', initMap);