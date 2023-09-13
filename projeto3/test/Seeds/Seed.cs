using app.ClassesModelo;
using app.Interfaces;

namespace test.Seeds;

public class Seed
{

    public static void Seed1(DadosServicos DadosServicos)
    {

        List<Local> listLocal = new()
        {
            new Local { Identificador = 1, Nome = "Salvador" },
            new Local { Identificador = 2, Nome = "Jakarta" },
            new Local { Identificador = 3, Nome = "Nova Iorque" },
            new Local { Identificador = 4, Nome = "Londres" },
            //new Local { Identificador = 5, Nome = "Tóquio" },
        };
        foreach (var local in listLocal) { DadosServicos.AdicionarLocal(local); }

        List<ItemEntrega> listItemEntrega = new()
        {
            new ItemEntrega { Identificador = 1, Nome = "NVMe 2tb" },
            new ItemEntrega { Identificador = 2, Nome = "Monitor 27 polegadas" },
            new ItemEntrega { Identificador = 3, Nome = "Teclado mecânico" },
            new ItemEntrega { Identificador = 4, Nome = "Mouse sem fio" },
            new ItemEntrega { Identificador = 5, Nome = "Cadeira ergonômica" },
            new ItemEntrega { Identificador = 6, Nome = "Fone de ouvido Bluetooth" },
            new ItemEntrega { Identificador = 7, Nome = "Impressora a laser" },
            new ItemEntrega { Identificador = 8, Nome = "Webcam HD" },
            new ItemEntrega { Identificador = 9, Nome = "Tablet Android" },
            new ItemEntrega { Identificador = 10, Nome = "Console de jogos" },
            new ItemEntrega { Identificador = 11, Nome = "Smartphone Android" },
            new ItemEntrega { Identificador = 12, Nome = "Fogão a gás" },
            new ItemEntrega { Identificador = 13, Nome = "Geladeira duplex" },
            new ItemEntrega { Identificador = 14, Nome = "Máquina de lavar roupa" },
            new ItemEntrega { Identificador = 15, Nome = "Aspirador de pó" },
            new ItemEntrega { Identificador = 16, Nome = "Liquidificador" },
            new ItemEntrega { Identificador = 17, Nome = "Cafeteira" },
            new ItemEntrega { Identificador = 18, Nome = "Panela de pressão" },
            new ItemEntrega { Identificador = 19, Nome = "Mochila para laptop" },
            new ItemEntrega { Identificador = 20, Nome = "Câmera DSLR" },
            new ItemEntrega { Identificador = 21, Nome = "Micro-ondas" },
            new ItemEntrega { Identificador = 22, Nome = "Caixa de som Bluetooth" },
            new ItemEntrega { Identificador = 23, Nome = "Laptop gamer" },
            new ItemEntrega { Identificador = 24, Nome = "Relógio inteligente" },
            new ItemEntrega { Identificador = 25, Nome = "Bicicleta de montanha" },
            new ItemEntrega { Identificador = 26, Nome = "Tênis de corrida" },
            new ItemEntrega { Identificador = 27, Nome = "Jaqueta de couro" },
            new ItemEntrega { Identificador = 28, Nome = "Mala de viagem" },
            new ItemEntrega { Identificador = 29, Nome = "Cama king size" },
            new ItemEntrega { Identificador = 30, Nome = "Mesa de jantar" },
            new ItemEntrega { Identificador = 31, Nome = "Sofá de couro" },
            new ItemEntrega { Identificador = 32, Nome = "Ventilador de teto" },
            new ItemEntrega { Identificador = 33, Nome = "Máquina de café expresso" },
            new ItemEntrega { Identificador = 34, Nome = "Console de jogos" },
            new ItemEntrega { Identificador = 35, Nome = "Monitor ultrawide" },
            new ItemEntrega { Identificador = 36, Nome = "Smart TV 4K" },
            new ItemEntrega { Identificador = 37, Nome = "Sistema de som surround" },
            new ItemEntrega { Identificador = 38, Nome = "Projetor HD" },
            new ItemEntrega { Identificador = 39, Nome = "Máquina de costura" },
            new ItemEntrega { Identificador = 40, Nome = "Violão acústico" },
            new ItemEntrega { Identificador = 41, Nome = "Quadro de pintura" },
            new ItemEntrega { Identificador = 42, Nome = "Estante de livros" },
            new ItemEntrega { Identificador = 43, Nome = "Churrasqueira a gás" },
            new ItemEntrega { Identificador = 44, Nome = "Cadeira de escritório" },
            new ItemEntrega { Identificador = 45, Nome = "Secador de cabelo" },
            new ItemEntrega { Identificador = 46, Nome = "Máquina de barbear" },
            new ItemEntrega { Identificador = 47, Nome = "Máquina de waffle" },
            new ItemEntrega { Identificador = 48, Nome = "Batedeira" },
            new ItemEntrega { Identificador = 49, Nome = "Forno de micro-ondas" },
            new ItemEntrega { Identificador = 50, Nome = "Liquidificador de alta potência" },
        };

        foreach (var itemEntrega in listItemEntrega) { DadosServicos.AdicionarItemEntrega(itemEntrega); }

        List<Caminhao> caminhoesList = new()
        {
            new Caminhao { Identificador = 1, Placa = "ABC-1234" },
            new Caminhao { Identificador = 2, Placa = "ALE-3454" },
            new Caminhao { Identificador = 3, Placa = "BRA-9023" },
        };

        foreach (var caminhao in caminhoesList) { DadosServicos.AdicionarCaminhao(caminhao); }

        for (int ci = 1; ci < 6; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(1, ci);
        }

        for (int ci = 6; ci < 11; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(2, ci);
        }
        for (int ci = 11; ci < 16; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(3, ci);
        }
        for (int ci = 16; ci < 30; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(4, ci);
        }
    }

