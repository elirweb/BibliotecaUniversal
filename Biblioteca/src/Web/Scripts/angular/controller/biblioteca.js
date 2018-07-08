biblioteca.controller('biblioctrl', ['$scope', 'biblioservi', function ($scope, biblioservi) {
   
    $scope.Registrar = function () {
        var dataobj ={
            razaosocial: $scope.RazaoSocial,
            usuario: $scope.Usuario,
            senha: $scope.Senha,
            email: $scope.Email,
            cnpj: $scope.Cnpj,
            situacao: $scope.sit
        };
        //alert(JSON.stringify(dataobj));
       
        biblioservi.Registrar(JSON.stringify(dataobj)).
        then(function (data) {
            alert(data);
        });
        
        
        
        
       
    }


    $scope.ProcessarBotao = function (idbotao, texto) {
        document.getElementById(idbotao).innerHTML = texto;
    }

}]);