using System;

namespace GeeksChallenge.CloudLibrary.Dtos
{
	public class OptionDefaultValuesUpsertDto
	{
		public int Id { get; set; }
		public string OptionValue { get; set; }
		public int ServiceOptionId { get; set; }
		public int CreatedById { get; set; }
		public int? UpdatedById { get; set; }
		public int? DeletedById { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public DateTime? DeletedDate { get; set; }


 

	}
}
