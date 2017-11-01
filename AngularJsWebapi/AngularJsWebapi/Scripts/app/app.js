var EmpApp = angular.module('BookApp', ['ngRoute', 'BooksControllers']);
EmpApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/list',
    {
        templateUrl: 'Books/list.html',
        controller: 'ListController'
    }).
    when('/create',
    {
        templateUrl: 'Books/edit.html',
        controller: 'EditController'
    }).
    when('/edit/:id',
    {
        templateUrl: 'Books/edit.html',
        controller: 'EditController'
    }).
    when('/delete/:id',
    {
        templateUrl: 'Books/delete.html',
        controller: 'DeleteController'
    }).
    otherwise(
    {
        redirectTo: '/list'
    });
}]);