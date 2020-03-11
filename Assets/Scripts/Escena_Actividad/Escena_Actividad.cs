using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.IO;
using System.Linq;
using InTheHand.Devices.Bluetooth;
using InTheHand.Devices.Bluetooth.Rfcomm;
using InTheHand.Devices.Enumeration;
using System.Data;
using Mono.Data.Sqlite;

public class Escena_Actividad : MonoBehaviour {

	public bool modo_prueba;
	//--------------------------------------------------------
	//-----------Variables Base de Datos SQLite---------------
	//--------------------------------------------------------
	private string BDfile;
	private IDataReader puntero_preguntas;
	//--------------------------------------------------------
	//--------------------------------------------------------
	//--------------------------------------------------------
	//--------------------------------------------------------
    //-----------Variables de control Bluetooth---------------
    //--------------------------------------------------------
    private bool bandera_cambio_de_linea = false;
    private bool[] estado_botones = new bool[10];
    private Stream _Stream;
    private byte contador_array_estado_botones = 0;
    private bool bandera_sincronizacion = true;
    //---------------Control botones--------------------
    private bool bandera_control_boton_1 = false;
    private bool bandera_control_boton_2 = false;
    private bool bandera_control_boton_3 = false;
    private bool bandera_control_boton_4 = false;
    private bool bandera_control_boton_5 = false;
    private bool bandera_control_boton_6 = false;
    private bool bandera_control_boton_7 = false;
    private bool bandera_control_boton_8 = false;
    private bool bandera_control_boton_9 = false;
    private bool bandera_control_boton_10 = false;
    //--------------------------------------------------
    //--------------------------------------------------------
    //--------------------------------------------------------
    //--------------------------------------------------------
    //-----------------
    //Pisadas del avión
    //-----------------
    public GameObject pie_1;
    public GameObject pie_2;
    public GameObject pie_3;
    public GameObject pie_4;
    public GameObject pie_5;
    public GameObject pie_6;
    public GameObject pie_7;
    public GameObject pie_8;
    public GameObject pie_9;
    public GameObject pie_10;
    //-----------------
    private bool acceso_bloqueado_1 = false;
    private bool acceso_bloqueado_2 = false;
    private bool acceso_bloqueado_3 = false;
    private bool acceso_bloqueado_4 = false;
    private bool acceso_bloqueado_5 = false;
    private bool acceso_bloqueado_6 = false;
    private bool acceso_bloqueado_7 = false;
    private bool acceso_bloqueado_8 = false;
    private bool acceso_bloqueado_9 = false;
    private bool acceso_bloqueado_10 = false;
    private bool acceso_bloqueado_11 = false;
    private bool acceso_bloqueado_12 = false;
    //-----------------
    //-----------------
    //-----------------
    //-------------------
    //Manejo de respuesta
    //-------------------
    public Image barra_progreso_respuesta;
    private int estado_de_la_respuesta = 1;
    private int nodos_de_la_respuesta;
    //-------------------
    //-------------------
    //-------------------
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
	public  Texture2D[] frames_pasando_pagina;
	public float framesPorSegundo = 10;
	public RawImage libreta;
	private bool bandera_abriendo_libreta = true;
	private float aux_opacidad = 0f;
	private bool animacion_pasando_pagina = false;
	private float time_inicio_frame = 0f;
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
	private bool bandera_termino_opacidad_1 = true;
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
	private byte vidas_actuales = 5;
    //-------------------------------------------------------------
    //-------------------------------------------------------------
    //-------------------------------------------------------------
    //-------------------------------------------------------------
    //-----------------Variables de control------------------------
    //-------------------------------------------------------------
    private byte pregunta_actual = 1;
    List<string> array_camino_correcto = new List<string>();
    private int tiempo_para_pregunta_actual = 0;
    private int numero_de_opciones_pregunta_actual = 0;
    private byte numero_de_preguntas = 0;
    private bool bandera_pasar_a_siguiente_pregunta = false;
    //-------------------------------------------------------------
    //-------------------------------------------------------------
    //-------------------------------------------------------------

