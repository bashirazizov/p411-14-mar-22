(function () {
    "use strict";

    let skip = 6;
    let projectCount = $("#projCount").val();

    //$(document).on("click", "#load-more-button", function (e) {
    //    e.preventDefault();
    //    $.ajax({
    //        url: "/Projects/LoadProjects?skip=" + skip,
    //        type: "get",
    //        success: function (res) {
    //            skip += 6;
    //            res.forEach(elem => {
    //                let project = `
    //                        <div class="col-lg-4 col-md-6 portfolio-item">
    //                            <div class="portfolio-wrap">
    //                                <img src="/assets/img/portfolio/${elem.image}" class="img-fluid" alt="">
    //                                <div class="portfolio-info">
    //                                    <h4>${elem.name}</h4>
    //                                    <div class="portfolio-links">
    //                                        <a href="/assets/img/portfolio/${elem.image}" data-gallery="portfolioGallery" class="portfolio-lightbox" title="@item.Name"><i class="bx bx-plus"></i></a>
    //                                        <a href="/Projects/Info/${elem.id}" title="More Details"><i class="bx bx-link"></i></a>
    //                                    </div>
    //                                </div>
    //                            </div>
    //                        </div>
    //                    `
    //                $(".portfolio-container").append(project)
    //            })
    //            if (skip >= projectCount) {
    //                $("#load-more-button").remove();
    //            }

    //        }
    //    })
    //})

    $(document).on("click", "#load-more-button", function (e) {
        e.preventDefault();
        $.ajax({
            url: "/Projects/LoadProjectsAsView?skip=" + skip,
            type: "get",
            success: function (res) {
                skip += 6;
                $(".portfolio-container").append(res);
                if (skip >= projectCount) {
                    $("#load-more-button").remove();
                }

            }
        })
    })

    $(document).on("keyup", "#search", function () {
        $("#search-results").html("");
        let query = $("#search").val();
        if (query.length>2) {
            $.ajax({
                url: "/Projects/SearchProject?query=" + query,
                type: "get",
                success: function (result) {
                    $("#search-results").append(result);
                }

            })
        }
    });

    $(document).on("keyup", "#searchv2", function () {
        $(".results-wrapper").html("");
        let query = $("#searchv2").val();
        if (query.length > 1) {
            $.ajax({
                url: "/Projects/SearchProjectv2?query=" + query,
                type: "get",
                success: function (result) {
                    console.log(result);
                    result.forEach(elem => {
                        let resultHtml = `
                        <a href="/Projects/Info/${elem.id}">
                            <img src="/assets/img/portfolio/${elem.image}" />
                            ${elem.name}
                        </a>
                        `
                        console.log(resultHtml)
                        $(".results-wrapper").append(resultHtml);
                    })
                }

            })
        }
    });
    /**
     * Easy selector helper function
     */
    const select = (el, all = false) => {
        el = el.trim()
        if (all) {
            return [...document.querySelectorAll(el)]
        } else {
            return document.querySelector(el)
        }
    }

    /**
     * Easy event listener function
     */
    const on = (type, el, listener, all = false) => {
        let selectEl = select(el, all)
        if (selectEl) {
            if (all) {
                selectEl.forEach(e => e.addEventListener(type, listener))
            } else {
                selectEl.addEventListener(type, listener)
            }
        }
    }

    /**
     * Easy on scroll event listener 
     */
    const onscroll = (el, listener) => {
        el.addEventListener('scroll', listener)
    }

    /**
     * Navbar links active state on scroll
     */
    let navbarlinks = select('#navbar .scrollto', true)
    const navbarlinksActive = () => {
        let position = window.scrollY + 200
        navbarlinks.forEach(navbarlink => {
            if (!navbarlink.hash) return
            let section = select(navbarlink.hash)
            if (!section) return
            if (position >= section.offsetTop && position <= (section.offsetTop + section.offsetHeight)) {
                navbarlink.classList.add('active')
            } else {
                navbarlink.classList.remove('active')
            }
        })
    }
    window.addEventListener('load', navbarlinksActive)
    onscroll(document, navbarlinksActive)

    /**
     * Scrolls to an element with header offset
     */
    const scrollto = (el) => {
        let header = select('#header')
        let offset = header.offsetHeight

        if (!header.classList.contains('header-scrolled')) {
            offset -= 20
        }

        let elementPos = select(el).offsetTop
        window.scrollTo({
            top: elementPos - offset,
            behavior: 'smooth'
        })
    }

    /**
     * Toggle .header-scrolled class to #header when page is scrolled
     */
    let selectHeader = select('#header')
    if (selectHeader) {
        const headerScrolled = () => {
            if (window.scrollY > 100) {
                selectHeader.classList.add('header-scrolled')
            } else {
                selectHeader.classList.remove('header-scrolled')
            }
        }
        window.addEventListener('load', headerScrolled)
        onscroll(document, headerScrolled)
    }

    /**
     * Back to top button
     */
    let backtotop = select('.back-to-top')
    if (backtotop) {
        const toggleBacktotop = () => {
            if (window.scrollY > 100) {
                backtotop.classList.add('active')
            } else {
                backtotop.classList.remove('active')
            }
        }
        window.addEventListener('load', toggleBacktotop)
        onscroll(document, toggleBacktotop)
    }

    /**
     * Mobile nav toggle
     */
    on('click', '.mobile-nav-toggle', function (e) {
        select('#navbar').classList.toggle('navbar-mobile')
        this.classList.toggle('bi-list')
        this.classList.toggle('bi-x')
    })

    /**
     * Mobile nav dropdowns activate
     */
    on('click', '.navbar .dropdown > a', function (e) {
        if (select('#navbar').classList.contains('navbar-mobile')) {
            e.preventDefault()
            this.nextElementSibling.classList.toggle('dropdown-active')
        }
    }, true)

    /**
     * Scrool with ofset on links with a class name .scrollto
     */
    on('click', '.scrollto', function (e) {
        if (select(this.hash)) {
            e.preventDefault()

            let navbar = select('#navbar')
            if (navbar.classList.contains('navbar-mobile')) {
                navbar.classList.remove('navbar-mobile')
                let navbarToggle = select('.mobile-nav-toggle')
                navbarToggle.classList.toggle('bi-list')
                navbarToggle.classList.toggle('bi-x')
            }
            scrollto(this.hash)
        }
    }, true)

    /**
     * Scroll with ofset on page load with hash links in the url
     */
    window.addEventListener('load', () => {
        if (window.location.hash) {
            if (select(window.location.hash)) {
                scrollto(window.location.hash)
            }
        }
    });

    /**
     * Testimonials slider
     */
    new Swiper('.testimonials-slider', {
        speed: 600,
        loop: true,
        autoplay: {
            delay: 5000,
            disableOnInteraction: false
        },
        slidesPerView: 'auto',
        pagination: {
            el: '.swiper-pagination',
            type: 'bullets',
            clickable: true
        },
        breakpoints: {
            320: {
                slidesPerView: 1,
                spaceBetween: 20
            },

            1200: {
                slidesPerView: 2,
                spaceBetween: 20
            }
        }
    });

    /**
     * Porfolio isotope and filter
     */
    window.addEventListener('load', () => {
        let portfolioContainer = select('.portfolio-container.isotoped');
        if (portfolioContainer) {
            let portfolioIsotope = new Isotope(portfolioContainer, {
                itemSelector: '.portfolio-item',
                layoutMode: 'fitRows'
            });

            let portfolioFilters = select('#portfolio-flters li', true);

            on('click', '#portfolio-flters li', function (e) {
                e.preventDefault();
                portfolioFilters.forEach(function (el) {
                    el.classList.remove('filter-active');
                });
                this.classList.add('filter-active');

                portfolioIsotope.arrange({
                    filter: this.getAttribute('data-filter')
                });
                portfolioIsotope.on('arrangeComplete', function () {
                    AOS.refresh()
                });
            }, true);
        }

    });

    /**
     * Initiate portfolio lightbox 
     */
    const portfolioLightbox = GLightbox({
        selector: '.portfolio-lightbox'
    });

    /**
     * Portfolio details slider
     */
    new Swiper('.portfolio-details-slider', {
        speed: 400,
        loop: true,
        autoplay: {
            delay: 5000,
            disableOnInteraction: false
        },
        pagination: {
            el: '.swiper-pagination',
            type: 'bullets',
            clickable: true
        }
    });

    /**
     * Animation on scroll
     */

})()