biblioteca.service("biblioservi", function ($http, url_api) {
    this.Registrar = function (model) {
        return $http.post(
            url_api.baseUrlSite + 'Biblioteca/RespostaCadastro',
            model, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            }

        );
    };

    this.RetornarDados = function (token) {
        return $http.get(
            url_api.baseUrl + 'Livro/Gestao/ObterLivro',
            { headers: { 'Authorization': 'Bearer ' + token } }
        );
    };

   

})