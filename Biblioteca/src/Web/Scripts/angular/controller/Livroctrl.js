

biblioteca.controller('livroctrl', ['$scope', 'biblioservi', '$window', 'TokenServ', function ($scope, biblioservi, $window, TokenServ) {

    var tokendados = TokenServ.RetornoToken(localStorage.getItem('token'), localStorage.getItem("modulo"));
    $scope.tokenlv = tokendados.getToken();
    
    
    $scope.RetornoDadosLivro = function (token) {
        biblioservi.RetornarDados(token).
            then(function (response) {
                $scope.resultado = response.data;

            }).catch(function (response) {
                alert("Erro na aplicação: "+ response.data);
            });
    };
    $scope.RetornoDadosLivro(tokendados.getToken());

    $scope.EdicaoLivro = function (idlivro) {
        biblioservi.EdicaoLivro(idlivro, $scope.tokenlv).then(function (response) {
            angular.forEach(response.data, function (value, key) {
                $scope.Titulo = response.data.Titulo;
                $scope.Descricao = response.data.Descricao;
                $scope.Editora = response.data.Editora;
                $scope.QtdPg = response.data.QtdPg;
                $scope.DescCategoria = response.data.DescCategoria;

            });
            $window.location.href = "/Usuario/Emprestimo/";
        }).catch(function (response) {
            alert('Erro no acesso ao dados');
        });
    };

    $scope.AtualizarLivro = function () {
        //criar as variaveis para receber os dados
        var fd = new FormData();
        fd.append('Titulo', $scope.Titulo);
        fd.append('Descricao', $scope.Descricao);
        fd.append('Editora', $scope.Editora);
        fd.append('QtdPg', $scope.QtdPg);
        fd.append('DescCategoria', $scope.DescCategoria);

        biblioservi.AtualizarLivro(fd, $scope.tokenlv).then(function (response) {
            alert(response);
        }).catch(function (response) {
            alert('Erro no acesso ao dados');
        });
    };

    $scope.ExcluirLivro = function (idlivro) {
     
        biblioservi.ExcluirLivro(idlivro, $scope.tokenlv).then(function (response) {

        }).catch(function (response) {
            alert('Erro no acesso ao dados');
        });
    };

}]);

