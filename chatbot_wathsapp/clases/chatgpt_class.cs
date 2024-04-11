using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections.ObjectModel;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using System.Threading;

using chatbot_wathsapp.clases.herramientas;
using OpenQA.Selenium.Interactions;
using System.Net.Http;

using OpenAI_API;


namespace chatbot_wathsapp.clases
{
    class chatgpt_class
    {
        operaciones_arreglos op_arr = new operaciones_arreglos();
        operaciones_textos op_tex = new operaciones_textos();
        
        Tex_base bas = new Tex_base();
        

        
        string[] G_caracter_separacion_funciones_espesificas = var_fun_GG.GG_caracter_separacion_funciones_espesificas;
        string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;

        int G_donde_inicia_la_tabla = var_fun_GG.GG_indice_donde_comensar;

        string[] G_dir_arch_conf_chatbot =
        {
            /*0*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[1, 0],//"config\\chatbot\\info_para_comandos_chatbot\\00_paginaweb.txt",
            /*1*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[2, 0],//"config\\chatbot\\info_para_comandos_chatbot\\01_ya_entrado_en_la_mensajeria.txt",
            /*2*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[3, 0],//"config\\chatbot\\info_para_comandos_chatbot\\02_chequeo_no_leidos.txt",
            /*3*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[4, 0],//"config\\chatbot\\info_para_comandos_chatbot\\03_clickeo.txt",
            /*4*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[5, 0],//"config\\chatbot\\info_para_comandos_chatbot\\04_lectura_del_mensage.txt",
            /*5*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[6, 0],//"config\\chatbot\\info_para_comandos_chatbot\\05_reconocer_textbox_de_envio.txt",
            /*6*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[7, 0],//"config\\chatbot\\info_para_comandos_chatbot\\06_buscar_nombre.txt",
            /*7*/Tex_base.GG_dir_bd_y_valor_inicial_bidimencional[8, 0],//"config\\chatbot\\info_para_comandos_chatbot\\07_nombre_del_clikeado.txt",

        };
        public string[] G_dir_arch_transferencia =
        {
            /*0*//*1*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\no_hacer_caso.txt",//no_hacer_caso
            /*1*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\1.txt",//preguntas
            /*2*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\2.txt",//respuestas
            /*3*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\3.txt",//pedidos
            /*4*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\4.txt",//agregar preguntas para_watsap desde el watsap o lectura del chatbot depende la bandera
            /*5*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\5.txt",//agregar respuestas  para_chatbot desde el watsap o lectura del chatbot depende la bandera
            /*6*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\6.txt",//agregar pedidos para_watsap desde el watsap o lectura del chatbot depende la bandera
            /*7*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\7.txt",//agregar pregunta  para_chatbot desde el watsap o lectura del chatbot depende la bandera
            /*8*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\8.txt",//agregar respuesta para_watsap desde el watsap o lectura del chatbot depende la bandera
            /*9*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\9.txt",//agregar pedidos  para_chatbot desde el watsap o lectura del chatbot depende la bandera
            /*10*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\10.txt",//agregar pregunta  para_chatbot desde el watsap o lectura del chatbot depende la bandera
            /*11*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\11.txt",//agregar respuesta para_watsap desde el watsap o lectura del chatbot depende la bandera
            /*12*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\xerox\\config\\inf\\bklkfjc\\12.txt",//agregar pedidos  para_chatbot desde el watsap o lectura del chatbot depende la bandera
        };
        public string G_direccion_de_banderas_transferencias =/*0*/Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\xerox\\config\\inf\\bklkfjc\\b.txt";
        
        int id_grup_transferencias = 0;
        

        string[][] G_info_de_configuracion_chatbot = null;



        public void configuracion_de_inicio()
        {


            G_info_de_configuracion_chatbot = extraer_info_de_archivos_de_configuracion_chatbot(G_dir_arch_conf_chatbot);

            //<span class="l7jjieqr cfzgl7ar ei5e7seu h0viaqh7 tpmajp1w c0uhu3dl riy2oczp dsh4tgtl sy6s5v3r gz7w46tb lyutrhe2 qfejxiq4 fewfhwl7 ovhn1urg ap18qm3b ikwl5qvt j90th5db aumms1qt"
            //aria-label="No leídos">1</span>

            int tiempo_en_segunds_espera = 4;
            int tiempo_en_minutos = 5;


            //damos algunas opciones para iniciar el chomer
            var opciones = new ChromeOptions();
            opciones.AddArguments("--start-maximized");
            opciones.AddExcludedArgument("enable-automation");

            //declaramos el elemento manejadores
            var manejadores = new ChromeDriver(opciones);
            manejadores.Navigate().GoToUrl(G_info_de_configuracion_chatbot[0][1]);

            //declaramos un elemento esperarque nos ayude a evitar erroes de elementos no encontrados
            var esperar = new WebDriverWait(manejadores, TimeSpan.FromMinutes(tiempo_en_minutos));//segun 5 min es suficiente pero no hace  la espera
            Thread.Sleep(tiempo_en_segunds_espera * 500);//puse este yo para que se haga la espera

            //esperar.Until(manej => manej.FindElement(By.Id("side")));//este es un id que aparece despues de escanear el codigo

            esperar.Until(manej =>
            {
                //IWebElement elemento_app = manej.FindElement(By.Id("app"));
                IWebElement elementoSide = manej.FindElement(By.Id(G_info_de_configuracion_chatbot[1][1]));
                return elementoSide;
            });

            procesos(manejadores, esperar);

        }

        public void procesos(IWebDriver manejadores, WebDriverWait esperar)
        {

            //estos son del no leido--------------------------------------------------------------------
            string elementos = G_info_de_configuracion_chatbot[2][1];
            string elementos_clase = G_info_de_configuracion_chatbot[3][1];
            //-----------------------------------------------------------------------------------------

            //------------------------------------------------------------------------------------------

            bool hay_pregunta = false;
            while (true)
            {
                try
                {
                    

                    //checa si estan los elementos  esto sustitulle al // esperar.Until(manej => manej.FindElement(By.XPath(elementos)));//busca el elemento del no leido
                    //porque siempre marcaba error
                     hay_pregunta = false;
                    hay_pregunta = esperar.Until(manej =>
                    {
                        datos_salida_y_borrado(manejadores, esperar);
                        // Si el elemento no está presente, espera y luego vuelve a intentar
                        Thread.Sleep(1000); // Puedes ajustar el tiempo de espera según tu escenario
                        return hay_pregunta;

                    });
                    //---------------------------------------------------------------------------------------------
                    //

                }
                catch (NoSuchElementException ex) { }

                catch (Exception ex) { }

                catch { }

            }

        }


        
        

        private void buscar_nombre_y_dar_click(IWebDriver manejadores, WebDriverWait esperar, string nombre_o_numero)
        {
            Actions action = new Actions(manejadores);
            action.SendKeys(Keys.Escape).Perform();

            IWebDriver manejadores_de_busqueda = manejadores;
            //ReadOnlyCollection<IWebElement> elementos = manejadores_de_busqueda.FindElements(By.XPath("//span[contains(@title, 'Jorge')]"));
            IWebElement elemento = manejadores_de_busqueda.FindElement(By.XPath(G_info_de_configuracion_chatbot[6][1] + nombre_o_numero + "')]"));
            string a = elemento.Text;
            elemento.Click();

        }

        

        //WebDriverWait G_esperar2;
        private void mandar_mensage(WebDriverWait esperar, object texto_enviar_arreglo_objeto)
        {
            string[] texto_enviar_arreglo_string = op_arr.convierte_objeto_a_arreglo(texto_enviar_arreglo_objeto, "\n");


            //G_esperar2 = esperar;
            //aqui hacemos que reconosca la barra de texto y escriba

            string lugar_a_escribir = G_info_de_configuracion_chatbot[5][1];
            //var escribir_msg = G_esperar2.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));
            var escribir_msg = esperar.Until(manej => manej.FindElement(By.XPath(lugar_a_escribir)));
            string texto_enviar = string.Join("\n", texto_enviar_arreglo_string);

            escribir_msg.SendKeys(texto_enviar);
            escribir_msg.SendKeys(Keys.Enter);
            Thread.Sleep(3000); // Puedes ajustar el tiempo de espera según tu escenario

        }

        private string[] leer_respuesta_ia(WebDriverWait esperar)
        {

            //estos son los de buscar el mensage que nos llego
            string elementos2 = G_info_de_configuracion_chatbot[4][1];

            ReadOnlyCollection<IWebElement> elementos_ = esperar.Until(manej3 => manej3.FindElements(By.XPath(elementos2)));
            
            string[] textosDelMensaje = new string[elementos_.Count];
            for (int i = elementos_.Count-1; i > 0; i--)
            {
                string temp = elementos_[i].Text;
                if ((temp[temp.Length - 1]+"") == G_caracter_separacion_funciones_espesificas[0])
                {
                    break;
                }
                textosDelMensaje[i] = temp;
            }
            textosDelMensaje= op_arr.quitar_nulos_arreglo(textosDelMensaje);
            return textosDelMensaje;
        }

        private string[][] extraer_info_de_archivos_de_configuracion_chatbot(string[] direcciones)
        {

            string[][] info_a_retornar = null;
            for (int i = 0; i < direcciones.Length; i++)
            {
                int indice_configuracion_archivos_chatbot = Convert.ToInt32(bas.sacar_indice_del_arreglo_de_direccion(direcciones[i]));
                info_a_retornar = op_arr.agregar_arreglo_a_arreglo_de_arreglos(info_a_retornar, Tex_base.GG_base_arreglo_de_arreglos[indice_configuracion_archivos_chatbot]);
            }

            return info_a_retornar;
        }

        

        


        string[,] mensajes_acumulados = null;
        public string[,] acumulador_de_mensajes(string nombre = null, string mensge = null, string operacion = "agregar")
        {
            if (operacion == "agregar")
            {
                mensajes_acumulados = op_arr.agregar_registro_del_array_bidimensional(mensajes_acumulados, nombre + G_caracter_separacion_funciones_espesificas[0] + mensge, G_caracter_separacion_funciones_espesificas[0]);
                return null;
            }
            else if (operacion == "retornar")
            {
                string[,] tem_mensages = mensajes_acumulados;
                mensajes_acumulados = null;
                return tem_mensages;
            }
            return null;
        }

        public void mandar_mens_cumulados(IWebDriver manejadores, WebDriverWait esperar)
        {
            if (mensajes_acumulados != null)
            {


                string[,] mensajes_para_y_mensaje = mensajes_acumulados;
                for (int i = 0; i < mensajes_para_y_mensaje.GetLength(0); i++)
                {
                    buscar_nombre_y_dar_click(manejadores, esperar, mensajes_para_y_mensaje[i, 0]);
                    mandar_mensage(esperar, mensajes_para_y_mensaje[i, 1]);
                }

            }
            

        }

        public string quitando_el_primeros_caracters_y_checa_si_es_int(string dato_a_checar, int numero_de_caracteres_a_quitar = 1)
        {
            string dato_sin_el_primer_caracter = op_tex.joineada_paraesida_y_quitador_de_extremos_del_string(dato_a_checar, restar_cuantas_ultimas_o_primeras_celdas: numero_de_caracteres_a_quitar, restar_primera_celda: true);
            try
            {
                int numero_a_retornar = Convert.ToInt32(dato_sin_el_primer_caracter);
                return "" + numero_a_retornar;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int[] checar_numero_de_direccion_de_archivo_atras_actual_adelante(int posicion_bandera)
        {
            string[] banderas = bas.Leer_inicial(G_direccion_de_banderas_transferencias);



            int numero_actual_posision = Convert.ToInt32(banderas[posicion_bandera]);
            int numero_adelante_posision = numero_actual_posision + 3;
            int numero_atras_posision = numero_actual_posision - 3;
            int[] arr_devolver = { -1, -1, -1 };


            if (G_dir_arch_transferencia.Length <= numero_adelante_posision)
            {
                if (numero_adelante_posision < 3)
                {
                    numero_adelante_posision = posicion_bandera;
                }
                else
                {
                    numero_adelante_posision = posicion_bandera;
                    while (numero_adelante_posision > 3)
                    {
                        numero_adelante_posision = numero_adelante_posision - 3;
                    }
                }
            }
            if (1 > numero_actual_posision - 3)
            {
                numero_atras_posision = (G_dir_arch_transferencia.Length - 4) + posicion_bandera;
            }
            arr_devolver[0] = numero_atras_posision;
            arr_devolver[1] = numero_actual_posision;
            arr_devolver[2] = numero_adelante_posision;




            return arr_devolver;

        }


        public void datos_entrada(string contacto, string mensage, string ia_ws = "ia")
        {

            if (ia_ws == "ws")//agrega a archivos pregunta de la ia
            {
                int[] id_atras_actual_adelante_ia_1 = checar_numero_de_direccion_de_archivo_atras_actual_adelante(1);//esta es de la ia
                int[] id_atras_actual_adelante_ws_2 = checar_numero_de_direccion_de_archivo_atras_actual_adelante(5);//este es del ws
                if (id_atras_actual_adelante_ws_2[1] == id_atras_actual_adelante_ia_1[1])
                {
                    bas.Agregar_a_archivo_sin_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_ws_2[2]], contacto + G_caracter_separacion_funciones_espesificas[1] + mensage);
                    bas.Editar_fila_espesifica_SIN_ARREGLO_GG(G_direccion_de_banderas_transferencias, 5, (id_atras_actual_adelante_ws_2[2] + 3) + "");
                }
                else
                {
                    bas.Agregar_a_archivo_sin_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_ws_2[1]], contacto + G_caracter_separacion_funciones_espesificas[1] + mensage);
                }


            }

