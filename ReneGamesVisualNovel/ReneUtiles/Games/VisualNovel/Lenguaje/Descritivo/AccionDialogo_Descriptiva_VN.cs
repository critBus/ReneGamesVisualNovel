/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 7/5/2022
 * Hora: 17:08
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Clases.Condicionales;
using ReneUtiles.Clases.LeguajeDescritivo.Metodos;
using ReneUtiles.Games.VisualNovel.Dialogo;
namespace ReneUtiles.Games.VisualNovel.Lenguaje.Descritivo
{
	/// <summary>
	/// Description of AccionDialogo_Descriptiva_VN.
	/// </summary>
	public class AccionDialogo_Descriptiva_VN:AccionDialogo_VN
	{
		public Algoritmo Accion;
		public AccionDialogo_Descriptiva_VN(Algoritmo accion)
		{
			this.Accion=accion;
		}
	}
}
