//jQuery scripts - mpxx240

$(function () {

    //datapicker 
    $('.date-picker').datepicker();

    //drag and drop
    $(".ui-widget-content").draggable({ revert: "invalid" });
    $(".ui-widget-header").droppable();

    //do not show toggler on page load
    $(document).ready(function () {
        $(".toggler").toggle(false);
    });

    //show toggle on click
    $(".buttonTask").click(function () {
        $(this).siblings(".toggler").toggle("blind");
    });
});
