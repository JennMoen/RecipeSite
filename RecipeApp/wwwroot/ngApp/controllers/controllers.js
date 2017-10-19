var RecipeApp;
(function (RecipeApp) {
    var Controllers;
    (function (Controllers) {
        var HomeController = (function () {
            function HomeController($http) {
                var _this = this;
                this.$http = $http;
                this.message = "Welcome to your recipe headquarters!";
                $http.get('/api/recipes/recents').then(function (results) {
                    _this.recents = results.data;
                });
            }
            return HomeController;
        }());
        Controllers.HomeController = HomeController;
        var MyRecipesController = (function () {
            function MyRecipesController($http) {
                var _this = this;
                this.$http = $http;
                this.message = "My recipes";
                $http.get('/api/recipes').then(function (results) {
                    _this.recipes = results.data;
                });
            }
            return MyRecipesController;
        }());
        Controllers.MyRecipesController = MyRecipesController;
        var AddRecipeController = (function () {
            function AddRecipeController(filepickerService, $scope, $http, $state) {
                this.filepickerService = filepickerService;
                this.$scope = $scope;
                this.$http = $http;
                this.$state = $state;
            }
            AddRecipeController.prototype.pickFile = function () {
                this.filepickerService.pick({ mimetype: 'image/*' }, this.fileUploaded.bind(this));
            };
            AddRecipeController.prototype.fileUploaded = function (file) {
                this.file = file;
                this.$scope.$apply();
                this.image = file.url;
            };
            AddRecipeController.prototype.addRecipe = function (recipe, imageUrl) {
                var _this = this;
                recipe.imageUrl = imageUrl;
                this.$http.post('/api/recipes', recipe, recipe.imageUrl)
                    .then(function (results) {
                    _this.$state.go('myRecipes');
                })
                    .catch(function (reason) {
                    console.log(reason);
                });
            };
            return AddRecipeController;
        }());
        Controllers.AddRecipeController = AddRecipeController;
    })(Controllers = RecipeApp.Controllers || (RecipeApp.Controllers = {}));
})(RecipeApp || (RecipeApp = {}));
//# sourceMappingURL=controllers.js.map