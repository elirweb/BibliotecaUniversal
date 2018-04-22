var url = "http://localhost:10078/biblioteca/Login/authenticar/";

biblioteca.service("authService", function ($http) {
    this.Authenticar = function (login, senha) {
        return $http.get(url+login+"/"+senha);

    }
    
})