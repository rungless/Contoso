

var courseModule = (function () {
    return {
        getCourses: function (callback) {
            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://conweb.azurewebsites.net/api/courses",
                success: function (data) {
                    callback(data);
                }
            });
        }

    };
}());