
biblioteca.controller('usuarioctrl', ['$scope', 'Ususervi', '$window', function ($scope, Ususervi, $window) {
    

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
                    if (response.data.Msg == "Dados enviado com sucesso") {
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

}]);


