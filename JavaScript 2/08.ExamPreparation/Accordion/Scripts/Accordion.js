(function() {
    function Accordion() {
        var accordionElements = [];
        this.accordionElements = accordionElements;
    }

    Accordion.prototype.getAccordion = function (accordionHolder) {
        var accHolder = document.getElementById(accordionHolder);

        var mainAccordion = new Item();
        accHolder.appendChild(mainAccordion);
        return mainAccordion;
    }

    Accordion.prototype.add = function (elementName) {
        var currItem = new Item(elementName);
        this.accordionElements.push(currItem);
        return currItem;
    }

    Accordion.prototype.addSubItem = function (itemName) {

    }

    function Item(title) {
        var subItem = document.createElement('li');
        var subUL = document.createElement('ul');
        var InnerSubUL = document.createElement('ul');
        subUL.innerHTML = title;
        subUL.appendChild(InnerSubUL);
        subUL.addEventListener('click', show, false)

        this.itemElement = subUL;
    }

    Item.prototype.addSubItem = function (subItemName) {
        //var subUL = document.createElement('ul');
        var subItem = document.createElement('li');
        subItem.innerHTML = subItemName;
        //subUL.appendChild(subItem);
        var firstCh = this.itemElement.lastChild;
        firstCh.appendChild(subItem);
        //return subItem;
    }

    function show(ev) {
        ev.stopPropagation;
        var currentElement = ev.target;

        if (currentElement.className == 'hide') {
            var siblings = getSiblings(currentElement);
            hideAll(siblings);
            currentElement.className = 'show';
        }
        else {
            if (currentElement.className == 'show') {
                currentElement.className = 'hide';
            }
            else {
                currentElement.className = 'show'
            }
        }
    }

    function getSiblings(currElement) {
        var result = [];
        var node = currElement.parentNode.firstChild;

        while (node && node.nodeType === 1) {
            result.push(node);
            node = node.nextElementSibling || node.nextSibling;
        }

        // console.log(result);
        return result;
    }

    function hideAll(elements) {
        for (var i = 0; i < elements.length; i++) {
            elements[i].className = 'hide';
        }
    }

    var acc = new Accordion();
    var webItem = acc.add('web');
    webItem.addSubItem('HTML');
    webItem.addSubItem('CSS');
    webItem.addSubItem('JS');
    acc.add('desctop');
    acc.add('Mobile');
    acc.add("Embedded");

    var accHolder = document.getElementById('accordion-holder');

    for (var i = 0; i < acc.accordionElements.length; i++) {
        accHolder.appendChild(acc.accordionElements[i].itemElement);
    }
}());