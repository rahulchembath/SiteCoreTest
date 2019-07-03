(function ($) {
    var pageNo = 1;
    var hasBlog = true;
    var inProgress = false;

    $(window).scroll(function () {
        var docHeight = $(document).height();
        var winScrolled = $(window).height() + $(window).scrollTop();
        if ((docHeight - winScrolled) < 1) {
            searchBlogs();
        }
    });
    function searchBlogs() {
        var query = $("#hdnQueryText").val();
        if (hasBlog && !inProgress) {
            inProgress = true;
            $("#divLoader").show();
            $.ajax({
                url: '/api/Sitecore/Search/SearchBlogs',
                data: { pageNo: pageNo, query: query},
                contentType: 'application/html; charset=utf-8',
                type: 'GET',
                dataType: 'html',
                success: (function (result) {
                    if ($.trim(result)) {
                        $('#blgSearchResults').append(result);
                        inProgress = false;
                        $("#divLoader").hide();
                        pageNo++;
                        applyEllipsis();
                    } else {
                        hasBlog = false;
                        inProgress = false;
                        $("#divLoader").hide();
                    }
                }),
                error: (function (xhr, status) {
                    hasBlog = false;
                    inProgress = false;
                    $("#divLoader").hide();
                })
            });
        }
    }
})(jQuery);