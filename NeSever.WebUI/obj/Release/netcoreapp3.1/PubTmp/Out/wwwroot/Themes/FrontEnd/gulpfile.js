/**
 * Created by Crumina on 09.11.2017.
 */

/*=========== GULP + Plugins init ==============*/

var gulp = require('gulp'),
	plumber = require('gulp-plumber'), // generates an error message
	prefixer = require('gulp-autoprefixer'), // automatically prefixes to css properties
	uglify = require('gulp-uglify-es').default, // for minimizing js-files
	cssmin = require('gulp-cssmin'), // for minimizing css-files
	svgmin = require('gulp-svgmin'), // for minimizing svg-files
	handlebars = require('gulp-compile-handlebars'), // dynamically generates an HTML page from parts
	rename = require('gulp-rename'), // to rename files
	sass = require('gulp-sass'), // for compiling scss-files to css
	webserver = require('browser-sync'), // for online synchronization with the browser
	imagemin = require('gulp-imagemin'), // for minimizing images-files
	cache = require('gulp-cache'), // connecting the cache library
	del = require('del'), // for the cleaning APP
	concat = require('gulp-concat'),
	zip = require('gulp-zip'),
	replace = require('gulp-replace'),
	sourcemaps = require('gulp-sourcemaps'),
	htmlhint = require("gulp-htmlhint"); // for HTML-validation


/*=========== ON-Line synchronization from browsers ==============*/

/* server settings */
var config = {
	server: {
		baseDir: 'src'
	},
	notify: false
};

// server start
gulp.task('webserver', function () {
	webserver(config);
});


/*=========== Compile SCSS ==============*/

gulp.task('sass', function(cb) {

    gulp.src('src/sass/*.scss')
		.pipe(sourcemaps.init())
		.pipe(plumber())
        .pipe(sass(
			{
				linefeed: "crlf"
			}
		))
		.pipe(prefixer())
		.pipe(gulp.dest('./src/css'))
        .pipe(gulp.dest('./app/css'))
		.pipe(cssmin())
		.pipe(rename({
			suffix: '.min'
		}))
		.pipe(sourcemaps.write('./maps'))
		.pipe(gulp.dest('./src/css'))
		.pipe(gulp.dest('./app/css'));

	gulp.src('src/Bootstrap/scss/*.scss')
		.pipe(plumber())
		.pipe(sass(
			{
				linefeed: "crlf"
			}
		))
		.pipe(cssmin())
		.pipe(sourcemaps.write('./maps'))
		.pipe(gulp.dest('./src/Bootstrap/dist/css'))
		.pipe(gulp.dest('./app/Bootstrap/dist/css'))

		.pipe(webserver.reload({stream: true}));
		cb();
});

/*=========== Compile JS ==============*/

gulp.task('js', function (cb) {

	gulp.src('src/js/**/*.js')
		.pipe(uglify())
		.pipe(gulp.dest('./app/js'));

	gulp.src('src/Bootstrap/dist/js/*.js')
		.pipe(uglify())
		.pipe(gulp.dest('./src/Bootstrap/dist/js'))
		.pipe(gulp.dest('./app/Bootstrap/dist/js'))

		.pipe(webserver.reload({stream: true}));

	cb();
});


/*=========== Watch ==============*/

gulp.task('watch', function() {
    gulp.watch('src/sass/**/*.scss', gulp.series('sass'));
    gulp.watch('src/Bootstrap/scss/*.scss', gulp.series('sass'));
});


/*=========== Minimization IMAGE ==============*/

gulp.task('images', function(cb){
    gulp.src('src/img/*')
        .pipe(cache(imagemin({
            interlaced: true
        })))
        .pipe(gulp.dest('app/img'));

	gulp.src('src/screenshots/*')
		.pipe(cache(imagemin({
			interlaced: true
		})))
		.pipe(gulp.dest('app/screenshots'));

	cb();
});

gulp.task('compress', function(cb) {
	gulp.src('src/img/*')
		.pipe(imagemin())
		.pipe(gulp.dest('app/img'));

	gulp.src('src/screenshots/*')
		.pipe(imagemin())
		.pipe(gulp.dest('app/screenshots'));
	cb();
});


/*=========== Minimization SVG ==============*/

gulp.task('svg-min', function (cb) {
	gulp.src('src/svg-icons/*.svg')
		.pipe(svgmin({
			plugins: [{
				removeDoctype: true
			}, {
				removeComments: true
			}, {
				cleanupNumericValues: {
					floatPrecision: 2
				}
			}, {
				convertColors: {
					names2hex: true,
					rgb2hex: true
				}
			}]
		}))
		.pipe(gulp.dest('app/svg-icons'));

	cb();
});


/*============= Copy Files unchanged ==============*/

gulp.task('copy-files', function(cb) {
    gulp.src('src/fonts/**/*')
        .pipe(gulp.dest('app/fonts'));

	gulp.src('src/mp3/*.*')
		.pipe(gulp.dest('app/mp3'));

	gulp.src('src/videos/*.*')
		.pipe(gulp.dest('app/videos'));

	cb();
});


/*============= Auto-deleting temporary files ==============*/

gulp.task('clean-app', function(cb){
    del(['app/**/*']);
	cb();
});


/*============= Handlebars ==============*/

gulp.task('html', function() {
	return gulp.src('src/pages-sources/*.hbs')
		.pipe(handlebars({}, {
			ignorePartials: true,
			batch: ['src/partials/']
		}))
		.pipe(rename({
			extname: '.html'
		}))
		.pipe(gulp.dest('src'))
		.pipe(gulp.dest('app'))
});


/*============= HTML-validator ==============*/

gulp.task('html-valid', function(cb) {
	gulp.src("app/*.html")
		.pipe(htmlhint());
	cb();
});


/*============= Join tasks ==============*/

gulp.task('default', gulp.parallel('webserver', 'watch', 'sass'));

gulp.task('build', gulp.series('clean-app', 'html', 'html-valid', 'sass', 'js', 'svg-min', 'images', 'compress', 'copy-files'));


