var http = require('http');

  var server = http.createServer(function (req, res){

        res.writeHead(200, {'Content-Type': 'text/html'});

        res.write("<h1>Seja bem-vindo web socket!<br /> proximo passo implementar a comunicação do socket</h1>");

        res.end();

  });

  server.listen(1337);