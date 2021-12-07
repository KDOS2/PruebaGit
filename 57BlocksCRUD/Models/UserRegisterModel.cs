using System.ComponentModel.DataAnnotations;

namespace _57BlocksCRUD.Models
{
    public class UserRegisterModel
    {
        public int UserId { get; set; }
        
        /// <summary>
        /// nombre del usuario
        /// </summary>
        [Required]
        [StringLength(255)]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        /// <summary>
        /// apellido del usuario
        /// </summary>
        [Required]
        [StringLength(255)]
        [Display(Name = "Last name")]
        public string UserlastName { get; set; }

        /// <summary>
        /// email del usuario
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(255)]  
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
         ErrorMessage = "Email is not valid")]
        public string email { get; set; }

        /// <summary>
        /// password del usuario
        /// </summary>
        [Required]
        [StringLength(255)]
        [Display(Name = "Password")]
        public string pws { get; set; }
    }
}
