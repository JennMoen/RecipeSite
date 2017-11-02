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
        var FilePickerService = (function () {
            function FilePickerService(filepickerService, $scope) {
                this.filepickerService = filepickerService;
                this.$scope = $scope;
            }
            FilePickerService.prototype.pickFile = function () {
                this.filepickerService.pick({ mimetype: 'image/*' }, this.fileUploaded.bind(this));
            };
            FilePickerService.prototype.fileUploaded = function (file) {
                this.file = file;
                this.$scope.$apply();
                this.image = file.url;
            };
            return FilePickerService;
        }());
        Services.FilePickerService = FilePickerService;
        angular.module('RecipeApp').service('filePickerService', FilePickerService);
    })(Services = RecipeApp.Services || (RecipeApp.Services = {}));
})(RecipeApp || (RecipeApp = {}));
//# sourceMappingURL=services.js.map