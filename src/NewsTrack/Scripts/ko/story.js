var storyApiUrl = '/api/Story/';

//custom method of Date.js
function getTimeAgo(varDate) {
    if (varDate && new Date(varDate) != 'Invalid Date') {
        var hour = new Date(varDate).getHours();// Math.ceil((new Date() - new Date(varDate)) / 36e5);
        if (hour < 10)
            return $.timeago(varDate.toString().slice(-1) == 'Z' ? varDate : varDate + 'Z');
        else
            return $D(varDate).strftime("%b %d, %Y at %I:%m%p");
    }
    else {
        return new Date();
    }
}

//Model for Story
function Story(data, hub) {
    var self = this;
    data = data || {};
    self.Id = data.Id;
    self.Title = data.Title;
    self.StoryData = ko.observable();
    if (data.StoryData) {
        self.Link = data.StoryData[0].Url;
        self.LinkIcon = data.StoryData[0].ThumbnailUrl;
        self.AltText = data.StoryData[0].AltText;
        self.LinkCaption = data.StoryData[0].Caption;
        var mappedStorysData = $.map(data.StoryData, function (item) { return new StoryData(item); });
        self.StoryData(mappedStorysData);
    }
    self.Detail = ko.observable(data.Descripition || "");
    self.PostedByID = data.UserID || "";
    //self.PostedByName = data.PostedByName || "";
    //self.PostedByAvatar = data.PostedByAvatar || "";
    self.PostedDate = getTimeAgo(data.CreatedOn);
    self.GroupName = data.GroupName,
    self.CategoryName = data.CategoryName,
    self.TotalLikes = ko.observable(data.TotalLikes);
    self.TotalDisLikes = ko.observable(data.TotalDisLikes);
    self.Liked = ko.observable(data.Liked);
    self.Views = ko.observable(data.ViewsCount || 0);
    self.Active = ko.observable(data.Active || true),
    self.broadCastType = 1;
    self.StoryComments = ko.observableArray();
    if (data.StoryComments) {
        var mappedComments = $.map(data.StoryComments, function (item) { return new Comment(item); });
        self.StoryComments(mappedComments);
    }

    self.error = ko.observable();
}

//Model for Story comment
function Comment(data) {
    var self = this;
    data = data || {};
    // Persisted properties
    self.CommentId = data.Id;
    self.StotyId = data.StotyId;
    self.Message = ko.observable(data.Message || "");
    self.CommentedBy = data.UserID || "";
    self.CommentedByAvatar = data.PostedByAvatar || "";
    self.CommentedByName = data.PostedByName || "";
    self.CommentedDate = getTimeAgo(data.CreatedOn);
    self.TotalLikes = ko.observable(data.TotalLikes);
    self.Liked = ko.observable(data.Liked);
    self.broadCastType = 1;
    self.error = ko.observable();
}

//Model for story data collage
function StoryData(data) {
    var self = this;
    self.Id = data.Id;
    self.StoryID = data.StoryID;
    self.AltText = data.AltText;
    self.Url = data.Url;
    self.ThumbnailUrl = data.ThumbnailUrl;
    self.Type = data.Type;
    self.Caption = data.Caption;
}

//Model for SiteMap
function SiteMap(data) {
    var self = this;

    self.Id = data.Id;
    self.Url = data.Url;
    self.Title = data.Title;
}

//View Model for SiteMap
function VM_SM() {
    var self = this;

    self.sitemaps = ko.observableArray();
    self.last = ko.observable();

    self.init = function (data) {
        var mapper_sm = $.map(data, function (item) { return new SiteMap(item) });
        self.sitemaps(mapper_sm);
    }

    self.add = function (data) {
        self.sitemaps.remove(function (item) {
            return item.Id == data.Id;
        });
        if (self.sitemaps().length)
            self.last(undefined);
        if (self.last())
            self.sitemaps(self.last());

        self.last(new SiteMap(data));
    }

    self.remove = function (data) {
        self.sitemaps.remove(function (item) {
            return item.Id == data.Id;
        });
    }

    self.update = function (oldId, newId, newTitle) {
        $.each(self.sitemaps(), function () {
            if (this.Id == oldId) {
                this.Id = newId;
                this.Title = newTitle;
                return true;
            }
        });
    }
}
//View Model for Story Detail
function VM_Story() {
    var self = this;

    self.pendingRequest = ko.observable(false);
    self.detail = ko.observable();

    self.init = function () {
        self.pendingRequest(true);;
        $.myAjax({
            url: '/api/Story/',
            data: { 'id': 1 },
            showProgress: true,
            async: false,
            success: function (data) {
                self.pendingRequest(false);
                if (self.error() == null) {
                    self.detail(new Story(data));
                }
            }
        });
    }
    self.error = ko.observable();
}

