namespace AutoMeetsUI
{
	/// <summary>
	/// Styles of page animations for appearing/disappearing
	/// </summary>
	public enum PageAnimation
	{
		/// <summary>
		/// No animation takes place
		/// </summary>
		None = 0,

		/// <summary>
		/// The page slides in and fades in from the bottom
		/// </summary>
		SlideAndFadeInFromBottom = 1,

		/// <summary>
		/// The pages slides out and fades out from the top
		/// </summary>
		SlideAndFadeOutToTop = 2,

		/// <summary>
		/// The extra page slides in and fades in from the right
		/// </summary>
		ExtraSlideAndFadeInFromRight = 3,

		/// <summary>
		/// The extra pages slides out and fades out from the right
		/// </summary>
		ExtraSlideAndFadeOutToRight = 4,

		/// <summary>
		/// The extra page slides in and fades in from the left
		/// </summary>
		ExtraSlideAndFadeInFromLeft = 5,

		/// <summary>
		/// The extra pages slides out and fades out from the lfet
		/// </summary>
		ExtraSlideAndFadeOutToLeft = 6,

		/// <summary>
		/// The extra page slides in and fades in from the bottom
		/// </summary>
		ExtraSlideAndFadeInFromBottom = 7,

		/// <summary>
		/// The extra pages slides out and fades out from the bottom
		/// </summary>
		ExtraSlideAndFadeOutToBottom = 8,
	}
}
