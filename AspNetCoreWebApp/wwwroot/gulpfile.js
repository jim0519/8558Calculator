var gulp = require('gulp'),
    concat = require('gulp-concat');

var $ = require('gulp-load-plugins')();

//var app = {
//    srcPath: 'src/',   //源代码路径
//    devPath: 'build/',  //整合后的路径，开发路径
//    prdPath: 'dist/'  //生产环境路径
//};

gulp.task('style', function () {
    gulp.src(['./bower_components/bootstrap/dist/css/*.css'])
        .pipe(concat('AllBootstrap.css'))
        .pipe(gulp.dest('./css'));
});

gulp.task('js', function () {
    gulp.src(['./bower_components/jquery/dist/*.min.js',
        './bower_components/jquery-md5/*.js'])
        .pipe($.uglify())
        .pipe($.concat('AllJS.js'))
        .pipe(gulp.dest('./js'));
});

gulp.task('default', ['style','js']);