(function () {
    /*---------------------------Create classes --------------------------*/
    var Url = Class.create({
        init: function (title, url) {
            this.title = title;
            this.url = url;
        },
        display: function () {
            var urlHTML = document.createElement("a");
            urlHTML.href = this.url;
            urlHTML.target = "_blank";
            urlHTML.innerHTML = this.title;
            urlHTML.style.cssText = "display: block; margin-left:10px;";
            return urlHTML;
        }
    });

    var Folder = Class.create({
        init: function (title, urls) {
            this.title = title;
            this.urls = urls;
        },
        display: function () {
            var i = 0
            var folderContainer = document.createElement("div");
            folderContainer.style.cssText = "padding: 20px; border-bottom: 1px solid black;";

            var folderTitle = document.createElement("p");
            folderTitle.innerHTML = this.title;
            folderTitle.style.cssText = "weight: 800; font-size: 20px; margin: 0;";

            folderContainer.appendChild(folderTitle);

            for (i = 0; i < this.urls.length; i++) {
                var currentUrl = this.urls[i].display();
                folderContainer.appendChild(currentUrl);
            }

            return folderContainer;
        }
    });

    var FavouriteSiteBar = Class.create({
        init: function (folders, urls) {
            this.folders = folders;
            this.urls = urls;
        },
        display: function () {
            var i = 0
            var sideBarContainer = document.createElement("div");
            sideBarContainer.style.cssText = "width: 200px; border: 1px solid black;";

            for (i = 0; i < this.folders.length; i++) {
                var currentFolder = this.folders[i].display();
                sideBarContainer.appendChild(currentFolder);
            }

            for (i = 0; i < this.urls.length; i++) {
                var currentUrl = this.urls[i].display();
                sideBarContainer.appendChild(currentUrl);
            }

            return sideBarContainer;
        }
    });

    /*---------------------------Test classes functionality --------------------------*/
    var telerikSite = new Url("Telerik", "http://telerik.com");
    var telerikAcademySite = new Url("Telerik Academy", "http://telerikacademy.com/");
    var telerikAcademyForum = new Url("Telerik Academy Forum", "http://forums.academy.telerik.com/");
    var telerikSites = [telerikSite, telerikAcademySite, telerikAcademyForum];
    var telerikFolder = new Folder("Telerik", telerikSites);

    var abv = new Url("ABV mail", "http://abv.bg");
    var yahoo = new Url("Yahoo mail", "http://yahoo.com");
    var gmail = new Url("Gmail", "http://gmail.com");
    var mails = [abv, yahoo, gmail];
    var mailsFolder = new Folder("Mails", mails);

    var folders = [telerikFolder, mailsFolder];

    var google = new Url("Google", "http://google.bg");
    var dnes = new Url("Dnes BG", "http://dnes.bg");
    var sitesOutOfFolder = [dnes, google];

    var siteBar = new FavouriteSiteBar(folders, sitesOutOfFolder);

    var test = siteBar.display();
    document.body.appendChild(test);
}());