namespace _57BlocksCRUD.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        private string _email;
        private string _pws;

        [Required]
        [EmailAddress]
        [StringLength(255)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$",
         ErrorMessage = "Email is not valid")]
        public string email { get { return _email; } set { _email = value; } }

        [Required]
        [StringLength(255)]
        [Display(Name = "Password")]
        public string pws { get { return _pws; } set { _pws = value; } }

        /// <summary>
        /// fecha de ingreso
        /// </summary>
        public DateTime date { get; set; }

        /// <summary>
        /// hora de ingreso
        /// </summary>
        public int hour { get; set; }

    }
}
