biblioteca.service("TokenServ", function () {
    this.RetornoToken = function (token, modulo) {
        var tokendados = new TokenDados(token, modulo);
        return tokendados;

    }
    
})

class TokenDados  {
    constructor(token, modulo) {
        this.token = token;
        this.modulo = modulo;
    }

    getToken() {
        return this.token;
    }

    getModulo() {
        return this.modulo;
    }
  
}