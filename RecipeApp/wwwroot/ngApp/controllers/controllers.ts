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
        //public recipes;

        //constructor(private $http: ng.IHttpService) {
        //    $http.get('/api/recipes').then((results) => {
        //        this.recipes = results.data;
               
        //    });
        //}

        public categories;

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/categories/recipes').then((results) => {
                this.categories = results.data;
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

        public addIngredient(ingredient) {

            this.$http.post(`/api/recipes/${this.$stateParams['id']}/ingredients`, ingredient)
                .then((results) => {
                    this.$state.reload();
                    console.log(ingredient);
                })
                .catch((reason) => {
                    console.log(reason);
                });
        }
    }

    export class AddRecipeController {

        public file;
        public image;
        public categories;

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

        constructor(private filepickerService, private $scope: ng.IScope, private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            $http.get('/api/categories').then((results) => {
                this.categories = results.data;
            });
        }
    }

    export class MenuController {
        public menus;

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/menus').then((results) => {
                this.menus = results.data;
            });
        }


    }

    export class MenuDetailController {

        public menu;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            $http.get(`/api/menus/${this.$stateParams['id']}`).then((results) => {
                this.menu = results.data;

            });
        }

    }

    export class NoteController {

        public notes;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            $http.get('/api/notes').then((results) => {
                this.notes = results.data;

            });
        }

        public addNote(note) {
            this.$http.post('/api/notes', note).then((results) => {
                this.$state.reload();
                console.log(note);
            }).catch((reason) => {
                console.log(reason);
            });
        }
    

    }

    export class NoteDetailController{

        public note;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            $http.get(`/api/notes/${this.$stateParams['id']}`).then((results) => {
                this.note = results.data;

            });
        }
    }

}