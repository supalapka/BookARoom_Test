// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {

    $('#daysCountInput').on('input', function (e) {
        var price = +$("#priceTagSpan").text()
        var daysCount = +$('#daysCountInput').val()
        if (daysCount < 0) {
            alert("days count cant be less then 0");
            $('#daysCountInput').val(0);
            $('#price').val(0);
            return;
        }
        var total = +price * daysCount
        $('#price').val(+total);
        $('#priceOutput').text(total+"$");
    });

});