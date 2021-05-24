using CursoEntityFramework1.Domain;
using CursoEntityFramework1.ValueObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            //InserirDadosEmMassa();
            //ConsultarDados();
            //CadastrarPedido();
            //ConsultarPedidoCarregamentoAdiantado();
            //AtualizarDados();
            RemoverRegistro();
        }

        private static void RemoverRegistro() {
            using var db = new Data.ApplicationContext();
            var cliente = db.Clientes.Find(5);
            //db.Clientes.Remove(cliente); qualquer uma dessas
            //db.Remove(cliente);
            db.Entry(cliente).State = EntityState.Deleted;

            db.SaveChanges();

        }

        private static void AtualizarDados() {
            using var db = new Data.ApplicationContext();
            var cliente = db.Clientes.Find(4);
            cliente.Nome = "Cliente alterado passo 2";

            //--------outra forma (usam o mesmo save changes)
            var clienteDesconectado = new {
                Nome = "Cliente desconecto",
                Telefone = "123"
            };
        
            db.Entry(cliente).CurrentValues.SetValues(clienteDesconectado);
            //db.Clientes.Update(cliente);
            db.SaveChanges();


        }
        private static void ConsultarPedidoCarregamentoAdiantado() {
            using var db = new Data.ApplicationContext();
            var pedidos = db.Pedidos.Include(p=>p.Itens).ThenInclude(p=>p.Produto).ToList();
            Console.WriteLine(pedidos.Count);
        }
        private static void CadastrarPedido() {
            using var db = new Data.ApplicationContext();

            var cliente = db.Clientes.FirstOrDefault();
            var produto = db.Produtos.FirstOrDefault();

            var pedido = new Pedido {
                ClienteId = cliente.Id,
                IniciadoEm = DateTime.Now,
                FinalizadoEm = DateTime.Now,
                Observacao = "Pedido teste",
                status = StatusPedido.Analise,
                TipoFrete = TipoFrete.SemFrete,
                Itens = new List<PedidoItem> {
                    new PedidoItem {
                        IdProduto = produto.Id,
                        Desconto = 0,
                        Quantidade =1,
                        Valor=10,
                    }
                }


            };

            db.Pedidos.Add(pedido);
            db.SaveChanges();
        }
        private static void ConsultarDados() {
            using var db = new Data.ApplicationContext();
            //var consultaPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList();
            var consultaPorMetodo = db.Clientes.Where(p => p.Id > 0).OrderBy(p=>p.Id).ToList();
            foreach (var cliente in consultaPorMetodo) {
                Console.WriteLine($"Consultando cliente: {cliente.Id}");
                //db.Clientes.Find(cliente.Id);
                db.Clientes.FirstOrDefault(p=>p.Id==cliente.Id);
            }
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
