$(function () {
    // hent kunden med kunde-id fra url og vis denne i skjemaet
    const id = window.location.search.substring(1);

    const url = "Sighting/HentEn?" + id;
    $.get(url, function (report) {
        $("#id").val(report.id); // må ha med id inn skjemaet, hidden i html
        $("#firstname").val(report.firstname);
        $("#lastname").val(report.lastname);
        $("#phoneNr").val(report.phoneNr);
        $("#city").val(report.city);
        $("#country").val(report.country);
        $("#duration").val(report.duration); // Hvordan skal duration vises når vi henter den
        $("#dateposted").val(report.dateposted);
        $("#datetime").val(report.datetime);
        $("#comments").val(report.comments);
    });
});

function endreSighting() {
    // Henter og kombinerer Streng og Select-verdi
    let durationNumber = $("#durationNumber").val();
    let durationUnit = $("#durationUnit").val();
    let duration = durationNumber + durationUnit;

    const report = {
        id: $("#id").val(), // må ha med denne som ikke har blitt endret for å vite hvilken kunde som skal endres
        city: $("#city").val(),
        country: $("#country").val(),
        duration: duration,
        dateposted: $("#dateposted").val(), // skal det være mulig å endre på utgivelsesdatoen (admin)
        datetime: $("#datetime").val(),
        comments: $("#comments").val(),
        firstname: $("#firstname").val(),
        lastname: $("#lastname").val(),
        phoneNr: $("#phoneNr").val()
    };
    $.post("Sighting/Endre", report, function (OK) {
        if (OK) {
            window.location.href = 'index.html';
        }
        else {
            $("#feil").html("Feil i db - prøv igjen senere");
        }
    });
}