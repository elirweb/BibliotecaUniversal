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
            {
                transformRequest: angular.identity,
                headers: { 'Authorization': 'Bearer ' + token }
            }
        );
    };


    this.EdicaoLivro = function (registro, token) {
        
        return $http.get(
            url_api.baseUrl + 'Livro/Gestao/obterlivroid/'+registro, //criar este servico na api
            {
                transformRequest: angular.identity,
                headers: { 'Authorization': 'Bearer ' + token}
            }
        );
    };
   
    this.AtualizarLivro = function (lv, token) {
       
        return $http.post(
            url_api.baseUrl + 'Livro/Gestao/update-livro/',lv,
            {
                transformRequest: angular.identity,
                headers: { 'Authorization': 'Bearer ' + token }
            }
        );
    };

    this.ExcluirLivro = function (idlivro, token) {
        return $http.get(
            url_api.baseUrl + 'Livro/Gestao/delete-livro/'+idlivro, 
            {
                transformRequest: angular.identity,
                headers: { 'Authorization': 'Bearer ' + token }
            }
        );
    };
})