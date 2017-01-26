﻿function viewModel() {
	var self = this;

	var itemMapping = {
		'ignore': ["Created", "Modified", "IsNotify", "Priority", "NextNotifyTime", "ToDoList_Id"],
		'copy': ["Id"]
	}

	var mapping = {
		'ignore': ["Created", "Modified", "User", "User_Id"],
		"Items": {
			create: function (options) {
				var m = ko.mapping.fromJS(options.data, itemMapping);

				m.Text.subscribe(function (newText) {
					self.setText(m.Id, newText);
				});
				m.IsCompleted.subscribe(function (newValue) {
					self.markItem(m.Id, newValue);
				});
				return m;
			}
		},
		'Name': {
			create: function (options) {
				var m = ko.mapping.fromJS(options.data);
				m.subscribe(function (newValue) {
					self.setName(options.parent.Id(), newValue);
				});
				return m;
			}
		}

	}

	self.removeItem = function (item) { self.toDoLists.remove(item) };

	ko.bindingHandlers.inline = {
		init: function (element, valueAccessor) {
			var span = $(element);
			var input = $('<input />', { 'type': 'text', 'style': 'display:none' });
			span.after(input);

			ko.applyBindingsToNode(input.get(0), { value: valueAccessor() });
			ko.applyBindingsToNode(span.get(0), { text: valueAccessor() });

			span.click(function () {
				input.width(span.width());
				span.hide();
				input.show();
				input.focus();
			});

			input.blur(function () {
				span.show();
				input.hide();
			});

			input.keypress(function (e) {
				if (e.keyCode == 13) {
					span.show();
					input.hide();
				};
			});
		}
	};

	self.loadLists = function () {
		$.ajax({
			type: 'GET',
			contentType: 'application/json',
			url: '/Home/GetUsersList',
			dataType: 'JSON',
			success: function (data) {
				$.each(data, function (index, element) {

					var model = ko.mapping.fromJS(element, mapping);
					self.toDoLists.push(model);
					console.log(model);

				});
			},
			error: function () {
			}
		});
	}
	self.setText = function (itemid, value) {
		var data = JSON.stringify({
			'id': itemid,
			'newText': value
		});
		$.ajax({
			type: 'POST',
			contentType: 'application/json',
			url: '/Home/SetText',
			dataType: 'JSON',
			data: data,
			success: function (data) {
			},
			error: function () {
			}
		});
	}
	self.setName = function (itemid, value) {
		$.ajax({
			type: 'POST',
			url: '/Home/SetName',
			data: {'id': itemid,'newName': value},
			success: function (data) {
			},
			error: function () {
			}
		});
	}
	self.markItem = function (itemid, value) {
		var data = JSON.stringify({
			'id': itemid,
			'newValue': value
		});
		$.ajax({
			type: 'POST',
			contentType: 'application/json',
			url: '/Home/MarkItem',
			dataType: 'JSON',
			data: data,
			success: function (data) {
			},
			error: function () {
			}
		});
	}
	self.toDoLists = ko.observableArray([]);
}

$(function(){
	var vm = new viewModel();
	vm.loadLists();

	ko.applyBindings(vm);
});