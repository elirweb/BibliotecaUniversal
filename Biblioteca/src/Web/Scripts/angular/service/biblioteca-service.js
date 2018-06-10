biblioteca.service("biblioservi", function ($http) {
    this.Registrar = function (formulario) {
        return $http.post({
            url: '',
            method: 'POST',
            headers: { 'Content': 'application/json' },
            data: formulario
        })
            

    }

})