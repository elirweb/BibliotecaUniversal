
biblioteca.service("authService", function ($http,url_api) {
    this.Authenticar = function (login, senha) {
        var configheader = { 'Content-Type': 'application/json' };
        return $http.get(url_api.baseUrl + "Usuario/Login/authenticar/" + login + "/" + senha, configheader);
    }
   
    
})