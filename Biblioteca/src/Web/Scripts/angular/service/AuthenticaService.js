var url = "localhost:10078/api/security/token";

biblioteca.service("authService", function ($http) {
    var data = "grant_type=password&username=elir&password=1234";

    this.Authenticar = function () {
        return $http.post(url, data,
            { headers: { 'Content-Type': 'application/x-www-form-urlenconded' } });
    }
})