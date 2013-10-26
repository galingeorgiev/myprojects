function onGenerateTagCloud() {
    tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress",
        "xaml", "js", "http", "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp",
        "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS", "http",
        "c#", "cms", "js", "cms", "c#", "c#", "c#", "c#", "c#", "javascript", "javascript"];
    generateTagCloud(tags, 17, 42);
}
function generateTagCloud(tags, minFontSize, maxFontSize) {
    var uniqueTags = getUniqueTags(tags);
    var minValue = getMinValue(uniqueTags);
    var maxValue = getMaxValue(uniqueTags);
    var fontSizeStep = (maxFontSize - minFontSize) / (maxValue - minValue);
    
    var fragment = document.createDocumentFragment();

    for (var i in uniqueTags) {
        var currentElementFontSize = Math.round(maxFontSize - ((maxValue - parseInt(uniqueTags[i])) * fontSizeStep));
        var content = i;
        var anchor = generateAnchor(currentElementFontSize, content);
        /*We adding textNodeBefore and textNodeAfter because content will be unbreakable(only one line). You can tested this.*/
        var textNodeBefore = document.createTextNode(' ');
        fragment.appendChild(textNodeBefore);
        fragment.appendChild(anchor);
    }

    var divContainer = document.createElement('div');
    divContainer.id = 'tagCloudContainer';
    document.body.appendChild(divContainer)
    divContainer.appendChild(fragment);
}

function getUniqueTags(tags) {
    var uniqueTags = [];
    var i = 0;
    for (i = 0; i < tags.length; i++) {
        var tagName = tags[i].toLowerCase();
        if (uniqueTags[tagName] !== undefined) {
            var value = uniqueTags[tagName] + 1;
            uniqueTags[tagName] = value;
        }
        else {
            uniqueTags[tagName] = 1;
        }
        
    }

    return uniqueTags;
}

function getAssociativeArrayLength(associativeArr) {
    var keys = Object.keys(associativeArr);
    var length = keys.length;
    return length;
}

function getMinValue(associativeArr) {
    var minValue = Number.MAX_VALUE;
    for (var i in associativeArr) {
        if (associativeArr[i] < minValue) {
            minValue = associativeArr[i];
        }
    }

    return minValue;
}

function getMaxValue(associativeArr) {
    var maxValue = Number.MIN_VALUE;
    for (var i in associativeArr) {
        if (associativeArr[i] > maxValue) {
            maxValue = associativeArr[i];
        }
    }

    return maxValue;
}

function generateAnchor(fontSize, content) {
    var anchor = document.createElement('a');
    anchor.href = '#';
    anchor.style.cssText = 'font-size: ' + fontSize + 'px;';
    anchor.innerHTML = content;
    return anchor;
}
