biblioteca.service("Ususervi", function ($http, url_api) {
    this.Registrar = function (model) {
        return $http.post(
            url_api.baseUrlSite + 'Login/Cadastro',
            model, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            }

        )
    }

    this.RetornarDados = function (token) {
        return $http.get(
            url_api.baseUrl + 'Livro/Gestao/ObterLivro',
            { headers: { 'Authorization': 'Bearer ' + token } }
        );
    };



})