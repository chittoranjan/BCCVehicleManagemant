
//AJAX Colling for Department and Designation dropdown list........

$(document).ready(function() {
    $("#DepartmentDD").change(function () {
        var selectDepartmentId = $("#DepartmentDD").val();
        var jsonData = { departmentId: selectDepartmentId };
        $.ajax({
            url: "/EmployeeDesignation/GetByDepartment",
            data: jsonData,
            type: "POST",
            success: function(response) {
                $("#DesignationDD").empty();
                var options = "<option>Select Designation</option>";
                $.each(response, function(key, departmentObj) {
                    options += "<option value='" + departmentObj.Id + "'>" + departmentObj.Designation + "</option>";
                });
                $("#productDD").append(options);
            },
        error:function () {
            alert("Data not found!");
        }


    });
    });
});