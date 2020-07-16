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

public class Escena_Menu : MonoBehaviour
{
    public bool modo_prueba;
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
    private bool bandera_fuePresionado_boton_1 = false;
    private bool bandera_fuePresionado_boton_2 = false;
    private bool bandera_fuePresionado_boton_3 = false;
    private bool bandera_fuePresionado_boton_4 = false;
    private bool bandera_fuePresionado_boton_5 = false;
    private bool bandera_fuePresionado_boton_6 = false;
    private bool bandera_fuePresionado_boton_7 = false;
    private bool bandera_fuePresionado_boton_8 = false;
    private bool bandera_fuePresionado_boton_9 = false;
    private bool bandera_fuePresionado_boton_10 = false;
    //--------------------------------------------------
    //--------------------------------------------------------
    //--------------------------------------------------------
    //--------------------------------------------------------
	//-------------------------------------------------------------
	//----------Variables para la animación de la escena-----------
	//-------------------------------------------------------------
	public Text texto_titulo;
    public GameObject ayuda_regresar;
    public GameObject fondo_opc_1;
	public GameObject fondo_opc_2;
	public GameObject fondo_opc_3;
	public GameObject fondo_opc_4;
	public GameObject boton_fracciones;
	public GameObject boton_multiplicaciones;
	public GameObject boton_geometria;
	public GameObject boton_series;
    private float aux_animacion_boton;
    private bool animacion_boton_fracciones;
    private bool animacion_boton_multiplicaciones;
    private bool animacion_boton_geometria;
    private bool animacion_boton_series;
    public GameObject texto_boton_fracciones;
    public GameObject texto_boton_multiplicaciones;
    public GameObject texto_boton_geometria;
    public GameObject texto_boton_series;
    //---------------------------------------
    public GameObject texto_una_pregunta;
    public GameObject texto_tres_preguntas;
    public GameObject texto_cinco_preguntas;
    public GameObject texto_diez_preguntas;
    //--------------------------------------
    public GameObject boton_sin_limite;
    public GameObject boton_contrarreloj;
    public Text texto_sin_limite;
    public Text texto_contrarreloj;
	//-----------Variables de control de animación-----------------
	private RectTransform RT_boton_fraciones;
	private RectTransform RT_boton_multiplicaciones;
	private RectTransform RT_boton_geometria;
	private RectTransform RT_boton_series;
    private RectTransform RT_texto_una_pregunta;
    private RectTransform RT_texto_tres_preguntas;
    private RectTransform RT_texto_cinco_preguntas;
    private RectTransform RT_texto_diez_preguntas;
    private RectTransform RT_boton_sin_limite;
    private RectTransform RT_boton_contrarreloj;
    private byte estado_de_la_escena; //0=escoger tema 1=número de preguntas 2=eloj o contrarreloj
	//-------------Animación movimiento del fondo------------------
	public GameObject fondo_animacion_fracciones;
    public GameObject fondo_animacion_multiplicaciones;
    public GameObject fondo_animacion_geometria;
    public GameObject fondo_animacion_series;
	private RectTransform RT_fondo_fracciones;
    private RectTransform RT_fondo_multiplicaciones;
    private RectTransform RT_fondo_geometria;
    private RectTransform RT_fondo_series;
    private bool bandera_animacion_fondo;
    //------------------Bandera contar tiempo----------------------
    //private bool temporizador_encendido;
	//-------------------------------------------------------------
	//-------------------------------------------------------------
	//-------------------------------------------------------------
	//-------------------------------------------------------------
	//-------------------------------------------------------------
	//--------Variables de control de la escena--------------------
	//-------------------------------------------------------------
	private byte seleccion_actual;
    private byte seleccion_de_tema = 0;
    private byte seleccion_de_numero_preguntas = 0;
    private bool bandera_escena_1;
    private bool bandera_escena_2;
	//-------------------------------------------------------------
	//-------------------------------------------------------------
	//-------------------------------------------------------------
    void Start() {
        //Sí modo prueba está activado no se inicia con conexión Bluetooth
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
    	//--------------------------------------------------------------------------------
        //---------Inicialización de las variables para la animación de la escena---------
        //--------------------------------------------------------------------------------
        RT_boton_fraciones = boton_fracciones.GetComponent<RectTransform>();
        RT_boton_multiplicaciones = boton_multiplicaciones.GetComponent<RectTransform>();
        RT_boton_geometria = boton_geometria.GetComponent<RectTransform>();
        RT_boton_series = boton_series.GetComponent<RectTransform>();
        RT_fondo_fracciones = fondo_animacion_fracciones.GetComponent<RectTransform>();
        RT_fondo_multiplicaciones = fondo_animacion_multiplicaciones.GetComponent<RectTransform>();
        RT_fondo_geometria = fondo_animacion_geometria.GetComponent<RectTransform>();
        RT_fondo_series = fondo_animacion_series.GetComponent<RectTransform>();
        RT_texto_una_pregunta = texto_una_pregunta.GetComponent<RectTransform>();
        RT_texto_tres_preguntas = texto_tres_preguntas.GetComponent<RectTransform>();
        RT_texto_cinco_preguntas = texto_cinco_preguntas.GetComponent<RectTransform>();
        RT_texto_diez_preguntas = texto_diez_preguntas.GetComponent<RectTransform>();
        RT_boton_sin_limite = boton_sin_limite.GetComponent<RectTransform>();
        RT_boton_contrarreloj = boton_contrarreloj.GetComponent<RectTransform>();
        bandera_animacion_fondo = true;
        //temporizador_encendido = false;
        aux_animacion_boton = 1f;
        animacion_boton_fracciones = true;
        animacion_boton_multiplicaciones = false;
        animacion_boton_geometria = false;
        animacion_boton_series = false;
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //----------Inicialización de las variables para el control de la escena----------
        //--------------------------------------------------------------------------------
        seleccion_actual = 1;
        estado_de_la_escena = 0;
        bandera_escena_1 = false;
        bandera_escena_2 = false;
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
    }

