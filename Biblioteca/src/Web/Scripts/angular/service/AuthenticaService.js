
biblioteca.service("authService", function ($http) {
    this.Authenticar = function (login, senha) {
        return $http.get(url_authenticar+login+"/"+senha);

    }
    
})