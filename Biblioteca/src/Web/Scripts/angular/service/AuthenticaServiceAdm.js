var url_authenticaradm = "http://localhost:10078/Adm/Login/authenticar/";

biblioteca.service("authServiceadm", function ($http) {
    this.Authenticar = function (Usuario, senha) {
       
        return $http.get("http://localhost:10078/Adm/LoginAdm/authenticar/" + Usuario + "/" + senha);
    }

})