shader SceneProvider
{
	cbuffer(0) SceneData
	{
		mat4 projection;
		mat4 view;
		mat4 viewPositionless;
		float time;
		vec3 viewPosition;
		vec2 viewport;
		vec2 screen;
		float zFar;
		float zNear;
	};
}