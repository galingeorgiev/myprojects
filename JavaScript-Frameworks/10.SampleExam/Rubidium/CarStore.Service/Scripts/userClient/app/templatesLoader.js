window.templateLoader = (function () {

    var rootUrl = "Scripts/userClient/partials/";
    var templates = {};

    function getTemplate(name) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates[name]) {
                resolve(templates[name]);
            } else {
                $.ajax({
                    url: rootUrl + name + ".html",
                    type: "GET",
                    success: function(templateHtml) {
                        templates[name] = templateHtml;
                        resolve(templateHtml);
                    },
                    error: function(err) {
                        reject(err);
                    }
                });
            }
        });

        return promise;
    }

    return {
        loadTemplate: getTemplate
    };

}());