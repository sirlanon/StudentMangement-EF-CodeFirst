$(document).ready(function () {


})

function registerthisCancel(obj) {
    var confirm = {
        StudentID: $('#stdid').val(),
        SubjectID: obj.data("id")

    }


    var jsonOfLog = JSON.stringify(confirm);
    obj.prop("disabled", true);
    $.post("/Student/CancelReg", confirm, function () {
    });

}