using Core.Entities;
using CoreNT.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleaningEntities
{

    public class SupplierParameter
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; } = 34;
        public int DistrictId { get; set; } = 422;
        public int QuarterId { get; set; } = 32378;
    }

    public class Customer : IEntity
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        [Required(ErrorMessage = "Telefon boş bırakılamaz")]
        [StringLength(40, ErrorMessage = "En az 10 karakter olmalı", MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "İsim boş bırakılamaz")]
        [StringLength(50, ErrorMessage = "En fazla 50 karakter olabilir")]
        public string Name { get; set; }

        public int BackupId { get; set; }
    }
    public class AddressCustomer : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int QuarterId { get; set; }
        public string Address { get; set; }
    }
    public class CustomerNote : IEntity
    {
        [Key]
        public int NoteId { get; set; }
        public int CustomerId { get; set; }
        public string Note { get; set; }
    }

    public class District : IEntity, INameId
    {
        [Key]
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
    }

    public class Quarter : IEntity, INameId
    {
        [Key]
        public int Id { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }
    }

    public class City : IEntity, INameId
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OrderOld : IEntity
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int Status { get; set; }
        public DateTime? TakingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int Terminal { get; set; }
        [Range(0, 50000, ErrorMessage = "Makul bir değer girin!")]
        public decimal? Total { get; set; }
        public decimal? Paid { get; set; }
        public string Note { get; set; }
    }

    public class Order : IEntity
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int Status { get; set; }
        public DateTime? TakingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int Terminal { get; set; }
        [Range(0, 50000, ErrorMessage = "Makul bir değer girin!")]
        public decimal? Total { get; set; }
        public decimal? Paid { get; set; }
        public string Note { get; set; }
    }

    public class OrderRow : IEntity
    {
        [Key]
        public int RowId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int M2 { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
    }

    public class Product : IEntity
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string QuentityType { get; set; }
    }

    public class CustomerDto : IDto
    {
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int QuarterId { get; set; }
        public string Address { get; set; }
    }

    public class CustomerOrderDto : IDto
    {
        public Customer Customer { get; set; }
        public Order Order { get; set; }
    }

    public interface IDto
    {
    }

    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
    public class UserForRegisterDto : IDto
    {
        //[Required(ErrorMessage = "Email boş bırakılamaz")]
        //[EmailAddress]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Şifre girmediniz")]
        //[StringLength(255, ErrorMessage = "En az 6 karakter olmalı", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }


        //[Required(ErrorMessage = "2 şifre de aynı olmalı")]
        //[StringLength(255, ErrorMessage = "En az 6 karakter olmalı", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Compare("Password")]
        public string ConfirmPassword { get; set; }


        //[Required(ErrorMessage = "İsim boş bırakılamaz")]
        public string SupplierName { get; set; }
#nullable enable
        public string? OwnerName { get; set; }


        //[Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
        public string? IdentityName { get; set; }

        public string? PhoneNumber { get; set; }

        public int SupplierId { get; set; }

    }


}
