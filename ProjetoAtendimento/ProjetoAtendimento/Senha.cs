using System;

namespace ProjetoAtendimento
{
    public class Senha
    {
        private int id;
        private DateTime dataGerac;
        private DateTime horaGerac;
        private DateTime dataAtend;
        private DateTime horaAtend;

        public int Id { get => id; }
        public DateTime DataGerac { get => dataGerac; }
        public DateTime HoraGerac { get => horaGerac; }
        public DateTime DataAtend { get => dataAtend; set => dataAtend = value; }
        public DateTime HoraAtend { get => horaAtend; set => horaAtend = value; }

        public Senha(int id)
        {
            this.id = id;
            this.dataGerac = DateTime.Now.Date;
            this.horaGerac = DateTime.Now;
        }

        public string DadosParciais()
        {
            return $"{id} - {dataGerac:dd/MM/yyyy} - {horaGerac:HH:mm:ss}";
        }

        public string DadosCompletos()
        {
            return $"{id} - {dataGerac:dd/MM/yyyy} - {horaGerac:HH:mm:ss} - {dataAtend:dd/MM/yyyy} - {horaAtend:HH:mm:ss}";
        }
    }
}