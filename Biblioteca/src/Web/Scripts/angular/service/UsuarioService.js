biblioteca.service("Ususervi", function ($http, url_api) {
    this.Registrar = function (pedido, token) {
        alert(pedido);
        return $http.post(
            url_api.baseUrl + 'pedido/Gestao/registrar-emprestimo/',
            pedido, {
                transformRequest: angular.identity,
                headers: { 'Authorization': 'Bearer ' + token }
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