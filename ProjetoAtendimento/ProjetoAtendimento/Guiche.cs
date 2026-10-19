using System;
using System.Collections.Generic;

namespace ProjetoAtendimento
{
    public class Guiche
    {
        private int id;
        private Queue<Senha> atendimentos;

        public int Id { get => id; }
        public Queue<Senha> Atendimentos { get => atendimentos; }

        public Guiche()
        {
            atendimentos = new Queue<Senha>();
            id = 0;
        }

        public Guiche(int id)
        {
            atendimentos = new Queue<Senha>();
            this.id = id;
        }

        public bool Chamar(Queue<Senha> filaSenhas)
        {
            if (filaSenhas != null && filaSenhas.Count > 0)
            {
                Senha proxima = filaSenhas.Dequeue();
                proxima.DataAtend = DateTime.Now.Date;
                proxima.HoraAtend = DateTime.Now;
                atendimentos.Enqueue(proxima);
                return true;
            }
            return false;
        }
    }
}
