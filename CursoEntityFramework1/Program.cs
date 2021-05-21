using CursoEntityFramework1.Domain;
using CursoEntityFramework1.ValueObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CursoEntityFramework1 {
    class Program {
        static void Main(string[] args) {

            //using var db = new Data.ApplicationContext();
            //db.Database.Migrate();
            //var existe = db.Database.GetPendingMigrations().Any();
            //if (existe) {
            //    //regra de negócio
            //}

            //InserirDados();
            InserirDadosEmMassa();
        }
        private static void InserirDadosEmMassa() {
            var produto = new Produto {
                Descricao = "Sapato",
                CodigoBarras = "1234567891234",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            var cliente = new Cliente {
                Nome = "Kobata",
                CEP = "459",
                Cidade = "Teste",
                Estado = "SP",
                Telefone = "9946",
            };


            using var db = new Data.ApplicationContext();

            db.AddRange(produto, cliente);

            var registros = db.SaveChanges();
            Console.WriteLine($"Total de registros:{registros}");
        }
        private static void InserirDados() {
            var produto = new Produto {
                Descricao = "LUCAS",
                CodigoBarras = "1234567891234",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            using var db = new Data.ApplicationContext();
            //formas de inserir:
            //db.Produtos.Add(produto);
            //db.Set<Produto>().Add(produto);
            //db.Entry(produto).State = EntityState.Added;
            db.Add(produto);

            var registros = db.SaveChanges();
            Console.WriteLine($"Total Registros: {registros}");
        }
    }

}
