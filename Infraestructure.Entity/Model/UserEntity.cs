
using Infraestructure.Entity.Vet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Model
{
    [Table("User", Schema = "Security")]
    public class UserEntity
    {
        [Key]
        public int IdUser { get; set; }
        [Required(ErrorMessage ="el nombre es requerido")]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "el apellido es requerido")]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "el email es requerido")]
        [MaxLength(200)]
        public string Email { get; set; }
        [Required(ErrorMessage = "la contraseña es requerida")]
        [MaxLength(200)]
        public string Password { get; set; }
        public IEnumerable<RolUserEntity> RolUserEntities { get; set; }   //esto se usa para relacionar tablas(en este caso relacionamos
                                                                          //con la tabla RolUserEntity

        public IEnumerable<UserPetEntity> UserPetEntities { get; set; }
        

        [NotMapped]
        public string FullName {get{return $"{this.Name} {this.LastName}"; }}
    }

}
