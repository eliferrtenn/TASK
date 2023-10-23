using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VardabitCore.Common.EntityModel
{
	public abstract class EntityBase
	{
        public virtual long ID { get; set; }
        public virtual DateTime Yaratilma_Tarihi { get; set; } = DateTime.Now;
        public virtual DateTime Degistirilme_Tarihi { get; set; } = DateTime.Now;
        public virtual bool isDeleted { get; set; } = false;
        public virtual bool isActive { get; set; } = true;
    }
}