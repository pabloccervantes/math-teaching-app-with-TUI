<img align="right" src="https://conacic.cs.buap.mx/images/fcclogo.png" width="60">
<h1>Resumen</h1>
<p align="justify">
El proyecto consiste en el desarrollo de una aplicación de escritorio que funciona como material de apoyo para el repaso de temas del área de matemáticas en alumnos de educación básica (entre 9 y 12 años). Mediante el uso de una interfaz de usuario tangible (<i>figura 2.2</i>) se interactua con la aplicación por medio de una red <i>Bluetooth</i>, además la aplicación hace uso de una base de datos interna SQLite para el almacenamiento y carga de los ejercicios y/o contenidos a mostrar.<br>
El sistema de la aplicación consta de dos partes, las cuales identificamos como:</p>
<ul>
	<li><p align="justify"><b>Módulo Arduino:</b> Corresponde a una interfaz de usuario tangible (<i>IUT</i>) controlada por una placa de microcontrolador, <i>Arduino Uno</i>.</p></li>
	<li><p align="justify"><b>Módulo Unity:</b> Se trata de la aplicación de escritorio, para Windows y desarrollada en Unity, la cual presenta al usuario las actividades a realizar y que es controlada por medio de la <i>IUT</i>.</p></li>
</ul>
<h1>Desarrollo</h1>
<p align="justify">Lo primero que se abordó fue en relación con la comunicación entre los módulos, que se identifican como <i>módulo arduino</i> y <i>módulo unity</i>, como se mencionó anteriormente, se realizará por medio de una conexión bluetooth usando el módulo <i>HC-06</i> por parte del <i>módulo arduino</i> y el módulo bluetooth del equipo laptop por parte del <i>módulo unity</i>. Esta comunicación está representada en la <i>figura 1.1</i>. </p>
<div align="center">
  <img src="https://github.com/PabloCerv/math-teaching-app-with-TUI/blob/master/readme_images/1.png?raw=true" width="400">
</div>
<p align="center"><i>Figura 1.1 Comunicación entre módulos</i></p>
<p align="justify">Para comprender el funcionamiento de la comunicación, primero se debe abordar el funcionamiento del <i>-módulo arduino-</i>, el cual corresponde a una <i>IUT</i> orientada a usuarios de educación básica, la temática de esta corresponde al juego del avión (<i>figura 2.2</i>). Cuenta con diez posiciones seleccionables conectadas a una tarjeta de microcontrolador <i>Arduino Uno</i>, a su vez, esta contiene un módulo de <i>Bluetooth HC-06</i> (<i>figura 2.1</i>).</p>
<div align="center">
  <img src="https://github.com/PabloCerv/math-teaching-app-with-TUI/blob/master/readme_images/4.png?raw=true" width="500">
</div>
<p align="center"><i>Figura 2.1 Esquema de conexión -Módulo Arduino-</i></p>
<div align="center">
  <img src="https://github.com/PabloCerv/math-teaching-app-with-TUI/blob/master/readme_images/3.png?raw=true" width="500">
</div>
<p align="center"><i>Figura 2.2 Prototipo del -Módulo Arduino-</i></p>
<p align="justify">El envió de los datos se ve ejemplificado en la <i>figura 3.1.</i></p>
<div align="center">
  <img src="https://github.com/PabloCerv/math-teaching-app-with-TUI/blob/master/readme_images/2.png?raw=true" width="600">
</div>
<p align="center"><i>Figura 3.1 Datos durante la comunicación</i></p>
<p align="justify">El <i>-módulo Arduino-</i> envía una cadena de diez valores (0,1) que indica el estado de activación de cada posición del tapete (<i>IUT</i>), esta acción se realiza cinco veces por segundo (cada 200ms). A su vez, en cada envió de cadena, debido a la longitud, se envía posición por posición cada 20ms aproximadamente. 
Al final de cada envío de la cadena (string), se envía carácter de cambio de línea (LF), lo que le indica al <i>-módulo Unity-</i> que ya recibió la cadena completa, por lo que compara el valor de cada posición con el anterior recibido, y sí existió un cambio de: seleccionado, a: no seleccionado, entonces realiza la acción que corresponde a oprimir dicha posición. Lo anterior se puede observar en los fragmentos de código de las <i>figuras 4.1</i> y <i>4.2</i>.</p>
<div align="center">
  <img src="https://github.com/PabloCerv/math-teaching-app-with-TUI/blob/master/readme_images/5.png?raw=true" width="500">
</div>
<p align="center"><i>Figura 4.1 Código envío -Módulo Arduino-</i></p>
<div align="center">
  <img src="https://github.com/PabloCerv/math-teaching-app-with-TUI/blob/master/readme_images/6.png?raw=true" width="500">
