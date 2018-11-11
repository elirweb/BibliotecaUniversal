
biblioteca.controller('menuctrl', ['$scope', 'TokenServ', function ($scope, TokenServ) {
    var tokendados = TokenServ.RetornoToken(localStorage.getItem('token'), localStorage.getItem("modulo"));
    $scope.token = tokendados.getToken();
    $scope.Modulo = tokendados.getModulo();
    $scope.user = false;
    $scope.adm = false;
   

    $scope.MenuApp = function () {
        if ($scope.Modulo == "Administrador") {
            $scope.adm = true;
           
        } else {
          
            $scope.user = true;
        }
    };

    $scope.MenuApp();
   
}]);
