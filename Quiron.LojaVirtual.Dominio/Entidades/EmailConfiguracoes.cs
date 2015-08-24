namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class EmailConfiguracoes
    {
        public bool UsarSsl = false;
        public string ServidorSmtp = "stmp.gmail.com";
        public int ServidorPorta = 587;
        public string Usuario = "maiquelzf";
        public bool EscreverArquivo = false;
        public string PastaArquivo = @"c:\envioemail";
        public string De = "quiron@quiron.com.br";
        public string Para = "Pedido@quiron.com.br";
    }
}