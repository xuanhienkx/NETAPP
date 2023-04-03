$.fn.extend({
    mbqGrid: function (config) {
        var grid = $(this).gridmvc();

        function changeParamByName(href, newParam) {
            var param = newParam.split("=");
            var re = new RegExp("([?&])" + param[0] + "=.*?(&|$)", "i");
            if (href.match(re))
                return href.replace(re, '$1' + param[0] + "=" + param[1] + "$2");

            var link = href.indexOf("?") !== 1 ? "&" : "?";
            return href + link + newParam;
        }

        // clean up the grid header
        grid.jqContainer.find("th.grid-header").each(function () {
            var classesNumber = ['number', 'currency', 'currency', 'percent', 'percents'];
            for ( var cl in classesNumber) {
                if ($(this).hasClass(classesNumber[cl])) {
                    $(this).removeClass(classesNumber[cl]);
                    $(this).addClass('text-right');
                    break;
                }
            }
        });

        // set on click for sorting
        grid.jqContainer.find("th.grid-header>>a").each(function (inx, item) {
            var me = $(item);
            me.on("click", function () {
                var actionUrl = decodeURIComponent(config.url);
                var href = $(this).attr("href");
                var newParams = href.slice(href.indexOf("?") + 1).split("&");
                for (var i = 0; i < newParams.length; i++) {
                    actionUrl = changeParamByName(actionUrl, newParams[i]);
                }
                actionUrl = actionUrl.replace("#", config.currentIndex);
                $.mbqAjax({url:actionUrl, targetId: config.updateTargetId, success: grid.jqContainer.mbqGrid(config), error: config.ajaxFailure});

                return false;
            });
        });

        // apply context menu on the grid
        if (config.contextMenu != null) {
            $(this).find("table td").contextMenu({
                menuSelector: config.contextMenu,
                onInit: function (menu, target) {
                    var items = menu.find("li");
                    for (var i = 0; i < items.length; i++) {
                        var item = items[i];

                        // setup links
                        var link = $(item).attr("url");
                        var ajaxlink = $("a:first", item).attr("onclick");
                        if (link == undefined) {
                            if (ajaxlink !== undefined) {
                                link = $("a:first", item).data("ajax-url");
                                $(item).attr("url", link);
                            } else {
                                link = $("a:first", item).attr("href");
                                $(item).attr("url", link);
                            }
                        }
                        
                        var id = $('td:first', target.parent('tr')).text();
                        link = decodeURIComponent(link).replace("#", id);
                        //$("a:first", item).attr("href", "#");
                       
                        if (ajaxlink!==null && ajaxlink !== undefined && ajaxlink !== "") {
                            $("a:first", item).attr("data-ajax-url", link);
                        } else {
                            $("a:first", item).attr("href", link);
                        }
                        

                        // setup layout
                        var ew = $(item).attr("ew");
                        if (ew !== null && ew !== "" && ew !== undefined) {
                            var eWhen = JSON.parse(ew);
                            var currentValue = target.parent().find("td[data-name='" + eWhen.name + "']").html();
                            switch (eWhen.opr) {
                                case "=":
                                    if (currentValue !== eWhen.value)
                                        $(item).attr("disabled", "disabled").addClass("disabled");
                                    else
                                        $(item).removeAttr("disabled", "disabled").removeClass("disabled");
                                    break;
                                default:
                            }
                        }
                    }
                }
            });
        }

        GridMvc.prototype.applyFilterValues = function (initialUrl, columnName, values, skip) {
            var filters = this.jqContainer.find(".grid-filter");
            if (initialUrl.length > 0)
                initialUrl += "&";

            var url = "";
            if (!skip) {
                url += this.getFilterQueryData(columnName, values);
            }

            if (this.options.multiplefilters) { //multiple filters enabled
                for (var i = 0; i < filters.length; i++) {
                    if ($(filters[i]).attr("data-name") !== columnName) {
                        var filterData = this.parseFilterValues($(filters[i]).attr("data-filterdata"));
                        if (filterData.length === 0) continue;
                        if (url.length > 0) url += "&";
                        url += this.getFilterQueryData($(filters[i]).attr("data-name"), filterData);
                    } else {
                        continue;
                    }
                }
            }

            initialUrl = initialUrl + url;
            var link = initialUrl.indexOf("?") !== 0 ? "?" : "";
            url = decodeURIComponent(config.url).split("?")[0] + link + initialUrl;
            $.mbqAjax({url: url, targetId: config.updateTargetId,success: grid.jqContainer.mbqGrid(config), error: config.ajaxFailure});
        };
    }
});