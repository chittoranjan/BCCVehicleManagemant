
//AJAX Colling for Department and Designation dropdown list........

$(document).ready(function() {
    $("#departmentDD").change(function () {
        var selectDepartmentId = $("#departmentDD").val();
        var jsonData = { departmentId: selectDepartmentId };
        $.ajax({
            url: "/EmployeeDesignations/getbydepartment",
            data: jsonData,
            type: "POST",
            success: function(response) {
                $("#designationDD").empty();
                var options = "<option>Select Designation</option>";
                $.each(response, function(key, departmentObj) {
                    options += "<option value='" + departmentObj.Id + "'>" + departmentObj.Designation + "</option>";
                });
                $("#designationDD").append(options);
            },
            error:function (response) {
                alert("Data not found!");
        }

    });
    });
});