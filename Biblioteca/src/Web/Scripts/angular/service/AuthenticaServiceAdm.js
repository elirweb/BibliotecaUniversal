
biblioteca.service("authServiceadm", function ($http) {
    this.Authenticar = function (login, senha) {
        return $http.get(url_authenticaradm + login + "/" + senha);

    }

})