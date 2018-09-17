
biblioteca.controller('usuarioctrl', ['$scope', 'biblioservi', '$window', function ($scope, biblioservi, $window) {

    $scope.Registrar = function () {
        alert('Dados gravados com sucesso');
        $scope.LimparCampos();
    }

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


