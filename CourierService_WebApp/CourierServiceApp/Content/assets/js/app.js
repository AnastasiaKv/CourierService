
$(function() {

    $('.nav-tabs[data-toggle="tab-hover"] > li > a').hover(function() {
        $(this).tab('show');
    });

    $('.container-categories').perfectScrollbar();
    
    $('input.icheck').iCheck({
        checkboxClass: 'icheckbox_flat',
        radioClass: 'iradio_flat'
    });

    $('.menu-cart').hover(function() {
        $('.mycart-container').perfectScrollbar();
    }); 

    $('label.tree-toggler').click(function() {
        $(this).parent().children('ul.tree').toggle(300);
    });

    $("input[name=searchTxt]").focus(function() {
        var newWidth = $('.search-box').outerWidth() - 30 - (15 * 2);

        $(this).css({
            width: 150 + 'px'
        });

        $('#userInfo').animate({
            opacity: 0
        });
    });


    $("input[name=searchTxt]").blur(function() {
        $(this).css({
            width: ''
        });

        $('#userInfo').animate({
            opacity: 1
        });
    });

    $("#price-slider").ionRangeSlider({
        min: 0,
        max: 1000,
        type: 'double',
        //prefix: "$",
        maxPostfix: "+",
        prettify: false,
        hasGrid: true,
        gridMargin: 7
    });

    $("#img_01").elevateZoom({
        gallery: 'gallery-thumbs',
        cursor: 'pointer',
        galleryActiveClass: "active",
        imageCrossfade: true,
        loadingIcon: "spinner.gif"
    });

    $("#zoom_03").bind("click", function(e) {
        var ez = $('#zoom_03').data('elevateZoom');
        ez.closeAll(); //NEW: This function force hides the lens, tint and window   
        $.fancybox(ez.getGalleryList());
        return false;
    });

    var quantity_spinner = $("input[name='quantity']");

    quantity_spinner.TouchSpin({
        min: 1,
        max: 100,
        stepinterval: 1,
        prefix: ''
    });

});




