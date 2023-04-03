var isBlock = false;
var waiting = '<div class="progress-container"> <div class="progress"> <div class="progress-bar"> <div class="progress-shadow"></div></div></div></div>';
var options = {
    AjaxWait: {
        AjaxWaitMessage: waiting,
        AjaxWaitMessageCss: { top: "60px", border: "none" },
        Index: 999999
    },
    AjaxErrorMessage: "<h6>Error! please contact the monkey!</h6>",
    SessionOut: {
        StatusCode: 401,
        RedirectUrl: '/Account/Login'
    }
};

var AjaxGlobalHandler = {
    Initiate: function (options) {
        $.ajaxSetup({
            async: false,
            cache: false,
        });

        // Ajax events fire in following order
        $(document).ajaxStart(function (data) {
            if (!isBlock) {
                $.mbqBlockUI();
            }
        })
            .ajaxError(function (e, xhr, opts, thrownError) {
                if (options.SessionOut.StatusCode === xhr.status) {
                    document.location.replace(options.SessionOut.RedirectUrl);
                    return;
                }
                if (500 === xhr.status) {
                    $(".closeIcon").click();
                }
                bindErrors(xhr.status + ": " + thrownError, options);
                $.mbqUnBlockUI();
            })
            .ajaxStop(function () {
                $.mbqUnBlockUI();
            })
            .ajaxSend(function (e, xhr, opts) {

            })
            .ajaxSuccess(function (e, xhr, opts) {
              
            }).ajaxComplete(function (e, xhr, opts) {

            });
    }
};

function bindErrors(data, settings) {
    var errs = data;
    if (data.value !== undefined)
        errs = data.value;
    if (settings.error !== undefined) {
        settings.error(errs);
    } else if (settings.targetError != undefined) {
        settings.targetError.html(errs);
    } else {

        var $ctx = '<div class="row alert alert-error">Lỗi</div>';
        if (Object.prototype.toString.call(errs) === '[object Array]') {
            var ul = '<ul class="error">';
            for (var i = 0; i < errs.length; i++) {
                var li = '<li>' + errs[i] + '</li>';
                ul += li;
            }
            ul += '</ul>';
            $ctx = $ctx.replace('Lỗi', ul);
        } else {
            $ctx = errs;
        }

        $.mbqAlert({
            title: 'Lỗi',
            type: 'error',
            content: $ctx
        });
    }
}

function handleAjax(option) {
    var mode = option.method != undefined ? option.method : option.data != null ? "POST" : "GET";
    $.ajax({
        url: option.url,
        type: mode,
        async: false,
        contentType: option.contentType,
        processData: option.processData,
        data: option.data == undefined ? {} : option.data,
        success: function (data, status, xhr) {
            if (option.success && option.success !== undefined)
                $.mbqAjaxSuccess(data, option);
            else {
                if (data.success === true) {
                    if (data.dialog !== undefined && data.dialog == true) {
                        $.mbqDialog({
                            content: data.value.Views,
                            title: data.value.Title
                        });
                        $.mbqGetFuction("", ["data", "status", "xhr"]).apply(this, arguments);
                    } else {
                        $('#' + option.targetId).html(data.value);
                        $.mbqGetFuction("", ["data", "status", "xhr"]).apply(this, arguments);
                        //$('#' + option.targetId).InitFormat();
                    }
                } else if (data.success === false) { 
                    if (data.dialog !== undefined && data.dialog == true) {
                        $.mbqAlert({
                            title: 'Lỗi',
                            type: 'error',
                            columnClass: "col-md-4 col-md-offset-4 ",
                            content: data.value
                        });
                        
                        $.mbqGetFuction("", ["data", "status", "xhr"]).apply(this, arguments); 
                    } else {
                        bindErrors(data, { targetError: $('#' + option.targetId) });
                        $('#' + option.targetId).addClass('text-danger');
                    }
                } else {
                    $('#' + option.targetId).html(data);
                }
            }
            $.mbqUnBlockUI();
        }
    });
}

(function ($) {
    $.mbqGetFuction = function (code, argNames) {
        var fn = window, parts = (code || "").split(".");
        while (fn && parts.length) {
            fn = fn[parts.shift()];
        }
        if (typeof (fn) === "function") {
            return fn;
        }
        argNames.push(code);
        return Function.constructor.apply(null, argNames);
    };
    $.mbqAjaxSuccess = function (data, settings) {
        if (data.success !== undefined && data.success === false)
            bindErrors(data, settings);
        else if (settings.success !== undefined)
            settings.success(data);
        else if (settings.target !== undefined)
            if (data.value !== undefined) {
                settings.target.html($.parseHTML(data.value));
            } else {
                settings.target.html($.parseHTML(data));
            }
    };
    $.mbqAjax = function (option) {
        if (option.confirm !== undefined && option.confirm.content !== undefined) {
            $.mbqConfirm({
                content: option.confirm.content,
                title: option.confirm.confimTitle != undefined ? option.confirm.confimTitle : "Xác nhận",
                confirm: function (obj) {
                    handleAjax(option);
                }
            });
        } else {
            handleAjax(option);
        }
    };
    $.fn.extend({
        //for ajax link
        mbqAjax: function () {
            var target = $(this).data("ajax-update");
            if (target !== undefined && target !== null) {
                target = target.replace("#", '');
            }
            var url = $(this).attr("data-ajax-url");
            $.mbqAjax({
                url: url,
                confirm: { title: "Xác nhận", content: $(this).data("ajax-confirm") },
                targetId: target,
                method: $(this).attr("data-ajax-method")
            });
            return false;
        }
    });
    $.mbqBlockUI = function () {
        if (!isBlock) {
            $("#waitting").append(waiting);
            $("#waitting").show();
            isBlock = true;
            $("#waitting").css("z-index", 99999999);
        }
    }
    $.mbqUnBlockUI = function () {
        $("#waitting").css("z-index", -1);
        $("#waitting").html("");
        $("#waitting").hide();
        isBlock = false;
    }

})(jQuery);