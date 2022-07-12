/* -----------------------------
     * Bootstrap components init
     * Script file: bootstrap.bundle.js
     * Documentation about used plugin:
     * https://v4-alpha.getbootstrap.com/getting-started/introduction/
* ---------------------------*/

CRUMINA.Bootstrap = function () {
	//  Activate the Tooltips
	$('[data-toggle="tooltip"], [rel="tooltip"]').tooltip();

	// And Popovers
	$('[data-toggle="popover"]').popover();

	/* -----------------------------
	   * Replace select tags with bootstrap dropdowns
	   * Documentation about used plugin:
	   * https://silviomoreto.github.io/bootstrap-select/
	   * ---------------------------*/
	$('.selectpicker').selectpicker();

	/* -----------------------------
	 * Date time picker input field
	 * Script file: daterangepicker.min.js, moment.min.js
	 * Documentation about used plugin:
	 * https://v4-alpha.getbootstrap.com/getting-started/introduction/
	 * ---------------------------*/
	var date_select_field = $('input[name="datetimepicker"]');
	/*moment.locale('uk');*/
	if (date_select_field.length) {
		var start = moment().subtract(29, 'days');

		date_select_field.daterangepicker({
			minDate: '12/05/1900',
			startDate: start,
			autoUpdateInput: false,
			singleDatePicker: true,
			showDropdowns: true,
			locale: {
				format: 'DD/MM/YYYY'
			}
		});
		date_select_field.on('focus', function () {
			$(this).closest('.form-group').addClass('is-focused');
		});
		date_select_field.on('apply.daterangepicker', function (ev, picker) {
			$(this).val(picker.startDate.format('DD/MM/YYYY'));
			$(this).closest('.form-group').addClass('is-focused');
		});
		date_select_field.on('hide.daterangepicker', function () {
			if ('' === $(this).val()) {
				$(this).closest('.form-group').removeClass('is-focused');
			}
		});

	}
};

$(document).ready(function () {
	CRUMINA.Bootstrap();
});

/* -----------------------------
     * End * Init Bootstrap components init
* ---------------------------*/


/*--------------------------------------------------------------------------------------------------------------------*/


/* -----------------------------
     * Forms validation added Errors Messages
* ---------------------------*/

CRUMINA.FormValidation = function () {
	$('.needs-validation').each(function () {
		var form = $(this)[0];
		form.addEventListener("submit", function (event) {
			if (form.checkValidity() == false) {
				event.preventDefault();
				event.stopPropagation();
			}
			form.classList.add("was-validated");
		}, false);
	});
};

$(document).ready(function () {
	CRUMINA.FormValidation();
});

/* -----------------------------
   * End * Init Forms validation added Errors Messages
* ---------------------------*/


/*--------------------------------------------------------------------------------------------------------------------*/


/* -----------------------------
     * FullCalendar Init
     * Script file: fullcalendar.js
     * https://fullcalendar.io/
* ---------------------------*/

