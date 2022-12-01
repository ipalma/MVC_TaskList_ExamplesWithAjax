function tachar(id) {
    var taskId = id;
    var link = markTasksUrl;

    link = link.replace("taskId", taskId);

    $.ajax({
        url: link, success: function (result) {
            location.reload();
        }
    });
}

function createTask() {
    var link = addTasksUrl;

    var data = $('#txtNewTask').val();

    if (data === undefined || data === "")
        return;
    link = link.replace("description", data);

    $.ajax({
        url: link, success: function (result) {
            location.reload();
        }
    });

}