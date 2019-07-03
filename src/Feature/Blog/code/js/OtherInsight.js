(function ($) {
    $(document).ready(function () {
        sliderFunction();
        applyEllipsis();
    });

function sliderFunction() {
    try {
        $('.owl-carousel').owlCarousel({
            loop: true,
            margin: 10,
            responsiveClass: true,
            responsive: {
                0: {
                    items: 1,
                    nav: true
                },
                768: {
                    items: 2,
                    nav: true
                },
                1000: {
                    items: 3,
                    nav: true,
                    loop: true
                    // margin: 20
                }
            }
        })
    }
    catch (Exception) {
    }

    }
})(jQuery);