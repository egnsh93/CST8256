$(function () {

    // Course offering page on dropdown change
    $("#SelectedCourseId").change(function (e) {
        // If valid according to unobtrusive JS
        if ($(this).valid()) {
            $.ajax({
                type: $(this).action,
                url: "/CourseOffering/List",
                data: { courseId: $(this).val() },
                dataType: "json",
                cache: false,
                success: function (data) {
                    $("#courseOfferings").html(data.partial);
                    $("#Description").val(data.description);
                }
            });
        }
    });

    // Course offering page on submit
    $("#submitOffering").submit(function (e) {

        e.preventDefault();

        // If valid according to unobtrusive JS
        if ($(this).valid()) {

            // Properties to send to controller
            var properties = {
                SelectedCourseId: $("#SelectedCourseId").val(),
                Semester: $("#Semester").val(),
                SelectedYear: $("#SelectedYear").val()
            };

            // Request to post the selected offering
            $.post($(this).url, properties, function (data) {

                // Determine which alert type to display
                if (data.error === true) {
                    $("#resultNotification").removeClass("alert-success");
                    $("#resultNotification").addClass("alert-danger");
                } else {
                    $("#resultNotification").removeClass("alert-danger");
                    $("#resultNotification").addClass("alert-success");
                }

            })
                .success(function (data) {

                    $("#resultNotification").show().text(data.message).delay(4000);
                    $("#resultNotification").fadeOut("slow");

                    // Reset Semester and Year dropdowns to default value
                    $("#Semester option:eq(0)").attr("selected", "selected");
                    $("#SelectedYear option:eq(0)").attr("selected", "selected");

                    // Get the course offerings with a specific ID
                    $.get("/CourseOffering/List", { courseId: properties.SelectedCourseId })
                        .success(function (result) {
                            // Load offerings into HTML
                            $("#courseOfferings").html(result.partial);
                        });
                });
        }
    });7
});