            else if (ia_ws == "ia")//agrega a archivos pregunta de la ia
            {
                int[] id_atras_actual_adelante_ia_1 = checar_numero_de_direccion_de_archivo_atras_actual_adelante(2);//esta es de la ia
                int[] id_atras_actual_adelante_ws_2 = checar_numero_de_direccion_de_archivo_atras_actual_adelante(5);//este es del ws
                if (id_atras_actual_adelante_ws_2[1] == id_atras_actual_adelante_ia_1[1])
                {
                    bas.Agregar_a_archivo_sin_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_ws_2[2]], contacto + G_caracter_separacion_funciones_espesificas[1] + mensage);
                    bas.Editar_fila_espesifica_SIN_ARREGLO_GG(G_direccion_de_banderas_transferencias, 5, id_atras_actual_adelante_ws_2[2] + "");
                }
                else
                {
                    bas.Agregar_a_archivo_sin_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_ws_2[1]], contacto + G_caracter_separacion_funciones_espesificas[1] + mensage);
                }


            }

        }


        public void datos_salida_y_borrado(IWebDriver manejadores, WebDriverWait esperar, string ia_ws = "ia")
        {
            int[] id_atras_actual_adelante_1 = checar_numero_de_direccion_de_archivo_atras_actual_adelante(1);//esta es de la ia
            int[] id_atras_actual_adelante_2 = checar_numero_de_direccion_de_archivo_atras_actual_adelante(4);//este es del ws

            if (ia_ws == "ws")//envia info de archivos respuesta y elimina la informacion
            {
                if (id_atras_actual_adelante_1[1] == id_atras_actual_adelante_2[1])
                {

                }
                else
                {
                    string[] respuestas_ia = bas.Leer_inicial(G_dir_arch_transferencia[id_atras_actual_adelante_2[1]]);
                    for (int i = G_donde_inicia_la_tabla; i < respuestas_ia.Length; i++)
                    {
                        string[] res_espliteada = respuestas_ia[i].Split(G_caracter_separacion_funciones_espesificas[1][0]);
                       // regresr_respuesta_ia(manejadores, esperar, res_espliteada[0], res_espliteada[1]);
                    }

                    bas.cambiar_archivo_con_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_2[1]], new string[] { "sin_informacion" });
                    bas.Editar_fila_espesifica_SIN_ARREGLO_GG(G_direccion_de_banderas_transferencias, 5, id_atras_actual_adelante_2[2] + "");
                }


            }

            else if (ia_ws == "ia")//envia info de archivos respuesta y elimina la informacion
            {
                if (id_atras_actual_adelante_1[1] == id_atras_actual_adelante_2[1])
                {
                    string[] lee_preguntas_ia = bas.Leer_inicial(G_dir_arch_transferencia[id_atras_actual_adelante_1[1]]);
                    if (1 < lee_preguntas_ia.Length)
                    {
                        for (int i = G_donde_inicia_la_tabla; i < lee_preguntas_ia.Length; i++)
                        {
                            string[] pregunta_espliteada = lee_preguntas_ia[i].Split(G_caracter_separacion_funciones_espesificas[1][0]);
                            mandar_mensage(esperar, pregunta_espliteada[1] + G_caracter_separacion_funciones_espesificas[0]);
                            Thread.Sleep(5000);
                            string textosDelMensaje = op_tex.joineada_paraesida_SIN_NULOS_y_quitador_de_extremos_del_string(leer_respuesta_ia(esperar));
                            string texto_joineado = op_tex.joineada_paraesida_SIN_NULOS_y_quitador_de_extremos_del_string(textosDelMensaje, " ");
                            datos_entrada(pregunta_espliteada[0], texto_joineado);
                        }

                        bas.cambiar_archivo_con_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_1[1]], new string[] { "sin_informacion" });

                        //bas.Editar_fila_espesifica_SIN_ARREGLO_GG(G_direccion_de_banderas_transferencias, 1, id_atras_actual_adelante_2[2] + "");
                    }
                }
                else
                {
                    string[] lee_preguntas_ia = bas.Leer_inicial(G_dir_arch_transferencia[id_atras_actual_adelante_1[1]]);
                    if (1 < lee_preguntas_ia.Length)
                    {
                        for (int i = G_donde_inicia_la_tabla; i < lee_preguntas_ia.Length; i++)
                        {
                            string[] pregunta_espliteada = lee_preguntas_ia[i].Split(G_caracter_separacion_funciones_espesificas[1][0]);
                            mandar_mensage(esperar, pregunta_espliteada[1]);
                            Thread.Sleep(5000);
                            string textosDelMensaje = op_tex.joineada_paraesida_SIN_NULOS_y_quitador_de_extremos_del_string(leer_respuesta_ia(esperar));
                            string texto_joineado = op_tex.joineada_paraesida_SIN_NULOS_y_quitador_de_extremos_del_string(textosDelMensaje, " ");
                            datos_entrada(pregunta_espliteada[0], texto_joineado);
                        }

                        bas.cambiar_archivo_con_arreglo(G_dir_arch_transferencia[id_atras_actual_adelante_1[1]], new string[] { "sin_informacion" });
                    }
                    bas.Editar_fila_espesifica_SIN_ARREGLO_GG(G_direccion_de_banderas_transferencias, 1, id_atras_actual_adelante_1[2] + "");
                }


            }


        }


    }
}




