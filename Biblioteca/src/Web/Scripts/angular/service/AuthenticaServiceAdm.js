
biblioteca.service("authServiceadm", function ($http, url_api) {
    this.Authenticar = function (Usuario, senha) {
        return $http.get(url_api.baseUrl+"Adm/LoginAdm/authenticar/" + Usuario + "/" + senha);
    }

    this.RegistrarAdm = function (model) {
        return $http.post(url_api.baseUrlSite + "LoginBiblioteca/RespostaAdm", model,
            {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            });
    }

})