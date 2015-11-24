﻿$(function () {

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
    });

    // Student registration page on dropdown change
    $("#SelectedOffering").change(function (e) {

        // If valid according to unobtrusive JS
        if ($(this).valid()) {

            // Properties to send to controller
            var $opt = $(this.options[this.selectedIndex]);

            var properties = {
                SelectedOffering: $(this).val(),
                SelectedYear: $opt.attr("data-year"),
                SelectedSemester: $opt.attr("data-semester"),
                Number: $("#studentNumber").val(),
                Name: $("#studentName").val(),
                Type: $("input[type='radio'][name='Type']:checked")
            };

            // If valid according to unobtrusive JS
            if ($(this).valid()) {
                $.ajax({
                    type: $(this).action,
                    url: "/Student/List",
                    data: { courseId: properties.SelectedOffering, semester: properties.SelectedSemester, year: properties.SelectedYear },
                    dataType: "HTML",
                    cache: false,
                    success: function (data) {
                        $("#studentsInOffering").html(data);
                    }
                });
            }
        }
    });

    // Student registration page on submit
    $("#submitStudent").submit(function (e) {

        e.preventDefault();

        // If valid according to unobtrusive JS
        if ($(this).valid()) {

            var properties = {
                SelectedOffering: $("#SelectedOffering").val(),
                SelectedYear: $("#SelectedOffering option:selected").attr("data-year"),
                SelectedSemester: $("#SelectedOffering option:selected").attr("data-semester"),
                Number: $("#studentNumber").val(),
                Name: $("#studentName").val(),
                Type: $("input[name=Type]:checked").val()
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

                    // Get the students by offering
                    $.get("/Student/List", { courseId: properties.SelectedOffering, semester: properties.SelectedSemester, year: properties.SelectedYear })
                        .success(function (result) {
                            // Load offerings into HTML
                            $("#studentsInOffering").html(result);
                        });
                });
        }
    });
});

