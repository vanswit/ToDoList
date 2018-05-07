function Delete(ID) {

    var ans = confirm("Are you sure you want to delete this Record?");

    if (ans) {

        $.ajax({

            url: "/ToDo/Delete/" + ID,

            type: "POST",

            contentType: "application/json;charset=UTF-8",

            dataType: "json",

            error: function (errormessage) {

                alert(errormessage.responseText);

            }

        });

    }

}