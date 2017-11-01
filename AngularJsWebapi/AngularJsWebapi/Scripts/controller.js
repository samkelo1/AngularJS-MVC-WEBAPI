var BooksControllers = angular.module("BooksControllers", []);
// this controller call the api method and display the list of employees  
// in list.html  
BooksControllers.controller("ListController", ['$scope', '$http',
    function ($scope, $http) {
        $http.get('/api/Books').success(function (data) {
            $scope.books = data;
        });
    }
]);
// this controller call the api method and display the record of selected employee  
// in delete.html and provide an option for delete  
BooksControllers.controller("DeleteController", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {
        $scope.id = $routeParams.id;
        $http.get('/api/books/' + $routeParams.id).success(function (data) {
            $scope.ISBN = data.ISBN;
            $scope.Title = data.Title;
            $scope.Subtitle = data.Subtitle;
            $scope.Description = data.Discription;
            $scope.Contributors = data.Contributors;
            $scope.Language = data.Language;
            $scope.PublicationDate = data.PublicationDate;
                    });
        $scope.delete = function () {
            $http.delete('/api/Books/' + $scope.id).success(function (data) {
                $location.path('/list');
            }).error(function (data) {
                $scope.error = "An error has occured while deleting Book! " + data;
            });
        };
    }
]);
// this controller call the api method and display the record of selected employee  
// in edit.html and provide an option for create and modify the employee and save the employee record  
/*BooksControllers.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {
        $http.get('/api/country').success(function (data) {
            $scope.countries = data;
        });
        $scope.id = 0;
        $scope.getStates = function () {
            var country = $scope.country;
            if (country) {
                $http.get('/api/country/' + country).success(function (data) {
                    $scope.states = data;
                });
            }
            else {
                $scope.states = null;
            }
        }*/
        $scope.save = function () {
            var obj = {
                id: $scope.id,
                ISBN: $scope.ISBN,
                Title: $scope.Title,
                Subtitle: $scope.Subtitle,
                Description: $scope.Description,
                Contributors: $scope.Contributors,
                Language: $scope.Language,
                PublicationDate: $scope.PublicationDate
               
            };
            if ($scope.id == 0) {
                $http.post('/api/Books/', obj).success(function (data) {
                    $location.path('/list');
                }).error(function (data) {
                    $scope.error = "An error has occured while adding book! " + data.ExceptionMessage;
                });
            }
            else {
                $http.put('/api/Books/', obj).success(function (data) {
                    $location.path('/list');
                }).error(function (data) {
                    console.log(data);
                    $scope.error = "An Error has occured while Saving book! " + data.ExceptionMessage;
                });
            }
        }
        if ($routeParams.id) {
            $scope.id = $routeParams.id;
            $scope.title = "Edit Book";
            $http.get('/api/Books/' + $routeParams.id).success(function (data) {
                $scope.ISBN = data.ISBN;
                $scope.Title = data.Title;
                $scope.Subtitle = data.Subtitle;
                $scope.Description = data.Description;
                $scope.Contributors = data.Contributors;
                $scope.Language = data.Language;
                $scope.PublicationDate = new Date(data.PublicationDate);
                $scope.getStates();
            });
        }
        else {
            $scope.title = "Create New Book";
        }
    }
]);