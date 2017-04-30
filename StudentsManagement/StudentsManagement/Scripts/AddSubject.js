$(document).ready(function () {
    $("body").on("click", "#addSubject", addSubject);

})

function addSubject() {
    var subject = {
        SubjectName: $('#name').val(),
        SubjectNumOfStudent: $('#number').val()
        
    }

    var jsonOfLog = JSON.stringify(subject);

    $.post("/Student/AddSubject", subject).success(function () {
        alert("OK");
    });

}