$(function () {
    hentAlleSightings();
});

function hentAlleSightings() {
    $.get("sighting/hentAlle", function (reports) {
        formaterSightings(reports);
    });
}

function formaterSightings(reports) {
    let ut = "<table class='table table-striped'>" +
        "<tr>" +
        "<th>City</th><th>Country</th><th>Duration</th><th>Date Posted</th><th>Date/Time</th><th>Comments</th>" +
        "<th></th><th></th>" +
        "</tr>";
    for (let report of reports) {
        ut += "<tr>" +
            "<td>" + report.city + "</td>" +
            "<td>" + report.country + "</td>" +
            "<td>" + report.duration + "</td>" +
            "<td>" + report.dateposted + "</td>" +
            "<td>" + report.datetime + "</td>" +
            "<td>" + report.comments + "</td>" +
            "<td> <a class='btn btn-primary' href='endre.html?id=" + report.id + "'>Endre</a></td>" +
            "<td> <button class='btn btn-danger' onclick='slettSighting(" + report.id + ")'>Slett</button></td>" +
            "</tr>";
    }
    ut += "</table>";
    $("#reports").html(ut);
}

function slettSighting(id) {
    const url = "Sighting/Slett?id=" + id;
    $.get(url, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}