CRUMINA.fullCalendar = function () {
	var calendarEl = document.getElementById('calendar');

	var calendar = new FullCalendar.Calendar(calendarEl, {
		plugins: ['interaction', 'dayGrid', 'timeGrid'],
		defaultView: 'dayGridMonth',
		defaultDate: '2019-05-07',
		header: {
			left: 'prev',
			center: 'title',
			right: 'next,dayGridMonth,timeGridWeek,timeGridDay'
		},
		buttonText: {
			month:    ' ',
			week:     ' ',
			day:      ' '
		},
		buttonIcons: {
			prev: 'far fa-chevron-left',
			next: 'far fa-chevron-right'
		},

		eventClick: function (info) {
			var url = info.event.url;
			var is_modal = url.match(/^modal\:(#[-\w]+)$/);
			if(!is_modal) {
				return;
			}

			info.jsEvent.preventDefault();
			var modal = is_modal[1];

			$(modal).modal('show');
		},
		events: [
			{
				title: 'Chris Greyson’s Bday',
				start: '2019-05-08',
				url: 'modal:#public-event'
			},
			{
				title: 'Make Dinner Plans...',
				start: '2019-05-08',
				url: 'modal:#private-event'
			},
			{
				title: 'Jenny’s Birthday...',
				start: '2019-05-30',
				url: 'modal:#private-event'
			},
			{
				title: 'Videocall to talk...',
				start: '2019-05-30',
				url: 'modal:#public-event'
			},
			{
				title: 'Breakfast at the...',
				start: '2019-05-26',
				url: 'modal:#public-event'
			},
			{
				title: 'Send the new...',
				start: '2019-05-26',
				url: 'modal:#private-event'
			},
			{
				title: 'Take Querty to the...',
				start: '2019-05-26',
				url: 'modal:#public-event'
			}
		]
	});

	calendar.render();
};

$(document).ready(function () {
	if(($('#calendar')).length > 0){
		CRUMINA.fullCalendar();
	}
});

/* -----------------------------
     * End * Init FullCalendar
* ---------------------------*/


/*--------------------------------------------------------------------------------------------------------------------*/


/* -----------------------
 * Init Fixed Header
 * Script file: Headroom.js
 * Copyright (c) 2017 Nick Williams - http://wicky.nillia.ms/headroom.js
 * --------------------- */

$(document).ready(function () {
	var $header = $('#header--standard');

	if ($header.length) {
		$header.headroom(
			{
				"offset": 100,
				"tolerance": 5,
				"classes": {
					"initial": "animated",
					"pinned": "slideDown",
					"unpinned": "slideUp"
				}
			}
		);
	}
});

/* -----------------------
   * End * Init Fixed Header
 * --------------------- */


/*--------------------------------------------------------------------------------------------------------------------*/


/* -----------------------
 * Init Ion.RangeSlider
 * Script file: ion.rangeSlider.js
 * GitHub page:     https://github.com/IonDen/ion.rangeSlider
 * --------------------- */

CRUMINA.rangeSlider = function () {
	$(".range-slider-js").ionRangeSlider({
			type: "double",
			grid: true,
			min: 0,
			max: 1000,
			from: 200,
			to: 800,
			prefix: "$"
		}
	);
};

$(document).ready(function () {
	CRUMINA.rangeSlider();
});

/* -----------------------
   * End * Init Range Slider
 * --------------------- */


/*--------------------------------------------------------------------------------------------------------------------*/


/* -----------------------------
	* Init Isotope sorting
	* Script file: isotope.pkgd.js
	* http://isotope.metafizzy.co
* ---------------------------*/

CRUMINA.IsotopeSort = function () {
	var $containerSort = $('.sorting-container');
	$containerSort.each(function () {
		var $current = $(this);
		var layout = ($current.data('layout').length) ? $current.data('layout') : 'masonry';
		$current.isotope({
			itemSelector: '.sorting-item',
			layoutMode: layout,
			percentPosition: true
		});

		$current.imagesLoaded().progress(function () {
			$current.isotope('layout');
		});

		var $sorting_buttons = $current.siblings('.sorting-menu').find('li');

		$sorting_buttons.on('click', function () {
			if ($(this).hasClass('active')) return false;
			$(this).parent().find('.active').removeClass('active');
			$(this).addClass('active');
			var filterValue = $(this).data('filter');
			if (typeof filterValue != "undefined") {
				$current.isotope({filter: filterValue});
				return false;
			}
		});
	});
};

$(document).ready(function () {
	CRUMINA.IsotopeSort();
});

/* -----------------------------
	* End * Init Isotope sorting
* ---------------------------*/


/*--------------------------------------------------------------------------------------------------------------------*/


/* -----------------------
 * Init Progress bars Animation
 * Script file: jquery.appear.js
 * https://github.com/morr/jquery.appear/
* --------------------- */

$(document).ready(function () {
	var $progress_bar = $('.skills-item');

	$progress_bar.each(function () {
		$progress_bar.appear({force_process: true});
		$progress_bar.on('appear', function () {
			var current_bar = $(this);
			if (!current_bar.data('inited')) {
				current_bar.find('.skills-item-meter-active').fadeTo(300, 1).addClass('skills-animate');
				current_bar.data('inited', true);
			}
		});
	});
});

/* -----------------------
   * End * Init Progress bars Animation
* --------------------- */


/*--------------------------------------------------------------------------------------------------------------------*/


/* -----------------------------
	* Lightbox popups for media
	* Script file: jquery.magnific-popup.min.js
	* Documentation about used plugin:
	* http://dimsemenov.com/plugins/magnific-popup/documentation.html
* ---------------------------*/

CRUMINA.mediaPopups = function () {
	$('.play-video').magnificPopup({
		disableOn: 700,
		type: 'iframe',
		mainClass: 'mfp-fade',
		removalDelay: 160,
		preloader: false,
		fixedContentPos: false
	});
	$('.js-zoom-image').magnificPopup({
		type: 'image',
		removalDelay: 500, //delay removal by X to allow out-animation
		callbacks: {
			beforeOpen: function () {
				// just a hack that adds mfp-anim class to markup
				this.st.image.markup = this.st.image.markup.replace('mfp-figure', 'mfp-figure mfp-with-anim');
				this.st.mainClass = 'mfp-zoom-in';
			}
		},
		closeOnContentClick: true,
		midClick: true
	});
	$('.js-zoom-gallery').each(function () {
		$(this).magnificPopup({
			delegate: 'a',
			type: 'image',
			gallery: {
				enabled: true
			},
			removalDelay: 500, //delay removal by X to allow out-animation
			callbacks: {
				beforeOpen: function () {
					// just a hack that adds mfp-anim class to markup
					this.st.image.markup = this.st.image.markup.replace('mfp-figure', 'mfp-figure mfp-with-anim');
					this.st.mainClass = 'mfp-zoom-in';
				}
			},
			closeOnContentClick: true,
			midClick: true
		});
	});
};

$(document).ready(function () {

	if (typeof $.fn.magnificPopup !== 'undefined'){
		CRUMINA.mediaPopups();
	}
});

/* -----------------------
   * End * Init Media Popups
* --------------------- */


/*--------------------------------------------------------------------------------------------------------------------*/


/* -----------------------------
     * Equal height elements Init
     * Script file: jquery.matchHeight.js
     * Documentation about used plugin:
     * http://brm.io/jquery-match-height/
* ---------------------------*/

CRUMINA.equalHeight = function () {
	$('.js-equal-child').find('.theme-module').matchHeight({
		property: 'min-height'
	});
};

$(document).ready(function () {
	if (typeof $.fn.matchHeight !== 'undefined'){
		CRUMINA.equalHeight();
	}
});

/* -----------------------
   * End * Init Equal height elements
* --------------------- */


/*--------------------------------------------------------------------------------------------------------------------*/


/* -----------------------------
     * Material design js effects
     * Script file: material.min.js
     * Documentation about used plugin:
     * http://demos.creative-tim.com/material-kit/components-documentation.html
* ---------------------------*/

CRUMINA.Materialize = function () {
	$.material.init();

	$('.checkbox > label').on('click', function () {
		$(this).closest('.checkbox').addClass('clicked');
	})
};

$(document).ready(function () {
	CRUMINA.Materialize();
});

/* -----------------------
   * End * Init Materialize
* --------------------- */


/*--------------------------------------------------------------------------------------------------------------------*/


/* -----------------------------
 * Top Search bar function
 * Script file: selectize.min.js
 * Documentation about used plugin:
 * https://github.com/selectize/selectize.js
 * ---------------------------*/

$(document).ready(function () {
	var topUserSearch = $('.js-user-search');

	if (topUserSearch.length) {
		topUserSearch.selectize({
			delimiter: ',',
			persist: false,
			maxItems: 2,
			valueField: 'name',
			labelField: 'name',
			searchField: ['name'],
			options: [
				{image: 'img/avatar30-sm.jpg', name: 'Marie Claire Stevens', message:'12 Friends in Common', icon:'olymp-happy-face-icon'},
				{image: 'img/avatar54-sm.jpg', name: 'Marie Davidson', message:'4 Friends in Common', icon:'olymp-happy-face-icon'},
				{image: 'img/avatar49-sm.jpg', name: 'Marina Polson', message:'Mutual Friend: Mathilda Brinker', icon:'olymp-happy-face-icon'},
				{image: 'img/avatar36-sm.jpg', name: 'Ann Marie Gibson', message:'New York, NY', icon:'olymp-happy-face-icon'},
				{image: 'img/avatar22-sm.jpg', name: 'Dave Marinara', message:'8 Friends in Common', icon:'olymp-happy-face-icon'},
				{image: 'img/avatar41-sm.jpg', name: 'The Marina Bar', message:'Restaurant / Bar', icon:'olymp-star-icon'}
			],
			render: {
				option: function(item, escape) {
					return '<div class="inline-items">' +
						(item.image ? '<div class="author-thumb"><img src="' + escape(item.image) + '" alt="avatar"></div>' : '') +
						'<div class="notification-event">' +
						(item.name ? '<span class="h6 notification-friend"></a>' + escape(item.name) + '</span>' : '') +
						(item.message ? '<span class="chat-message-item">' + escape(item.message) + '</span>' : '') +
						'</div>'+
						(item.icon ? '<span class="notification-icon"><svg class="' + escape(item.icon) + '"><use xlink:href="icons/icons.svg#' + escape(item.icon) + '"></use></svg></span>' : '') +
						'</div>';
				},
				item: function(item, escape) {
					var label = item.name;
					return '<div>' +
						'<span class="label">' + escape(label) + '</span>' +
						'</div>';
				}
			}
		});
	}
});

/* -----------------------
   * End * Init Top Search bar function
* --------------------- */


/*--------------------------------------------------------------------------------------------------------------------*/


/* -----------------------
 * Init Sticky Sidebar function
 * Script file: sticky-sidebar.js
 * https://github.com/abouolia/sticky-sidebar
* --------------------- */

CRUMINA.StickySidebar = function () {
	var $header = $('#site-header');

	$('.crumina-sticky-sidebar').each(function () {

		var sidebar = new StickySidebar (this, {
			topSpacing: $header.height(),
			bottomSpacing: 0,
			containerSelector: false,
			innerWrapperSelector: '.sidebar__inner',
			resizeSensor: true,
			stickyClass: 'is-affixed',
			minWidth: 0
		})
	});
};

$(document).ready(function () {
	CRUMINA.StickySidebar();
});

/* -----------------------
   * End * Init Sticky Sidebar function
* --------------------- */


/*--------------------------------------------------------------------------------------------------------------------*/


/* -----------------------------
     * Sliders and Carousels
     * Script file: swiper.jquery.min.js
     * Documentation about used plugin:
     * http://idangero.us/swiper/api/
* ---------------------------*/

var swipers = {};

$(document).ready(function () {
	var initIterator = 0;
	var $breakPoints = false;
	$('.swiper-container').each(function () {

		var $t = $(this);
		var index = 'swiper-unique-id-' + initIterator;

		$t.addClass('swiper-' + index + ' initialized').attr('id', index);
		$t.find('.swiper-pagination').addClass('pagination-' + index);

		var $effect = ($t.data('effect')) ? $t.data('effect') : 'slide',
			$crossfade = ($t.data('crossfade')) ? $t.data('crossfade') : true,
			$loop = ($t.data('loop') == false) ? $t.data('loop') : true,
			$showItems = ($t.data('show-items')) ? $t.data('show-items') : 1,
			$scrollItems = ($t.data('scroll-items')) ? $t.data('scroll-items') : 1,
			$scrollDirection = ($t.data('direction')) ? $t.data('direction') : 'horizontal',
			$mouseScroll = ($t.data('mouse-scroll')) ? $t.data('mouse-scroll') : false,
			$autoplay = ($t.data('autoplay')) ? parseInt($t.data('autoplay'), 10) : 0,
			$autoheight = ($t.hasClass('auto-height')) ? true: false,
			$slidesSpace = ($showItems > 1) ? 20 : 0;

		if ($showItems > 1) {
			$breakPoints = {
				480: {
					slidesPerView: 1,
					slidesPerGroup: 1
				},
				768: {
					slidesPerView: 2,
					slidesPerGroup: 2
				}
			}
		}

		swipers['swiper-' + index] = new Swiper('.swiper-' + index, {
			pagination: '.pagination-' + index,
			paginationClickable: true,
			direction: $scrollDirection,
			mousewheelControl: $mouseScroll,
			mousewheelReleaseOnEdges: $mouseScroll,
			slidesPerView: $showItems,
			slidesPerGroup: $scrollItems,
			spaceBetween: $slidesSpace,
			keyboardControl: true,
			setWrapperSize: true,
			preloadImages: true,
			updateOnImagesReady: true,
			autoplay: $autoplay,
			autoHeight: $autoheight,
			loop: $loop,
			breakpoints: $breakPoints,
			effect: $effect,
			fade: {
				crossFade: $crossfade
			},
			parallax: true,
			onSlideChangeStart: function (swiper) {
				var sliderThumbs = $t.siblings('.slider-slides');
				if (sliderThumbs.length) {
					sliderThumbs.find('.slide-active').removeClass('slide-active');
					var realIndex = swiper.slides.eq(swiper.activeIndex).attr('data-swiper-slide-index');
					sliderThumbs.find('.slides-item').eq(realIndex).addClass('slide-active');
				}
			}
		});
		initIterator++;
	});


	//swiper arrows
	$('.btn-prev').on('click', function () {
		var sliderID = $(this).closest('.slider-slides').siblings('.swiper-container').attr('id');
		swipers['swiper-' + sliderID].slidePrev();
	});

	$('.btn-next').on('click', function () {
		var sliderID = $(this).closest('.slider-slides').siblings('.swiper-container').attr('id');
		swipers['swiper-' + sliderID].slideNext();
	});

	//swiper arrows
	$('.btn-prev-without').on('click', function () {
		var sliderID = $(this).closest('.swiper-container').attr('id');
		swipers['swiper-' + sliderID].slidePrev();
	});

	$('.btn-next-without').on('click', function () {
		var sliderID = $(this).closest('.swiper-container').attr('id');
		swipers['swiper-' + sliderID].slideNext();
	});


	// Click on thumbs
	$('.slider-slides .slides-item').on('click', function () {
		if ($(this).hasClass('slide-active')) return false;
		var activeIndex = $(this).parent().find('.slides-item').index(this);
		var sliderID = $(this).closest('.slider-slides').siblings('.swiper-container').attr('id');
		swipers['swiper-' + sliderID].slideTo(activeIndex + 1);
		$(this).parent().find('.slide-active').removeClass('slide-active');
		$(this).addClass('slide-active');

		return false;
	});

});

/* -----------------------
   * End * Init Swipers
* --------------------- */


/*--------------------------------------------------------------------------------------------------------------------*/


/* -----------------------
 * COUNTER NUMBERS Init
 * Script file: jquery.waypoints.js
 * https://github.com/imakewebthings/waypoints
 * --------------------- */

$(document).ready(function () {
	var $counter = $('.counter');

	if ($counter.length) {
		$counter.each(function () {
			jQuery(this).waypoint(function () {
				$(this.element).find('span').countTo();
				this.destroy();
			}, {offset: '95%'});
		});
	}
});

/* -----------------------
   * End * Init COUNTER NUMBERS
* --------------------- */

/* -----------------------
  * Create the map
  * https://leafletjs.com/
  * --------------------- */

CRUMINA.maps = {
	maps: {
		mapUSA: {
			config: {
				id: 'map',
				map: {
					center: new L.LatLng(38.897663, -77.036575),
					zoom: 12,
					maxZoom: 18,
					layers: new L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/Canvas/World_Light_Gray_Base/MapServer/tile/{z}/{y}/{x}', {
						maxZoom: 16,
						attribution: ''
					})
				},
				icon: {
					iconSize  : [36, 54],
					iconAnchor: [22, 94],
					className : 'icon-map'
				}
			},
			markers: [
				{
					coords: [38.897663, -77.036575],
					icon: 'map-marker.png'
				}
			]
		}
	},
	init: function () {
		var _this = this;

		for (var key in this.maps) {
			var data = this.maps[key];

			if (!data.config || !data.markers) {
				continue;
			}

			if (!document.getElementById(data.config.id)) {
				continue;
			}

			var map = new L.map(data.config.id, data.config.map);
			var cluster = L.markerClusterGroup({
				iconCreateFunction: function (cluster) {
					var childCount = cluster.getChildCount();
					var config = data.config.cluster;
					return new L.DivIcon({
						html: '<div><span>' + childCount + '</span></div>',
						className: 'marker-cluster marker-cluster-' + key,
						iconSize: new L.Point(config.iconSize[0], config.iconSize[1])
					});
				}
			});
			data.markers.forEach(function (item) {
				data.config.icon['iconUrl'] = './img/' + item.icon;
				var icon = L.icon(data.config.icon);

				var marker = L.marker(item.coords, {icon: icon});
				cluster.addLayer(marker);
			});

			map.addLayer(cluster);
			this.disableScroll(jQuery("#" + data.config.id), map);
		}
	},
	disableScroll: function ($map, map) {
		map.scrollWheelZoom.disable();

		$map.bind('mousewheel DOMMouseScroll', function (event) {
			event.stopPropagation();
			if (event.ctrlKey == true) {
				event.preventDefault();
				map.scrollWheelZoom.enable();
				setTimeout(function () {
					map.scrollWheelZoom.disable();
				}, 1000);
			} else {
				map.scrollWheelZoom.disable();
			}
		});
	}
};

$(document).ready(function () {
	CRUMINA.maps.init();
});