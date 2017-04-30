$(document).ready(function () {


})

function registerthisSubject(obj) {
    var confirm = {
        StudentID: $('#stdid').val(),
        SubjectID: obj.data("id")

    }
    var jsonOfLog = JSON.stringify(confirm);

    obj.prop("disabled", true);
    
    $.post("/Student/ConfirmRegister", confirm, function (msg) {
        var value = msg.data;
        alert(value);
        obj.data("check").val() = "true";
        
    });

}