biblioteca
        .config(function ($routeProvider,$locationProvider) {
            $routeProvider
                .when('/biblioteca-cadastro', {
                    templateUrl: '/Biblioteca/Cadastro',
                    controller: 'biblioctrl'
                })
                .when('/biblioteca-livro', {
                    templateUrl: '/Biblioteca/Livro',
                    controller: 'biblioctrl'
                })
                .when('/biblioteca-lista', {
                    templateUrl: '/Biblioteca/Lista',
                    controller: 'biblioctrl'
                })
                .when('/biblioteca-dados', {
                    templateUrl: '/Biblioteca/DadosBilioteca',
                    controller: 'biblioctrl'
                })
                .when('/usuario-dados', {
                    templateUrl: '/Usuario/DadosUsuario',
                    controller: 'biblioctrl'
                })
                .when('/usuario-emprestimo', {
                    templateUrl: '/Usuario/EmprestimoLivro',
                    controller: 'biblioctrl'
                }).otherwise({ redirectTo: '/elir' });
            
        });