    void Update() {
        //Sí modo prueba está activado no se recibe por Bluetooth
        if(!modo_prueba){
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
                        //Sí lo que recibe es diferente al retorno de carro y cambio de línea
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
                        bandera_control_boton_1 = true;
                    }
                } else {
                    if(bandera_control_boton_1){
                        bandera_fuePresionado_boton_1 = true;
                        bandera_control_boton_1 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 2---------
                if(estado_botones[1]){
                    if(!bandera_control_boton_2){
                        bandera_control_boton_2 = true;
                    }
                } else {
                    if(bandera_control_boton_2){
                        bandera_fuePresionado_boton_2 = true;
                        bandera_control_boton_2 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 3---------
                if(estado_botones[2]){
                    if(!bandera_control_boton_3){
                        bandera_control_boton_3 = true;
                    }
                } else {
                    if(bandera_control_boton_3){
                        bandera_fuePresionado_boton_3 = true;
                        bandera_control_boton_3 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 4---------
                if(estado_botones[3]){
                    if(!bandera_control_boton_4){
                        bandera_control_boton_4 = true;
                    }
                } else {
                    if(bandera_control_boton_4){
                        bandera_fuePresionado_boton_4 = true;
                        bandera_control_boton_4 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 5---------
                if(estado_botones[4]){
                    if(!bandera_control_boton_5){
                        bandera_control_boton_5 = true;
                    }
                } else {
                    if(bandera_control_boton_5){
                        bandera_fuePresionado_boton_5 = true;
                        bandera_control_boton_5 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 6---------
                if(estado_botones[5]){
                    if(!bandera_control_boton_6){
                        bandera_control_boton_6 = true;
                    }
                } else {
                    if(bandera_control_boton_6){
                        bandera_fuePresionado_boton_6 = true;
                        bandera_control_boton_6 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 7---------
                if(estado_botones[6]){
                    if(!bandera_control_boton_7){
                        bandera_control_boton_7 = true;
                    }
                } else {
                    if(bandera_control_boton_7){
                        bandera_fuePresionado_boton_7 = true;
                        bandera_control_boton_7 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 8---------
                if(estado_botones[7]){
                    if(!bandera_control_boton_8){
                        bandera_control_boton_8 = true;
                    }
                } else {
                    if(bandera_control_boton_8){
                        bandera_fuePresionado_boton_8 = true;
                        bandera_control_boton_8 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 9---------
                if(estado_botones[8]){
                    if(!bandera_control_boton_9){
                        bandera_control_boton_9 = true;
                    }
                } else {
                    if(bandera_control_boton_9){
                        bandera_fuePresionado_boton_9 = true;
                        bandera_control_boton_9 = false;
                    }
                }
                //----------------------------
                //-------CASO BOTÓN 10---------
                if(estado_botones[9]){
                    if(!bandera_control_boton_10){
                        bandera_control_boton_10 = true;
                    }
                } else {
                    if(bandera_control_boton_10){
                        bandera_fuePresionado_boton_10 = true;
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
        //----------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------SÍ LA ESCENA ESTÁ EN SELECCIÓN DE TEMA--------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------
        if (estado_de_la_escena == 0){
        //-------------------------------------------------------------
        //----------------Movimiento de los botones--------------------
        //-------------------------------------------------------------
        //----------------Animación botón fracciones-------------------
        if(seleccion_actual==1){
            if(animacion_boton_fracciones) {
                aux_animacion_boton+=0.051f; 
                if(RT_boton_fraciones.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                RT_boton_fraciones.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton>1.8f){
                    animacion_boton_fracciones = false;
                }
            } else {
                aux_animacion_boton-=0.021f;
                if(RT_boton_fraciones.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                } 
                RT_boton_fraciones.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton<1.2f){
                   aux_animacion_boton+=0.021f;
                }
            }
        }
        //-------------------------------------------------------------
        //-------------Animación botón multiplicaciones----------------
        if(seleccion_actual==2){
            if(animacion_boton_multiplicaciones) {
                if(RT_boton_multiplicaciones.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                aux_animacion_boton+=0.051f; 
                RT_boton_multiplicaciones.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton>1.8f){
                    animacion_boton_multiplicaciones = false;
                }
            } else {
                if(RT_boton_multiplicaciones.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                aux_animacion_boton-=0.021f; 
                RT_boton_multiplicaciones.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton<1.2f){
                    aux_animacion_boton+=0.021f;
                }
            }
        }
        //-------------------------------------------------------------
        //----------------Animación botón geometría--------------------
        if(seleccion_actual==3){
            if(animacion_boton_geometria) {
                if(RT_boton_geometria.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                aux_animacion_boton+=0.051f; 
                RT_boton_geometria.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton>1.8f){
                    animacion_boton_geometria = false;
                }
            } else {
                if(RT_boton_geometria.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                aux_animacion_boton-=0.021f; 
                RT_boton_geometria.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton<1.2f){
                    aux_animacion_boton+=0.021f;
                }
            }
        }
        //-------------------------------------------------------------
        //------------------Animación botón series---------------------
        if(seleccion_actual==4){
            if(animacion_boton_series) {
                if(RT_boton_series.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                aux_animacion_boton+=0.051f; 
                RT_boton_series.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton>1.8f){
                    animacion_boton_series = false;
                }
            } else {
                if(RT_boton_series.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                aux_animacion_boton-=0.021f; 
                RT_boton_series.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton<1.2f){
                    aux_animacion_boton+=0.021f;
                }
            }
        }
        //-------------------------------------------------------------
        //-------------------------------------------------------------
        //-------------------------------------------------------------
        //-----------------Control de teclas---------------------------
        //-------------------------------------------------------------
    	//--------------Cuando se oprime "Enter"-----------------------
        //-------------------------------------------------------------
    	if(Input.GetKeyUp(KeyCode.Space)||bandera_fuePresionado_boton_3) {
    		estado_de_la_escena = 1;
            seleccion_de_tema = seleccion_actual;
            //----------------caso especial de animación----------------------------
            if(seleccion_actual==1){
                animacion_boton_fracciones = true;
                animacion_boton_multiplicaciones = true;
                animacion_boton_geometria = true;
                animacion_boton_series = true;
            }
            //----------------------------------------------------------------------
            seleccion_actual = 1;
            ayuda_regresar.SetActive(true);
            //----------------------------------------------------------------------
            //se inhabilitan opciones del menú anterior y se habilitan las del nuevo
            //----------------------------------------------------------------------
            boton_fracciones.SetActive(false);
            boton_multiplicaciones.SetActive(false);
            boton_geometria.SetActive(false);
            boton_series.SetActive(false);
            texto_boton_fracciones.SetActive(false);
            texto_boton_multiplicaciones.SetActive(false);
            texto_boton_geometria.SetActive(false);
            texto_boton_series.SetActive(false);
            texto_una_pregunta.SetActive(true);
            texto_tres_preguntas.SetActive(true);
            texto_cinco_preguntas.SetActive(true);
            texto_diez_preguntas.SetActive(true);
            texto_titulo.text = "¿Cuántas preguntas?";
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
    	}
    	//--------------Cuando se oprime derecha-----------------------
        if (Input.GetKeyUp("right")||bandera_fuePresionado_boton_5) {
        	if(seleccion_actual==4){
        		seleccion_actual = 1;
        	} else {
        		seleccion_actual++;
        	}
        }
        //-----------Cuando se orpime izquierda------------------------
        if (Input.GetKeyUp("left")||bandera_fuePresionado_boton_4) {
        	if(seleccion_actual==1){
        		seleccion_actual = 4;
        	} else {
        		seleccion_actual--;
        	}
        }
        //------------------------------------------------------------
        //------------------------------------------------------------
        //------------------------------------------------------------
        //------------------------------------------------------------
        //-----------Dependiendo de la selección actual---------------
        //------------------------------------------------------------
        switch (seleccion_actual) {
            case 1: {
                fondo_opc_1.SetActive(true);
                fondo_opc_2.SetActive(false);
                fondo_opc_3.SetActive(false);
                fondo_opc_4.SetActive(false);
                animacion_boton_multiplicaciones = true;
                animacion_boton_geometria = true;
                animacion_boton_series = true;
                RT_boton_multiplicaciones.localScale = new Vector3(1f, 1f, 1f);
                RT_boton_geometria.localScale = new Vector3(1f, 1f, 1f);
                RT_boton_series.localScale = new Vector3(1f, 1f, 1f);
                fondo_animacion_fracciones.SetActive(true);
                fondo_animacion_multiplicaciones.SetActive(false);
                fondo_animacion_geometria.SetActive(false);
                fondo_animacion_series.SetActive(false);
                texto_boton_fracciones.GetComponent<Text>().color = Color.white;
                texto_boton_multiplicaciones.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_boton_geometria.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_boton_series.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                break;
            }
            case 2: {
                fondo_opc_1.SetActive(false);
                fondo_opc_2.SetActive(true);
                fondo_opc_3.SetActive(false);
                fondo_opc_4.SetActive(false);
                animacion_boton_fracciones = true;
                animacion_boton_geometria = true;
                animacion_boton_series = true;
                RT_boton_fraciones.localScale = new Vector3(1f, 1f, 1f);
                RT_boton_geometria.localScale = new Vector3(1f, 1f, 1f);
                RT_boton_series.localScale = new Vector3(1f, 1f, 1f);
                fondo_animacion_fracciones.SetActive(false);
                fondo_animacion_multiplicaciones.SetActive(true);
                fondo_animacion_geometria.SetActive(false);
                fondo_animacion_series.SetActive(false);
                texto_boton_fracciones.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_boton_multiplicaciones.GetComponent<Text>().color = Color.white;
                texto_boton_geometria.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_boton_series.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                break;
            }
            case 3: {
                fondo_opc_1.SetActive(false);
                fondo_opc_2.SetActive(false);
                fondo_opc_3.SetActive(true);
                fondo_opc_4.SetActive(false);
                animacion_boton_multiplicaciones = true;
                animacion_boton_fracciones = true;
                animacion_boton_series = true;
                RT_boton_fraciones.localScale = new Vector3(1f, 1f, 1f);
                RT_boton_multiplicaciones.localScale = new Vector3(1f, 1f, 1f);
                RT_boton_series.localScale = new Vector3(1f, 1f, 1f);
                fondo_animacion_fracciones.SetActive(false);
                fondo_animacion_multiplicaciones.SetActive(false);
                fondo_animacion_geometria.SetActive(true);
                fondo_animacion_series.SetActive(false);
                texto_boton_fracciones.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_boton_multiplicaciones.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_boton_geometria.GetComponent<Text>().color = Color.white;
                texto_boton_series.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                break;
            }
            case 4: {
                fondo_opc_1.SetActive(false);
                fondo_opc_2.SetActive(false);
                fondo_opc_3.SetActive(false);
                fondo_opc_4.SetActive(true);
                animacion_boton_multiplicaciones = true;
                animacion_boton_geometria = true;
                animacion_boton_fracciones = true;
                RT_boton_fraciones.localScale = new Vector3(1f, 1f, 1f);
                RT_boton_multiplicaciones.localScale = new Vector3(1f, 1f, 1f);
                RT_boton_geometria.localScale = new Vector3(1f, 1f, 1f);
                fondo_animacion_fracciones.SetActive(false);
                fondo_animacion_multiplicaciones.SetActive(false);
                fondo_animacion_geometria.SetActive(false);
                fondo_animacion_series.SetActive(true);
                texto_boton_fracciones.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_boton_multiplicaciones.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_boton_geometria.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_boton_series.GetComponent<Text>().color = Color.white;
                break;
            }
        }
        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        }
        //----------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------SÍ LA ESCENA ESTÁ EN SELECCIÓN DE NÚMERO DE PREGUNTAS---------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------
        if (estado_de_la_escena == 1){
        //-------------------------------------------------------------
        //----------------Movimiento de los botones--------------------
        //-------------------------------------------------------------
        //----------------Animación botón fracciones-------------------
        if(seleccion_actual==1){
            if(animacion_boton_fracciones) {
                aux_animacion_boton+=0.051f; 
                if(RT_texto_una_pregunta.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                RT_texto_una_pregunta.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton>1.8f){
                    animacion_boton_fracciones = false;
                }
            } else {
                aux_animacion_boton-=0.021f;
                if(RT_texto_una_pregunta.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                } 
                RT_texto_una_pregunta.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton<1.2f){
                   aux_animacion_boton+=0.021f;
                }
            }
        }
        //-------------------------------------------------------------
        //-------------Animación botón multiplicaciones----------------
        if(seleccion_actual==2){
            if(animacion_boton_multiplicaciones) {
                if(RT_texto_tres_preguntas.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                aux_animacion_boton+=0.051f; 
                RT_texto_tres_preguntas.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton>1.8f){
                    animacion_boton_multiplicaciones = false;
                }
            } else {
                if(RT_texto_tres_preguntas.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                aux_animacion_boton-=0.021f; 
                RT_texto_tres_preguntas.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton<1.2f){
                    aux_animacion_boton+=0.021f;
                }
            }
        }
        //-------------------------------------------------------------
        //----------------Animación botón geometría--------------------
        if(seleccion_actual==3){
            if(animacion_boton_geometria) {
                if(RT_texto_cinco_preguntas.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                aux_animacion_boton+=0.051f; 
                RT_texto_cinco_preguntas.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton>1.8f){
                    animacion_boton_geometria = false;
                }
            } else {
                if(RT_texto_cinco_preguntas.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                aux_animacion_boton-=0.021f; 
                RT_texto_cinco_preguntas.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton<1.2f){
                    aux_animacion_boton+=0.021f;
                }
            }
        }
        //-------------------------------------------------------------
        //------------------Animación botón series---------------------
        if(seleccion_actual==4){
            if(animacion_boton_series) {
                if(RT_texto_diez_preguntas.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                aux_animacion_boton+=0.051f; 
                RT_texto_diez_preguntas.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton>1.8f){
                    animacion_boton_series = false;
                }
            } else {
                if(RT_texto_diez_preguntas.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                aux_animacion_boton-=0.021f; 
                RT_texto_diez_preguntas.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton<1.2f){
                    aux_animacion_boton+=0.021f;
                }
            }
        }
        //-------------------------------------------------------------
        //-------------------------------------------------------------
        //-------------------------------------------------------------
        //-----------------Control de teclas---------------------------
        //-------------------------------------------------------------
        //--------------Cuando se oprime "Enter"-----------------------
        //-------------------------------------------------------------
        if(Input.GetKeyUp(KeyCode.Space)||bandera_fuePresionado_boton_3) {
            if(bandera_escena_1 == false){
                estado_de_la_escena = 1;
                bandera_escena_1 = true;
                //Se mantiene el fondo de acuerdo a la selección anterior
                switch (seleccion_de_tema){
                    case 1: fondo_animacion_fracciones.SetActive(true);
                            fondo_animacion_multiplicaciones.SetActive(false);
                            fondo_animacion_geometria.SetActive(false);
                            fondo_animacion_series.SetActive(false);
                            break;
                    case 2: fondo_animacion_fracciones.SetActive(false);
                            fondo_animacion_multiplicaciones.SetActive(true);
                            fondo_animacion_geometria.SetActive(false);
                            fondo_animacion_series.SetActive(false); 
                            break;
                    case 3: fondo_animacion_fracciones.SetActive(false);
                            fondo_animacion_multiplicaciones.SetActive(false);
                            fondo_animacion_geometria.SetActive(true);
                            fondo_animacion_series.SetActive(false);
                            break;
                    case 4: fondo_animacion_fracciones.SetActive(false);
                            fondo_animacion_multiplicaciones.SetActive(false);
                            fondo_animacion_geometria.SetActive(false);
                            fondo_animacion_series.SetActive(true);
                            break;
                }
                //-------------------------------------------------------
            } else {
                estado_de_la_escena = 2;
                seleccion_de_numero_preguntas = seleccion_actual;
                //----------------caso especial de animación----------------------------
                if(seleccion_actual==1){
                    animacion_boton_fracciones = true;
                    animacion_boton_multiplicaciones = true;
                    animacion_boton_geometria = true;
                    animacion_boton_series = true;
                }
                //----------------------------------------------------------------------
                seleccion_actual = 1;
                //----------------------------------------------------------------------
                //se inhabilitan opciones del menú anterior y se habilitan las del nuevo
                //----------------------------------------------------------------------
                texto_una_pregunta.SetActive(false);
                texto_tres_preguntas.SetActive(false);
                texto_cinco_preguntas.SetActive(false);
                texto_diez_preguntas.SetActive(false);
                texto_titulo.text = "Selecciona un modo";
                boton_sin_limite.SetActive(true);
                boton_contrarreloj.SetActive(true);
                //----------------------------------------------------------------------
                //----------------------------------------------------------------------
                //----------------------------------------------------------------------
            }
        }
        //--------------Cuando se oprime derecha-----------------------
        if (Input.GetKeyUp("right")||bandera_fuePresionado_boton_5) {
            if(seleccion_actual==4){
                seleccion_actual = 1;
            } else {
                seleccion_actual++;
            }
        }
        //-----------Cuando se orpime izquierda------------------------
        if (Input.GetKeyUp("left")||bandera_fuePresionado_boton_4) {
            if(seleccion_actual==1){
                seleccion_actual = 4;
            } else {
                seleccion_actual--;
            }
        }
        //-----------Cuando se orpime regresar------------------------
        if (Input.GetKeyUp("w")||bandera_fuePresionado_boton_6) {
            estado_de_la_escena = 0;
            //----------------caso especial de animación----------------------------
            if(seleccion_actual==seleccion_de_tema){
                animacion_boton_fracciones = true;
                animacion_boton_multiplicaciones = true;
                animacion_boton_geometria = true;
                animacion_boton_series = true;
            }
            //----------------------------------------------------------------------
            ayuda_regresar.SetActive(false);
            seleccion_actual = seleccion_de_tema;
            bandera_escena_1 = false;
            //----------------------------------------------------------------------
            //se inhabilitan opciones del menú anterior y se habilitan las del nuevo
            //----------------------------------------------------------------------
            boton_fracciones.SetActive(true);
            boton_multiplicaciones.SetActive(true);
            boton_geometria.SetActive(true);
            boton_series.SetActive(true);
            texto_boton_fracciones.SetActive(true);
            texto_boton_multiplicaciones.SetActive(true);
            texto_boton_geometria.SetActive(true);
            texto_boton_series.SetActive(true);
            texto_una_pregunta.SetActive(false);
            texto_tres_preguntas.SetActive(false);
            texto_cinco_preguntas.SetActive(false);
            texto_diez_preguntas.SetActive(false);
            texto_titulo.text = "Selecciona un tema";
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
        }
        //------------------------------------------------------------
        //------------------------------------------------------------
        //------------------------------------------------------------
        //------------------------------------------------------------
        //-----------Dependiendo de la selección actual---------------
        //------------------------------------------------------------
        switch (seleccion_actual) {
            case 1: {
                fondo_opc_1.SetActive(true);
                fondo_opc_2.SetActive(false);
                fondo_opc_3.SetActive(false);
                fondo_opc_4.SetActive(false);
                animacion_boton_multiplicaciones = true;
                animacion_boton_geometria = true;
                animacion_boton_series = true;
                RT_texto_tres_preguntas.localScale = new Vector3(1f, 1f, 1f);
                RT_texto_cinco_preguntas.localScale = new Vector3(1f, 1f, 1f);
                RT_texto_diez_preguntas.localScale = new Vector3(1f, 1f, 1f);
                texto_una_pregunta.GetComponent<Text>().color = Color.white;
                texto_tres_preguntas.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_cinco_preguntas.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_diez_preguntas.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                break;
            }
            case 2: {
                fondo_opc_1.SetActive(false);
                fondo_opc_2.SetActive(true);
                fondo_opc_3.SetActive(false);
                fondo_opc_4.SetActive(false);
                animacion_boton_fracciones = true;
                animacion_boton_geometria = true;
                animacion_boton_series = true;
                RT_texto_una_pregunta.localScale = new Vector3(1f, 1f, 1f);
                RT_texto_cinco_preguntas.localScale = new Vector3(1f, 1f, 1f);
                RT_texto_diez_preguntas.localScale = new Vector3(1f, 1f, 1f);
                texto_una_pregunta.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_tres_preguntas.GetComponent<Text>().color = Color.white;
                texto_cinco_preguntas.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_diez_preguntas.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                break;
            }
            case 3: {
                fondo_opc_1.SetActive(false);
                fondo_opc_2.SetActive(false);
                fondo_opc_3.SetActive(true);
                fondo_opc_4.SetActive(false);
                animacion_boton_multiplicaciones = true;
                animacion_boton_fracciones = true;
                animacion_boton_series = true;
                RT_texto_una_pregunta.localScale = new Vector3(1f, 1f, 1f);
                RT_texto_tres_preguntas.localScale = new Vector3(1f, 1f, 1f);
                RT_texto_diez_preguntas.localScale = new Vector3(1f, 1f, 1f);
                texto_una_pregunta.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_tres_preguntas.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_cinco_preguntas.GetComponent<Text>().color = Color.white;
                texto_diez_preguntas.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                break;
            }
            case 4: {
                fondo_opc_1.SetActive(false);
                fondo_opc_2.SetActive(false);
                fondo_opc_3.SetActive(false);
                fondo_opc_4.SetActive(true);
                animacion_boton_multiplicaciones = true;
                animacion_boton_geometria = true;
                animacion_boton_fracciones = true;
                RT_texto_una_pregunta.localScale = new Vector3(1f, 1f, 1f);
                RT_texto_tres_preguntas.localScale = new Vector3(1f, 1f, 1f);
                RT_texto_cinco_preguntas.localScale = new Vector3(1f, 1f, 1f);
                texto_una_pregunta.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_tres_preguntas.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_cinco_preguntas.GetComponent<Text>().color = new Color(0f, 0.47f, 0.81f);
                texto_diez_preguntas.GetComponent<Text>().color = Color.white;
                break;
            }
        }
        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        }
        //----------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------SÍ LA ESCENA ESTÁ EN SELECCIÓN DE MODO--------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------
        if (estado_de_la_escena == 2){
        //-------------------------------------------------------------
        //----------------Movimiento de los botones--------------------
        //-------------------------------------------------------------
        //----------------Animación botón fracciones-------------------
        if(seleccion_actual==1){
            if(animacion_boton_fracciones) {
                aux_animacion_boton+=0.051f; 
                if(RT_boton_sin_limite.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                RT_boton_sin_limite.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton>1.8f){
                    animacion_boton_fracciones = false;
                }
            } else {
                aux_animacion_boton-=0.021f;
                if(RT_boton_sin_limite.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                } 
                RT_boton_sin_limite.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton<1.2f){
                   aux_animacion_boton+=0.021f;
                }
            }
        }
        //-------------------------------------------------------------
        //-------------Animación botón multiplicaciones----------------
        if(seleccion_actual==2){
            if(animacion_boton_multiplicaciones) {
                if(RT_boton_contrarreloj.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                aux_animacion_boton+=0.051f; 
                RT_boton_contrarreloj.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton>1.8f){
                    animacion_boton_multiplicaciones = false;
                }
            } else {
                if(RT_boton_contrarreloj.localScale.x==1f){
                    aux_animacion_boton=1.02f;
                }
                aux_animacion_boton-=0.021f; 
                RT_boton_contrarreloj.localScale = new Vector3(aux_animacion_boton, aux_animacion_boton, aux_animacion_boton);
                if(aux_animacion_boton<1.2f){
                    aux_animacion_boton+=0.021f;
                }
            }
        }
        //-------------------------------------------------------------
        //-------------------------------------------------------------
        //-------------------------------------------------------------
        //-----------------Control de teclas---------------------------
        //-------------------------------------------------------------
        //--------------Cuando se oprime "Enter"-----------------------
        //-------------------------------------------------------------
        if(Input.GetKeyUp(KeyCode.Space)||bandera_fuePresionado_boton_3) {
            if(bandera_escena_2 == false){
                estado_de_la_escena = 2;
                bandera_escena_2 = true;
            } else {
                //************************************************************************************************************
                //------------------------------------TERMINA LA ESCENA MENÚ--------------------------------------------------
                //************************************************************************************************************
                //print("tema: "+seleccion_de_tema+" num_preguntas: "+seleccion_de_numero_preguntas+" modo: "+seleccion_actual);
                PlayerPrefs.SetInt("seleccion_de_tema", seleccion_de_tema);//1: fracciones, 2: multiplicaciones, 3: geometría, 4:series
                PlayerPrefs.SetInt("num_preguntas", seleccion_de_numero_preguntas);//1: 1, 2: 3, 3: 5 4: 10
                PlayerPrefs.SetInt("modo", seleccion_actual);//1: sin límite 2: contrarreloj
                SceneManager.LoadScene("Actividad", LoadSceneMode.Single);
            }
        }
        //--------------Cuando se oprime derecha-----------------------
        if (Input.GetKeyUp("right")||bandera_fuePresionado_boton_5) {
            if(seleccion_actual==2){
                seleccion_actual = 1;
            } else {
                seleccion_actual++;
            }
        }
        //-----------Cuando se orpime izquierda------------------------
        if (Input.GetKeyUp("left")||bandera_fuePresionado_boton_4) {
            if(seleccion_actual==1){
                seleccion_actual = 2;
            } else {
                seleccion_actual--;
            }
        }
        //------------------------------------------------------------
        //-----------Cuando se orpime regresar------------------------
        if (Input.GetKeyUp("w")||bandera_fuePresionado_boton_6) {
            estado_de_la_escena = 1;
            //----------------caso especial de animación----------------------------
            if(seleccion_actual==seleccion_de_numero_preguntas){
                animacion_boton_fracciones = true;
                animacion_boton_multiplicaciones = true;
                animacion_boton_geometria = true;
                animacion_boton_series = true;
            }
            //----------------------------------------------------------------------
            seleccion_actual = seleccion_de_numero_preguntas;
            bandera_escena_2 = false;
            //----------------------------------------------------------------------
            //se inhabilitan opciones del menú anterior y se habilitan las del nuevo
            //----------------------------------------------------------------------
            boton_sin_limite.SetActive(false);
            boton_contrarreloj.SetActive(false);
            texto_una_pregunta.SetActive(true);
            texto_tres_preguntas.SetActive(true);
            texto_cinco_preguntas.SetActive(true);
            texto_diez_preguntas.SetActive(true);
            texto_titulo.text = "¿Cuántas preguntas?";
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
            //----------------------------------------------------------------------
        }
        //------------------------------------------------------------
        //------------------------------------------------------------
        //------------------------------------------------------------
        //------------------------------------------------------------
        //-----------Dependiendo de la selección actual---------------
        //------------------------------------------------------------
        switch (seleccion_actual) {
            case 1: {
                fondo_opc_1.SetActive(true);
                fondo_opc_2.SetActive(true);
                fondo_opc_3.SetActive(false);
                fondo_opc_4.SetActive(false);
                animacion_boton_multiplicaciones = true;
                RT_boton_contrarreloj.localScale = new Vector3(1f, 1f, 1f);
                texto_sin_limite.color = Color.white;
                texto_contrarreloj.color = new Color(0f, 0.47f, 0.81f);
                boton_sin_limite.GetComponent<Image>().color = Color.white;
                boton_contrarreloj.GetComponent<Image>().color = new Color(0f, 0.47f, 0.81f);
                break;
            }
            case 2: {
                fondo_opc_1.SetActive(false);
                fondo_opc_2.SetActive(false);
                fondo_opc_3.SetActive(true);
                fondo_opc_4.SetActive(true);
                animacion_boton_fracciones = true;
                RT_boton_sin_limite.localScale = new Vector3(1f, 1f, 1f);
                texto_sin_limite.color = new Color(0f, 0.47f, 0.81f);
                texto_contrarreloj.color = Color.white;
                boton_sin_limite.GetComponent<Image>().color = new Color(0f, 0.47f, 0.81f);
                boton_contrarreloj.GetComponent<Image>().color = Color.white;
                break;
            }
        }
        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        //----------------------------------------------------------------------
        }
        //----------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------
        //Se desactivan todas las banderas, si es que no fueron usadas
        bandera_fuePresionado_boton_1 = false;
        bandera_fuePresionado_boton_2 = false;
        bandera_fuePresionado_boton_3 = false;
        bandera_fuePresionado_boton_4 = false;
        bandera_fuePresionado_boton_5 = false;
        bandera_fuePresionado_boton_6 = false;
        bandera_fuePresionado_boton_7 = false;
        bandera_fuePresionado_boton_8 = false;
        bandera_fuePresionado_boton_9 = false;
        bandera_fuePresionado_boton_10 = false;
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

    //Corrutina que cuenta 'n' segundos reales
    /*IEnumerator UsingYield(int seconds) {
      temporizador_encendido = true;
      yield return new WaitForSeconds(seconds);
      temporizador_encendido = false;
   }*/
}
