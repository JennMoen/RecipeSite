namespace RecipeApp {

    angular.module('RecipeApp', ['ui.router', 'ngResource', 'ui.bootstrap', 'angular-filepicker']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider,
        filepickerProvider: any
    ) => {
        filepickerProvider.setKey('A6fbCENdXQh6IbTjEzVeQz')
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: RecipeApp.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('myRecipes', {
                url: '/myRecipes',
                templateUrl: '/ngApp/views/myRecipes.html',
                controller: RecipeApp.Controllers.MyRecipesController,
                controllerAs: 'controller'
            })
            .state('recipeDetails', {
                url: '/recipeDetails/:id',
                templateUrl: '/ngApp/views/recipeDetails.html',
                controller: RecipeApp.Controllers.RecipeDetailController,
                controllerAs: 'controller'
            })
            .state('menus', {
                url: '/menus',
                templateUrl: '/ngApp/views/menus.html',
                controller: RecipeApp.Controllers.MenuController,
                controllerAs: 'controller'
            })
            .state('menuDetails', {
                url: '/menuDetails/:id',
                templateUrl: '/ngApp/views/menuDetails.html',
                controller: RecipeApp.Controllers.MenuDetailController,
                controllerAs: 'controller'
            })
            .state('notes', {
                url: '/notes',
                templateUrl: '/ngApp/views/notes.html',
                controller: RecipeApp.Controllers.NoteController,
                controllerAs: 'controller'
            })
            .state('addRecipe', {
                url: '/addRecipe',
                templateUrl: '/ngApp/views/addRecipe.html',
                controller: RecipeApp.Controllers.AddRecipeController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: RecipeApp.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: RecipeApp.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: RecipeApp.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });


    //the yeoman code has an authInterceptor factory here--I just copied it for now

    angular.module('RecipeApp').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('RecipeApp').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });


}