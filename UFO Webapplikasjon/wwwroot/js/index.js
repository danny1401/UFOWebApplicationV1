$(function(){
    countSightings();
});


function countSightings() {
    let count = 0;

    $.get("sighting/hentAlle", function (reports) {
        for (let report of reports) {
            count++;
        }
        let ut = count;
        $("#count").html(ut);
    });
    let totalCount = $("#count").val();
    console.log(totalCount);

    function generateRandom(maxLimit = count) {
        let rand = Math.random() * maxLimit;
        rand = Math.floor(rand);
        return rand;
    }

    let randomId = 0;
    generateRandom(randomId);
    console.log(randomId);

    /*
    const url = "Sighting/HentEn?" + randomId;
    $.get(url, function (report) {
        $("#id").html(report.id); // må ha med id inn skjemaet, hidden i html
        $("#city").html(report.city);
        $("#country").html(report.country);
        $("#duration").html(report.duration);
        $("#dateposted").html(report.dateposted);
        $("#datetime").html(report.datetime);
        $("#comments").html(report.comments);
    });*/
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