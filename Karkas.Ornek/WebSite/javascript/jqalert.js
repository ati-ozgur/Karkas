// JQAlert
// 
// Author: Jon Davis <jon@jondavis.net>
// v0.9
//
// Required reference:  jQuery v1.2.3 (or higher) @ http://www.jquery.com/
// Suggested reference: jqDnR by Brice Burgess @ http://dev.iceburg.net/jquery/jqDnR/

if (!window.jQuery) {
    throw("jQuery must be referenced before using jqalert");
} else 

if (!window.jqalerter) {
    window.jqalerter = {
    
        alert: function(message, title, options, windowElement) {
            if (!options) {
                options = window.jqalerter.getDefaultOptions();
            } else {
                var opt = window.jqalerter.getDefaultOptions();
                options = window.jqalerter.overrideOptions(options, opt);
                window.jqalerter.getDefaultOptions(); // restore defaults
            }
            if (!windowElement) {
	            windowElement = jqalerter.getBaseWindowElement(options);
                document.body.insertBefore(windowElement, document.body.firstChild);
                options.customWindow = false;
            } else {
                if (!($(windowElement).attr("class") && $(windowElement).attr("class").indexOf("jqalert-container") > -1)) {
                    windowElement = $(windowElement).find(".jqalert-container")[0];
                }
                options.customWindow = true;
            }
            if (title) {
                $(windowElement).find(".jqalert-title").html(title);
            } else {
                $(windowElement).find(".jqalert-title").css("display", "none");
            }
            $(windowElement).find(".jqalert-message").html(message);
            if (options.backgroundColor) {
                $(windowElement).css("background-color", options.backgroundColor);
            }
            if (options.color) {
                $(windowElement).css("color", options.color);
            }
            window.jqalerter.addWindowOptions(windowElement, options);
            if (options.newWindow) {
                window.jqalerter.showWindow(windowElement, options);
            } else {
                window.jqalerter.showVirtualWindow(windowElement, options);
            }
        },
            
        getDefaultOptions: function(style) {
            if (!style) style = jqalerter.getDefaultStyleName();
            switch (style) {
                case "windowsSlate":
                    window.jqalerter.defaultOptions = {
                        fadeInRate: false, //200,
                        fadeOutRate: false, //200,
                        blockOpacity: 0.5,
                        blockColor: "Black",
                        backgroundColor: "Gray",
                        color: "Black",
                        windowOpacity: 1,
                        modal: true,
                        icon: null, // << use a url here
                        minWidth: "200px",
                        maxWidth: $(document).width(),
                        minHeight: "15px",
                        maxHeight: $(document).width(),
                        dynamicCss: true,
                        draggable: true,
                        windowCss: window.jqalerter.getDefaultWindowCss(style),
                        titleCss: window.jqalerter.getDefaultTitleCss(style),
                        bodyCss: window.jqalerter.getDefaultBodyCss(style),
                        buttonsCss: window.jqalerter.getDefaultButtonsCss(style),
                        iconCss: window.jqalerter.getDefaultIconCss(style),
                        showEffect: function(windowElement, initFunction) {
                            //debugger;
                            $(windowElement).css("opacity", "0");
                            $(windowElement).css("top", parseInt($(windowElement).css("top")) - 5);
                            $(windowElement).animate({
                                    "top": parseInt($(windowElement).css("top")) + 5,
                                    "opacity": 1
                                }, "200px", null, initFunction);
                            
                        },
                        hideEffect: function(windowElement, finalizeFunction) {
                            //debugger;
                            $(windowElement).css("opacity", "1");
                            $(windowElement).animate({
                                    "top": parseInt($(windowElement).css("top")) - 5,
                                    "opacity": 0
                                }, "200px", null, finalizeFunction);
                        },
                        setOption: function(name, value) {
                                this[name] = value;
                                return this;
                            },
                        styleName: jqalerter.getDefaultStyleName()
                    };
                 
            }
            
            return window.jqalerter.defaultOptions;
        },
        
        showVirtualWindow : function(windowElement, options) {
 	            //debugger;
            //$(windowElement).css("display", "");
            if (windowElement.parentNode && $(windowElement.parentNode).css("display") == "none") {
                $(windowElement.parentNode).css("display", "");
            }
            if ($(windowElement).attr("class") && 
                $(windowElement).attr("class").indexOf("jqalert-container") > -1) {
                $(windowElement).css("display", "");
            }
            $(windowElement).find(".jqalert-container").css("display", "");
            $(windowElement).find(".jqalert").css("display", "");
            
            $(windowElement).css("position", "fixed");
            
            if (!options) {
                options = window.jqalerter.getDefaultOptions();
            }
            if (options.dynamicCss) {
                if (!options.windowCss && options.windowCss == null) {
                    options.windowCss = window.jqalerter.getDefaultWindowCss(options.styleName);
                }
                if (!options.titleCss && options.titleCss == null) {
                    options.titleCss = window.jqalerter.getDefaultTitleCss(options.styleName);
                }
                if (!options.bodyCss && options.bodyCss == null) {
                    options.bodyCss = window.jqalerter.getDefaultBodyCss(options.styleName);
                }
                if (!options.buttonsCss && options.buttonsCss == null) {
                    options.buttonsCss = window.jqalerter.getDefaultButtonsCss(options.styleName);
                }
                if (options.icon && !options.iconCss && options.iconCss == null) {
                    options.iconCss = window.jqalerter.getDefaultIconCss(options.styleName);
                }
                if (options.windowCss) {
                    $(windowElement).css(options.windowCss);
                }
                var titleEl = $(windowElement).find(".jqalert-title");
                if (options.titleCss) {
                    if (titleEl.length > 0) {
                        titleEl.css(options.titleCss);
                    } else {
                        titleEl.css("display", "none");
                    }
                }
                if (options.bodyCss) {
                    $(windowElement).find(".jqalert-message").css(options.bodyCss);
                }
                if (options.buttonsCss) {
                    $(windowElement).find(".jqalert-buttons").css(options.buttonsCss);
                }
            }
            var iconEl = $(windowElement).find(".jqalert-icon");

            if (options.icon) {
                if (options.dynamicCss && options.iconCss) {
                    iconEl.css(options.iconCss);
                }
                iconEl.css("background-image", "url('" + options.icon + "')");
            } else {
                iconEl.css("display", "none");
            }
            
            if (options.modal) {
                if (!$(windowElement).css("z-index")) {
                    $(windowElement).css("z-index", (90+window.jqalerter.getWindowOptions().length).toString());
                }
                window.jqalerter.blockUI(options);
            }
            
            var elWidth = $(windowElement).width();   // requires jQuery Dimensions extension
            var elHeight = $(windowElement).height(); 
            if (!options.minWidth) {
                options.minWidth = 300;
            }
            if (!options.minHeight) {
                options.minHeight = 15;
            }
            if (!options.maxWidth) {
                options.maxWidth = $(document).width();
            }
            if (!options.maxHeight) {
                options.maxHeight = $(document).height();
            }
            if (elWidth < options.minWidth) {
                $(windowElement).css("width", options.minWidth);
                elWidth = parseInt($(windowElement).css("width"));
            }
            if (elWidth > options.maxWidth) {
                $(windowElement).css("width", options.maxWidth);
                elWidth = parseInt($(windowElement).css("width"));
            }
            if (elHeight < options.minHeight) {
                $(windowElement).css("height", options.minHeight);
                elHeight = parseInt($(windowElement).css("height"));
            }
            if (elHeight > options.maxHeight) {
                $(windowElement).css("height", options.maxHeight);
                elHeight = parseInt($(windowElement).css("height"));
            }
            var winWidth = $(window).width();
            var winHeight = $(window).height();
            $(windowElement)
                .css("top", (winHeight / 2) - (elHeight / 2))
                .css("left", (winWidth / 2) - (elWidth / 2));
            if (!options.fadeInRate && options.fadeInRate == null) {
                options.fadeInRate = 200;
            }

            if (options.draggable && $.fn.jqDrag) {
                $(windowElement).jqDrag('.jqalert-title');
            }
            
            var init = function() {
                var btn = $(windowElement).find(".jqalert-buttons button");
                if (btn.length > 0) btn = btn[0];
                else {
                    btn = $(windowElement).find(".jqalert-buttons input");
                    if (btn.length > 0) btn = btn[0];
                }
                btn.focus();
            };
            var xinit = null;
            if (!options.showEffect) xinit = init;
            if (options.fadeInRate) {
                $(windowElement)
                    .css("display", "none");
                    //.css("filter", "alpha(opacity=0)")
                    //.css("opacity", "0");
                $(windowElement).fadeIn(options.fadeInRate, xinit);
            } else {
                if (xinit) xinit();
            }
            if (options.showEffect) {
                options.showEffect(windowElement, init);
            } else {
                if (!xinit) init();
            }
            
        },
        
        getEmptyOptions: function() {
            return {
                fadeInRate: false, //200,
                fadeOutRate: false, //200,
                blockOpacity: 0.5,
                blockColor: "Black",
                backgroundColor: null, //"Gray",
                color: null, //"Black",
                windowOpacity: null, //1,
                modal: null, //true,
                icon: null, // << use a url here
                minWidth: null, //300,
                maxWidth: null, //$(document).width(),
                minHeight: null, //15,
                maxHeight: null, //$(document).width(),
                dynamicCss: false,
                windowCss: false, //window.jqalerter.getDefaultWindowCss(),
                titleCss: false, //window.jqalerter.getDefaultTitleCss(),
                bodyCss: false, //window.jqalerter.getDefaultBodyCss(),
                buttonsCss: false, //window.jqalerter.getDefaultButtonsCss(),
                iconCss: false, //window.jqalerter.getDefaultIconCss(),
                showEffect: null, // for effects, use function(windowElement) { .. }.
                hideEffect: null,
                draggable: null,
                setOption: function(name, value) {
                        this[name] = value;
                        return this;
                    },
                styleName: jqalerter.getDefaultStyleName()
            };
        },
        defaultOptions : false, // don't use defaultOptions directly; use getDefaultOptions()
        
        "getBaseWindowElement": function(options) {
            var em = 
                "<div class=\"jqalert-container\" >"
                + "<div class=\"jqalert\">"
                + " <div class=\"jqalert-title\">"
                + " </div>"
                + " <div class=\"jqalert-icon\">"
                + " </div>"
                + " <div class=\"jqalert-message\">"
                + " </div>"
                + " <div class=\"jqalert-buttons\">"
                + "  <button onclick=\""
                + "window.jqalerter.closeVirtualWindow(this.parentNode.parentNode.parentNode);"
                + "\"";
            if (options.modal) {
                em += " onblur=\""
                + "this.focus();"
                + "\"";
            }
            em += ">OK</button>"
                + " </div>"
                + "</div>"
                + "</div>";
            return $(em)[0];
	    },
	    
	    addWindowOptions: function(windowElement, options) {
	        if (!window.jqalerter.windowOptions) {
	            var windowOptions = new Array();
	            window.jqalerter.windowOptions = windowOptions;
	        }
	        window.jqalerter.windowOptions.push({
	                "windowElement": windowElement,
	                "options": options
	            });
	    },
	    
	    getWindowOptions: function(windowElement) {
	        if (!windowElement) {
	            if (!window.jqalerter.windowOptions) {
	                window.jqalerter.windowOptions = new Array();
	            } 
                return window.jqalerter.windowOptions;
	        }
	        if (window.jqalerter.windowOptions) {
	            var windowOptions = new Array();
	            var i,q;
	            for (i=0; i<window.jqalerter.windowOptions.length; i++) {
	                if (window.jqalerter.windowOptions[i].windowElement == windowElement) {
	                    return window.jqalerter.windowOptions[i].options;
	                }
	            }
	        }
	        return null;
	    }, 
		    
	    removeWindowOptions: function(windowElement, options) {
	        if (window.jqalerter.windowOptions) {
	            var windowOptions = new Array();
	            var i,q;
	            for (i=0; i<windowOptions.length; i++) {
	                if (windowOptions[i].windowElement == windowElement) {
	                    break;
	                }
	            }
	            var windowOptions = new Array();
	            for (q=0; q<i; q++) {
	                windowOptions.push(window.jqalerter.windowOptions[q]);
	            }
	            for (q=i+1; q<window.jqalerter.windowOptions.length; q++) {
	                windowOptions.push(window.jqalerter.windowOptions[q]);
	            }
	            window.jqalerter.windowOptions = windowOptions;
	        }
	    },
		    
        showWindow: function(windowElement, options) {
            alert("todo: showWindow  (not implemented)");
        },
        
        getDefaultStyleName: function () {
            return "windowsSlate";
        }, 
        
        getDefaultWindowCss: function(style) {
            if (!style) style = jqalerter.getDefaultStyleName();
            var ret = { };
            switch (style) {
                case "windowsSlate":
                default:
                    ret = { 
                        "background-color": "#e0e0e0",
                        border: "outset 1px",
                        padding: "1px",
                        "z-index": (91+window.jqalerter.getWindowOptions().length).toString()/*,
                        position: "fixed"*/
                        
                        // prerender for dimensions using opacity of 0
                        /*opacity: 1, 
                        filter: "alpha(opacity=100)"*/
                        
                    };
                    break;
            }
            return ret;
        },
        
        getDefaultTitleCss: function(style) {
            if (!style) style = jqalerter.getDefaultStyleName();
            var ret = { };
            switch (style) {
                case "windowsSlate":
                default:
                    ret = { 
                        "background-color": "Navy",
                        "border": "inset 1px",
                        "color": "White",
                        "font-weight": "bold",
                        "padding" : "2px 3px 3px 3px;",
                        "cursor" : "default"
                    };
                    break;
            }
            return ret;
        },
        
        getDefaultBodyCss: function(style) {
            if (!style) style = jqalerter.getDefaultStyleName();
            var ret = { };
            switch (style) {
                case "windowsSlate":
                default:
                    ret = { 
                        "margin": "5px 3px 2px 3px",
                        padding: "2px",
                        "min-height": "50px"
                    };
                    break;
            }
            return ret;
        },
        
        getDefaultButtonsCss: function(style) {
            if (!style) style = jqalerter.getDefaultStyleName();
            var ret = { };
            switch (style) {
                case "windowsSlate":
                default:
                    ret = { 
                        "text-align": "center",
                        "margin": "5px 0px 5px 0px"
                    };
                    break;
            }
            return ret;
        },
        
        getDefaultIconCss: function(style) {
            if (!style) style = jqalerter.getDefaultStyleName();
            var ret = { };
            switch (style) {
                case "windowsSlate":
                default:
                    ret = { 
                        "float": "left",
                        "width": "50px",
                        "height": "50px",
                        "margin": "5px",
                        "vertical-align": "middle",
                        "text-align": "center",
                        "background-repeat": "no-repeat",
                        "background-position": "center"
                    };
                    break;
            }
            return ret;
        },
        
 	    closeVirtualWindow: function(windowElement) {
	        var options = window.jqalerter.getWindowOptions(windowElement);
	        var fadeOutRate = 0;
	        if (options && options.fadeOutRate) {
	            fadeOutRate = options.fadeOutRate;
	        }
	        var finalize = function() {
                if (fadeOutRate > 0) {
                    $(windowElement).fadeOut(fadeOutRate, 
                        function () {
                            window.jqalerter.removeWindowOptions(windowElement);
                            if (options && !options.customWindow) {
                                windowElement.parentNode.removeChild(windowElement);
                            } else {
                                $(windowElement).css("display", "none");
                            }
                        });
                } else {
                    if (options && !options.customWindow) {
                        windowElement.parentNode.removeChild(windowElement);
                    } else {
                        $(windowElement).css("display", "none");
                    }
                    window.jqalerter.removeWindowOptions(windowElement);
                }
	        };
            if (options && options.hideEffect) {
                options.hideEffect(windowElement, finalize);
            } else {
                finalize();
            }
            if (options && options.modal) {
                window.jqalerter.unblockUI(options, windowElement);
            }
	    },
	    
       blockUI: function(options) {
            if (!options) {
                options = new Object();
            }
            if (options.fadeInRate == null) {
                options.fadeInRate = 200;
            }
            if (options.fadeOutRate == null) {
                options.fadeOutRate = 200;
            }
            if (options.blockOpacity == null) {
                options.blockOpacity = 0.5;
            }
            if (options.blockColor == null) {
                options.blockColor = "Black";
            }
            var blockerDiv = $("<div class=\"jqalerter-blocker\"></div>")[0];
            //blockerDiv.setAttribute("className", "jqalerter-blocker");
            $(blockerDiv)
                .css("position", "fixed")
                .css("width", $(document).width())
                .css("height", $(document).height())
                .css("top", 0)
                .css("left", 0)
                .css("z-index", "90")
                .css("overflow", "hidden")
                .css("background-color", options.blockColor)
                .css("display", "none");
            document.body.insertBefore(blockerDiv, document.body.firstChild);
            if (options.fadeInRate < 10) {
                $(blockerDiv)
                    .css("filter", "alpha(opacity=" + options.blockOpacity * 100 + ")")
                    .css("opacity", options.blockOpacity)
                    .css("display", "");
            } else {
                $(blockerDiv)
                    .css("filter", "alpha(opacity=1)")
                    .css("opacity", ".01")
                    .css("display", "")
                    .fadeTo(options.fadeInRate, options.blockOpacity);   
            }
            window.jqalerter.blockUIEvents(document.body);
        },
            
        blockUIEvents: function(el) {
            // todo (this is a temporary hack...
            // basically de-focuses input
            // and meanwhile the blocker div
            // is already mouse-blocking)
            var input = document.createElement("textarea");
            $(input)
                .css("filter", "alpha(opacity=0)")
                .css("opacity", "0")
                .css("position", "fixed")
                .css("top", "0")
                .css("left", "0");
            document.body.appendChild(input);
            input.focus();
            $(input).css("display", "none");
            document.body.removeChild(input);
        },
            
        unblockUI: function(options, windowElement) {
            var blockerJq = $(".jqalerter-blocker");
            if (blockerJq && blockerJq.length > 0) {
                var blockerElement = blockerJq[0];
                if (!options) {
                    if (windowElement) {
                        options = window.jqalerter.getWindowOptions(windowElement);
                    } else {
                        options = new Object();
                    }
                }
                if (options.fadeOutRate == null) {
                    options.fadeOutRate = 200;
                }
                if (options.fadeOutRate) {
                    blockerJq.fadeOut(options.fadeOutRate, 
                        function() {
                            blockerElement.parentNode.removeChild(blockerElement);
                        });
                } else {
                    blockerJq.css("display", "none");
                    blockerElement.parentNode.removeChild(blockerElement);
                }
            }
        },
        
        overrideOptions: function(src, target) {
            for (var n in src) {
                target[n] = src[n];
            }
            return target;
        }
    }
}

if (!window.jqalert) {
    window.jqalert = window.jqalerter.alert;
}