using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Carro
    {
        private string nome;
        private short ano;
        private string marca;
        private decimal valor;


        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Nome deve ser Preenchido");
                }

                if (value.Count() == 1)
                {
                    throw new Exception("Nome deve conter pelo menos 2 caracteres");
                }

                nome = value;
            }
        }

        public string Marca
        {
            get
            {
                return marca;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Marca deve ser preenchida");   
                }

                if (value.Count() < 3)
                {
                    throw new Exception("Marca deve conter no mínimo 3 caracteres");
                }

                marca = value;
            }
        }

        public decimal Valor
        {
            get { return valor;  }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Valor deve ser maior que zero");
                }
                valor = value;
            }
        }

        public short AnoFabricação
        {
            get { return ano; }
            set
            {
                if (value < 1885)
                {
                    throw new Exception("Ano deve ser maior que 1885");
                }
                if (value >= DateTime.Now.Year)
                {
                    throw new Exception("Ano deve ser menor ou igual a " + DateTime.Now.Year);
                }
                ano = value;
            }
        }

    }
}
