biblioteca.service("biblioservi", function ($http,url_api) {
    this.Registrar = function (model) {
        console.log(model);
        return $http.post(
            url_api.baseUrlSite+'Biblioteca/RespostaCadastro',
             model 
        )
    }

   

})