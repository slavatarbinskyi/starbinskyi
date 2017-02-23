var markSelected = function (span) {
	var list = span.closest("li");
	if (list.classList.contains('selected')) {
		list.classList.remove('selected');
		span.style.color = "black";
		return;
	}
	list.classList.add("selected");
	span.style.color = "green";
};

var GetSelectedList = function () {
	var result = [];
	$('.note').each(function (index, element) {
		if (element.classList.contains('selected')) {
			result.push(element);
		}
	});
	return result;

}




var map;
$(document).ready(function () {

	map = new GMaps({
		el: '#map',
		lat: 48.29106893815631,
		lng: 25.926307439804077,
		click: function (e) {
			var list = GetSelectedList();
			var ids = [];
			var listNames = [];
			list.forEach(function (item) {
				ids.push(item.children[2].value);
				listNames.push(item.children[1].innerText);
			});
			if (list.length != 0) {
				map.addMarker({
					lat: e.latLng.lat(),
					lng: e.latLng.lng(),
					infoWindow: {
						content: '<p>' + listNames.toString() + '</p>'
						}
				});
				listNames = [];
				list.forEach(function (item) {
					item.classList.remove("selected");
					$(".glyphicon-globe").css("color", "black");
				});
				var jsonData = JSON.stringify({
					'IdsList': ids,
					'Lat': e.latLng.lat(),
					'Lon': e.latLng.lng()
				});
				$.ajax({
					type: "PUT",
					beforeSend: function (xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
					url: appContext.buildUrl("/api/ToDoList/AttachLocation"),
					contentType: "application/json",
					data: jsonData,
					dataType: "JSON",
					success: function () {
					},
					error: function () {
					}
				});
			}


		}
	});
	loadMarkers();
});

//Set center on click of sticker
var SetCenter = function (list) {
	var listid = list.children[2].value;
	$.ajax({
		type: "GET",
		beforeSend: function (xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
		url: appContext.buildUrl("/api/ToDoList/GetPointById/" + listid),
		contentType: "application/json",
		dataType: "JSON",
		success: function (data) {
			if ((data.Lon == null || data.Lon == 0) && (data.Lat == null || data.Lat == 0)) {
				return;
			}
			map.setCenter(data.Lat, data.Lon);
			map.setZoom(9);
		},
		error: function () {
		}
	});
}

//load coordinates for markers
var loadMarkers = function () {

	$.ajax({
		type: "GET",
		beforeSend: function (xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
		url: appContext.buildUrl("/api/ToDoList/GetPoints"),
		dataType: "json",
		success: function (data) {

			//add markers to map
			$.each(data,
				function (index, marker) {
					map.addMarker({
						lat: marker.Lat,
						lng: marker.Lon,
						infoWindow: {
							content: '<p>' + marker.ListsName.toString() + '</p>'
						}
					});

				});
		}
	});
}