</div>
<p align="center"><i>Figura 4.2 Código recepción -Módulo Unity-</i></p>
<p align="justify">Dentro de la aplicación (<i>módulo Unity</i>), se tienen dos pantallas principales:</p>
<ul>
	<li><p align="justify"><b>Menú de la actividad:</b> Es la primera en mostrarse, contiene las opciones de configuración de la actividad (selección de tema, selección de número de ejercicios, selección modo [c/s contrarreloj]).</p></li>
	<li><p align="justify"><b>Actividad:</b> Presenta los ejercicios con las opciones de respuesta y las instrucciones de selección usando el tapete (<i>IUT</i>). </p></li>
</ul>
<div align="center">
  <img src="https://github.com/PabloCerv/math-teaching-app-with-TUI/blob/master/readme_images/7.png?raw=true" width="300">
  <img src="https://github.com/PabloCerv/math-teaching-app-with-TUI/blob/master/readme_images/8.png?raw=true" width="300">
</div>
<p align="center"><i>Figura 5.1 Pantalla Opciones - Figura 5.2 Pantalla Actividad</i></p>
<div align="center">
  <img src="https://github.com/PabloCerv/math-teaching-app-with-TUI/blob/master/readme_images/9.png?raw=true" width="600">
</div>
<p align="center"><i>Figura 5.3 Secciones de pantalla Actividad</i></p>
<p align="justify">Como se aprecia en la figura 5.3, existe un apartado de “estado del tapete”, el cual muestra, en tiempo real, que posiciones están siendo seleccionadas. Los recorridos en el tapete, presentados en las opciones, cambian en cada ejercicio.</p>
<p align="justify">Los ejercicios son obtenidos desde una base de datos SQLite incluida en la aplicación, esto se hizo así para en un futuro cargar los ejercicios desde un nuevo módulo o desde una plataforma web a la aplicación, la que guardaría estos ejercicios en su base. La DB solo consta de dos tablas ya que no se hace uso de muchos datos diferentes, pero se podría expandir para la inclusión de un sistema de usuarios, evaluaciones o clasificaciones.</p>
<div align="center">
  <img src="https://github.com/PabloCerv/math-teaching-app-with-TUI/blob/master/readme_images/10.png?raw=true" width="500">
</div>
<p align="center"><i>Figura 6.1 Estructura base de datos interna</i></p>
<div align="center">
  <img src="https://github.com/PabloCerv/math-teaching-app-with-TUI/blob/master/readme_images/11.png?raw=true" width="300">
  <img src="https://github.com/PabloCerv/math-teaching-app-with-TUI/blob/master/readme_images/12.png?raw=true" width="300">
</div>
<p align="center"><i>Figura 6.2 Datos tabla preguntas - Figura 6.3 Datos tabla respuestas</i></p>
<p align="justify">En el campo “<i>caminos_respuesta</i>”, se indica el camino a seguir en el tapete (<i>IUT</i>) para responder la opción correspondiente. El <i>camino</i> puede contener de una a todas las posiciones, sin importar el orden de aparición o la repetición de alguna. El camino está señalado mediante una cadena tipo <i>string</i>, indicando la posición del tapete con su correspondiente numérico y separando las posiciones con caracteres 248 en ascii [°]. Para indicar la selección simultánea de posiciones se ligan con guion medio (sólo disponible para las posiciones 4-5, 7-8).</p>
<div align="center">
  <img src="https://github.com/PabloCerv/math-teaching-app-with-TUI/blob/master/readme_images/13.png?raw=true" width="500">
</div>
<p align="center"><i>Figura 6.4 Ejemplos de campo: “caminos_respuesta”</i></p>
<p align="justify">Dentro del proyecto en Unity, las dos escenas (menú y actividad), contienen en los objetos “<i>canvas</i>”, la propiedad de “<b><i>modo prueba</i></b>” (<i>figura 7.1</i>), al activarla y ejecutar la simulación, la aplicación podrá ser controlada con teclado sin conectar el tapete (<i>IUT</i>), los números del bloque numérico representan pisar una posición en el <i>tapete</i>.</p>
<div align="center">
  <img src="https://github.com/PabloCerv/math-teaching-app-with-TUI/blob/master/readme_images/14.png?raw=true" width="400">
</div>
<p align="center"><i>Figura 7.1 “Modo prueba” activado en proyecto Unity</i></p>
<br>
<br>
<p align="center"><b>Pablo Cerón Cervantes (pabloccervantes@gmail.com)</b></p>
