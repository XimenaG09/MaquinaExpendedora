namespace ProyectoDemo.Model
{
    //Modelos de nuestro proyecto
    public class Consumable
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity_in_stock { get; set; }

        public string Cambio { get; set; }
        
        public Consumable(string name, double price, int quantity_in_stock)
        {
            Name = name;
            Price = price;
            Quantity_in_stock = quantity_in_stock;
        }

        public bool IsInStock()
        {
            if(this.Quantity_in_stock > 0) 
            { 
                return true; 
            } else 
            { 
                return false;
            }
        }

        public bool validarValor(double valor)
        {
            if (this.Price <= valor)
            {
                double cambio = valor - this.Price;
                int cambioMonedas1000 = Convert.ToInt32(cambio) / 1000;

                double residuoMonedas1000 = Convert.ToInt32(cambio) % 1000;
                int cambioMonedas500 = Convert.ToInt32(residuoMonedas1000) / 500;

                double residuoMonedas500 = Convert.ToInt32(residuoMonedas1000) % 500;
                int cambioMonedas200 = Convert.ToInt32(residuoMonedas500) / 200;

                double residuoMonedas200 = Convert.ToInt32(residuoMonedas500) % 200;
                int cambioMonedas100 = Convert.ToInt32(residuoMonedas200) / 100;

                this.Cambio = cambioMonedas1000 + " monedas de 1000, " + cambioMonedas500 + " monedas de 500, " +cambioMonedas200+ " monedas de 200 y " +cambioMonedas100+ " monedas de 100";

                return true;
            }
            return false;
        }

        public void restProduct()
        {
            this.Quantity_in_stock--;
        }

        public void sumQuantity(int quantity)
        {
            this.Quantity_in_stock += quantity;
        }

    }
}