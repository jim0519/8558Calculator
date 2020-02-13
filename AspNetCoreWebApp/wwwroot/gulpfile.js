var gulp = require('gulp'),
    concat = require('gulp-concat');

var $ = require('gulp-load-plugins')();

//var app = {
//    srcPath: 'src/',   //源代码路径
//    devPath: 'build/',  //整合后的路径，开发路径
//    prdPath: 'dist/'  //生产环境路径
//};

gulp.task('style', function () {
    gulp.src(['./bower_components/bootstrap/dist/css/bootstrap.css',
        './bower_components/jquery-ui/themes/base/jquery-ui.css',
        './css/site.min.css'
    ])
        .pipe(concat('AllCss.css'))
        .pipe(gulp.dest('./css'));
});

gulp.task('js', function () {
    gulp.src(['./bower_components/jquery/dist/jquery.js',
        './bower_components/jquery-md5/*.js',
        './bower_components/jquery.cookie/*.js',
        './bower_components/bootstrap/dist/js/bootstrap.js',
        './bower_components/jquery-ui/jquery-ui.js',
        './js/site.js'])
        .pipe($.uglify())
        .pipe($.concat('AllJS.js'))
        .pipe(gulp.dest('./js'));
});

gulp.task('default', ['style','js']);