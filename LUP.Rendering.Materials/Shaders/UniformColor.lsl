
shader UniformColor : IComputeColor
{
	uniform vec4 <color>;

	override vec4 Compute()
	{
		return color;
	}
}