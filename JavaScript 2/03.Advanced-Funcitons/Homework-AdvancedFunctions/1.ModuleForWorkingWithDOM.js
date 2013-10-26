function testDomModule() {
    var domModule = (function () {
        // Add element to parent element by given selector.
        function appendChild(newElement, parentElementSelector) {
            var selectedParentElement = document.querySelectorAll(parentElementSelector);

            if (newElement instanceof HTMLElement) {
                if (selectedParentElement.length === 0) {
                    return undefined;
                }
                else if (selectedParentElement.length === 1) {
                    selectedParentElement[0].appendChild(newElement);
                }
                else {
                    var i = 0;
                    for (i = 0; i < selectedParentElement.length; i++) {
                        selectedParentElement[i].appendChild(newElement.cloneNode(true));
                    }
                }
            }
            else {
                return undefined;
            }
        }

        // Remove element from the DOM  by given selector.
        function removeChild(parentElementSelector, htmlElement) {
            var selectedParentElement = document.querySelectorAll(parentElementSelector);
            
            if (selectedParentElement.length === 0) {
                return undefined;
            }
            else if (selectedParentElement.length === 1) {
                var selectedElements = selectedParentElement[0].querySelectorAll(htmlElement);

                if (selectedElements.length === 0) {
                    return undefined;
                }
                else if (selectedElements.length === 1) {
                    selectedElements[0].parentNode.removeChild(selectedElements[0])
                }
                else {
                    var i = 0;
                    for (i = 0; i < selectedElements.length; i++) {
                        selectedElements[i].parentNode.removeChild(selectedElements[i])
                    }
                }
            }
            else {
                for (i = 0; i < selectedParentElement.length; i++) {
                    selectedElements = selectedParentElement[i].querySelectorAll(htmlElement);

                    if (selectedElements.length === 0) {
                        return undefined;
                    }
                    else if (selectedElements.length === 1) {
                        selectedElements[0].parentNode.removeChild(selectedElements[0])
                    }
                    else {
                        for (j = 0; j < selectedElements.length; j++) {
                            selectedElements[z].parentNode.removeChild(selectedElements[z])
                        }
                    }
                }
            }
        }

        // Attach event to given selector by given event type and event hander.
        function addHandler(htmlElementSelector, eventType, functionToExecute) {
            var selectedElements = document.querySelectorAll(htmlElementSelector);

            if (selectedElements.length === 0) {
                return undefined;
            }
            else {
                var i = 0;
                for (i = 0; i < selectedElements.length; i++) {
                    selectedElements[i].addEventListener(eventType, functionToExecute, false);
                }
            }
        }

        // Add elements to buffer, which appends them to the DOM when their for some selector count becomes 100.
        // The buffer contains elements for each selector it gets.
        var fragmentsBuffer = [];

        function appentToBuffer(elementSelector, newElement) {
            var MAX_SIZE = 100;

            if (!fragmentsBuffer[elementSelector]) {
                fragmentsBuffer[elementSelector] = document.createDocumentFragment();
            }

            fragmentsBuffer[elementSelector].appendChild(newElement);

            if (fragmentsBuffer[elementSelector].childNodes.length === MAX_SIZE) {
                var parentElement = document.querySelector(elementSelector);
                parentElement.appendChild(fragmentsBuffer[elementSelector]);
                fragmentsBuffer[elementSelector] = null;
            }
        }

        return {
            appendChild: appendChild,
            removeChild: removeChild,
            addHandler: addHandler,
            appentToBuffer: appentToBuffer
        };
    })();

    // Show functionality
    var div = document.createElement("div");
    domModule.appendChild(div, "#wrapper");

    domModule.removeChild("ul", "li:first-of-type");

    domModule.addHandler("ul li", "click",
                         function () {
                             alert("clicked")
                         });

    var i = 0;
    for (i = 0; i < 110; i++) {
        var h1 = document.createElement("h1");
        h1.innerHTML = i;
        domModule.appentToBuffer("#wrapper", h1);
    }
}