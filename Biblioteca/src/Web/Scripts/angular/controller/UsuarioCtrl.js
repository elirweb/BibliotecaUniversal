
biblioteca.controller('usuarioctrl', ['$scope', 'Ususervi', 'TokenServ', '$window', function ($scope, Ususervi, $window, TokenServ) {
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

}]);


