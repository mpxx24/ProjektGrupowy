$(function () {

    //datapicker 
    $(".date-picker").datepicker();

    //drag and drop
    $(".task").draggable({ revert: "invalid" });
    $(".task-group").droppable();

    //do not show toggler on page load
    $(document).ready(function () {
        $(".task-info").toggle(false);
    });

    //show toggle on click
    $(".button-task-text").click(function () {
        $(this).siblings(".task-info").toggle("blind");
    });

    //get id attribute of parent div
    $(".findParentsId").click(function () {
        var mDiv = $(this).parents("div").slice(1,2).attr("title");
        $(function () {
            sessionStorage.GroupId = mDiv;
        });
    });

    $(document).ready(function () {
        $("#TaskGroupIdRetriever").attr("value", sessionStorage.GroupId);
    });

});


