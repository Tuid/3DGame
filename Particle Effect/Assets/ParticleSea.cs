using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityStandardAssets.ImageEffects;


public class ParticleSea : MonoBehaviour {
	public ParticleSystem particle;
	private ParticleSystem.Particle[] particles;
	public float spacing = 0.5f;

	public int width;
	public int length;

	public float[] positionZ= new float[10000];
	public float[] positionX= new float[10000];
	public float[] positionY= new float[10000];
	public float noiseScale = 0.2f;
	public float heghtScale = 3f;
	public  float time =0;
	void  Start(){
		particles = new ParticleSystem.Particle[width * length];
		particle.maxParticles = width * length;
		particle.Emit(width*length);
		particle.GetParticles(particles);
		defaultPosition ();
	}



	void Update(){
	
		time += Time.deltaTime;
		for (int i = 0; i < width; i++) {

			for (int j = 0; j < length; j++) {
				float z = positionZ[i * width +j];
				particles [i * width +j].position = new Vector3(i*spacing ,j*spacing,positionZ [i * width + j]);
			   
			}
		particle.SetParticles (particles, particles.Length);
		}
	}
		
     void defaultPosition (){
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < length; j++) {
				float z = Mathf.PerlinNoise (i * noiseScale + 0.01f, j * noiseScale + 0.01f) * heghtScale;
				positionZ [i * width + j] = z;
			}

		}
	}


}