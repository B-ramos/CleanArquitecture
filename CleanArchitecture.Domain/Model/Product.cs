using System;

namespace CleanArchitecture.Domain.Model
{
    public class Product : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


        // exemplo simples de update, ele verifica se a própeiedade não é nula e substitui pela original, caso sejá nula ele mantem a original
        public void Update(Product newProduct)
        {
            if (newProduct.Name is not null)
                this.Name = newProduct.Name;

            if (newProduct.Description is not null)
                this.Description = newProduct.Description;

            if (newProduct.Price != this.Price && newProduct.Price > 0)// aqui ele só troca se o preço for diferente do original e maior que 0
                this.Price = newProduct.Price;

            this.UpdatedAt = DateTime.Now; // acrescenta a data de atualização
        }
    }
}
