/*
 *Setting for history.js
 */
$(document).ready(function () {
    var History = window.History;
    if (History.enabled) {
        State = History.getState();
        // set initial state to first page that was loaded
        History.pushState({ urlPath: window.location.pathname }, $("title").text(), State.urlPath);
    } else {
        return false;
    }

    var loadAjaxContent = function (target, url) {
        $.myAjax({
            url: url,
            dataType: 'html',
            success: function (data) {
                $(target).html(data);
                //var temp = document.createElement('div');
                //temp.innerHTML = data;
                //if (temp.querySelector('div.container-section'))
                //    $(target).html(temp.querySelector('div.container-section').innerHTML);
                //else
                //    $(target).html(data);
                //debugger;
                //  ko.cleanNode($(target).get()[0]);
                //if (url != null && url.trim() == "" || url == "http://localhost:44302/" || url == "http://localhost:44302" || url.indexOf('Group') > 1 || url.indexOf('Category') > 1)
                //    ko.applyBindings({ koStory: vmStory }, $('div.container-section').get()[0]);
                //else if (url.indexOf('Story') > 1)
                //    ko.applyBindings({ koDetail: vmDetail }, $('div.container-section').get()[0]);
            }
        });
    };

    var updateContent = function (State) {
        loadAjaxContent(State.data.target, State.data.urlPath);
    };

    // Content update and back/forward button handler
    History.Adapter.bind(window, 'statechange', function () {
        updateContent(History.getState());
    });

    // navigation link handler
    $('body').on('click', 'a', function (e) {
        if ($(this).data('loadfull'))
            return true;
        var urlPath = $(this).attr('href');
        var title = $(this).attr('title');
        var target = $(this).data('target');
        var newpath = urlPath;
        var type = $(this).data('loadmylayout');
        if (type)
            newpath += '?loadmylayout=1';
        History.pushState({ urlPath: newpath, target: target }, title, urlPath);
        return false; // continue default click action of <a ...>
    });
})
/*
 * Custom jquery.validation defaults
 */
$.validator.setDefaults({
    highlight: function (element, errorClass, validClass) {
        if (element.type === 'radio') {
            this.findByName(element.name).addClass(errorClass).removeClass(validClass);
        } else {
            $(element).addClass(errorClass).removeClass(validClass);
            $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
        }
    },
    unhighlight: function (element, errorClass, validClass) {
        if (element.type === 'radio') {
            this.findByName(element.name).removeClass(errorClass).addClass(validClass);
        } else {
            $(element).removeClass(errorClass).addClass(validClass);
            $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
        }
    },
    showErrors: function (errorMap, errorList) {
        this.defaultShowErrors();
        // If an element is valid, it doesn't need a tooltip
        $("." + this.settings.validClass).tooltip("destroy");

        // Add tooltips
        for (var i = 0; i < errorList.length; i++) {
            var error = errorList[i];
            //var id = '#' + error.element.id;
            //var isInModal = $(id).parents('.modal').length > 0;
            //, container: isInModal, html: false }) // Activate the tooltip on focus
            $(error.element).tooltip({ trigger: "focus" })
				.attr('data-tooltip', 'tooltip-danger')
				.attr("data-original-title", error.message);
        }
    }
});