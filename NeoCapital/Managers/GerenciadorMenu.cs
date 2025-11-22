using System;

namespace NeoCapitalRPG
{
    public class GerenciadorMenu
    {
        private GerenciadorCenarios gerenciadorCenarios;
        private GerenciadorInventario gerenciadorInventario;

        public GerenciadorMenu(GerenciadorCenarios gerenciadorCenarios, GerenciadorInventario gerenciadorInventario)
        {
            this.gerenciadorCenarios = gerenciadorCenarios;
            this.gerenciadorInventario = gerenciadorInventario;
        }

        public void MenuViela(Personagem jogador)
        {
            while (true)
            {
                ExibirOpcoesMenu();

                string escolha = Console.ReadLine();

                if (ProcessarEscolha(escolha, jogador))
                {
                    return; // Sai do menu para continuar o loop do jogo
                }
            }
        }

        private void ExibirOpcoesMenu()
        {
            Console.WriteLine("\n═══ VIELA INICIAL ═══");
            Console.WriteLine("Para onde você quer ir?");
            Console.WriteLine("1 - Ferro-Velho (Batalhar contra drones antigos)");
            Console.WriteLine("2 - Mercado Abandonado (Enfrentar gangue Chrome Shadows)");
            Console.WriteLine("3 - Verificar inventário");
            Console.WriteLine("4 - Melhorar arma (requer peças)");

            Console.Write("\nSua escolha: ");
        }

        private bool ProcessarEscolha(string escolha, Personagem jogador)
        {
            switch (escolha)
            {
                case "1":
                    gerenciadorCenarios.IrParaFerroVelho(jogador);
                    return true;

                case "2":
                    gerenciadorCenarios.IrParaMercadoAbandonado(jogador);
                    return true;

                case "3":
                    gerenciadorInventario.VerificarInventario(jogador);
                    return false;

                case "4":
                    gerenciadorInventario.MelhorarArma(jogador);
                    return false;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida!");
                    Console.ResetColor();
                    return false;
            }
        }
    }
}