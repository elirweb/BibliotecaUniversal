

biblioteca.controller('livroctrl', ['$scope', 'biblioservi', '$window', 'TokenServ', function ($scope, biblioservi, $window, TokenServ) {

    //tem que pensar em outro jeito de colocar este token
    var tokendados = TokenServ.RetornoToken(localStorage.getItem('token'), localStorage.getItem("modulo"));
    
    
    
    $scope.RetornoDadosLivro = function (token) {
        biblioservi.RetornarDados(token).
            then(function (response) {
                $scope.resultado = response.data;

            }).catch(function (response) {
                alert("Erro na aplicação: "+ response.data);
            });
    };
    $scope.RetornoDadosLivro(tokendados.getToken());

}]);

