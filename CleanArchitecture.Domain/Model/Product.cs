using System;

namespace CleanArchitecture.Domain.Model
{
    public class Product : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void Update(Product newProduct)
        {
            if (newProduct.Name is not null)
                this.Name = newProduct.Name;

            if (newProduct.Description is not null)
                this.Description = newProduct.Description;

            if (newProduct.Price != this.Price && newProduct.Price > 0)
                this.Price = newProduct.Price;

            this.UpdatedAt = DateTime.Now;
        }
    }
}
