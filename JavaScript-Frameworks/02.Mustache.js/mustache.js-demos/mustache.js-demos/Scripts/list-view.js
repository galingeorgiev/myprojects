/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
	var ListView = Class.create({
		init: function (itemsSource) {
			if (!(itemsSource instanceof Array)) {
				throw "The itemsSource of a ListView must be an array!";
			}
			this.itemsSource = itemsSource;
		},
		render: function (template) {
			var list = document.createElement("ul");
			for (var i = 0; i < this.itemsSource.length; i++) {
				var listItem = document.createElement("li");
				var item = this.itemsSource[i];
				listItem.innerHTML = template(item);
				list.appendChild(listItem);
			}
			return list.outerHTML;
		}
	});

	c.getListView = function (itemsSource) {
		return new ListView(itemsSource);
	}
}(controls || {}));