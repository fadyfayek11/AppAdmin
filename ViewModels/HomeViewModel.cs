namespace App.Admin.ViewModels
{
	public class HomeViewModel
	{
		public List<TestimonyHomeViewModel> Testimonies { get; set; }
		public List<RoomsHomeViewModel>? Rooms { get; set; }
		public List<TeamHomeViewModel> Team { get; set; }
		public List<CoverTexts>? Covers { get; set; }
		public AboutModel? About { get; set; }

    }

	public class TestimonyHomeViewModel
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string UserName { get; set; }
		public string UserJob { get; set; }

	}
	public class RoomsHomeViewModel
	{
		public int RoomId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string CoverImagePath { get; set; }
		public double Price { get; set; }
	}
    public class RoomHomeViewModel
	{
		public int RoomId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string CoverImagePath { get; set; }
        public double Price { get; set; }
        public double Size { get; set; }
        public int MaxOccupancy { get; set; }
        public bool AllowSmoking { get; set; }
        public ICollection<RoomDetailsHomeViewModel>? RoomDetails { get; set; }
        public ICollection<RoomImagesHomeViewModel>? RoomImages { get; set; }
    }
	public class RoomDetailsHomeViewModel
	{
		public string DetailName { get; set; }
		public bool IsIcon { get; set; }
		public int RoomId { get; set; }
		public List<DetailsDescriptionHomeViewModel> DetailsDescription { get; set; }
	}
	public class RoomImagesHomeViewModel
	{
		public string Path { get; set; }
		public int RoomId { get; set; }
	}
	public class DetailsDescriptionHomeViewModel
	{
		public string? Description { get; set; }
		public bool IsIcon { get; set; }
		public int RoomDetailsId { get; set; }

	}
	public class TeamHomeViewModel
	{
		public string Key { get; set; }
		public string Value { get; set; }
	}
}
