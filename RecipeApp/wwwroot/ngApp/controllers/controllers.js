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
                $http.get('/api/categories/recipes').then(function (results) {
                    _this.categories = results.data;
                });
            }
            return MyRecipesController;
        }());
        Controllers.MyRecipesController = MyRecipesController;
        var RecipeDetailController = (function () {
            function RecipeDetailController($http, $state, $stateParams) {
                var _this = this;
                this.$http = $http;
                this.$state = $state;
                this.$stateParams = $stateParams;
                $http.get("/api/recipes/" + $stateParams['id']).then(function (results) {
                    _this.recipe = results.data;
                });
            }
            RecipeDetailController.prototype.addStep = function (step) {
                var _this = this;
                this.$http.post("/api/recipes/" + this.$stateParams['id'] + "/steps", step)
                    .then(function (results) {
                    _this.$state.reload();
                })
                    .catch(function (reason) {
                    console.log(reason);
                });
            };
            RecipeDetailController.prototype.addIngredient = function (ingredient) {
                var _this = this;
                this.$http.post("/api/recipes/" + this.$stateParams['id'] + "/ingredients", ingredient)
                    .then(function (results) {
                    _this.$state.reload();
                    console.log(ingredient);
                })
                    .catch(function (reason) {
                    console.log(reason);
                });
            };
            return RecipeDetailController;
        }());
        Controllers.RecipeDetailController = RecipeDetailController;
        var AddRecipeController = (function () {
            function AddRecipeController(filepickerService, $scope, $http, $state) {
                var _this = this;
                this.filepickerService = filepickerService;
                this.$scope = $scope;
                this.$http = $http;
                this.$state = $state;
                $http.get('/api/categories').then(function (results) {
                    _this.categories = results.data;
                });
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
        var MenuController = (function () {
            function MenuController($http) {
                var _this = this;
                this.$http = $http;
                $http.get('/api/menus').then(function (results) {
                    _this.menus = results.data;
                });
            }
            return MenuController;
        }());
        Controllers.MenuController = MenuController;
        var MenuDetailController = (function () {
            function MenuDetailController($http, $state, $stateParams) {
                var _this = this;
                this.$http = $http;
                this.$state = $state;
                this.$stateParams = $stateParams;
                $http.get("/api/menus/" + this.$stateParams['id']).then(function (results) {
                    _this.menu = results.data;
                });
            }
            return MenuDetailController;
        }());
        Controllers.MenuDetailController = MenuDetailController;
        var NoteController = (function () {
            function NoteController($http, $state, $stateParams) {
                var _this = this;
                this.$http = $http;
                this.$state = $state;
                this.$stateParams = $stateParams;
                $http.get('/api/notes').then(function (results) {
                    _this.notes = results.data;
                });
            }
            NoteController.prototype.addNote = function (note) {
                var _this = this;
                this.$http.post('/api/notes', note).then(function (results) {
                    _this.$state.reload();
                    console.log(note);
                }).catch(function (reason) {
                    console.log(reason);
                });
            };
            return NoteController;
        }());
        Controllers.NoteController = NoteController;
        var NoteDetailController = (function () {
            function NoteDetailController($http, $state, $stateParams) {
                var _this = this;
                this.$http = $http;
                this.$state = $state;
                this.$stateParams = $stateParams;
                $http.get("/api/notes/" + this.$stateParams['id']).then(function (results) {
                    _this.note = results.data;
                });
            }
            return NoteDetailController;
        }());
        Controllers.NoteDetailController = NoteDetailController;
    })(Controllers = RecipeApp.Controllers || (RecipeApp.Controllers = {}));
})(RecipeApp || (RecipeApp = {}));
//# sourceMappingURL=controllers.js.map