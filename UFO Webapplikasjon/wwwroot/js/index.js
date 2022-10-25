$(function(){
    latestSightings();
});

function latestSightings() {
    $.get("sighting/hentAlle", function (reports) {
        countTotal(reports);
    });
}

function countTotal(reports) {
    // Telleren
    let count = 0;

    // Looper gjennom alle kolonnene i tabellen
    for (let report of reports) {
        count++;
    }

    // Summen av alle kolonnene
    let ut = count;
    $("#count").html(ut);

    // De siste posisjonene
    latestPosition = count;
    secondLatestPosition = count - 1;

    console.log(latestPosition);
    console.log(secondLatestPosition);

    // Henter de siste observasjonene
    const url1 = "Sighting/HentEn?id=" + latestPosition;
    $.get(url1, function (report1) {
        $("#id1").html(report1.id);
        $("#city1").html(report1.city);
        $("#country1").html(report1.country);
        $("#duration1").html(report1.duration);
        $("#dateposted1").html(report1.dateposted);
        $("#datetime1").html(report1.datetime);
        $("#comments1").html(report1.comments);
    });
    const url2 = "Sighting/HentEn?id=" + secondLatestPosition;
    $.get(url2, function (report2) {
        $("#id2").html(report2.id);
        $("#city2").html(report2.city);
        $("#country2").html(report2.country);
        $("#duration2").html(report2.duration);
        $("#dateposted2").html(report2.dateposted);
        $("#datetime2").html(report2.datetime);
        $("#comments2").html(report2.comments);
    });
    $("#update2").attr('href', "./endre.html?id=" + secondLatestPosition);
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