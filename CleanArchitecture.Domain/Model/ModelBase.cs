using CleanArchitecture.Domain.Enums;
using System;

namespace CleanArchitecture.Domain.Model
{
    abstract public class ModelBase // Só pode ser herdada e não instanciada
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public EnumStatus Status { get; set; }

        public ModelBase()
        {
            CreatedAt = DateTime.Now; // Valor padrão ao criar um objeto
            UpdatedAt = null;
        }
    }
}