    public static void Seed2(DadosServicos DadosServicos)
    {
        List<Local> listLocal = new()
        {
            new Local { Identificador = 1, Nome = "Salvador" },
            new Local { Identificador = 2, Nome = "Jakarta" },
            new Local { Identificador = 3, Nome = "Nova Iorque" },
            new Local { Identificador = 4, Nome = "Londres" },
            new Local { Identificador = 5, Nome = "Tóquio" },
            new Local { Identificador = 5, Nome = "Indonesia" },
             new Local { Identificador = 6, Nome = "Brasilia" },
        };
        foreach (var local in listLocal) { DadosServicos.AdicionarLocal(local); }

        List<ItemEntrega> listItemEntrega = new()
        {
            new ItemEntrega { Identificador = 1, Nome = "NVMe 2tb" },
            new ItemEntrega { Identificador = 2, Nome = "Monitor 27 polegadas" },
            new ItemEntrega { Identificador = 3, Nome = "Teclado mecânico" },
            new ItemEntrega { Identificador = 4, Nome = "Mouse sem fio" },
            new ItemEntrega { Identificador = 5, Nome = "Cadeira ergonômica" },
            new ItemEntrega { Identificador = 6, Nome = "Fone de ouvido Bluetooth" },
            new ItemEntrega { Identificador = 7, Nome = "Impressora a laser" },
            new ItemEntrega { Identificador = 8, Nome = "Webcam HD" },
            new ItemEntrega { Identificador = 9, Nome = "Tablet Android" },
            new ItemEntrega { Identificador = 10, Nome = "Console de jogos" },
            new ItemEntrega { Identificador = 11, Nome = "Smartphone Android" },
            new ItemEntrega { Identificador = 12, Nome = "Fogão a gás" },
            new ItemEntrega { Identificador = 13, Nome = "Geladeira duplex" },
            new ItemEntrega { Identificador = 14, Nome = "Máquina de lavar roupa" },
            new ItemEntrega { Identificador = 15, Nome = "Aspirador de pó" },
            new ItemEntrega { Identificador = 16, Nome = "Liquidificador" },
            new ItemEntrega { Identificador = 17, Nome = "Cafeteira" },
            new ItemEntrega { Identificador = 18, Nome = "Panela de pressão" },
            new ItemEntrega { Identificador = 19, Nome = "Mochila para laptop" },
            new ItemEntrega { Identificador = 20, Nome = "Câmera DSLR" },
            new ItemEntrega { Identificador = 21, Nome = "Micro-ondas" },
            new ItemEntrega { Identificador = 22, Nome = "Caixa de som Bluetooth" },
            new ItemEntrega { Identificador = 23, Nome = "Laptop gamer" },
            new ItemEntrega { Identificador = 24, Nome = "Relógio inteligente" },
            new ItemEntrega { Identificador = 25, Nome = "Bicicleta de montanha" },
            new ItemEntrega { Identificador = 26, Nome = "Tênis de corrida" },
            new ItemEntrega { Identificador = 27, Nome = "Jaqueta de couro" },
            new ItemEntrega { Identificador = 28, Nome = "Mala de viagem" },
            new ItemEntrega { Identificador = 29, Nome = "Cama king size" },
            new ItemEntrega { Identificador = 30, Nome = "Mesa de jantar" },
            new ItemEntrega { Identificador = 31, Nome = "Sofá de couro" },
            new ItemEntrega { Identificador = 32, Nome = "Ventilador de teto" },
            new ItemEntrega { Identificador = 33, Nome = "Máquina de café expresso" },
            new ItemEntrega { Identificador = 34, Nome = "Console de jogos" },
            new ItemEntrega { Identificador = 35, Nome = "Monitor ultrawide" },
            new ItemEntrega { Identificador = 36, Nome = "Smart TV 4K" },
            new ItemEntrega { Identificador = 37, Nome = "Sistema de som surround" },
            new ItemEntrega { Identificador = 38, Nome = "Projetor HD" },
            new ItemEntrega { Identificador = 39, Nome = "Máquina de costura" },
            new ItemEntrega { Identificador = 40, Nome = "Violão acústico" },
            new ItemEntrega { Identificador = 41, Nome = "Quadro de pintura" },
            new ItemEntrega { Identificador = 42, Nome = "Estante de livros" },
            new ItemEntrega { Identificador = 43, Nome = "Churrasqueira a gás" },
            new ItemEntrega { Identificador = 44, Nome = "Cadeira de escritório" },
            new ItemEntrega { Identificador = 45, Nome = "Secador de cabelo" },
            new ItemEntrega { Identificador = 46, Nome = "Máquina de barbear" },
            new ItemEntrega { Identificador = 47, Nome = "Máquina de waffle" },
            new ItemEntrega { Identificador = 48, Nome = "Batedeira" },
            new ItemEntrega { Identificador = 49, Nome = "Forno de micro-ondas" },
            new ItemEntrega { Identificador = 50, Nome = "Liquidificador de alta potência" },
        };

        foreach (var itemEntrega in listItemEntrega) { DadosServicos.AdicionarItemEntrega(itemEntrega); }

        List<Caminhao> caminhoesList = new()
        {
            new Caminhao { Identificador = 1, Placa = "ABC-1234" },
            new Caminhao { Identificador = 2, Placa = "ALE-3454" },
            new Caminhao { Identificador = 3, Placa = "BRA-9023" },
        };

        foreach (var caminhao in caminhoesList) { DadosServicos.AdicionarCaminhao(caminhao); }

        for (int ci = 1; ci < 6; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(1, ci);
        }

        for (int ci = 6; ci < 11; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(2, ci);
        }
        for (int ci = 11; ci < 14; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(3, ci);
        }
        for (int ci = 14; ci < 18; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(4, ci);
        }
        for (int ci = 18; ci < 21; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(5, ci);
        }
        for (int ci = 21; ci < 28; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(6, ci);
        }

        DadosServicos.AssociarPontoAoCaminhao(1, 1);
        DadosServicos.AssociarPontoAoCaminhao(2, 2);



        DadosServicos.AssociarPontoAoCaminhao(3, 3);
        DadosServicos.AssociarPontoAoCaminhao(5, 3);
        DadosServicos.AssociarPontoAoCaminhao(4, 3);
    }

