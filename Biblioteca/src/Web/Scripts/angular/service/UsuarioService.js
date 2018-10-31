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



})