biblioteca.controller('biblioctrl', ['$scope', 'biblioservi', '$window', function ($scope, biblioservi,$window) {
   
    $scope.Registrar = function () {
        var dataobj ={
            razaosocial: $scope.RazaoSocial,
            usuario: $scope.Usuario,
            senha: $scope.Senha,
            email: $scope.Email,
            cnpj: $scope.Cnpj,
            situacao: $scope.sit
        };
       
        biblioservi.Registrar(JSON.stringify(dataobj)).
        then(function (response) {
            if (response.Msg == "Dados enviados") {
                $window.location.href = "/Biblioteca/Endereco/" + localStorage.getItem('token');
            } else  {
                alert(response.Msg); // definir na view como será mostrado o erro na tela
            }


        }).catch(function (response) {
                alert(response.Msg);
        });
        
       
    }


    $scope.ProcessarBotao = function (idbotao, texto) {
        document.getElementById(idbotao).innerHTML = texto;
    }

}]);