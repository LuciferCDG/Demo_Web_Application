using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using DomainModel = Demo_Web_Application.Core.Model;

namespace Demo_Web_Application.Models
{
    public class StudentDto
    {

        #region constructor
        public StudentDto()
        {
        }

        public StudentDto(DomainModel.Student domainModel) { ConvertToViewModel(domainModel); }


        public StudentDto ConvertToViewModel(DomainModel.Student domainModel)
        {
            return Mapper.Map(domainModel, this);
        }

        public DomainModel.Student ConvertToDomianModel()
        {
            var domainModel = new DomainModel.Student();
            return Mapper.Map(this, domainModel);
        }
        #endregion

        public int StudentId { get; set; }
        public string StuName { get; set; }
        public string FName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string StuEmail { get; set; }
        public string StuPassword { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Locality { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public string Photo { get; set; }
        public string Signature { get; set; }

        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }

    }
}