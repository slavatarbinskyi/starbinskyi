
function readFile(input) {

	if (input.files && input.files[0]) {
		if (input.files[0].size > 2500000) {
			alert('big size');
			return;
		}
		var reader = new FileReader();

		reader.onload = function (e) {


			var boundary = $('.cr-boundary');
			if (boundary != null) {
				boundary.remove();
				var slider = $('.cr-slider-wrap');
				slider.remove();
			}
			crop(e.target.result);
		}
		reader.readAsDataURL(input.files[0]);
	}
}

var crop = function (src) {

	var c = new Croppie(document.getElementById('crop_image'), {
		viewport: { width: 200, height: 200, type: 'square' },
		boundary: { width: 300, height: 300 },
		showZoom: false
	});
	c.bind(src).then(function () {
	});
	$("#form").on('submit', function () {
		var pos = c.get();
		console.log(c.get());
		$("#points").val(pos.points);
		$("#zoom").val(pos.zoom);
		c.result("base64", "viewport").then(function (resp) {
			$("#basestring").val(resp);
		});
	});

}