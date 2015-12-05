$(function () {

    // Get the registered courses on load
/*    $.get("/Course/List")
        .success(function (result) {
            // Load offerings into HTML
            $("#registeredCourses").html(result);
        });*/

    // When the course form is submitted
    $("#submitCourse").submit(function (e) {

        e.preventDefault();

        // If valid according to unobtrusive JS
        if ($(this).valid()) {

            // Properties to send to controller
            var properties = {
                Number: $("#courseNumber").val(),
                Name: $("#courseName").val(),
                WeeklyHours: $("#courseHours").val(),
                Description: $("#Description").val()
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

                    // Clear form fields
                    $("#courseNumber").val("");
                    $("#courseName").val("");
                    $("#courseHours").val("");
                    $("#Description").val("");

                    // Reload the registered courses
                    $(".mvc-grid").mvcgrid({
                        reload: true
                    });
                });
        }
    });
});

