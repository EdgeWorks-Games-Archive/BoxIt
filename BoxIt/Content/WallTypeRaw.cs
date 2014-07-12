namespace BoxIt.Content
{
	public sealed class WallTypeRaw
	{
		public string Name { get; set; }
		public string TextureLocation { get; set; }
		public int HeightOffset { get; set; }

		public bool HasTop { get; set; }
		public string TopTextureLocation { get; set; }
	}
}