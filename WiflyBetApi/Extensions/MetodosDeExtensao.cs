using WiflyBetApi.Enums;

namespace WiflyBetApi.Extensions
{
    internal static class MetodosDeExtensao
    {
        public static void MensagemColorida(
            this
            string titulo1,
            string mensagem1,
            MensagemTipo tipo)
        {
            ColorirLetra(tipo);
            Console.WriteLine($"{titulo1}:{mensagem1}");
            Console.BackgroundColor = ConsoleColor.Black;
            //Console.Clear();
        }

        public static void MensagemColorida(
           this
           string titulo1,
           string mensagem1,
           string titulo2,
           string mensagem2,
           MensagemTipo tipo)
        {
            ColorirLetra(tipo);
            Console.WriteLine($"{titulo1}:{mensagem1}|{titulo2}:{mensagem2}");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void MensagemColorida(
           this
           string titulo1,
           string mensagem1,
           string titulo2,
           string mensagem2,
           string titulo3,
           string mensagem3,
           MensagemTipo tipo)
        {
            ColorirLetra(tipo);
            Console.WriteLine($"{titulo1}:{mensagem1}|{titulo2}:{mensagem2}|{titulo3}:{mensagem3}");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        static void ColorirLetra(MensagemTipo tipo)
        {

            switch (tipo)
            {
                case MensagemTipo.Verde:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.VerdeInverso:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case MensagemTipo.Amarelo:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.AmareloInverso:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case MensagemTipo.Vermelho:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.VermelhoInverso:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case MensagemTipo.Ciano:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.CianoInverso:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
                case MensagemTipo.Azul:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.AzulInverso:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case MensagemTipo.Cinza:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.CinzaInverso:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;
                case MensagemTipo.Magenta:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.MagentaEscuro:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.VermelhoEscuro:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.VermelhoEscuroInverso:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case MensagemTipo.Padrao:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.PadraoInverso:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
