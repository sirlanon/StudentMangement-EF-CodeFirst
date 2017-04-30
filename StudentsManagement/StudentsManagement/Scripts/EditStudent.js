$(document).ready(function () {
    $("body").on("click", "#editStudent", editStudent);

})

function editStudent() {
    var student = {
        StudentID: $('#id').val(),
        StudentName: $('#name').val(),
        StudentAge: $('#age').val(),
        StudentGrade: $('#grade').val(),
        StudentYearOfGraduation: $('#year').val()
    }

    var jsonOfLog = JSON.stringify(student);

    $.post("/Student/Edit", student).success(function () {
        alert("OK");
    });

  
}