    public static void Seed3(DadosServicos DadosServicos)
    {
        List<Local> listLocal = new()
        {
            new Local { Identificador = 1, Nome = "Salvador" },
            new Local { Identificador = 2, Nome = "Jakarta" },
            new Local { Identificador = 3, Nome = "Nova Iorque" },
            new Local { Identificador = 4, Nome = "Londres" },
            new Local { Identificador = 5, Nome = "Brasilia" },
            new Local { Identificador = 6, Nome = "Goias" },
            new Local { Identificador = 7, Nome = "Curitiba" },
            new Local { Identificador = 8, Nome = "Parana" },
        };
        foreach (var local in listLocal) { DadosServicos.AdicionarLocal(local); }

        List<ItemEntrega> listItemEntrega = new()
        {
            new ItemEntrega { Identificador = 1, Nome = "NVMe 2tb" },
            new ItemEntrega { Identificador = 2, Nome = "Monitor 27 polegadas" },
            new ItemEntrega { Identificador = 3, Nome = "Teclado mecânico" },
            new ItemEntrega { Identificador = 4, Nome = "Mouse sem fio" },
            new ItemEntrega { Identificador = 5, Nome = "Cadeira ergonômica" },
            new ItemEntrega { Identificador = 6, Nome = "Fone de ouvido Bluetooth" },
            new ItemEntrega { Identificador = 7, Nome = "Impressora a laser" },
            new ItemEntrega { Identificador = 8, Nome = "Webcam HD" },
            new ItemEntrega { Identificador = 9, Nome = "Tablet Android" },
            new ItemEntrega { Identificador = 10, Nome = "Console de jogos" },
            new ItemEntrega { Identificador = 11, Nome = "Smartphone Android" },
            new ItemEntrega { Identificador = 12, Nome = "Fogão a gás" },
            new ItemEntrega { Identificador = 13, Nome = "Geladeira duplex" },
            new ItemEntrega { Identificador = 14, Nome = "Máquina de lavar roupa" },
            new ItemEntrega { Identificador = 15, Nome = "Aspirador de pó" },
            new ItemEntrega { Identificador = 16, Nome = "Liquidificador" },
            new ItemEntrega { Identificador = 17, Nome = "Cafeteira" },
            new ItemEntrega { Identificador = 18, Nome = "Panela de pressão" },
            new ItemEntrega { Identificador = 19, Nome = "Mochila para laptop" },
            new ItemEntrega { Identificador = 20, Nome = "Câmera DSLR" },
            new ItemEntrega { Identificador = 21, Nome = "Micro-ondas" },
            new ItemEntrega { Identificador = 22, Nome = "Caixa de som Bluetooth" },
            new ItemEntrega { Identificador = 23, Nome = "Laptop gamer" },
            new ItemEntrega { Identificador = 24, Nome = "Relógio inteligente" },
            new ItemEntrega { Identificador = 25, Nome = "Bicicleta de montanha" },
            new ItemEntrega { Identificador = 26, Nome = "Tênis de corrida" },
            new ItemEntrega { Identificador = 27, Nome = "Jaqueta de couro" },
            new ItemEntrega { Identificador = 28, Nome = "Mala de viagem" },
            new ItemEntrega { Identificador = 29, Nome = "Cama king size" },
            new ItemEntrega { Identificador = 30, Nome = "Mesa de jantar" },
            new ItemEntrega { Identificador = 31, Nome = "Sofá de couro" },
            new ItemEntrega { Identificador = 32, Nome = "Ventilador de teto" },
            new ItemEntrega { Identificador = 33, Nome = "Máquina de café expresso" },
            new ItemEntrega { Identificador = 34, Nome = "Console de jogos" },
            new ItemEntrega { Identificador = 35, Nome = "Monitor ultrawide" },
            new ItemEntrega { Identificador = 36, Nome = "Smart TV 4K" },
            new ItemEntrega { Identificador = 37, Nome = "Sistema de som surround" },
            new ItemEntrega { Identificador = 38, Nome = "Projetor HD" },
            new ItemEntrega { Identificador = 39, Nome = "Máquina de costura" },
            new ItemEntrega { Identificador = 40, Nome = "Violão acústico" },
            new ItemEntrega { Identificador = 41, Nome = "Quadro de pintura" },
            new ItemEntrega { Identificador = 42, Nome = "Estante de livros" },
            new ItemEntrega { Identificador = 43, Nome = "Churrasqueira a gás" },
            new ItemEntrega { Identificador = 44, Nome = "Cadeira de escritório" },
            new ItemEntrega { Identificador = 45, Nome = "Secador de cabelo" },
            new ItemEntrega { Identificador = 46, Nome = "Máquina de barbear" },
            new ItemEntrega { Identificador = 47, Nome = "Máquina de waffle" },
            new ItemEntrega { Identificador = 48, Nome = "Batedeira" },
            new ItemEntrega { Identificador = 49, Nome = "Forno de micro-ondas" },
            new ItemEntrega { Identificador = 50, Nome = "Liquidificador de alta potência" },
        };

        foreach (var itemEntrega in listItemEntrega) { DadosServicos.AdicionarItemEntrega(itemEntrega); }

        List<Caminhao> caminhoesList = new()
        {
            new Caminhao { Identificador = 1, Placa = "ABC-1234" },
            new Caminhao { Identificador = 2, Placa = "ALE-3454" },
            new Caminhao { Identificador = 3, Placa = "BRA-9023" },
        };

        foreach (var caminhao in caminhoesList) { DadosServicos.AdicionarCaminhao(caminhao); }
        var contador = 1;
        var acabar = contador + 3;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(1, ci);
            contador += 1;
        }
        acabar = contador + 2;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(2, ci);
            contador += 1;
        }
        acabar = contador + 2;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(3, ci);
            contador += 1;
        }
        acabar = contador + 3;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(4, ci);
            contador += 1;
        }
        acabar = contador + 5;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(5, ci);
            contador += 1;
        }
        acabar = contador + 6;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(6, ci);
            contador += 1;
        }


        DadosServicos.AssociarPontoAoCaminhao(1, 1);
        DadosServicos.AssociarPontoAoCaminhao(2, 1); // 2 locais 5 items

        DadosServicos.AssociarPontoAoCaminhao(3, 2);
        DadosServicos.AssociarPontoAoCaminhao(4, 2); // 2 locais 5 items

        DadosServicos.AssociarPontoAoCaminhao(5, 3); // 1 local 6 items
    }

    public static void Seed4(DadosServicos DadosServicos)
    {
        List<Local> listLocal = new()
        {
            new Local { Identificador = 1, Nome = "Salvador" },
            new Local { Identificador = 2, Nome = "Jakarta" },
            new Local { Identificador = 3, Nome = "Nova Iorque" },
            new Local { Identificador = 4, Nome = "Londres" },
            new Local { Identificador = 5, Nome = "Brasilia" },
            new Local { Identificador = 6, Nome = "Goias" },
            new Local { Identificador = 7, Nome = "Curitiba" },
            new Local { Identificador = 8, Nome = "Parana" },
        };
        foreach (var local in listLocal) { DadosServicos.AdicionarLocal(local); }

        List<ItemEntrega> listItemEntrega = new()
        {
            new ItemEntrega { Identificador = 1, Nome = "NVMe 2tb" },
            new ItemEntrega { Identificador = 2, Nome = "Monitor 27 polegadas" },
            new ItemEntrega { Identificador = 3, Nome = "Teclado mecânico" },
            new ItemEntrega { Identificador = 4, Nome = "Mouse sem fio" },
            new ItemEntrega { Identificador = 5, Nome = "Cadeira ergonômica" },
            new ItemEntrega { Identificador = 6, Nome = "Fone de ouvido Bluetooth" },
            new ItemEntrega { Identificador = 7, Nome = "Impressora a laser" },
            new ItemEntrega { Identificador = 8, Nome = "Webcam HD" },
            new ItemEntrega { Identificador = 9, Nome = "Tablet Android" },
            new ItemEntrega { Identificador = 10, Nome = "Console de jogos" },
            new ItemEntrega { Identificador = 11, Nome = "Smartphone Android" },
            new ItemEntrega { Identificador = 12, Nome = "Fogão a gás" },
            new ItemEntrega { Identificador = 13, Nome = "Geladeira duplex" },
            new ItemEntrega { Identificador = 14, Nome = "Máquina de lavar roupa" },
            new ItemEntrega { Identificador = 15, Nome = "Aspirador de pó" },
            new ItemEntrega { Identificador = 16, Nome = "Liquidificador" },
            new ItemEntrega { Identificador = 17, Nome = "Cafeteira" },
            new ItemEntrega { Identificador = 18, Nome = "Panela de pressão" },
            new ItemEntrega { Identificador = 19, Nome = "Mochila para laptop" },
            new ItemEntrega { Identificador = 20, Nome = "Câmera DSLR" },
            new ItemEntrega { Identificador = 21, Nome = "Micro-ondas" },
            new ItemEntrega { Identificador = 22, Nome = "Caixa de som Bluetooth" },
            new ItemEntrega { Identificador = 23, Nome = "Laptop gamer" },
            new ItemEntrega { Identificador = 24, Nome = "Relógio inteligente" },
            new ItemEntrega { Identificador = 25, Nome = "Bicicleta de montanha" },
            new ItemEntrega { Identificador = 26, Nome = "Tênis de corrida" },
            new ItemEntrega { Identificador = 27, Nome = "Jaqueta de couro" },
            new ItemEntrega { Identificador = 28, Nome = "Mala de viagem" },
            new ItemEntrega { Identificador = 29, Nome = "Cama king size" },
            new ItemEntrega { Identificador = 30, Nome = "Mesa de jantar" },
            new ItemEntrega { Identificador = 31, Nome = "Sofá de couro" },
            new ItemEntrega { Identificador = 32, Nome = "Ventilador de teto" },
            new ItemEntrega { Identificador = 33, Nome = "Máquina de café expresso" },
            new ItemEntrega { Identificador = 34, Nome = "Console de jogos" },
            new ItemEntrega { Identificador = 35, Nome = "Monitor ultrawide" },
            new ItemEntrega { Identificador = 36, Nome = "Smart TV 4K" },
            new ItemEntrega { Identificador = 37, Nome = "Sistema de som surround" },
            new ItemEntrega { Identificador = 38, Nome = "Projetor HD" },
            new ItemEntrega { Identificador = 39, Nome = "Máquina de costura" },
            new ItemEntrega { Identificador = 40, Nome = "Violão acústico" },
            new ItemEntrega { Identificador = 41, Nome = "Quadro de pintura" },
            new ItemEntrega { Identificador = 42, Nome = "Estante de livros" },
            new ItemEntrega { Identificador = 43, Nome = "Churrasqueira a gás" },
            new ItemEntrega { Identificador = 44, Nome = "Cadeira de escritório" },
            new ItemEntrega { Identificador = 45, Nome = "Secador de cabelo" },
            new ItemEntrega { Identificador = 46, Nome = "Máquina de barbear" },
            new ItemEntrega { Identificador = 47, Nome = "Máquina de waffle" },
            new ItemEntrega { Identificador = 48, Nome = "Batedeira" },
            new ItemEntrega { Identificador = 49, Nome = "Forno de micro-ondas" },
            new ItemEntrega { Identificador = 50, Nome = "Liquidificador de alta potência" },
        };

        foreach (var itemEntrega in listItemEntrega) { DadosServicos.AdicionarItemEntrega(itemEntrega); }

        List<Caminhao> caminhoesList = new()
        {
            new Caminhao { Identificador = 1, Placa = "ABC-1234" },
            new Caminhao { Identificador = 2, Placa = "ALE-3454" },
            new Caminhao { Identificador = 3, Placa = "BRA-9023" },
        };

        foreach (var caminhao in caminhoesList) { DadosServicos.AdicionarCaminhao(caminhao); }
        var contador = 1;
        var acabar = contador + 3;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(1, ci);
            contador += 1;
        }
        acabar = contador + 2;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(2, ci);
            contador += 1;
        }
        acabar = contador + 2;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(3, ci);
            contador += 1;
        }
        acabar = contador + 3;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(4, ci);
            contador += 1;
        }
        acabar = contador + 5;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(5, ci);
            contador += 1;
        }
        acabar = contador + 6;
        for (int ci = contador; ci < acabar; ci++)
        {
            DadosServicos.AssociarPontoAoItemDeEntrega(6, ci);
            contador += 1;
        }

        DadosServicos.AssociarPontoAoCaminhao(1, 1);
        DadosServicos.AssociarPontoAoCaminhao(2, 1);

        DadosServicos.AssociarPontoAoCaminhao(3, 2);
        DadosServicos.AssociarPontoAoCaminhao(4, 2);

        DadosServicos.AssociarPontoAoCaminhao(5, 3);
    }
}
