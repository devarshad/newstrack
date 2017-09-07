//all knockout data setting
var vmMessage = new VM_Message();
var vmStory = new VM_Story();
var vmStoryByCategory = new StoryByCategory();
var vmStoryByGroup = new StoryByGroup();
var vmSM = new VM_SM();
var vmDetailLayout = new VM_Detail();
ko.applyBindings({
    koMesssages: vmMessage,
    // koStory: vmStory,
    // koStoryByGroup: vmStoryByGroup,
    //  koDetail: vmDetail
});
//ko.applyBindings({ koStoryByGroup: vmStoryByGroup }, $('div.detail-container')[0]);
$(document).ready(function () {
    vmMessage.init();
    // vmStory.init();
    // vmStoryByGroup.init();
    //vmDetail.init();
});

var photoGalleryData = [
    { ID: 1, href: '', src: '/Content/Images/Slider/acnemain_0.jpg', Title: 'What Say You: Would you forgive someone if they cheated on you?' },
    { ID: 2, href: '', src: '/Content/Images/Slider/passengermain_0.jpg', Title: 'What Say You: Would you forgive someone if they cheated on you?' },
    { ID: 3, href: '', src: '/Content/Images/Slider/prom.jpg', Title: 'What Say You: Would you forgive someone if they cheated on you?' },
    { ID: 4, href: '', src: '/Content/Images/Slider/WEIRDTRENDSMAIN.jpg', Title: 'What Say You: Would you forgive someone if they cheated on you?' },
    { ID: 5, href: '', src: '/Content/Images/Slider/acnemain_0.jpg', Title: 'What Say You: Would you forgive someone if they cheated on you?' }
];
var dontMissData = [
    { ID: 1, href: '', src: '/Content/Images/Slider/acnemain_0.jpg', Title: 'What Say You: Would you forgive someone if they cheated on you?' },
    { ID: 2, href: '', src: '/Content/Images/Slider/passengermain_0.jpg', Title: 'What Say You: Would you forgive someone if they cheated on you?' },
    { ID: 3, href: '', src: '/Content/Images/Slider/prom.jpg', Title: 'What Say You: Would you forgive someone if they cheated on you?' },
    { ID: 4, href: '', src: '/Content/Images/Slider/WEIRDTRENDSMAIN.jpg', Title: 'What Say You: Would you forgive someone if they cheated on you?' },
    { ID: 5, href: '', src: '/Content/Images/Slider/acnemain_0.jpg', Title: 'What Say You: Would you forgive someone if they cheated on you?' }
];
var categoryData = [{
    ID: 1,
    Title: 'Hot Topics'
}, {
    ID: 2,
    Title: 'Most Viewed'
}, {
    ID: 3,
    Title: 'Most Commented'
}, {
    ID: 4,
    Title: 'This Urban Jungle'
}, {
    ID: 5,
    Title: 'Courts & Crime'
}, {
    ID: 6,
    Title: 'Animania'
}, {
    ID: 7,
    Title: 'Wild Singapura'
}, {
    ID: 8,
    Title: 'GE2015'
}, {
    ID: 9,
    Title: 'Remembering Lee Kuan Yew'
}, {
    ID: 10,
    Title: 'In the Heartlands'
}, {
    ID: 11,
    Title: 'Top Mum Awards 2015'
}];
var detailData = { dontMissData: dontMissData, categoryData: categoryData, photoGalleryData: photoGalleryData };
var data = [{
    ID: 1,
    Title: 'LOLLIPOP',
    CategoryName: 'lollipop',
    stories: [{
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 2,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/watermain.jpg?itok=vZcz3vy2',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 3,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/pornmain.jpg?itok=ANCxmXOp',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, ]
}, {
    ID: 2,
    Title: 'YOUTHPHORIA',
    CategoryName: 'youthphoria',
    stories: [{
        Id: 1,
        LinkIcon: 'http://images.stompverticals.stomp.com.sg/youthphoria/styles/home_page_section_image/s3/article/images/featured/2015/12/TAIWANKINDERGARTENMAIN.jpg?itok=KVycDMfS',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 2,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/watermain.jpg?itok=vZcz3vy2',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 3,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/pornmain.jpg?itok=ANCxmXOp',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, ]
}, {
    ID: 3,
    Title: 'CLUB STOMP',
    CategoryName: 'clubstomp',
    stories: [{
        Id: 1,
        LinkIcon: 'http://images.stompverticals.stomp.com.sg/clubstomp/styles/thumbnail_198x124/s3/article/images/featured/2015/12/main%20haha.jpg?itok=63HuH2-Z',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 2,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/watermain.jpg?itok=vZcz3vy2',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 3,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/pornmain.jpg?itok=ANCxmXOp',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, {
        Id: 1,
        LinkIcon: 'http://images.lollipop.sg/files/styles/thumbnail_400x240/s3/article/images/featured/2015/12/mainsteven.jpg?itok=HHAgvAqA',
        Title: 'Superstar Steven Lim Kor Kor\' hits on \'chiobu...'
    }, ]
}, ];