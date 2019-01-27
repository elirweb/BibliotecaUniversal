
biblioteca.controller('usuarioctrl', ['$scope', 'Ususervi', 'TokenServ', '$window', function ($scope, Ususervi, TokenServ,$window,) {
    var tokendados = TokenServ.RetornoToken(localStorage.getItem('token'), localStorage.getItem("modulo"));
   

    $scope.Registrar = function () {
        var fd = new FormData();
        var validCpf = ValidaCPF($scope.Cpf);
        fd.append('Nome', $scope.Nome);
        fd.append('Login', $scope.Login);
        fd.append('Senha', $scope.Senha);
        fd.append('Email', $scope.Email);
        fd.append('Cpf', $scope.Cpf);
        if (validCpf) {
            Ususervi.Registrar(fd).
                then(function (response) {
                    if (response.data.Msg === "sucesso") {
                        $window.location.href = "/Login/Endereco/";
                    }
                    else {
                        angular.forEach(response.data.Msg, function (value, key) {
                            $scope.MsgRetorno = value;
                        })
                    }
                   

                }).catch(function (response) {
                    $scope.Msgerro = response;
                });

        } else {
            $scope.MsgRetorno = "Ops! Cpf inválido";
        }
      
       
    };

    $scope.LimparCampos = function () {
        delete $scope.Nome;
        delete $scope.Login;
        delete $scope.Senha;
        delete $scope.ConfirmaSenha;
        delete $scope.Email;
        delete $scope.ConfEmail;
        delete $scope.Cpf;

        $scope.FormCadastro.$setPristine();
    }

    $scope.RetornoDadosLivro = function (token) {
        Ususervi.RetornarDados(token).
            then(function (response) {
                $scope.resultado = response.data;
                
            }).catch(function (response) {
                alert("Erro na aplicação: " + response.data);
            });
    };
    $scope.RetornoDadosLivro(tokendados.getToken());
    $scope.EmprestimoLivro = function (livro) {
        var p = new PedidoViewModel();
        p.LivroId = livro;
        p.UsuarioId = "13B8F5CA-DC04-4A11-A16F-F256FD7DB740";
        p.BibliotecaId = "9C2BA9A4-8D6A-4A01-A60B-C10A14B6A0FB";

        Ususervi.Registrar(JSON.stringify(p.getPedido()), tokendados.getToken()).
            then(function (response) {
                //if (response.data.Msg === "Pedido enviado com sucesso") {
                //    $window.location.href = "/Biblioteca/Endereco/";
                //}
                //else {
                //    angular.forEach(response.data.Msg, function (value, key) {
                //        $scope.MsgRetorno = value;
                //    })
                alert(response.data);


            }).catch(function (response) {
                $scope.Msgerro = response;
            });
    };
}]);

class PedidoViewModel {
    constructor(LivroId, UsuarioId, BibliotecaId) {
        this.LivroId = LivroId;
        this.UsuarioId = UsuarioId;
        this.BibliotecaId = BibliotecaId;
    }

    getPedido() {
        var p = new PedidoViewModel(this.LivroId, this.UsuarioId, this.BibliotecaId);
        return p;
    }
}


