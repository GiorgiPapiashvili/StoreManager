﻿namespace StoreManager.DTO
{
    public class City
    {
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
