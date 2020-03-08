using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escena_Actividad : MonoBehaviour {

	//---------------------------------------------
	//--------------Tema a mostrar-----------------
	//---------------------------------------------
	public Text texto_logo;
	public GameObject fracciones_logo;
	public GameObject multiplicaciones_logo;
	public GameObject geometria_logo;
	public GameObject series_logo;
	//---------------------------------------------
	//---------------------------------------------
	//---------------------------------------------
	//---------------------------------------------
	//------------Animación libreta----------------
	//---------------------------------------------
	public  Texture2D[] frames;
	public float framesPorSegundo = 10;
	public RawImage libreta;
	private bool bandera_abriendo_libreta = true;
	private float aux_opacidad = 0f;
	//---------------------------------------------
	//---------------------------------------------
	//---------------------------------------------
	//-------------------------------------------------------------
	//-----------------Elementos de la libreta---------------------
	//-------------------------------------------------------------
	public GameObject GO_titulo;
	public GameObject GO_pregunta;
	public GameObject GO_opcion_1;
	public GameObject GO_opcion_2;
	public GameObject GO_opcion_3;
	public GameObject GO_opcion_4;
	public GameObject GO_subtitulo;
	public GameObject GO_avion_lapiz_1;
	public GameObject GO_avion_lapiz_2;
	public GameObject GO_avion_lapiz_3;
	public GameObject GO_avion_lapiz_4;
	//Libreta > aviones a lápiz
	private bool bandera_termino_opacidad = false;
	//AVIÓN 1
	public GameObject GO_subtitulo_avion_1;
	public GameObject GO_num_1_1;public GameObject GO_fondo_1_1;
	public GameObject GO_num_2_1;public GameObject GO_fondo_2_1;
	public GameObject GO_num_3_1;public GameObject GO_fondo_3_1;
	public GameObject GO_num_4_1;public GameObject GO_fondo_4_1;
	public GameObject GO_num_5_1;public GameObject GO_fondo_5_1;
	public GameObject GO_num_6_1;public GameObject GO_fondo_6_1;
	public GameObject GO_num_7_1;public GameObject GO_fondo_7_1;
	public GameObject GO_num_8_1;public GameObject GO_fondo_8_1;
	public GameObject GO_num_9_1;public GameObject GO_fondo_9_1;
	public GameObject GO_num_10_1;public GameObject GO_fondo_10_1;
	//AVIÓN 2
	public GameObject GO_subtitulo_avion_2;
	public GameObject GO_num_1_2;public GameObject GO_fondo_1_2;
	public GameObject GO_num_2_2;public GameObject GO_fondo_2_2;
	public GameObject GO_num_3_2;public GameObject GO_fondo_3_2;
	public GameObject GO_num_4_2;public GameObject GO_fondo_4_2;
	public GameObject GO_num_5_2;public GameObject GO_fondo_5_2;
	public GameObject GO_num_6_2;public GameObject GO_fondo_6_2;
	public GameObject GO_num_7_2;public GameObject GO_fondo_7_2;
	public GameObject GO_num_8_2;public GameObject GO_fondo_8_2;
	public GameObject GO_num_9_2;public GameObject GO_fondo_9_2;
	public GameObject GO_num_10_2;public GameObject GO_fondo_10_2;
	//AVIÓN 3
	public GameObject GO_subtitulo_avion_3;
	public GameObject GO_num_1_3;public GameObject GO_fondo_1_3;
	public GameObject GO_num_2_3;public GameObject GO_fondo_2_3;
	public GameObject GO_num_3_3;public GameObject GO_fondo_3_3;
	public GameObject GO_num_4_3;public GameObject GO_fondo_4_3;
	public GameObject GO_num_5_3;public GameObject GO_fondo_5_3;
	public GameObject GO_num_6_3;public GameObject GO_fondo_6_3;
	public GameObject GO_num_7_3;public GameObject GO_fondo_7_3;
	public GameObject GO_num_8_3;public GameObject GO_fondo_8_3;
	public GameObject GO_num_9_3;public GameObject GO_fondo_9_3;
	public GameObject GO_num_10_3;public GameObject GO_fondo_10_3;
	//AVIÓN 4
	public GameObject GO_subtitulo_avion_4;
	public GameObject GO_num_1_4;public GameObject GO_fondo_1_4;
	public GameObject GO_num_2_4;public GameObject GO_fondo_2_4;
	public GameObject GO_num_3_4;public GameObject GO_fondo_3_4;
	public GameObject GO_num_4_4;public GameObject GO_fondo_4_4;
	public GameObject GO_num_5_4;public GameObject GO_fondo_5_4;
	public GameObject GO_num_6_4;public GameObject GO_fondo_6_4;
	public GameObject GO_num_7_4;public GameObject GO_fondo_7_4;
	public GameObject GO_num_8_4;public GameObject GO_fondo_8_4;
	public GameObject GO_num_9_4;public GameObject GO_fondo_9_4;
	public GameObject GO_num_10_4;public GameObject GO_fondo_10_4;
	//-------------------------------------------------------------
	//-------------------------------------------------------------
	//-------------------------------------------------------------
	//-------------------------------------------------------------
	//-------------Animación movimiento del fondo------------------
	//-------------------------------------------------------------
	public GameObject fondo_animacion_fracciones;
    public GameObject fondo_animacion_multiplicaciones;
    public GameObject fondo_animacion_geometria;
    public GameObject fondo_animacion_series;
	private RectTransform RT_fondo_fracciones;
    private RectTransform RT_fondo_multiplicaciones;
    private RectTransform RT_fondo_geometria;
    private RectTransform RT_fondo_series;
    private bool bandera_animacion_fondo;
    //-------------------------------------------------------------
    //-------------------------------------------------------------
    //-------------------------------------------------------------
    //-------------------------------------------------------------
    //---------------------Barra de tiempo-------------------------
    //-------------------------------------------------------------
    public GameObject barra_de_tiempo;
    private float progreso_barra = 1f;
    //-------------------------------------------------------------
    //-------------------------------------------------------------
    //-------------------------------------------------------------
    //-------------------------------------------------------------
    //--------------------------Vidas------------------------------
    //-------------------------------------------------------------
    public  Texture2D[] frames_vidas;
	public float framesPorSegundo_vidas = 10;
	public GameObject vida_1;
	public GameObject vida_2;
	public GameObject vida_3;
	public GameObject vida_4;
	public GameObject vida_5;
    //-------------------------------------------------------------
    //-------------------------------------------------------------
    //-------------------------------------------------------------

    void Start() {
    	//----------------------------------------------------------
        //-----------Animación movimiento del fondo-----------------
        //----------------------------------------------------------
        RT_fondo_fracciones = fondo_animacion_fracciones.GetComponent<RectTransform>();
        RT_fondo_multiplicaciones = fondo_animacion_multiplicaciones.GetComponent<RectTransform>();
        RT_fondo_geometria = fondo_animacion_geometria.GetComponent<RectTransform>();
        RT_fondo_series = fondo_animacion_series.GetComponent<RectTransform>();
        bandera_animacion_fondo = true;
        //----------------------------------------------------------
        //----------------------------------------------------------
        //----------------------------------------------------------
        //----------------------------------------------------------
        //--------------Objetos de la libreta-----------------------
        //----------------------------------------------------------
        GO_titulo.SetActive(false);
		GO_pregunta.SetActive(false);
		GO_opcion_1.SetActive(false);
		GO_opcion_2.SetActive(false);
		GO_opcion_3.SetActive(false);
		GO_opcion_4.SetActive(false);
		GO_subtitulo.SetActive(false);
		GO_avion_lapiz_1.SetActive(false);
		GO_avion_lapiz_2.SetActive(false);
		GO_avion_lapiz_3.SetActive(false);
		GO_avion_lapiz_4.SetActive(false);
		//----------------------------------------------------------
		//----------------------------------------------------------
		//----------------------------------------------------------
		//----------------------------------------------------------
		//-------Inicialización de variables de control-------------
		//----------------------------------------------------------
		barra_de_tiempo.GetComponent<Image>().fillAmount = 1f;
		//----------------------------------------------------------
		//----------------------------------------------------------
		//----------------------------------------------------------
		//------------------Tema a mostrar--------------------------
		switch (PlayerPrefs.GetInt("seleccion_de_tema")) {
			case 1: texto_logo.text = "Fracciones"; 
				fracciones_logo.SetActive(true); 
				multiplicaciones_logo.SetActive(false); 
				geometria_logo.SetActive(false); 
				series_logo.SetActive(false);
				fondo_animacion_fracciones.SetActive(true); 
				fondo_animacion_multiplicaciones.SetActive(false); 
				fondo_animacion_geometria.SetActive(false); 
				fondo_animacion_series.SetActive(false); 
				break;
			case 2: texto_logo.text = "Multiplicaciones"; 
				fracciones_logo.SetActive(false); 
				multiplicaciones_logo.SetActive(true); 
				geometria_logo.SetActive(false); 
				series_logo.SetActive(false); 
				fondo_animacion_fracciones.SetActive(false); 
				fondo_animacion_multiplicaciones.SetActive(true); 
				fondo_animacion_geometria.SetActive(false); 
				fondo_animacion_series.SetActive(false); 
				break;
			case 3: texto_logo.text = "Geometría"; 
				fracciones_logo.SetActive(false); 
				multiplicaciones_logo.SetActive(false); 
				geometria_logo.SetActive(true); 
				series_logo.SetActive(false); 
				fondo_animacion_fracciones.SetActive(false); 
				fondo_animacion_multiplicaciones.SetActive(false); 
				fondo_animacion_geometria.SetActive(true); 
				fondo_animacion_series.SetActive(false); 
				break;
			case 4: texto_logo.text = "Series"; 
				fracciones_logo.SetActive(false); 
				multiplicaciones_logo.SetActive(false); 
				geometria_logo.SetActive(false); 
				series_logo.SetActive(true); 
				fondo_animacion_fracciones.SetActive(false); 
				fondo_animacion_multiplicaciones.SetActive(false); 
				fondo_animacion_geometria.SetActive(false); 
				fondo_animacion_series.SetActive(true); 
				break;
		}
		//----------------------------------------------------------
    }


    void Update() {
    	//-------------------------------------------------------------
        //-------------------Movimieto del fondo-----------------------
        //-------------------------------------------------------------
        if(bandera_animacion_fondo){
            RT_fondo_fracciones.transform.Translate(new Vector3(0.15f,0.15f,0.15f));
            RT_fondo_multiplicaciones.transform.Translate(new Vector3(0.15f,0.15f,0.15f));
            RT_fondo_geometria.transform.Translate(new Vector3(0.15f,0.15f,0.15f));
            RT_fondo_series.transform.Translate(new Vector3(0.15f,0.15f,0.15f));
        } else {
            RT_fondo_fracciones.transform.Translate(new Vector3(-0.15f,-0.15f,-0.15f));
            RT_fondo_multiplicaciones.transform.Translate(new Vector3(-0.15f,-0.15f,-0.15f));
            RT_fondo_geometria.transform.Translate(new Vector3(-0.15f,-0.15f,-0.15f));
            RT_fondo_series.transform.Translate(new Vector3(-0.15f,-0.15f,-0.15f));
        }
        //-------------------------------------------------------------
        if(RT_fondo_fracciones.transform.position.y>370f){
            bandera_animacion_fondo = false;
        }
        if(RT_fondo_fracciones.transform.position.y<=(-36.0002f)){
            bandera_animacion_fondo = true;
        }
        //-------------------------------------------------------------
        //-------------------------------------------------------------
        //-------------------------------------------------------------
    	//-----------------------------------------------------------------------
        //------------------------Animación libreta------------------------------
        //-----------------------------------------------------------------------
        if(bandera_abriendo_libreta) {
        	int index = (int)(Time.time*framesPorSegundo) % frames.Length;
        	libreta.texture = frames[index];
        	if(index == frames.Length-1){
        		bandera_abriendo_libreta = false;
        	}
    	} else {//cuando termine animación de abrir libreta
    		//---------------------------------------------------------------------------------------------------------------
    		//----------------------------------------Incrementar opacidad---------------------------------------------------
    		//---------------------------------------------------------------------------------------------------------------
    		if(!bandera_termino_opacidad){
    		if(aux_opacidad<0.7f){
    			aux_opacidad+=0.005f;
    		} else {
    			bandera_termino_opacidad = true;
    		}
    		GO_titulo.GetComponent<Text>().color = new Color(0f,0f,0f,aux_opacidad);
			GO_pregunta.GetComponent<Text>().color = new Color(0f,0f,0f,aux_opacidad);
			GO_opcion_1.GetComponent<Text>().color = new Color(0f,0f,0f,aux_opacidad);
			GO_opcion_2.GetComponent<Text>().color = new Color(0f,0f,0f,aux_opacidad);
			GO_opcion_3.GetComponent<Text>().color = new Color(0f,0f,0f,aux_opacidad);
			GO_opcion_4.GetComponent<Text>().color = new Color(0f,0f,0f,aux_opacidad);
			GO_subtitulo.GetComponent<Text>().color = new Color(0f,0f,0f,aux_opacidad);
			GO_avion_lapiz_1.GetComponent<Image>().color = new Color(0f,0f,0f,aux_opacidad);
			GO_avion_lapiz_2.GetComponent<Image>().color = new Color(0f,0f,0f,aux_opacidad);
			GO_avion_lapiz_3.GetComponent<Image>().color = new Color(0f,0f,0f,aux_opacidad);
			GO_avion_lapiz_4.GetComponent<Image>().color = new Color(0f,0f,0f,aux_opacidad);
			//Avión 1
			GO_subtitulo_avion_1.GetComponent<Text>().color = new Color(0f,0f,0f,aux_opacidad);
			GO_num_1_1.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_1_1.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_2_1.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_2_1.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_3_1.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_3_1.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_4_1.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_4_1.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_5_1.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_5_1.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_6_1.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_6_1.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_7_1.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_7_1.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_8_1.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_8_1.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_9_1.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_9_1.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_10_1.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_10_1.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			//Avión 2
			GO_subtitulo_avion_2.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);
			GO_num_1_2.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_1_2.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_2_2.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_2_2.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_3_2.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_3_2.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_4_2.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_4_2.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_5_2.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_5_2.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_6_2.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_6_2.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_7_2.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_7_2.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_8_2.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_8_2.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_9_2.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_9_2.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_10_2.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_10_2.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			//Avión 3
			GO_subtitulo_avion_3.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);
			GO_num_1_3.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_1_3.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_2_3.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_2_3.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_3_3.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_3_3.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_4_3.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_4_3.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_5_3.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_5_3.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_6_3.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_6_3.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_7_3.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_7_3.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_8_3.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_8_3.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_9_3.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_9_3.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_10_3.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_10_3.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			//Avión 4
			GO_subtitulo_avion_4.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);
			GO_num_1_4.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_1_4.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_2_4.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_2_4.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_3_4.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_3_4.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_4_4.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_4_4.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_5_4.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_5_4.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_6_4.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_6_4.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_7_4.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_7_4.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_8_4.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_8_4.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_9_4.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_9_4.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			GO_num_10_4.GetComponent<Text>().color = new Color(0.19f,0.19f,0.19f,aux_opacidad);GO_fondo_10_4.GetComponent<Image>().color = new Color(0.21f,0.63f,1f,aux_opacidad);
			}
			//---------------------------------------------------------------------------------------------------------------
			//---------------------------------------------------------------------------------------------------------------
			//---------------------------------------------------------------------------------------------------------------
			//Hacer visible
    		GO_titulo.SetActive(true);
			GO_pregunta.SetActive(true);
			GO_opcion_1.SetActive(true);
			GO_opcion_2.SetActive(true);
			GO_opcion_3.SetActive(true);
			GO_opcion_4.SetActive(true);
			GO_subtitulo.SetActive(true);
			GO_avion_lapiz_1.SetActive(true);
			GO_avion_lapiz_2.SetActive(true);
			GO_avion_lapiz_3.SetActive(true);
			GO_avion_lapiz_4.SetActive(true);
			//----------------------------------------
			//----------------------------------------
    	}
        //-----------------------------------------------------------------------
        //-----------------------------------------------------------------------
        //-----------------------------------------------------------------------
    	//-----------------------------------------------------------------------
    	//--------------------------Barra de tiempo------------------------------
    	//-----------------------------------------------------------------------
    	if(progreso_barra>0f){
    		progreso_barra-=0.00025f;
    	}
    	barra_de_tiempo.GetComponent<Image>().fillAmount = progreso_barra;
    	//-----------------------------------------------------------------------
    	//-----------------------------------------------------------------------
    	//-----------------------------------------------------------------------
    	//-----------------------------------------------------------------------
    	//-------------------------------Vidas-----------------------------------
    	//-----------------------------------------------------------------------
    	int index_1 = (int)(Time.time*framesPorSegundo_vidas) % frames_vidas.Length;
        vida_1.GetComponent<RawImage>().texture = frames_vidas[index_1];
        vida_2.GetComponent<RawImage>().texture = frames_vidas[index_1];
		vida_3.GetComponent<RawImage>().texture = frames_vidas[index_1];
		vida_4.GetComponent<RawImage>().texture = frames_vidas[index_1];
		vida_5.GetComponent<RawImage>().texture = frames_vidas[index_1];
    	//-----------------------------------------------------------------------
    	//-----------------------------------------------------------------------
    	//-----------------------------------------------------------------------
    }//fin update
}
