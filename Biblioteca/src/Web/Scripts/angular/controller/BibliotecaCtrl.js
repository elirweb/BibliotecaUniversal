﻿
biblioteca.controller('biblioctrl', ['$scope', 'biblioservi', '$window', function ($scope, biblioservi, $window) {
    $scope.Registrar = function () {

        var form = $scope.FormCadastro;
        var fd = new FormData();
        var validCnpj = validarCNPJ($scope.Cnpj);
       
        fd.append('RazaoSocial', $scope.RazaoSocial);
        fd.append('Usuario', $scope.Usuario);
        fd.append('email', $scope.Email);
        fd.append('cnpj',$scope.Cnpj);
        fd.append('LabelSituacao', $scope.LabelSituacao);
        fd.append('Imagem', $scope.arquivo);
        
        if (validCnpj) {
            biblioservi.Registrar(fd).
                then(function (response) {
                    if (response.Msg == "Dados enviados") {
                        $window.location.href = "/Biblioteca/Endereco/" + localStorage.getItem('token');
                    }
                    else {
                        angular.forEach(response.Msg, function (value, key) {
                            $scope.Msgerro = value;
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
        $window.location.href = "/Biblioteca/Livro/" + localStorage.getItem('token');
    }

    

    $scope.LimparCampos = function () {
        delete $scope.RazaoSocial;
        delete $scope.Usuario;
        delete $scope.Senha;
        delete $scope.ConfirmaSenha;
        delete $scope.Email;
        delete $scope.ConfirmEmail;
        delete $scope.Cnpj;

        $scope.FormCadastro.$setPristine();
    }

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