$(document).ready(function () {
    $("body").on("click", "#detailsPartialView", detailsPartial);
})

function detailsPartial() {

    var id = $(this).data("id");

    $.post("/Student/DetailsPartial", { id: id })
    .success(function (resuit) {
        //alert("Details Partial View Showed");
        console.log(resuit);
        $(".resuiltStudent").html(resuit);
      
    })
}
