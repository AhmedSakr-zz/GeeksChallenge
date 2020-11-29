using System;
using System.Collections.Generic;
using GeeksChallenge.Domain.Models;

namespace GeeksChallenge.CloudLibrary.Dtos
{
    public class ServicesUpsertDto
    {
        public ServicesUpsertDto()
        {
            ServiceOptions = new List<ServiceOptionsUpsertDto>();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedById { get; set; }
        public int? UpdatedById { get; set; }
        public int? DeletedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public List<ServiceOptionsUpsertDto> ServiceOptions { get; set; }



    }
}
