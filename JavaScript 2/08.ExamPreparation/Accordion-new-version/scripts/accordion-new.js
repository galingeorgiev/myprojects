(function () {
    function Accordion(selector) {
        var accordionItems = [];
        this.accordionItems = accordionItems;
        var accordionPlace = document.getElementById(selector);
        this.accordionPlace = accordionPlace;
    }

    Accordion.prototype.add = function (itemName) {
        var subItem = new Item(itemName);
        this.accordionItems.push(subItem);

        return subItem;
    }

    Accordion.prototype.render = function () {
        if (this.accordionItems.length > 0) {
            var ulElement = document.createElement('ul');
            for (var i = 0; i < this.accordionItems.length; i++) {
                var subItems = this.accordionItems[i].render();
                ulElement.appendChild(subItems);
            }
            this.accordionPlace.appendChild(ulElement);
        }
    }

    Accordion.prototype.serialize = function () {
        var accordionElements = [];
        if (this.accordionItems.length > 0) {
            for (var i = 0; i < this.accordionItems.length; i++) {
                var elements = this.accordionItems[i].serialize();
                accordionElements.push(elements);
            }
        }

        return JSON.stringify(accordionElements);
    }

    function Item(itemName) {
        var accordionSubItems = [];
        this.accordionSubItems = accordionSubItems;
        this.itemName = itemName;
    }

    Item.prototype.add = function (subItemName) {
        var subItem = new Item(subItemName);
        this.accordionSubItems.push(subItem);

        return subItem;
    }

    Item.prototype.render = function () {
        var itemNode = document.createElement("li");

        itemNode.innerHTML = "<a href='#' >" + this.itemName + "</a>";

        if (this.accordionSubItems.length > 0) {
            var sublist = document.createElement("ul");
            //sublist.style.display = "none";
            for (var i = 0, len = this.accordionSubItems.length; i < len; i += 1) {
                var subitem = this.accordionSubItems[i].render();
                sublist.appendChild(subitem);
            }
            itemNode.appendChild(sublist);
        }

        return itemNode;
    }

    Item.prototype.serialize = function () {
        var accordionItems = [];
        var objItem = {
            itemTitle: itemTitle
        }

        if (this.accordionSubItems.length > 0) {
            for (var i = 0, len = this.accordionSubItems.length; i < len; i += 1) {
                var subitem = this.accordionSubItems[i].serialize();
                accordionItems.push(subitem);
            }
        }

        return accordionItems;
    }

    var accordion = new Accordion("accordion-holder");
    var webItem = accordion.add("Web");
    var html = webItem.add("HTML");
    html.add("v2");
    html.add("v3");
    html.add("v4");
    html.add("v5");
    webItem.add("CSS");
    webItem.add("JavaScript");
    webItem.add("jQuery");
    webItem.add("ASP.NET MVC");
    accordion.add("Desktop");
    accordion.add("Mobile");
    var emb = accordion.add("Embedded");
    emb.add("1");
    emb.add("2");
    emb.add("3");
    emb.add("4");
    accordion.render();

    var state = accordion.serialize();
    console.log(state);
}());