    void Start() {
    	//--------------------------------------------------------
		//----------------Base de Datos SQLite--------------------
		//--------------------------------------------------------
		BDfile = "URI=file:" + Application.dataPath + "/BD/BD_Avion.sqlite";
		switch(PlayerPrefs.GetInt("num_preguntas")){
			case 1: numero_de_preguntas = 1; break;
			case 2: numero_de_preguntas = 3; break;
			case 3: numero_de_preguntas = 5; break;
			case 4: numero_de_preguntas = 10; break;
		}
		obtener_datos_SQLite(PlayerPrefs.GetInt("seleccion_de_tema"));
		nodos_de_la_respuesta = array_camino_correcto.Count;
		barra_progreso_respuesta.fillAmount = 0f;
		//--------------------------------------------------------
		//--------------------------------------------------------
		//--------------------------------------------------------
    	//---------------------------------------------------------------------------------------------------------------------------------
    	//------------------------------Sí modo prueba está activado no se inicia con conexión Bluetooth-----------------------------------
    	//---------------------------------------------------------------------------------------------------------------------------------
        if(!modo_prueba){
        //---------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------Control de bluetooth-----------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------
        /* Elegir el dispositivo */
        var deviceInformation = PickDevice();
        if(deviceInformation == null){ throw new InvalidDataException("Error al recibir información del dispositivo: Verifique conexión");}
        /* Abrir el serial-port stream */
        _Stream = OpenBluetoothStream(deviceInformation, RfcommServiceId.SerialPort);
        if(_Stream == null) {throw new InvalidDataException("Fallo al iniciar Stream: Servicio no diponible"); }
        //---------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------
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

    //Función que obtiene los datos de la base de datos y llena las estructuras
	private void obtener_datos_SQLite(int tema_elegido){
		//Se limpian los aviones a lápiz
		GO_fondo_1_1.SetActive(false);
		GO_fondo_2_1.SetActive(false);
		GO_fondo_3_1.SetActive(false);
		GO_fondo_4_1.SetActive(false);
		GO_fondo_5_1.SetActive(false);
		GO_fondo_6_1.SetActive(false);
		GO_fondo_7_1.SetActive(false);
		GO_fondo_8_1.SetActive(false);
		GO_fondo_9_1.SetActive(false);
		GO_fondo_10_1.SetActive(false);
		GO_fondo_1_2.SetActive(false);
		GO_fondo_2_2.SetActive(false);
		GO_fondo_3_2.SetActive(false);
		GO_fondo_4_2.SetActive(false);
		GO_fondo_5_2.SetActive(false);
		GO_fondo_6_2.SetActive(false);
		GO_fondo_7_2.SetActive(false);
		GO_fondo_8_2.SetActive(false);
		GO_fondo_9_2.SetActive(false);
		GO_fondo_10_2.SetActive(false);
		GO_fondo_1_3.SetActive(false);
		GO_fondo_2_3.SetActive(false);
		GO_fondo_3_3.SetActive(false);
		GO_fondo_4_3.SetActive(false);
		GO_fondo_5_3.SetActive(false);
		GO_fondo_6_3.SetActive(false);
		GO_fondo_7_3.SetActive(false);
		GO_fondo_8_3.SetActive(false);
		GO_fondo_9_3.SetActive(false);
		GO_fondo_10_3.SetActive(false);
		GO_fondo_1_4.SetActive(false);
		GO_fondo_2_4.SetActive(false);
		GO_fondo_3_4.SetActive(false);
		GO_fondo_4_4.SetActive(false);
		GO_fondo_5_4.SetActive(false);
		GO_fondo_6_4.SetActive(false);
		GO_fondo_7_4.SetActive(false);
		GO_fondo_8_4.SetActive(false);
		GO_fondo_9_4.SetActive(false);
		GO_fondo_10_4.SetActive(false);
		//Variables auxiliares para obtener campos de tabla "respuestas"
		int id_pregunta = 0;
		//--------------------------------------------------------------------------------------------------------------------
		//-------------------------------------CONSULTA EN TABLA PREGUNTAS----------------------------------------------------
		//--------------------------------------------------------------------------------------------------------------------
		//Se crea conexión con Base de Datos
		IDbConnection conexionBD = new SqliteConnection(BDfile);{
			conexionBD.Open();//Se abre la conexión
			//Se prepara para consulta
			IDbCommand comandoBD = conexionBD.CreateCommand();{
				string SQL = "select * from preguntas where id_tema = "+tema_elegido.ToString()+" order by random() limit "+numero_de_preguntas.ToString();
				comandoBD.CommandText = SQL;
				//Leer el resultado de la consulta
				puntero_preguntas = comandoBD.ExecuteReader();{
					if (puntero_preguntas.Read()){
						//Se llenan los textos correspondientes en la escena
						GO_titulo.GetComponent<Text>().text = "Ejercicio #1";
						GO_pregunta.GetComponent<Text>().text = puntero_preguntas.GetString(1);
						//--------------------------------------------------
						tiempo_para_pregunta_actual = puntero_preguntas.GetInt32(4);
						//Debug.Log("Tiempo para esta pregunta: "+tiempo_para_pregunta_actual+" segundos");
						id_pregunta = puntero_preguntas.GetInt32(0);
						numero_de_opciones_pregunta_actual = puntero_preguntas.GetInt32(2);
					}
				}
			}
		}
		//--------------------------------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------------------------------
		//-------------------------------------CONSULTA EN TABLA RESPUESTAS---------------------------------------------------
		//--------------------------------------------------------------------------------------------------------------------
		//Se reinicia array camino correcto
		array_camino_correcto.Clear();
		//Se crea conexión con Base de Datos
		using(IDbConnection conexionBD_1 = new SqliteConnection(BDfile)){
			conexionBD_1.Open();//Se abre la conexión
			//Se prepara para consulta
			using(IDbCommand comandoBD_1 = conexionBD_1.CreateCommand()){
				string SQL_1 = "select * from respuestas where id_pregunta = "+id_pregunta.ToString();
				comandoBD_1.CommandText = SQL_1;
				//Leer el resultado de la consulta
				using(IDataReader puntero_respuestas = comandoBD_1.ExecuteReader()){
					if (puntero_respuestas.Read()){
						GO_opcion_1.GetComponent<Text>().text = "A) "+puntero_respuestas.GetString(1);
						//------------------------
						//Desglosar campo "camino"
						//------------------------
						string texto_auxiliar = puntero_respuestas.GetString(2);
		                string cad_aux = "";//cadena auxiliar
		                int i=0;
		                while(i<texto_auxiliar.Length){
		                    while( texto_auxiliar.Substring(i,1)!="°"){
		                        cad_aux=cad_aux+texto_auxiliar.Substring(i,1);
		                        i++;
		                    }
		                    i++;
		                    //--------------------------------------
		                    //manejo gráfico de los aviones a lápiz-
		                    //--------------------------------------
		                    switch (cad_aux) {
		                    	case "1": GO_fondo_1_1.SetActive(true); break;
		                    	case "2": GO_fondo_2_1.SetActive(true); break;
		                    	case "3": GO_fondo_3_1.SetActive(true); break;
		                    	case "4": GO_fondo_4_1.SetActive(true); break;
		                    	case "5": GO_fondo_5_1.SetActive(true); break;
		                    	case "6": GO_fondo_6_1.SetActive(true); break;
		                    	case "7": GO_fondo_7_1.SetActive(true); break;
		                    	case "8": GO_fondo_8_1.SetActive(true); break;
		                    	case "9": GO_fondo_9_1.SetActive(true); break;
		                    	case "10": GO_fondo_10_1.SetActive(true); break;
		                    	case "4-5": GO_fondo_4_1.SetActive(true); GO_fondo_5_1.SetActive(true); break;
		                    	case "7-8": GO_fondo_7_1.SetActive(true); GO_fondo_8_1.SetActive(true); break;
		                    }
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-----------------------------------------
		                    //-----Guardado de camino correcto---------
		                    //-----------------------------------------
		                    if(puntero_respuestas.GetInt32(4)==1){//Sí la respuesta es correcta
		                    	array_camino_correcto.Add(cad_aux);
		                    }
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    cad_aux = "";
		                }
						//------------------------
						//------------------------
						//------------------------
					}
					if (puntero_respuestas.Read()){
						GO_opcion_2.GetComponent<Text>().text = "B) "+puntero_respuestas.GetString(1);
						//------------------------
						//Desglosar campo "camino"
						//------------------------
						string texto_auxiliar = puntero_respuestas.GetString(2);
		                string cad_aux = "";//cadena auxiliar
		                int i=0;
		                while(i<texto_auxiliar.Length){
		                    while( texto_auxiliar.Substring(i,1)!="°"){
		                        cad_aux=cad_aux+texto_auxiliar.Substring(i,1);
		                        i++;
		                    }
		                    i++;
		                    //--------------------------------------
		                    //manejo gráfico de los aviones a lápiz-
		                    //--------------------------------------
		                    switch (cad_aux) {
		                    	case "1": GO_fondo_1_2.SetActive(true); break;
		                    	case "2": GO_fondo_2_2.SetActive(true); break;
		                    	case "3": GO_fondo_3_2.SetActive(true); break;
		                    	case "4": GO_fondo_4_2.SetActive(true); break;
		                    	case "5": GO_fondo_5_2.SetActive(true); break;
		                    	case "6": GO_fondo_6_2.SetActive(true); break;
		                    	case "7": GO_fondo_7_2.SetActive(true); break;
		                    	case "8": GO_fondo_8_2.SetActive(true); break;
		                    	case "9": GO_fondo_9_2.SetActive(true); break;
		                    	case "10": GO_fondo_10_2.SetActive(true); break;
		                    	case "4-5": GO_fondo_4_2.SetActive(true); GO_fondo_5_2.SetActive(true); break;
		                    	case "7-8": GO_fondo_7_2.SetActive(true); GO_fondo_8_2.SetActive(true); break;
		                    }
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-----------------------------------------
		                    //-----Guardado de camino correcto---------
		                    //-----------------------------------------
		                    if(puntero_respuestas.GetInt32(4)==1){//Sí la respuesta es correcta
		                    	array_camino_correcto.Add(cad_aux);
		                    }
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    cad_aux = "";
		                }
						//------------------------
						//------------------------
						//------------------------
					}
					if (puntero_respuestas.Read()){
						GO_opcion_3.GetComponent<Text>().text = "C) "+puntero_respuestas.GetString(1);
						//------------------------
						//Desglosar campo "camino"
						//------------------------
						string texto_auxiliar = puntero_respuestas.GetString(2);
		                string cad_aux = "";//cadena auxiliar
		                int i=0;
		                while(i<texto_auxiliar.Length){
		                    while( texto_auxiliar.Substring(i,1)!="°"){
		                        cad_aux=cad_aux+texto_auxiliar.Substring(i,1);
		                        i++;
		                    }
		                    i++;
		                    //--------------------------------------
		                    //manejo gráfico de los aviones a lápiz-
		                    //--------------------------------------
		                    switch (cad_aux) {
		                    	case "1": GO_fondo_1_3.SetActive(true); break;
		                    	case "2": GO_fondo_2_3.SetActive(true); break;
		                    	case "3": GO_fondo_3_3.SetActive(true); break;
		                    	case "4": GO_fondo_4_3.SetActive(true); break;
		                    	case "5": GO_fondo_5_3.SetActive(true); break;
		                    	case "6": GO_fondo_6_3.SetActive(true); break;
		                    	case "7": GO_fondo_7_3.SetActive(true); break;
		                    	case "8": GO_fondo_8_3.SetActive(true); break;
		                    	case "9": GO_fondo_9_3.SetActive(true); break;
		                    	case "10": GO_fondo_10_3.SetActive(true); break;
		                    	case "4-5": GO_fondo_4_3.SetActive(true); GO_fondo_5_3.SetActive(true); break;
		                    	case "7-8": GO_fondo_7_3.SetActive(true); GO_fondo_8_3.SetActive(true); break;
		                    }
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-----------------------------------------
		                    //-----Guardado de camino correcto---------
		                    //-----------------------------------------
		                    if(puntero_respuestas.GetInt32(4)==1){//Sí la respuesta es correcta
		                    	array_camino_correcto.Add(cad_aux);
		                    }
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    cad_aux = "";
		                }
						//------------------------
						//------------------------
						//------------------------
					}
					if (puntero_respuestas.Read()){
						GO_opcion_4.GetComponent<Text>().text = "D) "+puntero_respuestas.GetString(1);
						//------------------------
						//Desglosar campo "camino"
						//------------------------
						string texto_auxiliar = puntero_respuestas.GetString(2);
		                string cad_aux = "";//cadena auxiliar
		                int i=0;
		                while(i<texto_auxiliar.Length){
		                    while( texto_auxiliar.Substring(i,1)!="°"){
		                        cad_aux=cad_aux+texto_auxiliar.Substring(i,1);
		                        i++;
		                    }
		                    i++;
		                    //--------------------------------------
		                    //manejo gráfico de los aviones a lápiz-
		                    //--------------------------------------
		                    switch (cad_aux) {
		                    	case "1": GO_fondo_1_4.SetActive(true); break;
		                    	case "2": GO_fondo_2_4.SetActive(true); break;
		                    	case "3": GO_fondo_3_4.SetActive(true); break;
		                    	case "4": GO_fondo_4_4.SetActive(true); break;
		                    	case "5": GO_fondo_5_4.SetActive(true); break;
		                    	case "6": GO_fondo_6_4.SetActive(true); break;
		                    	case "7": GO_fondo_7_4.SetActive(true); break;
		                    	case "8": GO_fondo_8_4.SetActive(true); break;
		                    	case "9": GO_fondo_9_4.SetActive(true); break;
		                    	case "10": GO_fondo_10_4.SetActive(true); break;
		                    	case "4-5": GO_fondo_4_4.SetActive(true); GO_fondo_5_4.SetActive(true); break;
		                    	case "7-8": GO_fondo_7_4.SetActive(true); GO_fondo_8_4.SetActive(true); break;
		                    }
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-----------------------------------------
		                    //-----Guardado de camino correcto---------
		                    //-----------------------------------------
		                    if(puntero_respuestas.GetInt32(4)==1){//Sí la respuesta es correcta
		                    	array_camino_correcto.Add(cad_aux);
		                    }
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    cad_aux = "";
		                }
						//------------------------
						//------------------------
						//------------------------
					}
					conexionBD_1.Close();//Se cierra la conexión a la BD
					puntero_respuestas.Close();//Se cierra el puntero
				}
			}
		}
		//--------------------------------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------------------------------
	}

	//Función que obtiene los datos de la base de datos y llena las estructuras (EN UPDATE)
	private void obtener_datos_SQLite_UPDATE(){
		//Se limpian los aviones a lápiz
		GO_fondo_1_1.SetActive(false);
		GO_fondo_2_1.SetActive(false);
		GO_fondo_3_1.SetActive(false);
		GO_fondo_4_1.SetActive(false);
		GO_fondo_5_1.SetActive(false);
		GO_fondo_6_1.SetActive(false);
		GO_fondo_7_1.SetActive(false);
		GO_fondo_8_1.SetActive(false);
		GO_fondo_9_1.SetActive(false);
		GO_fondo_10_1.SetActive(false);
		GO_fondo_1_2.SetActive(false);
		GO_fondo_2_2.SetActive(false);
		GO_fondo_3_2.SetActive(false);
		GO_fondo_4_2.SetActive(false);
		GO_fondo_5_2.SetActive(false);
		GO_fondo_6_2.SetActive(false);
		GO_fondo_7_2.SetActive(false);
		GO_fondo_8_2.SetActive(false);
		GO_fondo_9_2.SetActive(false);
		GO_fondo_10_2.SetActive(false);
		GO_fondo_1_3.SetActive(false);
		GO_fondo_2_3.SetActive(false);
		GO_fondo_3_3.SetActive(false);
		GO_fondo_4_3.SetActive(false);
		GO_fondo_5_3.SetActive(false);
		GO_fondo_6_3.SetActive(false);
		GO_fondo_7_3.SetActive(false);
		GO_fondo_8_3.SetActive(false);
		GO_fondo_9_3.SetActive(false);
		GO_fondo_10_3.SetActive(false);
		GO_fondo_1_4.SetActive(false);
		GO_fondo_2_4.SetActive(false);
		GO_fondo_3_4.SetActive(false);
		GO_fondo_4_4.SetActive(false);
		GO_fondo_5_4.SetActive(false);
		GO_fondo_6_4.SetActive(false);
		GO_fondo_7_4.SetActive(false);
		GO_fondo_8_4.SetActive(false);
		GO_fondo_9_4.SetActive(false);
		GO_fondo_10_4.SetActive(false);
		//Variables auxiliares para obtener campos de tabla "respuestas"
		int id_pregunta = 0;
		//--------------------------------------------------------------------------------------------------------------------
		//-------------------------------------CONSULTA EN TABLA PREGUNTAS----------------------------------------------------
		//--------------------------------------------------------------------------------------------------------------------
		if (puntero_preguntas.Read()){
			//Se llenan los textos correspondientes en la escena
			GO_titulo.GetComponent<Text>().text = "Ejercicio #"+pregunta_actual.ToString();
			GO_pregunta.GetComponent<Text>().text = puntero_preguntas.GetString(1);
			//--------------------------------------------------
			tiempo_para_pregunta_actual = puntero_preguntas.GetInt32(4);
			//Debug.Log("Tiempo para esta pregunta: "+tiempo_para_pregunta_actual+" segundos");
			id_pregunta = puntero_preguntas.GetInt32(0);
			numero_de_opciones_pregunta_actual = puntero_preguntas.GetInt32(2);
		}
		//--------------------------------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------------------------------
		//-------------------------------------CONSULTA EN TABLA RESPUESTAS---------------------------------------------------
		//--------------------------------------------------------------------------------------------------------------------
		//Se reinicia array camino correcto
		array_camino_correcto.Clear();
		//Se crea conexión con Base de Datos
		using(IDbConnection conexionBD_1 = new SqliteConnection(BDfile)){
			conexionBD_1.Open();//Se abre la conexión
			//Se prepara para consulta
			using(IDbCommand comandoBD_1 = conexionBD_1.CreateCommand()){
				string SQL_1 = "select * from respuestas where id_pregunta = "+id_pregunta.ToString();
				comandoBD_1.CommandText = SQL_1;
				//Leer el resultado de la consulta
				using(IDataReader puntero_respuestas = comandoBD_1.ExecuteReader()){
					if (puntero_respuestas.Read()){
						GO_opcion_1.GetComponent<Text>().text = "A) "+puntero_respuestas.GetString(1);
						//------------------------
						//Desglosar campo "camino"
						//------------------------
						string texto_auxiliar = puntero_respuestas.GetString(2);
		                string cad_aux = "";//cadena auxiliar
		                int i=0;
		                while(i<texto_auxiliar.Length){
		                    while( texto_auxiliar.Substring(i,1)!="°"){
		                        cad_aux=cad_aux+texto_auxiliar.Substring(i,1);
		                        i++;
		                    }
		                    i++;
		                    //--------------------------------------
		                    //manejo gráfico de los aviones a lápiz-
		                    //--------------------------------------
		                    switch (cad_aux) {
		                    	case "1": GO_fondo_1_1.SetActive(true); break;
		                    	case "2": GO_fondo_2_1.SetActive(true); break;
		                    	case "3": GO_fondo_3_1.SetActive(true); break;
		                    	case "4": GO_fondo_4_1.SetActive(true); break;
		                    	case "5": GO_fondo_5_1.SetActive(true); break;
		                    	case "6": GO_fondo_6_1.SetActive(true); break;
		                    	case "7": GO_fondo_7_1.SetActive(true); break;
		                    	case "8": GO_fondo_8_1.SetActive(true); break;
		                    	case "9": GO_fondo_9_1.SetActive(true); break;
		                    	case "10": GO_fondo_10_1.SetActive(true); break;
		                    	case "4-5": GO_fondo_4_1.SetActive(true); GO_fondo_5_1.SetActive(true); break;
		                    	case "7-8": GO_fondo_7_1.SetActive(true); GO_fondo_8_1.SetActive(true); break;
		                    }
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-----------------------------------------
		                    //-----Guardado de camino correcto---------
		                    //-----------------------------------------
		                    if(puntero_respuestas.GetInt32(4)==1){//Sí la respuesta es correcta
		                    	array_camino_correcto.Add(cad_aux);
		                    }
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    cad_aux = "";
		                }
						//------------------------
						//------------------------
						//------------------------
					}
					if (puntero_respuestas.Read()){
						GO_opcion_2.GetComponent<Text>().text = "B) "+puntero_respuestas.GetString(1);
						//------------------------
						//Desglosar campo "camino"
						//------------------------
						string texto_auxiliar = puntero_respuestas.GetString(2);
		                string cad_aux = "";//cadena auxiliar
		                int i=0;
		                while(i<texto_auxiliar.Length){
		                    while( texto_auxiliar.Substring(i,1)!="°"){
		                        cad_aux=cad_aux+texto_auxiliar.Substring(i,1);
		                        i++;
		                    }
		                    i++;
		                    //--------------------------------------
		                    //manejo gráfico de los aviones a lápiz-
		                    //--------------------------------------
		                    switch (cad_aux) {
		                    	case "1": GO_fondo_1_2.SetActive(true); break;
		                    	case "2": GO_fondo_2_2.SetActive(true); break;
		                    	case "3": GO_fondo_3_2.SetActive(true); break;
		                    	case "4": GO_fondo_4_2.SetActive(true); break;
		                    	case "5": GO_fondo_5_2.SetActive(true); break;
		                    	case "6": GO_fondo_6_2.SetActive(true); break;
		                    	case "7": GO_fondo_7_2.SetActive(true); break;
		                    	case "8": GO_fondo_8_2.SetActive(true); break;
		                    	case "9": GO_fondo_9_2.SetActive(true); break;
		                    	case "10": GO_fondo_10_2.SetActive(true); break;
		                    	case "4-5": GO_fondo_4_2.SetActive(true); GO_fondo_5_2.SetActive(true); break;
		                    	case "7-8": GO_fondo_7_2.SetActive(true); GO_fondo_8_2.SetActive(true); break;
		                    }
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-----------------------------------------
		                    //-----Guardado de camino correcto---------
		                    //-----------------------------------------
		                    if(puntero_respuestas.GetInt32(4)==1){//Sí la respuesta es correcta
		                    	array_camino_correcto.Add(cad_aux);
		                    }
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    cad_aux = "";
		                }
						//------------------------
						//------------------------
						//------------------------
					}
					if (puntero_respuestas.Read()){
						GO_opcion_3.GetComponent<Text>().text = "C) "+puntero_respuestas.GetString(1);
						//------------------------
						//Desglosar campo "camino"
						//------------------------
						string texto_auxiliar = puntero_respuestas.GetString(2);
		                string cad_aux = "";//cadena auxiliar
		                int i=0;
		                while(i<texto_auxiliar.Length){
		                    while( texto_auxiliar.Substring(i,1)!="°"){
		                        cad_aux=cad_aux+texto_auxiliar.Substring(i,1);
		                        i++;
		                    }
		                    i++;
		                    //--------------------------------------
		                    //manejo gráfico de los aviones a lápiz-
		                    //--------------------------------------
		                    switch (cad_aux) {
		                    	case "1": GO_fondo_1_3.SetActive(true); break;
		                    	case "2": GO_fondo_2_3.SetActive(true); break;
		                    	case "3": GO_fondo_3_3.SetActive(true); break;
		                    	case "4": GO_fondo_4_3.SetActive(true); break;
		                    	case "5": GO_fondo_5_3.SetActive(true); break;
		                    	case "6": GO_fondo_6_3.SetActive(true); break;
		                    	case "7": GO_fondo_7_3.SetActive(true); break;
		                    	case "8": GO_fondo_8_3.SetActive(true); break;
		                    	case "9": GO_fondo_9_3.SetActive(true); break;
		                    	case "10": GO_fondo_10_3.SetActive(true); break;
		                    	case "4-5": GO_fondo_4_3.SetActive(true); GO_fondo_5_3.SetActive(true); break;
		                    	case "7-8": GO_fondo_7_3.SetActive(true); GO_fondo_8_3.SetActive(true); break;
		                    }
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-----------------------------------------
		                    //-----Guardado de camino correcto---------
		                    //-----------------------------------------
		                    if(puntero_respuestas.GetInt32(4)==1){//Sí la respuesta es correcta
		                    	array_camino_correcto.Add(cad_aux);
		                    }
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    cad_aux = "";
		                }
						//------------------------
						//------------------------
						//------------------------
					}
					if (puntero_respuestas.Read()){
						GO_opcion_4.GetComponent<Text>().text = "D) "+puntero_respuestas.GetString(1);
						//------------------------
						//Desglosar campo "camino"
						//------------------------
						string texto_auxiliar = puntero_respuestas.GetString(2);
		                string cad_aux = "";//cadena auxiliar
		                int i=0;
		                while(i<texto_auxiliar.Length){
		                    while( texto_auxiliar.Substring(i,1)!="°"){
		                        cad_aux=cad_aux+texto_auxiliar.Substring(i,1);
		                        i++;
		                    }
		                    i++;
		                    //--------------------------------------
		                    //manejo gráfico de los aviones a lápiz-
		                    //--------------------------------------
		                    switch (cad_aux) {
		                    	case "1": GO_fondo_1_4.SetActive(true); break;
		                    	case "2": GO_fondo_2_4.SetActive(true); break;
		                    	case "3": GO_fondo_3_4.SetActive(true); break;
		                    	case "4": GO_fondo_4_4.SetActive(true); break;
		                    	case "5": GO_fondo_5_4.SetActive(true); break;
		                    	case "6": GO_fondo_6_4.SetActive(true); break;
		                    	case "7": GO_fondo_7_4.SetActive(true); break;
		                    	case "8": GO_fondo_8_4.SetActive(true); break;
		                    	case "9": GO_fondo_9_4.SetActive(true); break;
		                    	case "10": GO_fondo_10_4.SetActive(true); break;
		                    	case "4-5": GO_fondo_4_4.SetActive(true); GO_fondo_5_4.SetActive(true); break;
		                    	case "7-8": GO_fondo_7_4.SetActive(true); GO_fondo_8_4.SetActive(true); break;
		                    }
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-------------------------------------
		                    //-----------------------------------------
		                    //-----Guardado de camino correcto---------
		                    //-----------------------------------------
		                    if(puntero_respuestas.GetInt32(4)==1){//Sí la respuesta es correcta
		                    	array_camino_correcto.Add(cad_aux);
		                    }
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    //-----------------------------------------
		                    cad_aux = "";
		                }
						//------------------------
						//------------------------
						//------------------------
					}
					conexionBD_1.Close();//Se cierra la conexión a la BD
					puntero_respuestas.Close();//Se cierra el puntero
				}
			}
		}
		//--------------------------------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------------------------------
		//--------------------------------------------------------------------------------------------------------------------
	}

	private void pasar_a_siguiente_pregunta () {
		bandera_pasar_a_siguiente_pregunta = true;
		bandera_termino_opacidad_1 = false;
		animacion_pasando_pagina = false;
		time_inicio_frame = 0f;
		pregunta_actual++;
		estado_de_la_respuesta = 1;
		barra_progreso_respuesta.fillAmount = 0f;
	}

    void Update() {
    	//-------------------------
    	//-------------------------------------------------------------
    	//---------------------Estado de avión-------------------------
    	//-------------------------------------------------------------
        if(!modo_prueba){//Sí modo prueba está activado no se recibe por Bluetooth
        	estado_avion();
        	//------------------------------------------------------------------------
        	//Se visualiza gráficamente que botones del avión están siendo presionados
        	//------------------------------------------------------------------------
        	pie_1.SetActive(bandera_control_boton_1);
        	pie_2.SetActive(bandera_control_boton_2);
        	pie_3.SetActive(bandera_control_boton_3);
        	pie_4.SetActive(bandera_control_boton_4);
        	pie_5.SetActive(bandera_control_boton_5);
        	pie_6.SetActive(bandera_control_boton_6);
        	pie_7.SetActive(bandera_control_boton_7);
        	pie_8.SetActive(bandera_control_boton_8);
        	pie_9.SetActive(bandera_control_boton_9);
        	pie_10.SetActive(bandera_control_boton_10);
        	//------------------------------------------------------------------------
        	//------------------------------------------------------------------------
        	//------------------------------------------------------------------------
        } else {
        	//Sí se está en modo prueba - el manejo es por teclado
        	if (Input.GetKey(KeyCode.Keypad1)) {
        		bandera_control_boton_1 = true;
        	} else {
        		bandera_control_boton_1 = false;
        	}
        	if (Input.GetKey(KeyCode.Keypad2)) {
        		bandera_control_boton_2 = true;
        	} else {
        		bandera_control_boton_2 = false;
        	}
        	if (Input.GetKey(KeyCode.Keypad3)) {
        		bandera_control_boton_3 = true;
        	} else {
        		bandera_control_boton_3 = false;
        	}
        	if (Input.GetKey(KeyCode.Keypad4)) {
        		bandera_control_boton_4 = true;
        	} else {
        		bandera_control_boton_4 = false;
        	}
        	if (Input.GetKey(KeyCode.Keypad5)) {
        		bandera_control_boton_5 = true;
        	} else {
        		bandera_control_boton_5 = false;
        	}
        	if (Input.GetKey(KeyCode.Keypad6)) {
        		bandera_control_boton_6 = true;
        	} else {
        		bandera_control_boton_6 = false;
        	}
        	if (Input.GetKey(KeyCode.Keypad7)) {
        		bandera_control_boton_7 = true;
        	} else {
        		bandera_control_boton_7 = false;
        	}
        	if (Input.GetKey(KeyCode.Keypad8)) {
        		bandera_control_boton_8 = true;
        	} else {
        		bandera_control_boton_8 = false;
        	}
        	if (Input.GetKey(KeyCode.Keypad9)) {
        		bandera_control_boton_9 = true;
        	} else {
        		bandera_control_boton_9 = false;
        	}
        	if (Input.GetKey(KeyCode.Keypad0)) {
        		bandera_control_boton_10 = true;
        	} else {
        		bandera_control_boton_10 = false;
        	}
        	//----------------------------------------------------
        	pie_1.SetActive(bandera_control_boton_1);
        	pie_2.SetActive(bandera_control_boton_2);
        	pie_3.SetActive(bandera_control_boton_3);
        	pie_4.SetActive(bandera_control_boton_4);
        	pie_5.SetActive(bandera_control_boton_5);
        	pie_6.SetActive(bandera_control_boton_6);
        	pie_7.SetActive(bandera_control_boton_7);
        	pie_8.SetActive(bandera_control_boton_8);
        	pie_9.SetActive(bandera_control_boton_9);
        	pie_10.SetActive(bandera_control_boton_10);
        	//----------------------------------------------------
        }
    	//-------------------------------------------------------------
    	//-------------------------------------------------------------
    	//-------------------------------------------------------------
    	//----------------------------------------------------------------------------------------------------------------------------------------------------------
    	//------------------------------------------------------------MANEJO DE RESPUESTA---------------------------------------------------------------------------
    	//----------------------------------------------------------------------------------------------------------------------------------------------------------
    	if(!bandera_pasar_a_siguiente_pregunta && bandera_termino_opacidad){
    		//Sí se está en el primer nodo de la respuesta
    		if(estado_de_la_respuesta == 1){
    			//
    		}
    		if(estado_de_la_respuesta <= nodos_de_la_respuesta){
    			//----------------------------------------------------------
    			//----------------------------------------------------------
    			//----------------------------------------------------------
    			if(bandera_control_boton_1 && !acceso_bloqueado_1){
    				if(array_camino_correcto[estado_de_la_respuesta-1] == "1"){
    					estado_de_la_respuesta++;
    					barra_progreso_respuesta.fillAmount = ((float)(estado_de_la_respuesta-1)/(float)nodos_de_la_respuesta);
    				} else {
    					//Sí el botón pisado es el incorrecto
    					estado_de_la_respuesta = 1;
    					barra_progreso_respuesta.fillAmount = 0f;
    					if(vidas_actuales>1){
    						vidas_actuales--;
    						switch (vidas_actuales) {
    							case 1: vida_1.SetActive(true);
    									vida_2.SetActive(false);
    									vida_3.SetActive(false);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 2: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(false);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 3: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(true);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 4: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(true);
    									vida_4.SetActive(true);
    									vida_5.SetActive(false); 
    									break;
    						}
    					} else {
    						//Se acabaron las vidas
    					}
    				}
    				acceso_bloqueado_1 = true;
    			}
    			if(bandera_control_boton_2 && !acceso_bloqueado_2){
    				if(array_camino_correcto[estado_de_la_respuesta-1] == "2"){
    					estado_de_la_respuesta++;
    					barra_progreso_respuesta.fillAmount = ((float)(estado_de_la_respuesta-1)/(float)nodos_de_la_respuesta);
    				} else {
    					//Sí el botón pisado es el incorrecto
    					estado_de_la_respuesta = 1;
    					barra_progreso_respuesta.fillAmount = 0f;
    					if(vidas_actuales>1){
    						vidas_actuales--;
    						switch (vidas_actuales) {
    							case 1: vida_1.SetActive(true);
    									vida_2.SetActive(false);
    									vida_3.SetActive(false);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 2: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(false);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 3: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(true);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 4: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(true);
    									vida_4.SetActive(true);
    									vida_5.SetActive(false); 
    									break;
    						}
    					} else {
    						//Se acabaron las vidas
    					}
    				}
    				acceso_bloqueado_2 = true;
    			}
    			if(bandera_control_boton_3 && !acceso_bloqueado_3){
    				if(array_camino_correcto[estado_de_la_respuesta-1] == "3"){
    					estado_de_la_respuesta++;
    					barra_progreso_respuesta.fillAmount = ((float)(estado_de_la_respuesta-1)/(float)nodos_de_la_respuesta);
    				} else {
    					//Sí el botón pisado es el incorrecto
    					estado_de_la_respuesta = 1;
    					barra_progreso_respuesta.fillAmount = 0f;
    					if(vidas_actuales>1){
    						vidas_actuales--;
    						switch (vidas_actuales) {
    							case 1: vida_1.SetActive(true);
    									vida_2.SetActive(false);
    									vida_3.SetActive(false);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 2: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(false);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 3: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(true);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 4: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(true);
    									vida_4.SetActive(true);
    									vida_5.SetActive(false); 
    									break;
    						}
    					} else {
    						//Se acabaron las vidas
    					}
    				}
    				acceso_bloqueado_3 = true;
    			}
    			if(bandera_control_boton_4 && !acceso_bloqueado_4){
    				if(array_camino_correcto[estado_de_la_respuesta-1] == "4"){
    					estado_de_la_respuesta++;
    					barra_progreso_respuesta.fillAmount = ((float)(estado_de_la_respuesta-1)/(float)nodos_de_la_respuesta);
    				} else {
    					if(array_camino_correcto[estado_de_la_respuesta-1] == "4-5"){
	    					//Se espera a que ambos números se pisen
	    				} else {
	    					//Sí el botón pisado es el incorrecto
	    					estado_de_la_respuesta = 1;
	    					barra_progreso_respuesta.fillAmount = 0f;
	    					if(vidas_actuales>1){
	    						vidas_actuales--;
	    						switch (vidas_actuales) {
	    							case 1: vida_1.SetActive(true);
	    									vida_2.SetActive(false);
	    									vida_3.SetActive(false);
	    									vida_4.SetActive(false);
	    									vida_5.SetActive(false); 
	    									break;
	    							case 2: vida_1.SetActive(true);
	    									vida_2.SetActive(true);
	    									vida_3.SetActive(false);
	    									vida_4.SetActive(false);
	    									vida_5.SetActive(false); 
	    									break;
	    							case 3: vida_1.SetActive(true);
	    									vida_2.SetActive(true);
	    									vida_3.SetActive(true);
	    									vida_4.SetActive(false);
	    									vida_5.SetActive(false); 
	    									break;
	    							case 4: vida_1.SetActive(true);
	    									vida_2.SetActive(true);
	    									vida_3.SetActive(true);
	    									vida_4.SetActive(true);
	    									vida_5.SetActive(false); 
	    									break;
	    						}
	    					} else {
	    						//Se acabaron las vidas
	    					}
	    				}
    				}
    				acceso_bloqueado_4 = true;
    			}
    			if(bandera_control_boton_5 && !acceso_bloqueado_5){
    				if(array_camino_correcto[estado_de_la_respuesta-1] == "5"){
    					estado_de_la_respuesta++;
    					barra_progreso_respuesta.fillAmount = ((float)(estado_de_la_respuesta-1)/(float)nodos_de_la_respuesta);
    				} else {
    					if(array_camino_correcto[estado_de_la_respuesta-1] == "4-5"){
	    					//Se espera a que ambos números se pisen
	    				} else {
	    					//Sí el botón pisado es el incorrecto
	    					estado_de_la_respuesta = 1;
	    					barra_progreso_respuesta.fillAmount = 0f;
	    					if(vidas_actuales>1){
	    						vidas_actuales--;
	    						switch (vidas_actuales) {
	    							case 1: vida_1.SetActive(true);
	    									vida_2.SetActive(false);
	    									vida_3.SetActive(false);
	    									vida_4.SetActive(false);
	    									vida_5.SetActive(false); 
	    									break;
	    							case 2: vida_1.SetActive(true);
	    									vida_2.SetActive(true);
	    									vida_3.SetActive(false);
	    									vida_4.SetActive(false);
	    									vida_5.SetActive(false); 
	    									break;
	    							case 3: vida_1.SetActive(true);
	    									vida_2.SetActive(true);
	    									vida_3.SetActive(true);
	    									vida_4.SetActive(false);
	    									vida_5.SetActive(false); 
	    									break;
	    							case 4: vida_1.SetActive(true);
	    									vida_2.SetActive(true);
	    									vida_3.SetActive(true);
	    									vida_4.SetActive(true);
	    									vida_5.SetActive(false); 
	    									break;
	    						}
	    					} else {
	    						//Se acabaron las vidas
	    					}
	    				}
    				}
    				acceso_bloqueado_5 = true;
    			}
    			if(bandera_control_boton_6 && !acceso_bloqueado_6){
    				if(array_camino_correcto[estado_de_la_respuesta-1] == "6"){
    					estado_de_la_respuesta++;
    					barra_progreso_respuesta.fillAmount = ((float)(estado_de_la_respuesta-1)/(float)nodos_de_la_respuesta);
    				} else {
    					//Sí el botón pisado es el incorrecto
    					estado_de_la_respuesta = 1;
    					barra_progreso_respuesta.fillAmount = 0f;
    					if(vidas_actuales>1){
    						vidas_actuales--;
    						switch (vidas_actuales) {
    							case 1: vida_1.SetActive(true);
    									vida_2.SetActive(false);
    									vida_3.SetActive(false);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 2: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(false);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 3: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(true);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 4: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(true);
    									vida_4.SetActive(true);
    									vida_5.SetActive(false); 
    									break;
    						}
    					} else {
    						//Se acabaron las vidas
    					}
    				}
    				acceso_bloqueado_6 = true;
    			}
    			if(bandera_control_boton_7 && !acceso_bloqueado_7){
    				if(array_camino_correcto[estado_de_la_respuesta-1] == "7"){
    					estado_de_la_respuesta++;
    					barra_progreso_respuesta.fillAmount = ((float)(estado_de_la_respuesta-1)/(float)nodos_de_la_respuesta);
    				} else {
    					if(array_camino_correcto[estado_de_la_respuesta-1] == "7-8"){
	    					//Se espera a que ambos números se pisen
	    				} else {
	    					//Sí el botón pisado es el incorrecto
	    					estado_de_la_respuesta = 1;
	    					barra_progreso_respuesta.fillAmount = 0f;
	    					if(vidas_actuales>1){
	    						vidas_actuales--;
	    						switch (vidas_actuales) {
	    							case 1: vida_1.SetActive(true);
	    									vida_2.SetActive(false);
	    									vida_3.SetActive(false);
	    									vida_4.SetActive(false);
	    									vida_5.SetActive(false); 
	    									break;
	    							case 2: vida_1.SetActive(true);
	    									vida_2.SetActive(true);
	    									vida_3.SetActive(false);
	    									vida_4.SetActive(false);
	    									vida_5.SetActive(false); 
	    									break;
	    							case 3: vida_1.SetActive(true);
	    									vida_2.SetActive(true);
	    									vida_3.SetActive(true);
	    									vida_4.SetActive(false);
	    									vida_5.SetActive(false); 
	    									break;
	    							case 4: vida_1.SetActive(true);
	    									vida_2.SetActive(true);
	    									vida_3.SetActive(true);
	    									vida_4.SetActive(true);
	    									vida_5.SetActive(false); 
	    									break;
	    						}
	    					} else {
	    						//Se acabaron las vidas
	    					}
	    				}
    				}
    				acceso_bloqueado_7 = true;
    			}
    			if(bandera_control_boton_8 && !acceso_bloqueado_8){
    				if(array_camino_correcto[estado_de_la_respuesta-1] == "8"){
    					estado_de_la_respuesta++;
    					barra_progreso_respuesta.fillAmount = ((float)(estado_de_la_respuesta-1)/(float)nodos_de_la_respuesta);
    				} else {
    					if(array_camino_correcto[estado_de_la_respuesta-1] == "7-8"){
	    					//Se espera a que ambos números se pisen
	    				} else {
	    					//Sí el botón pisado es el incorrecto
	    					estado_de_la_respuesta = 1;
	    					barra_progreso_respuesta.fillAmount = 0f;
	    					if(vidas_actuales>1){
	    						vidas_actuales--;
	    						switch (vidas_actuales) {
	    							case 1: vida_1.SetActive(true);
	    									vida_2.SetActive(false);
	    									vida_3.SetActive(false);
	    									vida_4.SetActive(false);
	    									vida_5.SetActive(false); 
	    									break;
	    							case 2: vida_1.SetActive(true);
	    									vida_2.SetActive(true);
	    									vida_3.SetActive(false);
	    									vida_4.SetActive(false);
	    									vida_5.SetActive(false); 
	    									break;
	    							case 3: vida_1.SetActive(true);
	    									vida_2.SetActive(true);
	    									vida_3.SetActive(true);
	    									vida_4.SetActive(false);
	    									vida_5.SetActive(false); 
	    									break;
	    							case 4: vida_1.SetActive(true);
	    									vida_2.SetActive(true);
	    									vida_3.SetActive(true);
	    									vida_4.SetActive(true);
	    									vida_5.SetActive(false); 
	    									break;
	    						}
	    					} else {
	    						//Se acabaron las vidas
	    					}
	    				}
    				}
    				acceso_bloqueado_8 = true;
    			}
    			if(bandera_control_boton_9 && !acceso_bloqueado_9){
    				if(array_camino_correcto[estado_de_la_respuesta-1] == "9"){
    					estado_de_la_respuesta++;
    					barra_progreso_respuesta.fillAmount = ((float)(estado_de_la_respuesta-1)/(float)nodos_de_la_respuesta);
    				} else {
    					//Sí el botón pisado es el incorrecto
    					estado_de_la_respuesta = 1;
    					barra_progreso_respuesta.fillAmount = 0f;
    					if(vidas_actuales>1){
    						vidas_actuales--;
    						switch (vidas_actuales) {
    							case 1: vida_1.SetActive(true);
    									vida_2.SetActive(false);
    									vida_3.SetActive(false);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 2: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(false);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 3: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(true);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 4: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(true);
    									vida_4.SetActive(true);
    									vida_5.SetActive(false); 
    									break;
    						}
    					} else {
    						//Se acabaron las vidas
    					}
    				}
    				acceso_bloqueado_9 = true;
    			}
    			if(bandera_control_boton_10 && !acceso_bloqueado_10){
    				if(array_camino_correcto[estado_de_la_respuesta-1] == "10"){
    					estado_de_la_respuesta++;
    					barra_progreso_respuesta.fillAmount = ((float)(estado_de_la_respuesta-1)/(float)nodos_de_la_respuesta);
    				} else {
    					//Sí el botón pisado es el incorrecto
    					estado_de_la_respuesta = 1;
    					barra_progreso_respuesta.fillAmount = 0f;
    					if(vidas_actuales>1){
    						vidas_actuales--;
    						switch (vidas_actuales) {
    							case 1: vida_1.SetActive(true);
    									vida_2.SetActive(false);
    									vida_3.SetActive(false);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 2: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(false);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 3: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(true);
    									vida_4.SetActive(false);
    									vida_5.SetActive(false); 
    									break;
    							case 4: vida_1.SetActive(true);
    									vida_2.SetActive(true);
    									vida_3.SetActive(true);
    									vida_4.SetActive(true);
    									vida_5.SetActive(false); 
    									break;
    						}
    					} else {
    						//Se acabaron las vidas
    					}
    				}
    				acceso_bloqueado_10 = true;
    			}
    			if(bandera_control_boton_4 && bandera_control_boton_5 && !acceso_bloqueado_11){
    				if(array_camino_correcto[estado_de_la_respuesta-1] == "4-5"){
    					estado_de_la_respuesta++;
    					barra_progreso_respuesta.fillAmount = ((float)(estado_de_la_respuesta-1)/(float)nodos_de_la_respuesta);
    				}
    				acceso_bloqueado_11 = true;
    			}
    			if(bandera_control_boton_7 && bandera_control_boton_8 && !acceso_bloqueado_12){
    				if(array_camino_correcto[estado_de_la_respuesta-1] == "7-8"){
    					estado_de_la_respuesta++;
    					barra_progreso_respuesta.fillAmount = ((float)(estado_de_la_respuesta-1)/(float)nodos_de_la_respuesta);
    				}
    				acceso_bloqueado_12 = true;
    			}
    			//Se desbloquean accesos si no se está pisando nada del tapete
    			if(!bandera_control_boton_1 && !bandera_control_boton_2 && !bandera_control_boton_3 && !bandera_control_boton_4 && !bandera_control_boton_5 && 
    				!bandera_control_boton_6 && !bandera_control_boton_7 && !bandera_control_boton_8 && !bandera_control_boton_9 && !bandera_control_boton_10){
    				acceso_bloqueado_1 = false;
    				acceso_bloqueado_2 = false;
    				acceso_bloqueado_3 = false;
    				acceso_bloqueado_4 = false;
    				acceso_bloqueado_5 = false;
    				acceso_bloqueado_6 = false;
    				acceso_bloqueado_7 = false;
    				acceso_bloqueado_8 = false;
    				acceso_bloqueado_9 = false;
    				acceso_bloqueado_10 = false;
    				acceso_bloqueado_11 = false;
    				acceso_bloqueado_12 = false;
    			}
    			//----------------------------------------------------------
    			//----------------------------------------------------------
    			//----------------------------------------------------------
    		}
    		//Sí ya se respondió correctamente el ejercicio
    		if(estado_de_la_respuesta > nodos_de_la_respuesta){
    			//***************************************************************************************
    			//*************************SE PASA A SIGUIENTE PREGUNTA**********************************
    			//***************************************************************************************
    			if(pregunta_actual<numero_de_preguntas){
		    		pasar_a_siguiente_pregunta();
		    	} else {
		    		//Se llegó al final de la actividad
		    	}
    			//***************************************************************************************
    			//***************************************************************************************
    		}
    	}
    	//----------------------------------------------------------------------------------------------------------------------------------------------------------
    	//----------------------------------------------------------------------------------------------------------------------------------------------------------
    	//----------------------------------------------------------------------------------------------------------------------------------------------------------
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
	    			aux_opacidad+=0.01f;
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
	    		} else {
	    			bandera_termino_opacidad = true;
	    		}
			}
			//---------------------------------------------------------------------------------------------------------------
			//---------------------------------------------------------------------------------------------------------------
			//---------------------------------------------------------------------------------------------------------------
			//--------------------------------------------------------------------------------------------------------------------------------------------------------------------
			//--------------------------------------------------------------------ANIMACIÓN PASAR PÁGINA--------------------------------------------------------------------------
			//--------------------------------------------------------------------------------------------------------------------------------------------------------------------
			if(bandera_pasar_a_siguiente_pregunta){
				//-------------------------
				//Se decrementa la opacidad
				//-------------------------
			if(!bandera_termino_opacidad_1){
	    		if(aux_opacidad>0f){
	    			aux_opacidad-=0.01f;
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
	    		} else {
	    			if(!animacion_pasando_pagina){
	    				time_inicio_frame = time_inicio_frame + 0.25f;
	    				int index = Convert.ToInt32(time_inicio_frame);
			        	libreta.texture = frames_pasando_pagina[index];
			        	if(index == frames_pasando_pagina.Length-1){
			        		animacion_pasando_pagina = true;
			        	}
	    			} else {
		    			//----------------------------------------------
		    			bandera_termino_opacidad_1 = true;
		    			obtener_datos_SQLite_UPDATE();
		    			nodos_de_la_respuesta = array_camino_correcto.Count;
		    			bandera_termino_opacidad = false;
		    			bandera_pasar_a_siguiente_pregunta = false;
		    			//----------------------------------------------
	    			}
	    		}
			}
				//-------------------------
				//-------------------------
				//-------------------------
			}
			//--------------------------------------------------------------------------------------------------------------------------------------------------------------------
			//--------------------------------------------------------------------------------------------------------------------------------------------------------------------
			//--------------------------------------------------------------------------------------------------------------------------------------------------------------------
			//Hacer visible
			switch (numero_de_opciones_pregunta_actual) {
				case 1: {
					GO_opcion_1.SetActive(true);
					GO_opcion_2.SetActive(false);
					GO_opcion_3.SetActive(false);
					GO_opcion_4.SetActive(false);
					GO_avion_lapiz_1.SetActive(true);
					GO_avion_lapiz_2.SetActive(false);
					GO_avion_lapiz_3.SetActive(false);
					GO_avion_lapiz_4.SetActive(false);
					break;}
				case 2: {
					GO_opcion_1.SetActive(true);
					GO_opcion_2.SetActive(true);
					GO_opcion_3.SetActive(false);
					GO_opcion_4.SetActive(false);
					GO_avion_lapiz_1.SetActive(true);
					GO_avion_lapiz_2.SetActive(true);
					GO_avion_lapiz_3.SetActive(false);
					GO_avion_lapiz_4.SetActive(false);
					break;}
				case 3: {
					GO_opcion_1.SetActive(true);
					GO_opcion_2.SetActive(true);
					GO_opcion_3.SetActive(true);
					GO_opcion_4.SetActive(false);
					GO_avion_lapiz_1.SetActive(true);
					GO_avion_lapiz_2.SetActive(true);
					GO_avion_lapiz_3.SetActive(true);
					GO_avion_lapiz_4.SetActive(false);
					break;}
				case 4: {
					GO_opcion_1.SetActive(true);
					GO_opcion_2.SetActive(true);
					GO_opcion_3.SetActive(true);
					GO_opcion_4.SetActive(true);
					GO_avion_lapiz_1.SetActive(true);
					GO_avion_lapiz_2.SetActive(true);
					GO_avion_lapiz_3.SetActive(true);
					GO_avion_lapiz_4.SetActive(true);
					break;}
			}
    		GO_titulo.SetActive(true);
			GO_pregunta.SetActive(true);
			GO_subtitulo.SetActive(true);
			
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

    //Verifica cuáles son los botones presionados en el avión
    private void estado_avion () {
    		//-----------------------------------------------------------------------------------------
            //-----------------------------------Control de Bluetooth----------------------------------
            //-----------------------------------------------------------------------------------------
            //Si el Stream está cerrado
            if (_Stream == null) { 
                throw new InvalidDataException("Conexión fallida"); 
            } else {
                var buffer = new byte[1];//buffer
                int read = _Stream.Read(buffer, 0, 1);//Se hace lectura del stream
                //Sí es la primera vez que se ejecuta
                if(bandera_sincronizacion){
                    //Sí se recibió algo
                    if(read != 0){
                        //Si se recibe el cambio de línea
                        if(System.Text.Encoding.UTF8.GetString(buffer) == "\n") {
                            bandera_sincronizacion = false;
                        }
                    }
                } else {
                    //Sí se recibió algo
                    if (read != 0) {
                        //Sí la bandera está encendida entonces se apaga
                        if(bandera_cambio_de_linea){
                            bandera_cambio_de_linea =false;
                            contador_array_estado_botones = 0;
                        }
                        //Sí lo que recive es diferente al retorno de carro y cambio de línea
                        if(buffer[0]!=13 && buffer[0]!=10) {
                            //Debug.Log("Se recibió: " +  System.Text.Encoding.UTF8.GetString(buffer));
                            if(contador_array_estado_botones<10){
                                if(System.Text.Encoding.UTF8.GetString(buffer) == "1"){
                                    estado_botones[contador_array_estado_botones] = true;
                                    contador_array_estado_botones++;
                                } else {
                                    estado_botones[contador_array_estado_botones] = false;
                                    contador_array_estado_botones++;
                                }
                            }
                        }
                        //Si se recibe el cambio de línea
                        if(System.Text.Encoding.UTF8.GetString(buffer) == "\n") {
                            //Debug.Log("cambio de linea");
                            bandera_cambio_de_linea = true;
                        }
                    }
                }
            }
             //----------------------Sí ya se recibió cadena completa----------------------------------
            if(bandera_cambio_de_linea){
                //-------CASO BOTÓN 1---------
                if(estado_botones[0]){
                    if(!bandera_control_boton_1){
                    	//El botón está siendo presionado
                        bandera_control_boton_1 = true;
                    }
                } else {
                    if(bandera_control_boton_1){
                        //el botón fue presionado - ya se soltó
                        bandera_control_boton_1 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 2---------
                if(estado_botones[1]){
                    if(!bandera_control_boton_2){
                    	//El botón está siendo presionado
                        bandera_control_boton_2 = true;
                    }
                } else {
                    if(bandera_control_boton_2){
                        //el botón fue presionado - ya se soltó
                        bandera_control_boton_2 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 3---------
                if(estado_botones[2]){
                    if(!bandera_control_boton_3){
                    	//El botón está siendo presionado
                        bandera_control_boton_3 = true;
                    }
                } else {
                    if(bandera_control_boton_3){
                        //el botón fue presionado - ya se soltó
                        bandera_control_boton_3 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 4---------
                if(estado_botones[3]){
                    if(!bandera_control_boton_4){
                    	//El botón está siendo presionado
                        bandera_control_boton_4 = true;
                    }
                } else {
                    if(bandera_control_boton_4){
                        //el botón fue presionado - ya se soltó
                        bandera_control_boton_4 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 5---------
                if(estado_botones[4]){
                    if(!bandera_control_boton_5){
                    	//El botón está siendo presionado
                        bandera_control_boton_5 = true;
                    }
                } else {
                    if(bandera_control_boton_5){
                        //el botón fue presionado - ya se soltó
                        bandera_control_boton_5 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 6---------
                if(estado_botones[5]){
                    if(!bandera_control_boton_6){
                    	//El botón está siendo presionado
                        bandera_control_boton_6 = true;
                    }
                } else {
                    if(bandera_control_boton_6){
                        //el botón fue presionado - ya se soltó
                        bandera_control_boton_6 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 7---------
                if(estado_botones[6]){
                    if(!bandera_control_boton_7){
                    	//El botón está siendo presionado
                        bandera_control_boton_7 = true;
                    }
                } else {
                    if(bandera_control_boton_7){
                        //el botón fue presionado - ya se soltó
                        bandera_control_boton_7 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 8---------
                if(estado_botones[7]){
                    if(!bandera_control_boton_8){
                    	//El botón está siendo presionado
                        bandera_control_boton_8 = true;
                    }
                } else {
                    if(bandera_control_boton_8){
                        //el botón fue presionado - ya se soltó
                        bandera_control_boton_8 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 9---------
                if(estado_botones[8]){
                    if(!bandera_control_boton_9){
                    	//El botón está siendo presionado
                        bandera_control_boton_9 = true;
                    }
                } else {
                    if(bandera_control_boton_9){
                        //el botón fue presionado - ya se soltó
                        bandera_control_boton_9 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 10---------
                if(estado_botones[9]){
                    if(!bandera_control_boton_10){
                    	//El botón está siendo presionado
                        bandera_control_boton_10 = true;
                    }
                } else {
                    if(bandera_control_boton_10){
                        //el botón fue presionado - ya se soltó
                        bandera_control_boton_10 = false;
                    }
                }
                //----------------------------
            }
            //-----------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------
            //-----------------------------------------------------------------------------------------
    }

    //Abre stream por bluetooth
    private static Stream OpenBluetoothStream(DeviceInformation deviceInformation, RfcommServiceId serviceId) {
        /* Obstener servicio de dispositivo seleccionado */
        var device = BluetoothDevice.FromDeviceInformation(deviceInformation);
        var result = device.GetRfcommServices(BluetoothCacheMode.Cached);
        var services = result.Services;
        /* Búsqueda y apertura de conexión */
        for (int i = 0; i < services.Count; ++i) {
            var current = services[i];
            if (current.ServiceId == serviceId) {
                return current.OpenStream();
            }
        }
        /* Sí no se logra conexión */
        return null;
    }

    //Obtener información de dipositivo
    private static DeviceInformation PickDevice() {
        /* Abrir seleccionador de dispositivo */
        var picker = new DevicePicker();
        var deviceInfo = picker.PickSingleDevice();
        return deviceInfo;
    }

    //Búsqueda de dispositivos que soporten el servicio
    private DeviceInformation[] FindAll(RfcommServiceId serviceId) {
        return DeviceInformation.FindAll(RfcommDeviceService.GetDeviceSelector(serviceId)).ToArray();
    }

}
