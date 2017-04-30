$(document).ready(function () {
    $("body").on("click", "#subjectPartialView", subjectPartial);
})

function subjectPartial() {

    var id = $(this).data("id");

    $.post("/Student/SubjectDetailPartial", { id: id })
    .success(function (details) {
        //alert("Details Partial View Showed");
        console.log(details);
        $(".detailSubject").html(details);
    })
}