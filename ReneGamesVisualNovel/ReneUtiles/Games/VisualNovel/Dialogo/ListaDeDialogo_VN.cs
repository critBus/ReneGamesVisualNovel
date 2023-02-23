/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 5/5/2022
 * Hora: 19:42
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Games.VisualNovel.Personajes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReneUtiles.Clases;
namespace ReneUtiles.Games.VisualNovel.Dialogo
{
	/// <summary>
	/// Description of ElementoDeListaDeDialogo.
	/// </summary>
	public class ListaDeDialogo_VN:ElementoDeDialgo_VN//ElementoDeListaDeDialogo
	{
		public List<ElementoDeListaDeDialogo_VN> opciones;
		public ListaDeDialogo_VN(Personaje_VN personaje,params ElementoDeListaDeDialogo_VN[] listaDeOpciones)
			:this(personaje,new List<ElementoDeListaDeDialogo_VN>(listaDeOpciones)){
		
		}
		public ListaDeDialogo_VN(Personaje_VN personaje, List<ElementoDeListaDeDialogo_VN> listaDeOpciones,string nombre=null,string texto=null,string descripcion=null)
			:base(personaje,nombre,texto,descripcion)
		{
			this.opciones=listaDeOpciones;
		}
	}
}
