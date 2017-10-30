var RecipeApp;
(function (RecipeApp) {
    var Services;
    (function (Services) {
        var DetailService = (function () {
            function DetailService($http, $stateParams) {
                this.$http = $http;
                this.$stateParams = $stateParams;
            }
            DetailService.prototype.GetById = function (id) {
                var _this = this;
                this.$http.get("/api/recipes/" + this.$stateParams['id']).then(function (results) {
                    _this.recipe = results.data;
                });
            };
            return DetailService;
        }());
        Services.DetailService = DetailService;
        angular.module('RecipeApp').service('detailService', DetailService);
    })(Services = RecipeApp.Services || (RecipeApp.Services = {}));
})(RecipeApp || (RecipeApp = {}));
//# sourceMappingURL=services.js.map