namespace LUPNeo
{
    shader SceneData
    {
	    cbuffer SceneData {
    		mat4 projection;
            mat4 view;
            mat4 viewWithoutPos;
            vec3 viewPos;
            vec2 resolution;
            float time;
            vec3 ambient;
    	} scene_data;
    }
}