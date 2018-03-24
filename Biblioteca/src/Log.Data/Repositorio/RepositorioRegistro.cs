
using System;
using System.Collections.Generic;
using Log.Domain.Entidade;
using MongoDB.Driver;

namespace Log.Data.Repositorio
{
    public class RepositorioRegistro : Domain.Interfaces.Repositorio.IRegistro<Domain.Entidade.Registro>
    {
        private string _basedados = string.Empty;
        private string _collection = string.Empty;
        public Config.Banco bd = new Config.Banco(System.Configuration.ConfigurationManager.AppSettings["enderecomongodb"]);


        public RepositorioRegistro()
        {

        }
        public void Adicionar(Registro T)
        {
            var client = new MongoClient(bd.Conexao);
            var db = client.GetDatabase(_basedados);
            var collection = db.GetCollection<Registro>(_collection);
            collection.InsertOne(T);


        }

        public IEnumerable<Registro> ObterRegistro()
        {
            throw new NotImplementedException();
        }
    }
}
