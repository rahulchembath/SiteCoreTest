(function ($) {
    var pageNo = 1;
    var hasBlog = true;
    var inProgress = false;
   
    $(window).scroll(function () {
        var docHeight = $(document).height();
        var winScrolled = $(window).height() + $(window).scrollTop();
        if ((docHeight - winScrolled) < 1) {
            getBlogs();
        }
    });
    function getBlogs() {
        var featureArticleId = $("#hdnFeaturedArticleId").val();
        var category = $("#hdnCategory").val();
        if (hasBlog && !inProgress) {
            inProgress = true;
            $("#divLoader").show();
            $.ajax({
                url: '/api/Sitecore/Blog/GetBlogs',
                data: { pageNo: pageNo, featureArticleId: featureArticleId, category:category },
                contentType: 'application/html; charset=utf-8',
                type: 'GET',
                dataType: 'html',
                success: (function (result) {
                    if ($.trim(result)) {
                        $('#blgList').append(result);
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