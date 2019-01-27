

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

    $scope.EdicaoLivro = function (registro) {
       

        biblioservi.EdicaoLivro(registro, $scope.tokenlv).then(function (response) {
            angular.forEach(response.data, function (value, key) {
                $scope.Titulo = value.Titulo;
                $scope.Descricao = value.Descricao;
                $scope.Editora = value.Editora;
                $scope.QtdPg = value.QtdPg;
                $scope.DescCategoria = value.DescCategoria;
                $scope.Idlivro = registro;
                $scope.idbiblioteca = value.IdBiblioteca;
               
            });
          
        }).catch(function (response) {
            alert('Erro no acesso ao dados');
        });
    };

    $scope.AtualizarLivro = function (idlivro) {
      

        var l = new Livro();
        l.Descricao = $scope.Descricao;
        l.DescCategoria = $scope.DescCategoria;
        l.Editora = $scope.Editora;
        l.Titulo = $scope.Titulo;
        l.IdBiblioteca = $scope.idbiblioteca;
        l.Ativo = 1;
        l.QtdPg = $scope.QtdPg;
        l.Id = idlivro;
       

        biblioservi.AtualizarLivro(JSON.stringify(l.getLivro()), $scope.tokenlv).then(function (response) {
            alert(response.data);
        }).catch(function (response) {
            alert(response.data);
            });
        
    };

    $scope.ExcluirLivro = function (idlivro) {
       
        biblioservi.ExcluirLivro(idlivro, $scope.tokenlv).then(function (response) {

        }).catch(function (response) {
            alert('Erro no acesso ao dados');
        });
    };

}]);

class Livro {
    constructor(Titulo, Descricao, Editora, QtdPg, DescCategoria, Id, IdBiblioteca) {
        this.Titulo = Titulo;
        this.Descricao = Descricao;
        this.Editora = Editora;
        this.QtdPg = QtdPg;
        this.DescCategoria = DescCategoria;
        this.Id = Id;
        this.IdBiblioteca = IdBiblioteca;
    }

    getLivro() {
        var l = new Livro(this.Titulo, this.Descricao, this.Editora, this.QtdPg, this.DescCategoria, this.Id, this.IdBiblioteca);
        return l;

    }
}