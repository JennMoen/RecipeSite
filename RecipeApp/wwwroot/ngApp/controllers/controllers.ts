namespace RecipeApp.Controllers {

    export class HomeController {

        public message = "Welcome to your recipe headquarters!";
        public recents;

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/recipes/recents').then((results) => {
                this.recents = results.data;
                
            });
        }
    }
    
    export class MyRecipesController {
        public message = "My recipes";

        public recipes;

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/recipes').then((results) => {
                this.recipes = results.data;
            });
        }
    }

    export class RecipeDetailController {
        public recipe;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            $http.get(`/api/recipes/${$stateParams['id']}`).then((results) => {
                this.recipe = results.data;
            });
        }

        public addStep(step) {
            
            this.$http.post(`/api/recipes/${this.$stateParams['id']}/steps`, step)
                .then((results) => {
                    this.$state.reload();
                })
                .catch((reason) => {
                    console.log(reason);
                });
        }
    }

    export class AddRecipeController {

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

       
        public addRecipe(recipe, imageUrl) {
            recipe.imageUrl = imageUrl;
            this.$http.post('/api/recipes', recipe, recipe.imageUrl)
                .then((results) => {
                    this.$state.go('myRecipes');
                })
                    .catch((reason) => {
                        console.log(reason);
                    });
        }
         
        constructor(private filepickerService, private $scope: ng.IScope, private $http: ng.IHttpService, private $state: ng.ui.IStateService ) { }
    }

    export class MenuController{ }

    export class MenuDetailController{}

    export class NoteController{}

}