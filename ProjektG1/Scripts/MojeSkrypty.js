﻿$(function () {

    //datapicker 
    $(".date-picker").datepicker();

    //drag and drop
    $(".task").draggable({ revert: "invalid" });
    $(".task-group").droppable();

    //do not show toggler on page load
    $(document).ready(function () {
        $(".toggler").toggle(false);
    });

    //show toggle on click
    $(".buttonTask").click(function () {
        $(this).siblings(".toggler").toggle("blind");
    });

    //get id attribute of parent div
    $(".findParentsId").click(function () {
        //var mDiv = $(this).closest("div").attr("title"); //closest
        var mDiv = $(this).parents("div").slice(1,2).attr("title"); //2nd closest
        alert(mDiv);
        $(function () {
            sessionStorage.GroupId = mDiv;
        });
    });

    $(document).ready(function () {
        $("#TaskGroupIdRetriever").attr("value", sessionStorage.GroupId);
    });

});


