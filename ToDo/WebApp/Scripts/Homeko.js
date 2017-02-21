
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
		'ignore': ["Created", "Modified", "Priority", "NextNotifyTime", "ToDoList_Id"],
		'copy': ["Id"]
	};
	var tagMapping =
	{
		'ignore': ["Created", "Modified"],
		'copy': ["Id"]
	};
	var listmapping = {
		'ignore': ["Created", "Modified", "User", "User_Id"],
		"Items": {
			create: function(options) {
				var m = newItem(options.data);
				return m;
			}
		},
		'Name': {
			create: function(options) {
				var m = ko.mapping.fromJS(options.data);

				m.subscribe(function(newValue) {

					self.setName(options.parent.Id(), newValue);
				});
				return m;
			}
		},
		'Tags': {
			create: function(options) {
				var m = newTag(options.data);
				return m;
			}
		}
	};

	//function to remove item
	self.removeItem = function(data, item) {
		data.Items.remove(item);
		$.ajax({
			type: "DELETE",
			beforeSend: function(xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
			url: appContext.buildUrl("/api/ToDoItem/RemoveItem/" + item.Id),
			success: function(data) {
			},
			error: function() {
			}
		});
	};

	//function to remove list 
	self.removeList = function(list) {
		self.toDoLists.remove(list);
		var Id = list.Id();
		$.ajax({
			type: "DELETE",
			beforeSend: function(xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
			url: appContext.buildUrl("/api/ToDoList/RemoveList/" + Id),
			success: function(data) {
			},
			error: function() {
			}
		});
	};

	//map new Item and subscribe
	var newItem = function(data) {
		var m = ko.mapping.fromJS(data, itemMapping);
		m.Text.subscribe(function(newValue) {
			//send ajax
			self.setText(m.Id, newValue);
		});
		m.IsCompleted.subscribe(function(newValue) {
			//send ajax
			self.markItem(m.Id, newValue);
		});
		return m;
	};

	//map new Tag and subscribes
	var newList = function(data) {
		var m = ko.mapping.fromJS(data, listmapping);


		var tags = [];
		$.each(m.Tags(),
			function(index, elem) {
				tags.push(elem.Name());

			});
		m.bindTagsEditor = function(elements) {
			$.each(elements,
				function(index, elem) {
					if (elem.nodeName == "INPUT") {
						$(elem).tagEditor({
							initialTags: tags,
							autocomplete: {
								delay: 0,
								minLength: 2,
								position: { collision: "flip" },
								source: TagsAutoComplete
							},
							placeholder: "Enter tags ...",
							beforeTagSave: function(field, editor, tags, tag, val) {
								self.AddTag(val, m.Id);
							},
							beforeTagDelete: function(field, editor, tags, val) {
								self.deleteTag(val, m.Id);
							}
						});
					}
				});
		};
		m.FindByTag = function() {
			$(".tag-editor-tag").each(function() {
					$(this).click(function() {
						var name = $(this).html();

						$.ajax({
							type: "GET",
							contentType: "application/json",
							beforeSend: function(xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
							url: appContext.buildUrl("/api/ToDoList/GetAllByTagName/" + name),
							dataType: "JSON",
							success: function(data) {
								self.toDoLists.removeAll();
								$(".filtertag").removeClass("hidden");
								$("#tagName").text("#" + name);
								$.each(data,
									function(index, element) {
										var model = newList(element);
										self.toDoLists.push(model);
									});
							},
							error: function() {
							}
						});
					});
				}
			);
		};


		m.sortedItems = ko.pureComputed(function() {
				var k = m.Items();
				var incompleted = [];
				var completed = [];
				for (var i = 0; i < k.length; i++) {
					if (k[i].IsCompleted())
						completed.push(k[i]);
					else
						incompleted.push(k[i]);
				}

				return incompleted.concat(completed);
			},
			m);
		return m;
	};

	//autocomplete for tags
	var TagsAutoComplete = [];
	self.GetTags = function() {
		$.ajax({
			type: "GET",
			beforeSend: function(xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
			url: appContext.buildUrl("/api/Tag/GetAll"),
			dataType: "json",
			success: function(data) {
				$.each(data,
					function(index, element) {
						TagsAutoComplete.push(element.Name);
					});
			},
		});
	};
	self.loaddef = function() {
		self.loadLists();
		$(".filtertag").addClass("hidden");
	};

	//map new Tag and subscribes
	var newTag = function(data) {
		var m = ko.mapping.fromJS(data, tagMapping);
		return m;
	};

	//function to add new tag
	self.AddTag = function(data, id) {
		$.ajax({
			type: "POST",
			beforeSend: function(xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
			url: appContext.buildUrl("/api/Tag/AddTag/" + data + "/" + id()),
			success: function(data) {

			},
			error: function() {
			}
		});
	};

	//function to delete tag
	self.deleteTag = function(data, id) {
		$.ajax({
			type: "DELETE",
			beforeSend: function(xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
			url: appContext.buildUrl("/api/Tag/RemoveTag/" + data + "/" + id()),
			success: function(data) {

			},
			error: function() {
			}
		});
	};

	//function to add new Item
	self.addItem = function(data) {
		var length = data.Items().length;
		if (length < 5) {
			var listid = data.Id;

			$.ajax({
				type: "POST",
				beforeSend: function(xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
				url: appContext.buildUrl("/api/ToDoItem/InsertItem"),
				data: { 'ToDoList_Id': listid, 'Text': "newItem", 'IsCompleted': false },
				success: function(item) {

					var m = newItem(item);
					data.Items.unshift(m);
				},
				error: function() {
				}
			});
		}

	};

	//function to add list
	self.addList = function(data) {
		var length = data.toDoLists().length;
		if (length < 50) {
			var jsonData =
				JSON.stringify({
					'Name': "DefaultTitle",
					'Items': [
						{
							'Text': "newItem",
							'IsCompleted': false
						}
					]
				});
			$.ajax({
				type: "POST",
				beforeSend: function(xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
				url: appContext.buildUrl("/api/ToDoList/InsertList"),
				contentType: "application/json",
				data: jsonData,
				dataType: "JSON",
				success: function(list) {
					var model = newList(list);
					self.toDoLists.push(model);

				},
				error: function() {
				}
			});
		}
	};
	self.ExportToExc = function () {
		var url = appContext.buildUrl("/Home/ExportToExcel");
		window.location=url;
	}

	//Binding for edit name
	ko.bindingHandlers.inline = {
		init: function(element, valueAccessor) {
			var span = $(element);
			var input = $("<input />", { 'type': "text", 'style': "display:none" });
			span.after(input);

			ko.applyBindingsToNode(input.get(0), { value: valueAccessor() });
			ko.applyBindingsToNode(span.get(0), { text: valueAccessor() });

			span.click(function() {
				input.width(span.width());
				span.hide();
				input.show();
				input.focus();
			});

			input.blur(function() {
				span.show();
				input.hide();
			});

			input.keypress(function(e) {
				if (e.keyCode == 13) {
					span.show();
					input.hide();
				}
			});
		}
	};

	//set notification time of item
	self.SetNotificationTime = function(data, e) {
		var element = $(".modalDateView")[0];
		ko.cleanNode(element);
		if (data.IsNotify() == true) {

			var id = data.Id;
			$.ajax({
				type: "PUT",
				contentType: "application/json",
				beforeSend: function(xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
				url: appContext.buildUrl("/api/ToDoItem/DismissNotification/" + id),
				dataType: "JSON",
				success: function(data) {
				},
				error: function(data) {
				}
			});
			data.IsNotify(false);
			e.preventDefault();
			e.stopPropagation();
		}
		data.picker = function() {
			$("#datetime24").combodate();
		};


		data.SetNotification = function(data) {
			var Id = data.Id;
			data.IsNotify(true);
			$.ajax({
				type: "PUT",
				contentType: "application/json",
				beforeSend: function(xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
				url: appContext.buildUrl("/api/ToDoItem/SetNotification/" + Id),
				dataType: "JSON",
				success: function(data) {
				},
				error: function(data) {
				}
			});
		};
		ko.applyBindings(data, $(".modalDateView")[0]);
	};

	//init load of all lists
	self.loadLists = function() {
		self.toDoLists.removeAll();
		$.ajax({
			type: "GET",
			contentType: "application/json",
			url: appContext.buildUrl("/api/ToDoList/GetAll/"),
			beforeSend: function(xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
			dataType: "JSON",
			success: function(data) {
				$.each(data,
					function(index, element) {
						var model = newList(element);
						self.toDoLists.push(model);
					});
			},
			error: function() {
			}
		});
	};

	//function to change name
	self.setText = function(itemid, value) {
		var itemId = itemid;
		var newText = value;
		$.ajax({
			type: "PUT",
			contentType: "application/json",
			beforeSend: function(xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
			url: appContext.buildUrl("/api/ToDoItem/SetText/" + itemId + "/" + newText),
			dataType: "JSON",
			success: function(data) {
			},
			error: function(data) {
			}
		});
	};

	//function to change name of list
	self.setName = function(itemid, value) {
		$.ajax({
			type: "PUT",
			beforeSend: function(xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
			url: appContext.buildUrl("/api/ToDoList/SetName/" + itemid + "/" + value),
			success: function(data) {
			},
			error: function() {
			}
		});
	};

	//function for marking item as completed
	self.markItem = function(itemid, value) {
		$.ajax({
			type: "PUT",
			contentType: "application/json",
			beforeSend: function(xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
			url: appContext.buildUrl("/api/ToDoItem/MarkItem/" + itemid + "/" + value),
			success: function(data) {

			},
			error: function() {
			}
		});
	};
	self.toDoLists = ko.observableArray([]);
}


$(function() {
	var vm = new viewModel();
	vm.loadLists();
	vm.GetTags();
	ko.applyBindings(vm, $(".stickerBoard")[0]);
});