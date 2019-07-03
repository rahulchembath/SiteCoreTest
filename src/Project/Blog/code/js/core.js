$(document).ready(function () {

	// Submenu
	// $("nav ul .main-link > a").click(function (e) {
	// 	if ($(this).parent().children('.submenu').hasClass('show')) {
	// 		$("nav ul .submenu").removeClass("show");
	// 		$(this).parent().removeClass('active');
	// 	} else {
	// 		$("nav ul .submenu").removeClass("show");
	// 		$("nav ul .main-link").removeClass('active');
	// 		if ($(this).parent().children(".submenu").length) {
	// 			$(this).parent().addClass('active');
	// 			$(this).parent().children(".submenu").addClass('show');
	// 		}
	// 	}
	// 	e.stopPropagation();
	// });
	// $("body").click(function () {
	// 	$("nav ul .submenu").removeClass("show");
	// 	$("nav ul .main-link").removeClass('active');
	// });
	$('.has-sub').on('click', function () {
		$(this).toggleClass('open');
		$(this).parent().find('.submenu').toggleClass('open');
	});
	$('.menu-mobile').on('click', function () {
		// $('nav').toggleClass('slide');
		// $('.overlay').toggleClass('fade');
		$('nav').addClass('slide');
		$('.overlay').addClass('fade');
	});
	$('.closeNav').on('click', function () {
		$('nav').removeClass('slide');
		$('.overlay').removeClass('fade');
	});
	/*$('.search-mobile').on('click', function(){
		$('.secondary_logo').toggleClass('visible');
	});
	$('.regionPais').on('click', function(){
		$('.listaPaises').toggleClass('show');
	});*/



	/** Scroll Back to Top Script **/
	$(window).scroll(function () {
		if ($(this).scrollTop() > 100) {
			$('#scroll').fadeIn();
			$('#searchBottom').removeClass("down");
		} else {
			$('#scroll').fadeOut();
			$('#searchBottom').addClass("down");
		}
	});
	$('#scroll').click(function () {
		$("html, body").animate({
			scrollTop: 0
		}, 600);
		return false;
	});
	/** Scroll Back to Top Script **/	 

});
