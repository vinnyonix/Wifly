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
        }

        static void ColorirLetra(MensagemTipo tipo)
        {

            switch (tipo)
            {
                case MensagemTipo.Sucesso:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.SucessoInverso:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case MensagemTipo.Alerta:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.AlertaInverso:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case MensagemTipo.Perigo:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.PerigoInverso:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case MensagemTipo.Info:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.InfoInverso:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
                case MensagemTipo.Link:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case MensagemTipo.LinkInverso:
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
