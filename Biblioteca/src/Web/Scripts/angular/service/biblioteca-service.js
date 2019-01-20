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


    this.EdicaoLivro = function (idlivro,token) {
        return $http.get(
            url_api.baseUrl + 'Livro/Gestao/ObterLivroPorID', idlivro, //criar este servico na api
            { headers: { 'Authorization': 'Bearer ' + token } }
        );
    };
   
    this.AtualizarLivro = function (model,token) {
        return $http.post(
            url_api.baseUrl + 'Livro/Gestao/update-livro', model,
            { headers: { 'Authorization': 'Bearer ' + token } }
        );
    };

    this.ExcluirLivro = function (idlivro, token) {
        return $http.post(
            url_api.baseUrl + 'Livro/Gestao/delete-livro', idlivro,  //criar este serviço na api
            { headers: { 'Authorization': 'Bearer ' + token } }
        );
    };
})