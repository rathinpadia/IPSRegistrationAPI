using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IPS_API.Model
{
    public class AccountType
    {
        [Key]
        public int AccountTypeId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string AccountTypeName { get; set; }

    }

    public class AssociatedIndividual
    {
        [Key]
        public int AssociatedIndividualId { get; set; }
        [Column(TypeName = "varchar(4)")]
        [Required]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateofBirth { get; set; }
    
        public int AccountTypeId { get; set; }
        [ForeignKey("AccountTypeId")]
        public virtual AccountType AccountType { get; set; }
    }
    public class PersonalAccount
    {
        [Key]
        public int PersonalAccountId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string AccountName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(9)")]
        public string TFN { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string AccountNo { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string BSB { get; set; }

        public ICollection<AssociatedIndividual> AssociatedIndividualPersonal { get; set; }
    }
    public class CorporateAccount
    {
        [Key]
        public int CorporateAccountId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string AccountName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CompanyName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(9)")]
        public string ABN { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string AccountNo { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string BSB { get; set; }
        public ICollection<CompanyOfficer> CompanyOfficers { get; set; }
        public ICollection<AssociatedIndividual> AssociatedIndividualCorporate { get; set; }
    }

    public class CompanyOfficer
    {
        [Key]
        public int CompanyOfficerId { get; set; }
        [Column(TypeName = "varchar(4)")]
        [Required]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
    }
}
