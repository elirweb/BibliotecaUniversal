biblioteca.service("biblioservi", function ($http) {
    this.Registrar = function (model) {
        console.log(model);
        return $http.post(
            'http://localhost:4372/Biblioteca/RespostaCadastro',
             model 
           
        )
            

    }

})