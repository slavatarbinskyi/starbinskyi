function Item(Text,IsCompleted) {
	this.Text = ko.observable(Text);
	this.IsCompleted = ko.observable(IsCompleted)
	this.Text.subscribe(function(newText)
	{
		self.setText(m.Id, newText);
	})
}
function ToDoList(Name,Items)
{
	this.Name = ko.observable(Name);
	this.Items = ko.observableArray(Items);
}

	function viewModel() {
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

		self.removeItem = function (data, item) {
			data.Items.remove(item);
			$.ajax({
				type: 'POST',
				url: '/Home/RemoveItem',
				data: { 'id': item.Id },
				success: function (data) {
				},
				error: function () {
				}
			});
		};
		self.removeList = function (list) {
			self.toDoLists.remove(list);
			$.ajax({
				type: 'POST',
				url: '/Home/RemoveList',
				data: { 'id': list.Id() },
				success: function (data) {
				},
				error: function () {
				}
			});
		};

		self.addItem = function (data) {
			var listid = data.Id;
			$.ajax({
				type: 'POST',
				url: '/Home/AddItem',
				data: { 'ToDoList_Id': listid,'Text':"newItem",'IsCompleted':false },
				success: function (id) {
				data.Items.push(new Item("newItem", false))
				},
				error: function () {
				}
			});


		};
		self.addList = function (data) {
		self.toDoLists.push(new ToDoList("DefaultTitle", [new Item("newItem", false)]))
		var data =
			JSON.stringify({
				'Name': "DefaultTitle",
				'Items': [
					{
						'Text': 'newItem',
						'IsCompleted':false
					}
				]
			});
		$.ajax({
			type: 'POST',
			url: '/Home/AddList',
			contentType: 'application/json',
			data: data,
			dataType: 'JSON',
			success: function (data) {
			},
			error: function () {
			}
		});
		};

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