//Model Story By Category and View Model for Story( and offcource Comment model)
function StoryByCategory(data, hub) {
    var self = this;

    self.ID = ko.observable(0);
    self.CategoryName = ko.observable("");
    self.GroupName = ko.observable("");
    self.pendingRequest = ko.observable(false);
    self.page = ko.observable(0);
    self.error = ko.observable();
    self.last = ko.observable();

    //featured top story in this category
    self.topstory = ko.observable();
    //all stories in this category
    self.stories = ko.observableArray();

    self.init = function () {
        self.error(null);
        self.getNextPage();
    }

    self.loaddata = function (data, skipbreadcum) {
        if (data && !data.Stories.length) {
            self.last(1);
            return;
        }

        self.ID(data.Id);
        self.GroupName(data.GroupName);
        self.CategoryName(data.CategoryName);

        var mappedStories = $.map(data.Stories, function (item) { return new Story(item, self.hub); });

        if (self.page() > 0) {
            self.stories(self.stories().concat(mappedStories));
        }
        else {
            self.topstory(mappedStories.shift());
            self.stories(mappedStories);
            if (!skipbreadcum)
                vmSM.add({ 'Id': data.Id, 'Url': '/Category/' + data.Id, 'Title': data.CategoryName });
        }
        self.page(self.page() + 1);
    }

    self.scrolled = function (event) {
        if (event == null || event == undefined)
            return true;
        var elem = event.target;
        if (elem.scrollTop == (elem.scrollHeight - elem.offsetHeight) && (!self.pendingRequest() && !self.last())) {
            self.pendingRequest(true);
            self.getNextPage();
        }
    };

    self.getNextPage = function () {
        $.myAjax({
            url: '/api/Category/',
            data: { 'id': 1, 'PageNumber': self.page(), 'PageSize': 10 },
            showProgress: true,
            async: false,
            success: function (data) {
                self.pendingRequest(false);
                if (self.error() == null) {
                    self.loaddata(data);
                }
            }
        });
    }

    if (data)
        self.loaddata(data, true);
    return self;
}

//Model Story By Group and ViewMOdel for StoryByCategory model
function StoryByGroup() {
    var self = this;

    self.ID = ko.observable(0);
    self.GroupName = ko.observable("");
    self.pendingRequest = ko.observable(false);
    self.page = ko.observable(0);
    self.error = ko.observable();
    self.last = ko.observable();

    //all categories in this group
    self.categories = ko.observableArray();

    self.init = function () {
        self.error(null);
        self.getNextPage();
    }

    self.loaddata = function (data) {
        if (!data.StoriesByCategory.length) {
            self.last(1);
            return;
        }
        var mappedCategories = $.map(data.StoriesByCategory, function (item) { if (item.Stories.length) return new StoryByCategory(item, self.hub); });

        if (self.page() > 0) {
            self.categories(self.categories().concat(mappedCategories));
        }
        else {
            self.ID(data.Id);
            self.GroupName(data.GroupName);
            self.categories(mappedCategories);
            vmSM.sitemaps([]);
            vmSM.add({ 'Id': data.Id, 'Url': '/Group/' + data.Id, 'Title': data.GroupName });
        }
        self.page(self.page() + 1);
    }

    self.scrolled = function (event) {
        if (event == null || event == undefined)
            return true;
        var elem = event.target;
        if (elem.scrollTop == (elem.scrollHeight - elem.offsetHeight) && (!self.pendingRequest() && !self.last())) {
            self.pendingRequest(true);
            self.getNextPage();
        }
    };

    self.getNextPage = function () {
        $.myAjax({
            url: '/api/Group/',
            data: { 'id': 1, 'PageNumber': self.page(), 'PageSize': 10 },
            showProgress: true,
            async: false,
            success: function (data) {
                self.pendingRequest(false);
                if (self.error() == null) {
                    self.loaddata(data);
                }
            }
        });
    }
    return self;
}