using UnityEngine;  
using UnityEngine.UI;  

public class BloodImage : RawImage {  

	private Slider BloodSlider;  

	protected override void OnRectTransformDimensionsChange()  
	{  
		base.OnRectTransformDimensionsChange();  

 
		if (BloodSlider == null)  
			BloodSlider = transform.parent.parent.GetComponent<Slider>();  

		if (BloodSlider != null)  
		{  

			float value = BloodSlider.value;  
			uvRect = new Rect(0,0,value,1);  
		}  
	}  
}  