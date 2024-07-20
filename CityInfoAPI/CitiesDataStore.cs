using CityInfoAPI.Models;

namespace CityInfoAPI
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public static CitiesDataStore current { get; } = new CitiesDataStore();

        public CitiesDataStore() => Cities = new List<CityDto>()
        {
            new CityDto()
            {
                Id = 1, Name = "Tabriz", Description = "My City", PointOfInterests = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto()
                    {
                        Id = 1,
                        Name = "Jaye Didani 1",
                        Description = "This is 1"
                    },
                    new PointOfInterestDto()
                    {
                        Id = 2,
                        Name = "Jaye Didani 2",
                        Description = "This is 2"
                    }
                }
            },
            new CityDto()
            {
                Id = 2, Name = "Tehran", Description = "My City", PointOfInterests = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto()
                    {
                        Id = 3,
                        Name = "Jaye Didani 3",
                        Description = "This is 3"
                    },
                    new PointOfInterestDto()
                    {
                        Id = 4,
                        Name = "Jaye Didani 4",
                        Description = "This is 4"
                    }
                }
            },
            new CityDto()
            {
                Id = 3,
                Name = "Esfahan",
                Description = "My City",
                PointOfInterests = new List<PointOfInterestDto>()
                {
                    new PointOfInterestDto()
                    {
                        Id = 5,
                        Name = "Jaye Didani 5",
                        Description = "This is 5"
                    },
                    new PointOfInterestDto()
                    {
                        Id = 6,
                        Name = "Jaye Didani 6",
                        Description = "This is 6"
                    }
                }
            }
        };
    }
}




