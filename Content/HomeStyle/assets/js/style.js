$(document).ready(function () {
    if ($('.home-header-slider').length > 0) {
        $(".home-header-slider").owlCarousel({
            items: 1,
            loop: true,
            dots: true,
            margin: 0,
            nav: false,
            autoplay: true,
            mouseDrag: false,
            animateOut: 'animate__fadeOut',
            animateIn: 'animate__fadeIn',
            autoplayHoverPause: false,
            autoplayTimeout: 4000,
            smartSpeed: 800,

        });
    }

    if ($('.home-mahsul-slider').length > 0) {
        $(".home-mahsul-slider").owlCarousel({
            items: 5,
            loop: false,
            dots: false,
            margin: 15,
            nav: true,
            autoplay: false,
            autoplayHoverPause: false,
            autoplayTimeout: 5000,
            smartSpeed: 800,
            navText: [
                '<i class="bi bi-chevron-left"></i>',
                '<i class="bi bi-chevron-right"></i>',
            ],
            responsive: {
                0: {
                    items: 1,
                    margin: 0,
                },
                685: {
                    items: 2,
                    margin: 40,
                },
                991: {
                    items: 2,
                    margin: 40,
                },
                1024: {
                    items: 3,
                },
                1200: {
                    items: 4,
                },
                1400: {
                    items: 5,
                },
                1600: {
                    items: 5,
                },
                1920: {
                    items: 5,
                },
            },
        });
    }



    $(".lang-downs > .dropdown-menu").hover(function () {
        $(".lang-downs > .nav-link").addClass("active");
    });

    $(".lang-downs > .dropdown-menu").mouseleave(function () {
        $(".lang-downs > .nav-link").removeClass("active");
    });

    $(".navicon").on("click", function () {
        $(this).toggleClass("navicon--active");
        $(".navbar-collapse").toggleClass("navbar-collapse--active");
        $("body,html").toggleClass("overflow");
        $(".overlay-body").toggle();
    });

    // sitedeki tüm dropdownları calıştırma  özelliği

    $(".js-down > li").click(function () {
        $(this).parent().prev().find("span").text($(this).text());
    });

    //dropdown ok toggle yönü
    $(".dropdown > .btn").on("show.bs.dropdown", function () {
        $(this).children(".bi-chevron-down").toggleClass("rotate-90");
    });

    $(".dropdown > .btn").on("hidden.bs.dropdown", function () {
        $(".bi-chevron-down").removeClass("rotate-90");
    });

    //mahsullar id ile cagırma işlemi
    $(".btn-mahsul").click(function () {
        let dataıd = $(this).attr("data-id");
        $(".btn-mahsul").removeClass("active");
        $(".loader").removeClass("d-none");
        $(this).addClass("active");
        $(".cards-main").html("");
        // $.ajax({
        //   url: "/url/" + dataıd,
        //   type: "GET",
        //   dataType: "html",
        //   success: function (dataıd) {
        setTimeout(() => {
            $(".cards-main").html(dataıd);
            $(".loader").addClass("d-none");
        }, 2000);
    });




    function beginx() {
        $(".btn").attr("disabled", "true");
    }
    function completex(response) {
        if (response.IsSuccess) {
            Swal.fire({
                icon: 'success',
                text: 'Formunuz başarıyla gönderildi',
                showConfirmButton: false,
                timer: 2000
            }).then(function () {
                $('form').find("input[type=text], textarea").val("");
            })
        }
        else {
            Swal.fire({
                icon: 'error',
                text: 'Formunuz gönderimi sırasında bir sorun oluştu.',
                showConfirmButton: false,
                timer: 2000
            }).then(function () {
                $('.btn').removeAttr("disabled");
            })
        }
    }
});

jQuery("img.svg").each(function () {
    var $img = jQuery(this);
    var imgID = $img.attr("id");
    var imgClass = $img.attr("class");
    var imgURL = $img.attr("src");
    jQuery.get(
        imgURL,
        function (data) {
            var $svg = jQuery(data).find("svg");
            if (typeof imgID !== "undefined") {
                $svg = $svg.attr("id", imgID);
            }
            if (typeof imgClass !== "undefined") {
                $svg = $svg.attr("class", imgClass + " replaced-svg");
            }
            $svg = $svg.removeAttr("xmlns:a");
            if (!$svg.attr("viewBox") && $svg.attr("height") && $svg.attr("width")) {
                $svg.attr(
                    "viewBox",
                    "0 0 " + $svg.attr("height") + " " + $svg.attr("width")
                );
            }
            $img.replaceWith($svg);
        },
        "xml"
    );
});