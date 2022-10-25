$(function(){
    hentAlleSightings();
});

function hentAlleSightings() {
    $.get("sighting/hentAlle", function (reports) {
        formaterSightings(reports);
    });
}

function formaterSightings(reports) {
    let ut = "<div class='container boxO'>";

    for (let report of reports) {
        ut += "<div class='row observation'>" +
            "<div class='col-3 dateF'>" +
            "<div>Published Date: " + report.dateposted + "</div>" +
            "<div>Date/Time: " + report.datetime + "</div>" +
            "<div>Duration: " + report.duration + "</div>" +
                "</div>" +
            "<div class='col-9 commentF'><div class='row'>" +
            "<div class='col-8 titleP'><h3>" +
                "<span class='fl'> " + report.city + "</span >, <span class='fl'>" + report.country + "</span>" +
            "</h3></div>" +
            "<div class='col-4'><div class='row'>" +
            "<a class='col-5 btnCrud' id='update1' href='endre.html?id=" + report.id + "'>Update</a>" +
            "<div class='col-1'></div>" +
            "<button class='col-5 btnCrud' onclick='slettSighting(" + report.id + ")'>Delete</button>" +
            "</div></div></div>" +
                "<div class='textF'><b>The observation:</b><br />" + report.comments + "</div>" +
            "</div></div>";
    }
    ut += "</div>";
    $("#reports").html(ut);
}

function slettSighting(id) {
    const url = "Sighting/Slett?id="+id;
    $.get(url, function (OK) {
        if (OK) {
            window.location.href = 'article.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}