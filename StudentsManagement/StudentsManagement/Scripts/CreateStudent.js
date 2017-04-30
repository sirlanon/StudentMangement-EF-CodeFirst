$(document).ready(function () {
    $("body").on("click", "#saveStudent", saveStudent);

})

function saveStudent() {
    var student = {
        StudentName: $('#name').val(),
        StudentAge: $('#age').val(),
        StudentGrade: $('#grade').val(),
        StudentYearOfGraduation: $('#year').val()
    }

    var jsonOfLog = JSON.stringify(student);

    $.post("/Student/Create", student).success(function () {
        alert("OK");
    });

    //$.ajax({
    //    type: 'POST',
    //    dataType: 'text',
    //    url: "/Student/Create",
    //    data: student,
    //    success: function (returnPayload) {
    //        // console && console.log("request succeeded");
    //    },
    //    error: function (xhr, ajaxOptions, thrownError) {
    //        //   console && console.log("request failed");
    //    },

    //    // processData: false,
    //    // async: false
    //});
}