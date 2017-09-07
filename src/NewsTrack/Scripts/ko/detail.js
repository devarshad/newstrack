function category(data) {
    var self = this;
    self.ID = ko.observable(0 || data.ID);
    self.Title = ko.observable('' || data.Title);
    self.error = ko.observable();
}
function dontMiss(data) {
    var self = this;
    self.ID = ko.observable(0 || data.ID);
    self.href = ko.observable('' || data.href);
    self.src = ko.observable('' || data.src);
    self.Title = ko.observable('' || data.Title);
    self.error = ko.observable();
}
function photoGallery(data) {
    var self = this;
    self.ID = ko.observable(0 || data.ID);
    self.href = ko.observable('' || data.href);
    self.src = ko.observable('' || data.src);
    self.Title = ko.observable('' || data.Title);
    self.error = ko.observable();
}
function newsDetail(data) {
    var self = this;
    self.MainHeadLine = ko.observable("" || data.MainHeadLine);
    self.DateStr = ko.observable("" || data.DateStr);
    self.ViewCount = ko.observable("" || data.ViewCount);
    self.CommentCount = ko.observable("" || data.CommentCount);
    self.ArticleText = ko.observable("" || data.ArticleText);
    if (data.Tags) {
        var mappedTags = $.map(data.Tags, function (item) { return new Tags(item); });
        self.Tags(mappedTags);
    }
    if (data.RelatedNews) {
        var mappedRelatedNews = $.map(data.RelatedNews, function (item) { return new RelatedNews(item); });
        self.RelatedNews(mappedRelatedNews);
    }
    if (data.Comment) {
        var mappedComment = $.map(data.Comment, function (item) { return new Comment(item); });
        self.Comment(mappedComment);
    }
}
function Tags(data) {
    var self = this;
    self.Title = ko.observable("" || data.Title);
    self.Href = ko.observable("" || data.Href);
    self.error = ko.observable();
}
function RelatedNews(data) {
    var self = this;
    self.ID = ko.observable(0 || data.ID);
    self.Title = ko.observable("" || data.Title);
    self.Href = ko.observable("" || data.Href);
    self.Src = ko.observable("" || data.Src);
    self.error = ko.observable();
}
function Comment(data) {
    var self = this;
    data = data || {};
    // Persisted properties
    self.CommentId = data.CommentId;
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
function VM_Detail() {
    var self = this;
    self.categoryList = ko.observableArray();
    self.dontMissList = ko.observableArray();
    self.photoGalleryList = ko.observableArray();
    self.init = function () {
        var mappedCategory = $.map(detailData.categoryData, function (item) { return new category(item); });
        self.categoryList(mappedCategory);
        var mappedDontMissList = $.map(detailData.dontMissData, function (item) { return new dontMiss(item); });
        self.dontMissList(mappedDontMissList);
        var mappedPhotoGalleryList = $.map(detailData.photoGalleryData, function (item) { return new photoGallery(item); });
        self.photoGalleryList(mappedPhotoGalleryList);
    };
    self.error = ko.observable();
}