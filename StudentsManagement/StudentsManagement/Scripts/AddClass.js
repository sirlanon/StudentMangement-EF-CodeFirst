$(document).ready(function () {
    $("body").on("click", "#saveClass", saveClass);

})

function saveClass() {
    var stdclass = {
        ClassID: $('#id').val(),
        ClassName: $('#name').val(),
        ClassTeacherName: $('#teacher').val(),
        ClassNumberOfStudent: $('#number').val()
    }

    var jsonOfLog = JSON.stringify(stdclass);

    $.post("/Student/AddClass", stdclass).success(function () {
        alert("OK");
    });
}