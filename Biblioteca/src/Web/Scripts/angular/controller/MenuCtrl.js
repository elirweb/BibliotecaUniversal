
biblioteca.controller('menuctrl', ['$scope', 'TokenServ', function ($scope, TokenServ) {
    var tokendados = TokenServ.RetornoToken(localStorage.getItem('token'), localStorage.getItem("modulo"));
    $scope.token = tokendados.getToken();
    $scope.Modulo = tokendados.getModulo();
    
}]);
