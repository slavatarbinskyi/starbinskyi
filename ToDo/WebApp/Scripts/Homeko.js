
//ToDoList model
function ToDoList(Name, Items) {
	this.Name = ko.observable(Name);
	this.Items = ko.observableArray(Items);
}
//Item model
function Item(Text, isCompleted) {
	this.Text = ko.observable(Text);
	this.IsCompleted = ko.observable(isCompleted);
}
//viewmodel
function viewModel() {
	var self = this;


	//mappings
	var itemMapping = {
		'ignore': ["Created", "Modified", "IsNotify", "Priority", "NextNotifyTime", "ToDoList_Id"],
		'copy': ["Id"]
	}
	var tagMapping =
		{
			'ignore': ["Created", "Modified"],
			'copy': ["Id"]
		}

	var listmapping = {
		'ignore': ["Created", "Modified", "User", "User_Id"],
		"Items": {
			create: function (options) {
				var m = newItem(options.data);
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
		},
		'Tags': {
			create: function (options) {
				var m = newTag(options.data);
				return m;
			}
		}
	}

	//function to remove item
	self.removeItem = function (data, item) {
		data.Items.remove(item);
		$.ajax({
			type: 'POST',
			url: appContext.buildUrl('/Home/RemoveItem'),
			data: { 'id': item.Id },
			success: function (data) {
			},
			error: function () {
			}
		});
	};

	//function to remove list
	self.removeList = function (list) {
		self.toDoLists.remove(list);
		$.ajax({
			type: 'POST',
			url: appContext.buildUrl('/Home/RemoveList'),
			data: { 'id': list.Id },
			success: function (data) {
			},
			error: function () {
			}
		});
	};

	//map new Item and subscribe
	var newItem = function (data) {
		var m = ko.mapping.fromJS(data, itemMapping);

		m.Text.subscribe(function (newValue) {
			//send ajax
			self.setText(m.Id, newValue);
		});
		m.IsCompleted.subscribe(function (newValue) {
			//send ajax
			self.markItem(m.Id, newValue);
		});
		return m;
	};

	//map new Tag and subscribes
	var newList = function (data) {
		var m = ko.mapping.fromJS(data, listmapping);

		var tags = [];
		$.each(m.Tags(), function (index, elem) {
			tags.push(elem.Name());
		});
		m.bindTagsEditor = function (elements) {
			$.each(elements, function (index, elem) {
				if (elem.nodeName == "INPUT") {
					$(elem).tagEditor({
						initialTags: tags,
						placeholder: 'Enter tags ...',
						beforeTagSave: function (field, editor, tags, tag, val) {
							self.AddTag(val,m.Id);
						},
						beforeTagDelete: function (field, editor, tags, val) {
							self.deleteTag(val,m.Id);
						}
					});
				}
			});
		}

		return m;
	};


	//map new Tag and subscribes
	var newTag = function (data) {
		var m = ko.mapping.fromJS(data, tagMapping);
		return m;
	};

	//function to add new tag
	self.AddTag = function (data,id) {
		$.ajax({
			type: 'POST',
			url: appContext.buildUrl('/Home/AddTag'),
			data: { 'Name': data,'listId':id },
			success: function (data) {

			},
			error: function () {
			}
		});
	};

	//function to delete tag
	self.deleteTag = function (data,id) {
		$.ajax({
			type: 'POST',
			url: appContext.buildUrl('/Home/RemoveTag'),
			data: { 'Name': data,'listId': id },
			success: function (data) {

			},
			error: function () {
			}
		});
	};

	//function to add new Item
	self.addItem = function (data) {

		var listid = data.Id;

		$.ajax({
			type: 'POST',
			url: appContext.buildUrl('/Home/AddItem'),
			data: { 'ToDoList_Id': listid, 'Text': "newItem", 'IsCompleted': false },
			success: function (item) {

				var m = newItem(item);
				data.Items.push(m);
			},
			error: function () {
			}
		});


	};

	//function to add list
	self.addList = function (data) {
		var data =
			JSON.stringify({
				'Name': "DefaultTitle",
				'Items': [
					{
						'Text': 'newItem',
						'IsCompleted': false
					}
				]
			});
		$.ajax({
			type: 'POST',
			url: appContext.buildUrl('/Home/AddList'),
			contentType: 'application/json',
			data: data,
			dataType: 'JSON',
			success: function (list) {
				var model = newList(list);
				self.toDoLists.push(model);

			},
			error: function () {
			}
		});
	};

	//Binding for edit name
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

	//init load of all lists
	self.loadLists = function () {
		$.ajax({
			type: 'GET',
			contentType: 'application/json',
			url: appContext.buildUrl('/Home/GetUsersList'),
			dataType: 'JSON',
			success: function (data) {
				$.each(data, function (index, element) {

					var model = newList(element);
					self.toDoLists.push(model);

				});
			},
			error: function () {
			}
		});
	}
	//function to change name
	self.setText = function (itemid, value) {
		var data = JSON.stringify({
			'id': itemid,
			'newText': value
		});
		$.ajax({
			type: 'POST',
			contentType: 'application/json',
			url: appContext.buildUrl('/Home/SetText'),
			dataType: 'JSON',
			data: data,
			success: function (data) {
			},
			error: function () {
			}
		});
	}

	//function to change name
	self.setName = function (itemid, value) {
		$.ajax({
			type: 'POST',
			url: appContext.buildUrl('/Home/SetName'),
			data: { 'id': itemid, 'newName': value },
			success: function (data) {
			},
			error: function () {
			}
		});
	}
	//function for marking item as completed
	self.markItem = function (itemid, value) {
		var data = JSON.stringify({
			'id': itemid,
			'newValue': value
		});
		$.ajax({
			type: 'POST',
			contentType: 'application/json',
			url: appContext.buildUrl('/Home/MarkItem'),
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



$(function () {

	var vm = new viewModel();
	vm.loadLists();
	ko.applyBindings(vm);
});