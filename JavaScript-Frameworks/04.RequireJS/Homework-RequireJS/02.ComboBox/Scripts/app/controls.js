/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="class.js" />
define(["libs/class", "jquery"], function (Class, $) {
	var controls = controls || {};
	var ComboBox = Class.create({
		init: function (itemsSource) {
			if (!(itemsSource instanceof Array)) {
				throw "The itemsSource of a ListView must be an array!";
			}
			this.itemsSource = itemsSource;
		},
		render: function (template) {
		    var list = $('<ul />');
			for (var i = 0; i < this.itemsSource.length; i++) {
				var item = this.itemsSource[i];
				var listItem = template(item);
				list.append(listItem);
			}
			return list;
		}
	});
	controls.ComboBox = function (itemsSource) {
	    return new ComboBox(itemsSource);
	}

	return controls;
});