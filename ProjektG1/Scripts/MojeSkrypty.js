$(function () {

    $(".date-picker").datepicker({minDate: 0});

    $(".task").draggable({ revert: "invalid" });
    $(".task-group").droppable();

    $(document).ready(function () {
        $(".task-info").toggle(false);
    });

    $(".button-task-text").click(function () {
        $(this).siblings(".task-info").toggle("blind");
    });
    
    $(".findParentsId").click(function () {
        var mDiv = $(this).parents("div").slice(1,2).attr("title");
        $(function () {
            sessionStorage.GroupId = mDiv;
        });
    });

    $(document).ready(function () {
        $("#TaskGroupIdRetriever").attr("value", sessionStorage.GroupId);
    });

    $(function() {
        $("[class='button-task-text'][title='True']").css("text-decoration", "line-through");
    });

    $("#AddTaskButton").click(function() {
        $("#dodajTask").show();
    });

    $("#CreateTaskButton").click(function () {
        $("#dodajTask").hide();
    });
});


