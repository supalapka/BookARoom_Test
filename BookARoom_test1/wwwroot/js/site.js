// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {

    $('#daysCountInput').on('input', function (e) {
        var price = +$("#priceTagSpan").text()
        var daysCount = +$('#daysCountInput').val()
        var total = +price*daysCount
        $('#priceOutput').text(total+"$");
    });

});