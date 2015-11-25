
    // This event triggers on page load

    document.addEventListener("DOMContentLoaded", function () {
        loadCourses();
    });

    function loadCourses() {

        courseModule.getCourses(setupCourseTable);

    }

    // This is the callback for when the data comes back in the studentmodule
    function setupCourseTable(courseList) {

        // We need a reference to the div/table that we are going to chuck our data into
        var coursesTable = document.getElementById("courseList");

        console.log(courseList);

        for (i = 0; i < courseList.length; i++) {
            // create row
            var row = document.createElement('tr');

            // add the columns in the row (td /data cells)
            var courseNameCol = document.createElement('td');
            courseNameCol.innerHTML = courseList[i].Title;
            row.appendChild(courseNameCol);

            var pointsCol = document.createElement('td');
            pointsCol.innerHTML = courseList[i].Points;
            row.appendChild(pointsCol);

            var assignmentsCol = document.createElement('td');
            assignmentsCol.innerHTML = courseList[i].Assignments;
            row.appendChild(assignmentsCol);

            var testsCol = document.createElement('td');
            testsCol.innerHTML = courseList[i].Tests;
            row.appendChild(testsCol);

            //Append the row to the end of the table
            coursesTable.appendChild(row);
        }
    }
