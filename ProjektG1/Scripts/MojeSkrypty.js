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
    
    $(".dropdown-toggle").click(function () {
        $(".dropdown-menu").toggle();
    });
    
   $(".findParentsId").click(function () {
        var mDiv = $(this).parents("div").slice(1, 2).attr("title");
        $(function () {
            sessionStorage.GroupId = mDiv;
        });
    });

    $(document).ready(function () {
        $("#TaskGroupIdRetriever").attr("value", sessionStorage.GroupId);
    });

    $(function () {
        $("[class='button-task-text'][title='True']").css("text-decoration", "line-through");
    });

    $("button[name='ButtonZakoncz']").click(function () {
        //if ($(this).children("i").hasClass("fa-circle-o")) {
            $(this).children("i").attr("class","fa fa-calculator");
        //} else {
        //    $(this).children("i").attr("class", "fa fa-circle-o");
        //}
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


