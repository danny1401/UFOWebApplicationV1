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
            "<div class='col-9 commentF'>" +
                "<div class='titleF'><h3><span class='fl'>" + report.city + "</span>, " + report.country + "</h3></div>" +
                "<div class='textF'><b>Comments about the observation:</b><br />" + report.comments + "</div>" +
            "</div></div>";
            /*
            "<td> <a class='btn btn-primary' href='endre.html?id="+report.id+"'>Endre</a></td>"+
            "<td> <button class='btn btn-danger' onclick='slettSighting("+report.id+")'>Slett</button></td>"+
            */
    }
    ut += "</div>";
    $("#reports").html(ut);
}

function slettSighting(id) {
    const url = "Sighting/Slett?id="+id;
    $.get(url, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}