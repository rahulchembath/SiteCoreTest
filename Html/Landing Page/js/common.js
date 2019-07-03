new WOW().init();
$( document ).ready(function() {
	applyEllipsis();
});
 function applyEllipsis()
 {
  	$('.two-lines').ellipsis({ lines: 2 });
	$('.searh-results li p').ellipsis({ lines: 1 });
	$('.three-lines').ellipsis({ lines: 3 });
	$('.box--responsive').ellipsis({ responsive: true });
}