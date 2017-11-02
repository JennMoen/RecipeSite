namespace RecipeApp.Services {

    export class DetailService {

       
        public recipe;

        public GetById(id) {
            this.$http.get(`/api/recipes/${this.$stateParams['id']}`).then((results) => {
                this.recipe = results.data;
            });
        }
        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService) {}
       
    }

    angular.module('RecipeApp').service('detailService', DetailService);


    export class FilePickerService {

        public file;
        public image;

        public pickFile() {
            this.filepickerService.pick(
                { mimetype: 'image/*' },
                this.fileUploaded.bind(this)
            );
        }


        public fileUploaded(file) {
            this.file = file;
            this.$scope.$apply();
            this.image = file.url;
        }
        constructor(private filepickerService, private $scope: ng.IScope){}
    }
    angular.module('RecipeApp').service('filePickerService', FilePickerService);

}