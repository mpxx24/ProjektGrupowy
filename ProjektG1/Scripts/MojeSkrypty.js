$(function () {

    $(".date-picker").datepicker({ minDate: 0 });

    $(".task").draggable({ revert: "invalid" });
    $(".task-group").droppable();

    $(document).ready(function () {
        $(".task-info").toggle(false);
    });

    $(".button-task-text").click(function () {
        $(this).siblings(".task-info").toggle("blind");
    });

    $(".dropdown-toggle").click(function (e) {
        $(".dropdown-menu").toggle();
        e.stopPropagation();
    });

    $("html").click(function () {
        $(".dropdown-menu").hide();
    });

    $(".findParentsId").click(function () {
        var mDiv = $(this).parents("div").slice(1, 2).attr("title");
            sessionStorage.GroupId = mDiv;

        });

    $(document).ready(function () {
        $("#TaskGroupIdRetriever").attr("value", sessionStorage.GroupId);
    });

    $("[class='button-task-text'][title='True']").css("text-decoration", "line-through");

    $(document).ready(function () {
        var mojI = $("i[title='zakoncz'][id='True']");
        mojI.removeClass("fa-square-o").addClass("fa-check-square-o");
    });

    $("#btnAddNewFriend").click(function ()
    {
        $("#newFriendButtonRow").hide();
        $("#addFriendEditor").show();

        //if ($('#addFriendEditor').is(':visible')) {
        //    if ($(this).attr("id") !== "addFriendEditor")
        //    {
        //        alert("poza");
        //    }
        //    alert("jestem widoczny");
        //}
    }
    );
    $("#addFriendSubmit").click(function () {
        $("#newFriendButtonRow").show();
        $("#addFriendEditor").hide();
    });

   

//$(".findParentsId").click(function () {
    //    $("#dodajTask").show();
    //});

    //$("#CreateTaskButton").click(function () {
    //    $("#dodajTask").hide();
    //});

    //$(function () {
    //    $(".task").mousedown(function () {
    //        $(".task-background").css("background-color", "grey").css("border", "1px dashed rgba(0,0,0,.2)");
    //    });
    //    $(".task").mouseup(function () {
    //        $(".task-background").css("background-color", "white").css("border", "none");
    //    });

    //});
});


