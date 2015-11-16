$(document).ready(function () {
    $("#SelectedCourseId").change(function () {
        var $opt = $(this.options[this.selectedIndex]),
            id = $(this).val(),
            year = $opt.attr("data-year"),
            semester = $opt.attr("data-semester");

        $.ajax({
            type: "GET",
            url: "/Student/GetStudentsInOffering",
            data: { offeringId: id, year: year, semester: semester },
            dataType: "HTML",
            cache: false,
            success: function (result) {
                $("#studentsInOffering").html(result);
            },
            error: function (xhr, status, error) {
                var err = eval("(" + xhr.responseText + ")");
                alert(err.Message);
            }
        });
    });
});