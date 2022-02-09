using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Model
{
    [Table("Rol",Schema ="Security")]   //se usa definir el nombre y el schema que tendra la tabla en la bd
    public class RolEntity
    {
        [Key]
        public int IdRol { get; set; }

        [MaxLength(100)]
        public string Rol { get; set; }
        
        public IEnumerable<RolUserEntity> RolUserEntities {get;set;}   //esto se usa para relacionar tablass
        public IEnumerable<RolPermissionEntity> RolPermissionEntities { get; set; }

    }
}
