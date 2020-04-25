using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedidosVinho.Models;

namespace PedidosVinho.Data
{
    public class SeedingService
    {
        private PedidosVinhoContext _context;

        public SeedingService(PedidosVinhoContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Linha.Any() ||
                _context.Produto.Any())
            {
                return;
            }

            Linha l1 = new Linha(1, "CASTELLAMARE");
            Linha l2 = new Linha(2, "SAN DIEGO");
            //CASTELLAMARE
            Produto p1 = new Produto(1,20030706, "Cabernet Sauvignon Gran Reserva 6/750", 50, l1);
            Produto p2 = new Produto(2,20031200, "Pinot Noir 6/750", 20, l1);
            Produto p3 = new Produto(3,20030702, "Cabernet Sauvignon 6/750", 17, l1);
            Produto p4 = new Produto(4,20030802, "Merlot 6/750", 17, l1);
            Produto p5 = new Produto(5,20031002, "Tannat 6/750", 17, l1);
            Produto p6 = new Produto(6,20030602, "Chardonnay 6/750", 17, l1);
            Produto p7 = new Produto(7,20030902, "Riesling 6/750", 17, l1);
            Produto p8 = new Produto(8,20031601, "Moscato Giallo 6/750", 17, l1);
            Produto p9 = new Produto(9,20070501, "Espumante Moscatel 6/750", 21, l1);
            Produto p10 = new Produto(10,20070601, "Espumante Moscatel Rose 6/750", 21, l1);
            Produto p11 = new Produto(11,20071001, "Espumante Brut 6/750", 26, l1);
            Produto p12 = new Produto(12,20071510, "Espumante Brut Rosé 6/750", 30, l1);
            Produto p13 = new Produto(13,20050701, "Cabernet Sauv Bag 3/5 litros", 52, l1);
            Produto p14 = new Produto(14,20050801, "Merlot Bag 3/5 litros", 52, l1);
            Produto p15 = new Produto(15,20050901, "Tannat Bag 3/5 litros", 52, l1);
            Produto p16 = new Produto(16,20060701, "Cabernet Sauvignon Bag 4/3 litros", 40, l1);
            Produto p17 = new Produto(17,20060801, "Merlot Bag 4/3 litros", 40, l1);
            Produto p18 = new Produto(18,20060901, "Tannat Bag 4/3 litros", 40, l1);
            Produto p19 = new Produto(19,20060601, "Riesling Bag 4/3 litros", 40, l1);
            Produto p20 = new Produto(20,20061001, "Chardonnay Bag 4/3 litros", 40, l1);
            Produto p21 = new Produto(21,20020700, "Cab Sauvignon 4,6 litros - Com Casco", 50, l1);
            Produto p22 = new Produto(22,20020800, "Merlot 4,6 litros - Com Casco", 50, l1);
            //SAN DIEGO
            Produto p23 = new Produto(23,20030102, "Tinto Seco 12/750", 8, l2);
            Produto p24 = new Produto(24,20031101, "Tinto Suave 12/750", 8, l2);
            Produto p25 = new Produto(25,20030202, "Rosé Seco 12/750", 8, l2);
            Produto p26 = new Produto(26,20030501, "Moscato 12/750", 11, l2);
            Produto p27 = new Produto(27,20070400, "Espumante Brut 6/750", 19, l2);
            Produto p28 = new Produto(28,20050101, "Tinto Comum Seco Bag 3/5 litros", 40, l2);
            Produto p29 = new Produto(29,20050301, "Tinto Comum Suave Bag 3/5 litros", 40, l2);
            Produto p30 = new Produto(30,20060501, "Moscato Bag 4/3 litros", 32, l2);
            Produto p31 = new Produto(31,20020100, "Tinto Seco 4,6 litros - Com Casco", 30, l2);
            Produto p32 = new Produto(32,20020300, "Tinto Suave 4,6 litros - Com Casco", 30, l2);
            Produto p33 = new Produto(33,20020200, "Rosé Seco 4,6 litros - Com Casco", 30, l2);
            Produto p34 = new Produto(34,20020400, "Niágara 4,6 litros - Com Casco", 30, l2);
            Produto p35 = new Produto(35,20020900, "Lorena 4,6 litros - Com Casco", 30, l2);
            Produto p36 = new Produto(36,20020500, "Moscato 4,6 litros - Com Casco", 40, l2);
            Produto p37 = new Produto(37,20080103, "Suco de Uva 06/1000 ml", 8, l2);
            Produto p38 = new Produto(38,20080200, "Suco de Uva Bag 4/3 litros", 22, l2);

            _context.Linha.AddRange(l1, l2);
            _context.Produto.AddRange(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12,
                p13, p14, p15, p16, p17, p18, p19, p20, p21, p22, p23, p24, p25, p26, p27, 
                p28, p29, p30, p31, p32, p33, p34, p35, p36, p37, p38);

            _context.SaveChanges();
        }
    }
}
