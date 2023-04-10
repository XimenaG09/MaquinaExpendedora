
using ProyectoDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDemo.Controller
{
    public class Controller
    {
        public List<Consumable> Products { get; set; }

        public string Pago {get; set;}


        public Controller()
        {
            this.Products = new List<Consumable>();

            Consumable pepsi = new Consumable("Pepsi", 3100, 5);

            Consumable cocacola = new Consumable("Coca Cola", 3500, 4);

            Consumable papas = new Consumable("Papas margaritas", 2500, 4);

            Consumable risadas = new Consumable("Risadas", 1800, 6);

            Consumable doritos = new Consumable("Doritos", 2500, 0);

            this.Products.Add(papas);
            this.Products.Add(pepsi);
            this.Products.Add(cocacola);
            this.Products.Add(risadas);
            this.Products.Add(doritos); 
        }

        public List<Consumable> GetProducts()
        {
            return this.Products;
        }

        public bool AddProduct(Consumable consumable)
        {
            Consumable enc = this.validaConsumable(consumable.Name);
            if(enc != null)
            {
                int last_size = this.Products.Count;

                this.Products.Add(consumable);

                if (this.Products.Count > last_size && this.Products[this.Products.Count - 1] != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } else
            {
                enc.Price = consumable.Price;
                enc.sumQuantity(consumable.Quantity_in_stock);
                return false;
            }
        }

        public string listarProduct()
        {
            string list = "";
            foreach (Consumable item in this.Products) 
            {
                list += item.Name+" "+item.Price + " " + item.Quantity_in_stock + "\n";
            }
            return list;
        }

        public Consumable validaConsumable(string name)
        {
            Consumable encontro = null;

            for (int i = 0; i < this.Products.Count; i++)
            {
                if (this.Products[i].Name == name)
                {
                    encontro = this.Products[i];
                }
            }

            return encontro;
        }

        public Consumable vender(string name)
        {
            Consumable enc = this.validaConsumable(name);
            if (enc != null)
            {
                if (enc.IsInStock())
                {
                    if (enc.validarValor(double.Parse(Pago)))
                    {
                        enc.restProduct();

                        return enc;
                    }
                }
            }

            return null;
        }

    }
}
