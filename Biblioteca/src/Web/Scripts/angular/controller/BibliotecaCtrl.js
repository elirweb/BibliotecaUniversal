
biblioteca.controller('biblioctrl', ['$scope', 'biblioservi', '$window', function ($scope, biblioservi, $window) {

    //tem que pensar em outro jeito de colocar este token
    document.getElementById("tokenlivro").value = localStorage.getItem("token");
   

    $scope.Registrar = function () {
        var fd = new FormData();
        var validCnpj = validarCNPJ($scope.Cnpj);
       
        fd.append('RazaoSocial', $scope.RazaoSocial);
        fd.append('Usuario', $scope.Usuario);
        fd.append('email', $scope.Email);
        fd.append('cnpj',$scope.Cnpj);
        fd.append('LabelSituacao', $scope.LabelSituacao);
        fd.append('Imagem', $scope.arquivo);
        fd.append('Senha', $scope.Senha);
        fd.append('token', localStorage.getItem("token"));
        fd.append('ConfirmaSenha', $scope.ConfirmaSenha);
        if (validCnpj) {
            biblioservi.Registrar(fd).
                then(function (response) {
                    if (response.data.Msg === "Dados enviados") {
                        $window.location.href = "/Biblioteca/Endereco/";
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
            $scope.MsgRetorno = "Ops! Cnpj inválido";
        }


       
    }


    $scope.ProcessarBotao = function (idbotao, texto) {
        document.getElementById(idbotao).innerHTML = texto;
        $scope.Registrar();
    }

    $scope.LinkLv = function () {
        $window.location.href = "/Biblioteca/Livro/";
    };

    

    $scope.LimparCampos = function () {
        delete $scope.RazaoSocial;
        delete $scope.Usuario;
        delete $scope.Senha;
        delete $scope.ConfirmaSenha;
        delete $scope.Email;
        delete $scope.ConfirmEmail;
        delete $scope.Cnpj;

        $scope.FormCadastro.$setPristine();
    };

    $scope.RetornoDadosLivro = function (token) {
        biblioservi.RetornarDados(token).
            then(function (response) {
                alert(response);

            }).catch(function (response) {
                alert("erro na consulta de dados");
            });
    };
    $scope.RetornoDadosLivro(localStorage.getItem("token"));

}]);

//diretiva 
biblioteca.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;

            element.bind('change', function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}]);
