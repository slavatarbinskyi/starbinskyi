// represent a single todo item
var ToDoItem = function (text, completed) {
	var self = this;
	self.text = ko.observable(text);
	self.completed = ko.observable(completed);
	self.editing = ko.observable(false);
};
// represent a single todo list
var ToDoList= function(name)
{
	var self = this;
	self.title = ko.observable(title);
	self.ToDoItems = ko.observableArray();

	// Load initial state from server, convert it to Task instances, then populate self.tasks
	$.getJSON("/Home/GetUsersList", function (allData) {
		var mappedTasks = $.map(allData, function (item) { return new ToDoItem(item) });
		self.ToDoItems(mappedTasks);
	});
}
