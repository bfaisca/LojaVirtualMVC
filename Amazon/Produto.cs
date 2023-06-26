using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class Produto
    {
        public string ID { get; set; } 
        public string Nome { get; set; }    
        public decimal Preco { get; set; }  
        public int Estoque { get; set; }
    }
}
