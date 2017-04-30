$(document).ready(function () {


})

function regSubject(obj) {
    var confirm = {
        StudentID: obj.data("id")

    }


    var jsonOfLog = JSON.stringify(confirm);
    //obj.prop("disabled", true);
    $.post("/Student/RegisterSubject", confirm, function () {
    });

}