(function ($) {
    $('#searchModal').on('hidden.bs.modal', function (e) {
        $('#srctext').val("");
    })
    $('#btnSubmit').click(function (e) {
        if ($('#srctext').val().trim() == "") {
            e.preventDefault();
        }
    });
})(jQuery);