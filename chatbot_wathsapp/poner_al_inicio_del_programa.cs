using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chatbot_wathsapp.clases.herramientas;

namespace chatbot_wathsapp.clases
{
    class poner_al_inicio_del_programa
    {
        Tex_base bas = new Tex_base();
        operaciones_arreglos op_arreglos = new operaciones_arreglos();

        int G_configuracion = var_fun_GG.GG_indice_donde_comensar;
        public string[] G_caracter_separacion = var_fun_GG.GG_caracter_separacion;
        public string[] G_separador_para_funciones_espesificas_ = var_fun_GG.GG_caracter_separacion_funciones_espesificas;



        public void inicio()
        {

            string direccion_archivo_de_direcciones_de_bd = "archivos_iniciales\\inicio.txt";
            string fila_inicial = "direccion_de_las_bases_de_datos" + bas.GG_separador_para_funciones_espesificas_[0] + "fila_inicial" + bas.GG_separador_para_funciones_espesificas_[0] + "arreglo_de_filas_separado_por_§//posdata_solo_ir_agregando_archivos_asta_abajo_por_que_las_filas_ya_son_ocupadas_por_el_programa_y_no_borrar";



            string[] agregar_filas =
            {
                
                /*1*/ "config\\chatbot\\info_para_comandos\\00_paginaweb.txt~info_para_comandos~https://chat.openai.com/",
                /*2*/ "config\\chatbot\\info_para_comandos\\01_ya_entrado_en_la_mensajeria.txt~info_para_comandos~__next",
                /*3*/ "config\\chatbot\\info_para_comandos\\02_chequeo_no_leidos.txt~info_para_comandos~//*[@id=\"__next\"]/div/div[2]/div[1]/div[1]/div/div/div/div/nav/div[2]/div[2]/div/span[1]/div[2]/ol~",
                /*4*/ "config\\chatbot\\info_para_comandos\\03_clickeo.txt~info_para_comandos~//*[@id=\"__next\"]/div/div[2]/div[1]/div[1]/div/div/div/div/nav/div[2]/div[2]/div/span[1]/div[2]/ol~",
                /*5*/ "config\\chatbot\\info_para_comandos\\04_lectura_del_mensage.txt~info_para_comandos~//div[@data-message-author-role=\"assistant\"]//p | //div[@data-message-author-role=\"user\"]~",
                /*6*/ "config\\chatbot\\info_para_comandos\\05_reconocer_textbox_de_envio.txt~info_para_comandos~//*[@id=\"prompt-textarea\"]~",
                /*7*/ "config\\chatbot\\info_para_comandos\\06_buscar_nombre.txt~info_para_comandos~//span[contains(@title, '",
                /*8*/ "config\\chatbot\\info_para_comandos\\07_nombre_del_clikeado.txt~info_para_comandos~//header[@class='AmmtE']//div[@class='Mk0Bp _30scZ']§//*[@id='main']/header/div[2]/div[1]/div/span",

            };

            bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(direccion_archivo_de_direcciones_de_bd, fila_inicial, agregar_filas, caracter_separacion_fun_esp_objeto: G_separador_para_funciones_espesificas_[2]);



            //Tex_base.GG_dir_bd_y_valor_inicial_bidimencional = op_arreglos.agregar_registro_del_array_bidimensional(Tex_base.GG_dir_bd_y_valor_inicial_bidimencional, direccion_archivo_de_direcciones_de_bd, new string[] { bas.G_separador_para_funciones_espesificas });

            for (int i = G_configuracion; i < Tex_base.GG_base_arreglo_de_arreglos[0].Length; i++)
            {
                string[] espliteados_direcciones_bases_datos_y_fila_inicial = Tex_base.GG_base_arreglo_de_arreglos[0][i].Split(bas.GG_separador_para_funciones_espesificas_[0][0]);
                string[] filas_iniciales = espliteados_direcciones_bases_datos_y_fila_inicial[2].Split(G_separador_para_funciones_espesificas_[1][0]);
                if (i > 0)
                {
                    bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(espliteados_direcciones_bases_datos_y_fila_inicial[0], espliteados_direcciones_bases_datos_y_fila_inicial[1], filas_iniciales);
                }
            }

            chatgpt_class ch_bt = new chatgpt_class();
            //entrada_salida_y_pedido
            bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(ch_bt.G_dir_arch_transferencia[0], "sin_informacion", leer_y_agrega_al_arreglo: false);
            bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(ch_bt.G_dir_arch_transferencia[1], "sin_informacion", leer_y_agrega_al_arreglo: false);
            bas.Crear_archivo_y_directorio_opcion_leer_y_agrega_arreglo(ch_bt.G_dir_arch_transferencia[2], "sin_informacion", leer_y_agrega_al_arreglo: false);


        }
    }
}
