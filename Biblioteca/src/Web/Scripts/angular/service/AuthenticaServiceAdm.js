
biblioteca.service("authServiceadm", function ($http, url_api) {
    this.Authenticar = function (Usuario, senha) {
       
        return $http.get(url_api.baseUrl+"Adm/LoginAdm/authenticar/" + Usuario + "/" + senha);
    }

})