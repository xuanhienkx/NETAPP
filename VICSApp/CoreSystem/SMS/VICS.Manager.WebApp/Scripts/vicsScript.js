(function($) {
        $.fn.contextMenu = function(settings) {
            return this.each(function() {
                // Open context menu
                $(this).on("contextmenu", function(e) {
                    // return native menu if pressing control
                    e.preventDefault();
                    if (e.ctrlKey) return;
                    var menu = $(settings.menuSelector);
                    var target = $(e.target);

                    // setup the layout of context menu
                    settings.onInit.call($(this), menu, target);

                    //open menu
                    menu.data("invokedOn", target)
                        .show()
                        .position({ my: "left top", at: "left top", of: target, collision: "none" })
                        .off('click')
                        .on('click', function(ev) {
                            $(this).hide();
                        });

                    return false;
                });

                //make sure menu closes on any click
                $(document).click(function() {
                    $(settings.menuSelector).hide();
                });
            });
        };
        $.fn.extend({
            mbqDialog: function (option) {
                $(this).click(function () {
                    $.mbqDialog(option);
                });
            },
            cleanFormat: function () {
                $(this).find(".currency,.number,p.percents").each(function (i) {
                    var self = $(this);
                    try {
                        var v = self.autoNumeric('get');
                        self.autoNumeric('destroy');
                        self.val(v);
                    } catch (err) {
                        console.log("Not an autonumeric field: " + self.attr("name"));
                    }
                });
            }
         
        });
        $.mbqDialog = function (option) {
            var style = "";
            var column = 'col-md-10 col-md-offset-2';
            if (option.columnClass !== undefined) {
                column = option.columnClass;
            }
            //if (option.width !== null)
            //    style = " style='margin: 0px auto;width:" + option.width + "px;'";

            var template = '<div class="jconfirm"><div class="jconfirm-bg"></div><div class="jconfirm-scrollpane"><div class="container"><div class="row"><div class="jconfirm-box-container span6 offset3"><div class="jconfirm-box"><div class="closeIcon"><span class="fa fa-times fa-inverse"></span></div><div class="title"></div><div class="content niceScroll"></div><div class="mbq-buttons"></div><div class="jquery-clear"></div></div></div></div></div></div></div>';
           
            $.dialog({
                template: template,
                resizable: true,
                async: false,
                content: option.content,
                columnClass: column,
                title: option.title,
                dialogClass: "modal-dialog",
                backgroundDismiss: false,
                closeIcon: true,
                confirmButton: false,
                cancelButton: false,
                theme: "mbqlight"
            });
            return false;
            //setTimeout(function () {
            //    $(function () {
            //        var $bt = $('.jconfirm-box .content').find(".buttons");
            //        $(document).find("div.jconfirm-box").find(".mbq-buttons").html($bt);
            //        $(document).find('.jconfirm-box .content').find(".buttons").remove();
            //        $(".currency,.number,.percent,.percents").on({
            //            click: function () {
            //                this.select();
            //            },
            //        });
            //       $.mbqUnBlockUI();
            //        AjaxGlobalHandler.Initiate(options);
            //    });
            //}, 300);

        }
        $.mbqConfirm = function (option) {
            var title = false;
            if (option.title !== undefined) {
                title = option.title;
            }
            var columnClass = 'col-md-6 col-md-offset-3';
            if (option.columnClass !== undefined) {
                columnClass = option.columnClass;
            }
            var content = '';
            if (typeof option === 'string') {
                content = option;
                title = 'Xác nhận';
            } else {
                content = option.content;
            }
            $.confirm({
                resizable: true,
                async: false,
                icon: "fa fa-question-circle fa-inverse",
                content: content,
                columnClass: columnClass,
                title: title,
                dialogClass: "modal-dialog",
                confirm: function () {
                    if (option.confirm !== undefined)
                        return option.confirm();
                    return true;
                },
                cancel: function () {

                },
                closeIcon: true,
                theme: "mbqlight",
                confirmButton: 'Có',
                cancelButton: 'Không',
                backgroundDismiss: true,
                confirmButtonClass: 'btn btn-primary',
                cancelButtonClass: 'btn btn-primary',
            });
        }
        $.mbqAlert = function (settings) {
            var title = 'Thông báo';
            var type = 'info';
            if (settings.type !== undefined && settings.type !== "") {
                type = settings.type;
            }
            if (settings.title !== undefined && settings.title !== "") {
                title = settings.title;
            }
            var alertSettings = {
                title: title,
                closeIcon: true,
                icon: settings.type === "info" ? "fa fa-exclamation fa-inverse" : "fa fa-exclamation-triangle fa-inverse",
                content: settings.content,
                confirm: function () {
                    if (settings.confirm !== undefined)
                        settings.confirm();
                    return;
                },
                confirmButton: 'Đóng',
                backgroundDismiss: true,
                theme: "mbqlight " + type,
                confirmButtonClass: 'btn btn-primary',
            };
            $.alert(alertSettings);
        }
})(jQuery);

// start page
$(document).ready(function() {
    AjaxGlobalHandler.Initiate(options);
    $('#side-menu').metisMenu();
    $(window).bind("load resize", function () {
        var topOffset = 50;
        var height = (this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.height;
        height = height - topOffset;
        if (height < 1) height = 1;
        if (height > topOffset) {
            setTimeout(function () {
                $("#page-wrapper").css("min-height", (height) + "px");
            }, 100); 
        }
    });
    
});