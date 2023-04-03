(function ($) {
    $.fn.pager = function (config) {
        function setHandler(inx, item) {
            var me = $(item);
            var pageNum = me.attr("data-page");
            
            me.on("click", function() {
                var actionUrl = decodeURIComponent(config.url).replace("#", pageNum); 
                $.mbqAjax({url: actionUrl, targetId: config.updateTargetId, success: config.ajaxSuccess, error: config.ajaxFailure});
                return false;
            });
        }

        //Bind click event handler for page links
        $(this).find("a").each(function (inx, item){setHandler(inx, item)});
        $(this).find("input").each(function (inx, item) { setHandler(inx, item) });
    };
}(jQuery));

