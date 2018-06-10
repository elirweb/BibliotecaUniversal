biblioteca.controller('authctrl', ['$scope', 'biblioservi', function ($scope, biblioservi) {
    $scope.Registrar = function () {
        var dataobj = {
            RazaoSocial: $scope.RazaoSocial,
            Usuario: $scope.Usuario,
            Senha: $scope.Senha,
            Email: $scope.Email,
            Email: $scope.Email,
            Cnpj: $scope.Cnpj,


        };
        var res = this.biblioservi.Registrar(dataobj);
        res.success(function (data, status, headers, config) {
            alert("Cadastro feito com sucesso");
        });
        
        res.error(function (data, status, headers, config) {
            alert("Erro no cadastro");
        });

        $scope.RazaoSocial = "";
        $scope.Usuario = "";
        $scope.Usuario = "",
        $scope.Senha = "";
        $scope.Email = "";
        $scope.Email = "";
        $scope.Cnpj = "";
    }


    $scope.ProcessarBotao = function (idbotao, texto) {
        document.getElementById(idbotao).innerHTML = texto;
    }

}]);