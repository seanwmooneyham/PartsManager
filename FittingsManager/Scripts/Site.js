
// Allows entire table row to become a link.
$(document).ready(function ($) {
    $(".link-table-row").click(function () {
        window.location = $(this).data("href");
    });
});

