
biblioteca.service("authService", function ($http) {
    this.Authenticar = function (login, senha) {
        return $http.get("http://localhost:10078/Usuario/Login/authenticar/"+login+"/"+senha);
    }
   
    
})