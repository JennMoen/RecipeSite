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


}