biblioteca.controller('authctrl', ['$scope', 'biblioservi', function ($scope, biblioservi) {
    $scope.Registrar = function () {
        this.biblioservi.Registrar($scope.formcadastro);
    }


    $scope.ProcessarBotao = function (idbotao, texto) {
        document.getElementById(idbotao).innerHTML = texto;
    }

}]);